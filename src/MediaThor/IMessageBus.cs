using System.Threading.Tasks;

namespace MediaThor
{
    public interface IMessageBus: ICommandsCounter
    {
        Task ExecuteCommand(Command command);
        Task<TResponse> ExecuteCommand<TResponse>(Command<TResponse> command);
        void SendCommand(Command command);
        void SendCommands(params Command[] commands);
        void RaiseEvent(Event @event);
    }

    public interface ICommandsCounter
    {
        int CountCommands();
    }
}
