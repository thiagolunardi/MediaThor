namespace MediaThor.Tester
{
    public interface IMessageHandlerTester : IMessageBus
    {
        Command[] SentCommands { get; }
        Event[] RaisedEvents { get; }
    }
}
