using System;

namespace MediaThor
{
    public class InvalidEventException : Exception
    {
        public Event Event { get; }

        public InvalidEventException(Exception ex, Event @event)
            : base("Invalid command", ex)
        {
            Event = @event;
        }
    }
}
