using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MediaThor
{
    public class MessageBus : IMessageBus
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly string _requestId;

        public MessageBus(
            IMediator mediator,
            ILogger<MediaThor> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _requestId = httpContextAccessor?.HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString();
        }

        public Task<TResponse> ExecuteCommand<TResponse>(Command<TResponse> command)
        {
            command.SetCorrelationId(_requestId);

            _logger.LogInformation("Execute command {@command}", command);
            if (!command.IsValid)
            {
                var ex = new InvalidCommandException(command.Errors.ToException(), command);
                _logger.LogError(ex, "Invalid command {@command} exception", command);
                throw ex;
            }
            return _mediator.Send(command);
        }

        public Task ExecuteCommand(Command command)
        {
            command.SetCorrelationId(_requestId);

            _logger.LogInformation("Execute command {@command}", command);
            if (!command.IsValid)
            {
                var ex = new InvalidCommandException(command.Errors.ToException(), command);
                _logger.LogError(ex, "Invalid command {@command} exception", command);
                throw ex;
            }
            return _mediator.Send(command);
        }

        public void SendCommands(params Command[] commands)
        {
            foreach (var command in commands)
                SendCommand(command);
        }

        public void SendCommand(Command command)
        {
            command.SetCorrelationId(_requestId);

            _logger.LogInformation("Send command {@command}", command);
            if (!command.IsValid)
            {
                var ex = new InvalidCommandException(command.Errors.ToException(), command);
                _logger.LogError(ex, "Invalid command {@command} exception", command);
                throw ex;
            }

            try
            {
                _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while handling {@command}", command);
            }
        }

        public void RaiseEvent(Event @event)
        {
            @event.SetCorrelationId(_requestId);

            _logger.LogInformation("Event raised {@event}", @event);
            if (!@event.IsValid)
            {
                var ex = new InvalidEventException(@event.Errors.ToException(), @event);
                _logger.LogError(ex, "Invalid event {@event} exception", @event);
                throw ex;
            }

            try
            {
                _mediator.Publish(@event);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while handling {@event}", @event);
            }
        }

        public int CountCommands()
        {
            if (_mediator is ICommandsCounter)
            {
                var counter = _mediator as ICommandsCounter;
                return counter.CountCommands();
            }
            return -1;
        }        
    }
}
