using MediatR;

namespace MediaThor.Tester
{
    public sealed class MessageBusTester : MessageBus, IMessageHandlerTester
    {
        private readonly MediaThorTester _mediaThorTester;
        public MessageBusTester(IMediator mediator)
            : base(mediator)
        {
            _mediaThorTester = mediator as MediaThorTester;
        }

        public Command[] SentCommands => _mediaThorTester.SentCommands;
        public Event[] RaisedEvents => _mediaThorTester.RaisedEvents;
    }
}
