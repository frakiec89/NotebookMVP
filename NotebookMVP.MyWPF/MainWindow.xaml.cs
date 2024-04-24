using Microsoft.Win32;
using NotebookMVP.Core;
using System.Windows;

// track
namespace NotebookMVP.MyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , IMainWindows
    {
        private bool _isCtr = false;

        public event EventHandler<EventArgs> FileOpen;
        public event EventHandler<EventArgs> FileSave;

        

        public string Path { get; set; }

        public string Content 
        {
            get { return textblockContent.Text; }
            set { textblockContent.Text = value;}
        }

        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseWheel += MainWindow_MouseWheel;
            KeyDown += MainWindow_KeyDown;
            KeyUp += MainWindow_KeyUp;
            textblockContent.AcceptsReturn = true;
        }

        private void MainWindow_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.RightCtrl 
                || e.Key == System.Windows.Input.Key.LeftCtrl)
            {
                _isCtr = false;
            }
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.RightCtrl
                || e.Key == System.Windows.Input.Key.LeftCtrl)
            {
                _isCtr = true;
            }
        }

        private void MainWindow_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.OriginalSource.ToString() == "System.Windows.Controls.TextBoxView" && _isCtr==true)
            {

                if (e.Delta > 0)
                {
                    textblockContent.FontSize += 3;
                }
                else
                {
                    if (textblockContent.FontSize - 3 > 0)
                        textblockContent.FontSize -= 3;
                }
            }
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "супер  пупер  формат |*.txt" +
                "|супер  пупер  формат2 |*.json";


            if (openFileDialog.ShowDialog() == true)
            {
                Path = openFileDialog.FileName;
                // вызываем  делегат  

                if(FileOpen != null)
                    FileOpen(Path, EventArgs.Empty); // илициальзацмя события 
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (FileSave != null)
                FileSave(Path, EventArgs.Empty); // илициальзацмя события  
        }

        private void btn_save_Select_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "супер  пупер  формат |*.txt" +
                "|супер  пупер  формат2 |*.json";

            if (saveFileDialog.ShowDialog() == true)
            {
                Path = saveFileDialog.FileName; 
                if (FileSave != null)
                    FileSave(Path, EventArgs.Empty); // илициальзацмя события  
            }
        }
    }
}