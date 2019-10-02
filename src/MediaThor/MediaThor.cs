using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediaThor
{
    public class MediaThor : IMediator, ICommandsCounter
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;
        private static ConcurrentBag<Task> _taskRunners;
        private readonly static object _taskLock = new object();

        public MediaThor(IServiceProvider serviceProvider, ILogger<MediaThor> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;

            RenewTaskRunnerBag();
        }

        public virtual Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var requestType = request.GetType();

            var taskRunner = Task.Run(async () =>
            {
                try
                {
                    _logger.LogInformation("Handling {@message}", request);

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var serviceFactory = scope.ServiceProvider.GetService<ServiceFactory>();

                        var handler = (RequestHandlerWrapper<TResponse>)Activator
                            .CreateInstance(typeof(RequestHandlerWrapperImpl<,>).MakeGenericType(requestType, typeof(TResponse)));

                        var response = await handler.Handle(request, cancellationToken, serviceFactory);

                        _logger.LogInformation("Message finished {@message} {@result}", request, response);
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error handling {@message}", request);
                    throw;
                }
            });

            AddTaskRunner(taskRunner);

            return taskRunner;
        }

        public virtual Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return PublishNotification(notification, cancellationToken);
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            if (notification is INotification instance)
            {
                return PublishNotification(instance, cancellationToken);
            }

            throw new ArgumentException($"{nameof(notification)} does not implement ${nameof(INotification)}");
        }

        public int CountCommands()
            => _taskRunners?.Count ?? 0;

        private Task PublishNotification(INotification notification, CancellationToken cancellationToken = default)
        {
            var notificationType = notification.GetType();

            var taskRunner = Task.Run(async () =>
            {
                try
                {
                    _logger.LogInformation("Handling {@message}", notification);

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var serviceFactory = scope.ServiceProvider.GetService<ServiceFactory>();

                        var handler = (NotificationHandlerWrapper)Activator
                            .CreateInstance(typeof(NotificationHandlerWrapperImpl<>).MakeGenericType(notificationType));

                        await handler.Handle(notification, cancellationToken, serviceFactory, PublishCore);

                        _logger.LogInformation("Message finished {@message}", notification);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error handling {@message}", notification);
                    throw;
                }
            });

            AddTaskRunner(taskRunner);

            return taskRunner;
        }

        /// <summary>
        /// Override in a derived class to control how the tasks are awaited. By default the implementation is a foreach and await of each handler
        /// </summary>
        /// <param name="allHandlers">Enumerable of tasks representing invoking each notification handler</param>
        /// <returns>A task representing invoking all handlers</returns>
        protected virtual async Task PublishCore(IEnumerable<Task> allHandlers)
        {
            foreach (var handler in allHandlers)
            {
                await handler.ConfigureAwait(false);
            }
        }

        private void RenewTaskRunnerBag()
        {
            _logger.LogInformation($"Renewing task runner bag. Tasks to be wiped: {CountCommands()}");

            var newBag = new ConcurrentBag<Task>();
            Interlocked.Exchange(ref _taskRunners, newBag);
        }

        private void AddTaskRunner(Task taskRunner)
        {
            lock (_taskLock)
            {
                CompletedTaskCollector();
                _taskRunners.Add(taskRunner);
            }
            _logger.LogInformation($"MediaThor task queue size {CountCommands()}");
        }

        private void CompletedTaskCollector()
        {
            if (_taskRunners.IsEmpty) return;
            foreach (var task in _taskRunners)
                if (!task.IsCompleted) return;
            RenewTaskRunnerBag();
        }        
    }
}
