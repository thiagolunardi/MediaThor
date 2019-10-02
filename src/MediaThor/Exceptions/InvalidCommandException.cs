using System;

namespace MediaThor
{
    public class InvalidCommandException : Exception
    {
        public Message Command { get; protected set; }

        public InvalidCommandException(Exception ex, Message cmd)
            : base("Invalid command", ex)
        {
            Command = cmd;
        }
    }
}
