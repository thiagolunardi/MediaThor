﻿namespace MediaThor.Examples
{
    public class Ping : IRequest<Pong>
    {
        public string Message { get; set; }
    }
}