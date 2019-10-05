using MediatR;

namespace MediaThor
{
    public abstract class Event : Message, INotification
    {
    }
}
