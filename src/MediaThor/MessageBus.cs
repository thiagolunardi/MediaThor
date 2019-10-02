using System;
using System.Threading.Tasks;
using MediatR;

namespace MediaThor
{
    public class MessageBus : IMessageBus
    {
        private readonly IMediator _mediator;
        private readonly string _requestId;

        public MessageBus(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> ExecuteCommand<TResponse>(Command<TResponse> command)
        {
            if (!command.IsValid)
            {
                var ex = new InvalidCommandException(command.Errors.ToException(), command);
                throw ex;
            }
            return _mediator.Send<TResponse>(command);
        }

        public Task ExecuteCommand(Command command)
        {
            if (!command.IsValid)
            {
                var ex = new InvalidCommandException(command.Errors.ToException(), command);
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
            if (!command.IsValid)
            {
                var ex = new InvalidCommandException(command.Errors.ToException(), command);
                throw ex;
            }

            try
            {
                _mediator.Send(command);
            }
            catch
            {
                // ignore
            }
        }

        public void RaiseEvent(Event @event)
        {
            if (!@event.IsValid)
            {
                var ex = new InvalidEventException(@event.Errors.ToException(), @event);
                throw ex;
            }

            try
            {
                _mediator.Publish(@event);
            }
            catch
            {
                // ignore
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
