using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediaThor
{
    public abstract class CommandHandler<TCommand> : IRequestHandler<TCommand>
        where TCommand : Command
    {
        protected readonly IMessageBus Bus;

        protected CommandHandler(IMessageBus bus)
        {
            Bus = bus;
        }

        async Task<Unit> IRequestHandler<TCommand, Unit>.Handle(TCommand command, CancellationToken cancellationToken)
        {
            await Handle(command, cancellationToken).ConfigureAwait(false);
            return Unit.Value;
        }

        /// <summary>
        /// Override in a derived class for the handler logic
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="cancellationToken"></param>
        public abstract Task Handle(TCommand command, CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : Command<TResponse>
    {
        protected readonly IMessageBus Bus;

        protected CommandHandler(IMessageBus bus)
        {
            Bus = bus;
        }

        public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
