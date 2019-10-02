using System;

namespace MediaThor
{
    public class InvalidCommandException : Exception
    {
        public Command Command { get; }

        public InvalidCommandException(Exception ex, Command cmd)
            : base("Invalid command", ex)
        {
            Command = cmd;
        }
    }
}
