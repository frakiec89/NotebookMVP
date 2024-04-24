// track
using NotebookMVP.Core;

namespace NotebookMVP.MyWPF
{
    public class MyPresenter
    {
        private string _titledef = "Блокнот (sgk) ";

        private Core.ITXTFileService _service;
        private Core.IMainWindows _ui;
        private Core.IMessageService _message;

        public MyPresenter(ITXTFileService service, IMainWindows ui, IMessageService message)
        {
            _service = service;
            _ui = ui;
            _message = message;
            _ui.FileSave += _ui_FileSave;
            _ui.FileOpen += _ui_FileOpen;
        }

        private void _ui_FileOpen(object? sender, EventArgs e)
        {
            try
            {
                string path = _ui.Path;
                string content = _service.GetContent(path);
                if (string.IsNullOrEmpty(content))
                {
                   _message.SendMessage("Файл загружен, но он пустой" , MessageType.Warning);
                }
                _ui.Content = content;
                _ui.Title = _titledef + path ;
               
            }
            catch (Exception ex)
            {
                _message.SendMessage(ex.Message, MessageType.Error);
            }
        }

        private void _ui_FileSave(object? sender, EventArgs e)
        {
            try
            {
                string path = _ui.Path;
                string content = _ui.Content; 
                _service.SaveContent(path, content);
                _message.SendMessage("Текст успешно сохранился в файле", MessageType.Info);
            }
            catch (Exception ex)
            {
                _message.SendMessage(ex.Message, MessageType.Error);
            }

        }
    }
}
