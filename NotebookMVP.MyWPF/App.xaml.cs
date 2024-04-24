using NotebookMVP.Core;
using System.Configuration;
using System.Data;
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

            BL.TXTFileService bl = new BL.TXTFileService();
            MessageService ms = new MessageService();


            MyPresenter myPresenter = new MyPresenter(bl, window, ms);

            window.Title = "Мой блокнот ...  откройте файл";
            app.Run(window);
        }

        public App() : base()
        {
          

        }
     

    }
}
