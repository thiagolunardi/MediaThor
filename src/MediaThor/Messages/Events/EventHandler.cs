using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediaThor
{
    public abstract class EventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : Event
    {
        protected readonly IMessageBus Bus;

        public EventHandler(IMessageBus bus)
        {
            Bus = bus;
        }

        public abstract Task Handle(TEvent @event, CancellationToken cancellationToken);
    }
}
