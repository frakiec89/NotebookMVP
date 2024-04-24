// track

using NotebookMVP.Core;
using System.Windows;

namespace NotebookMVP.MyWPF
{
    internal class MessageService : IMessageService
    {
        public void SendMessage(string message, MessageType type)
        {
            switch (type)
            {
                case MessageType.Info:
                    MessageBox.Show
                        (message, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageType.Warning:
                    MessageBox.Show
                      (message, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case MessageType.Error:
                    MessageBox.Show
                    (message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }

        }
    }
}
