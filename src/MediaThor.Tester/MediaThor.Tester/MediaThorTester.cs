using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediaThor.Tester
{
    public class MediaThorTester : MediaThor
    {
        private readonly List<Command> _commands;
        private readonly List<Event> _events;

        public Command[] SentCommands
            => _commands.ToArray();

        public Event[] RaisedEvents
            => _events.ToArray();

        public MediaThorTester(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _commands = new List<Command>();
            _events = new List<Event>();
        }

        public override Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken))
        {
            _events.Add(notification as Event);
            return base.Publish(notification, cancellationToken);
        }

        public override Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            _commands.Add(request as Command);
            return base.Send<TResponse>(request, cancellationToken);
        }
    }
}
