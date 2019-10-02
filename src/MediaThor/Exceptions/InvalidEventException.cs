using System;

namespace MediaThor
{
    public class InvalidEventException : Exception
    {
        public Event Event { get; protected set; }

        public override string Message => "Event not valid"; 

        public InvalidEventException(Exception ex, Event @event)
        {
            Event = @event;
        }
    }
}
