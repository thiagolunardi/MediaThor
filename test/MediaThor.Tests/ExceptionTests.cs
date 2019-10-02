using System;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using StructureMap;
using Xunit;

namespace MediaThor.Tests
{
    public class ExceptionTests
    {
        private readonly IMediator _mediator;

        public class Ping : ICommandRequest<Pong>
        {
        }

        public class Pong
        {
        }

        public class VoidPing : ICommandRequest
        {
        }

        public class Pinged : IEventNotification
        {
        }

        public class AsyncPing : ICommandRequest<Pong>
        {
        }

        public class AsyncVoidPing : ICommandRequest
        {
        }

        public class AsyncPinged : IEventNotification
        {
        }

        public class NullPing : ICommandRequest<Pong>
        {
        }

        public class VoidNullPing : ICommandRequest
        {
        }

        public class NullPinged : IEventNotification
        {
        }

        public class NullPingHandler : ICommandRequestHandler<NullPing, Pong>
        {
            public Task<Pong> Handle(NullPing request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new Pong());
            }
        }

        public class VoidNullPingHandler : ICommandRequestHandler<VoidNullPing, Unit>
        {
            public Task<Unit> Handle(VoidNullPing request, CancellationToken cancellationToken)
            {
                return Unit.Task;
            }
        }

        public ExceptionTests()
        {
            var container = new Container(cfg =>
            {
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
                cfg.For<IMediator>().Use<MediaThor>();
            });
            _mediator = container.GetInstance<IMediator>();
        }

        [Fact]
        public async Task Should_throw_for_send()
        {
            await Should.ThrowAsync<InvalidOperationException>(async () => await _mediator.Send(new Ping()));
        }

        [Fact]
        public async Task Should_throw_for_void_send()
        {
            await Should.ThrowAsync<InvalidOperationException>(async () => await _mediator.Send(new VoidPing()));
        }

        [Fact]
        public async Task Should_not_throw_for_publish()
        {
            Exception ex = null;
            try
            {
                await _mediator.Publish(new Pinged());
            }
            catch (Exception e)
            {
                ex = e;
            }
            ex.ShouldBeNull();
        }

        [Fact]
        public async Task Should_throw_for_async_send()
        {
            await Should.ThrowAsync<InvalidOperationException>(async () => await _mediator.Send(new AsyncPing()));
        }

        [Fact]
        public async Task Should_throw_for_async_void_send()
        {
            await Should.ThrowAsync<InvalidOperationException>(async () => await _mediator.Send(new AsyncVoidPing()));
        }

        [Fact]
        public async Task Should_not_throw_for_async_publish()
        {
            Exception ex = null;
            try
            {
                await _mediator.Publish(new AsyncPinged());
            }
            catch (Exception e)
            {
                ex = e;
            }
            ex.ShouldBeNull();
        }

        [Fact]
        public async Task Should_throw_argument_exception_for_send_when_request_is_null()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(NullPing));
                    scanner.IncludeNamespaceContainingType<Ping>();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf(typeof(ICommandRequestHandler<,>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => t => ctx.GetInstance(t));
                cfg.For<IMediator>().Use<Mediator>();
            });
            var mediator = container.GetInstance<IMediator>();

            NullPing request = null;

            await Should.ThrowAsync<ArgumentNullException>(async () => await mediator.Send(request));
        }

        [Fact]
        public async Task Should_throw_argument_exception_for_void_send_when_request_is_null()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(VoidNullPing));
                    scanner.IncludeNamespaceContainingType<Ping>();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf(typeof(ICommandRequestHandler<,>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => t => ctx.GetInstance(t));
                cfg.For<IMediator>().Use<Mediator>();
            });
            var mediator = container.GetInstance<IMediator>();

            VoidNullPing request = null;

            await Should.ThrowAsync<ArgumentNullException>(async () => await mediator.Send(request));
        }

        [Fact]
        public async Task Should_throw_argument_exception_for_publish_when_request_is_null()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(NullPinged));
                    scanner.IncludeNamespaceContainingType<Ping>();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf(typeof(ICommandRequestHandler<,>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => t => ctx.GetInstance(t));
                cfg.For<IMediator>().Use<Mediator>();
            });
            var mediator = container.GetInstance<IMediator>();

            NullPinged notification = null;

            await Should.ThrowAsync<ArgumentNullException>(async () => await mediator.Publish(notification));
        }

        [Fact]
        public async Task Should_throw_argument_exception_for_publish_when_request_is_null_object()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(NullPinged));
                    scanner.IncludeNamespaceContainingType<Ping>();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf(typeof(ICommandRequestHandler<,>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => t => ctx.GetInstance(t));
                cfg.For<IMediator>().Use<Mediator>();
            });
            var mediator = container.GetInstance<IMediator>();

            object notification = null;

            await Should.ThrowAsync<ArgumentNullException>(async () => await mediator.Publish(notification));
        }

        [Fact]
        public async Task Should_throw_argument_exception_for_publish_when_request_is_not_notification()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(NullPinged));
                    scanner.IncludeNamespaceContainingType<Ping>();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf(typeof(ICommandRequestHandler<,>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => t => ctx.GetInstance(t));
                cfg.For<IMediator>().Use<Mediator>();
            });
            var mediator = container.GetInstance<IMediator>();

            object notification = "totally not notification";

            await Should.ThrowAsync<ArgumentException>(async () => await mediator.Publish(notification));
        }
    }
}