// nocopy
using System.Windows;

namespace NotebookMVP.MyWPF
{
    
    public partial class App : Application
    {

        [STAThread]
        static void Main()
        {
            App app = new App();

            MainWindow window = new MainWindow();

            Core.ITXTFileService bl = new BL.TXTFileService();
            Core.IMessageService ms = new MessageService();


            MyPresenterBase myPresenter = new MyPresenter(bl, window, ms);

            window.Title = "Мой блокнот ...  откройте файл";
            app.Run(window);
        }

    }
}
