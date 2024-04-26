// nocopy
using NotebookMVP.Core;

namespace NotebookMVP.MyWPF
{
    public class MyPresenter : MyPresenterBase
    {
        public MyPresenter(ITXTFileService service, IMainWindows ui, IMessageService message) 
            : base(service, ui, message) 
        {
        
        }
      

        protected override void _ui_FileOpen(object? sender, EventArgs e)
        {
            try 
            {
                string path = _ui.Path;
                string content = _service.GetContent(path);

                if (string.IsNullOrEmpty(content))
                {
                    _message.SendMessage("Открыли пустой файл", MessageType.Warning);
                }

                _ui.Content = content;
                _ui.Title = base._titledef + " " + _ui.Path;
            } 
            catch (Exception ex)
            {
                _message.SendMessage("Error \n" + ex.Message, MessageType.Error);
            }
        }

        protected override void _ui_FileSave(object? sender, EventArgs e)
        {
            try
            {
                _service.SaveContent(_ui.Content, _ui.Path);
                _message.SendMessage
                    ($"Файл успешно  сохранен  в дерикторию:{_ui.Path}" , MessageType.Info);
                _ui.Title = base._titledef + " save";

            }
            catch (Exception ex)
            {
                _message.SendMessage("Error \n" + ex.Message, MessageType.Error);
            }
        }
    }
}
