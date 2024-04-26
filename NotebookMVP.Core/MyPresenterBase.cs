using NotebookMVP.Core;
// nocopy
namespace NotebookMVP.MyWPF
{
    public abstract class MyPresenterBase
    {
        protected Core.IMessageService _message;
        protected Core.ITXTFileService _service;
        protected string _titledef = "Блокнот (sgk) ";
        protected Core.IMainWindows _ui;

        public MyPresenterBase(ITXTFileService service, IMainWindows ui, IMessageService message)
        {
            _service = service;
            _ui = ui;
            _message = message;
            _ui.FileSave += _ui_FileSave;
            _ui.FileOpen += _ui_FileOpen;
        }

        protected abstract void _ui_FileOpen(object? sender, EventArgs e);
        protected abstract void _ui_FileSave(object? sender, EventArgs e);
     
    }
}