// nocopy

namespace NotebookMVP.Core
{
    public interface IMessageService
    {
        void SendMessage(string message , MessageType type);
    }
}
