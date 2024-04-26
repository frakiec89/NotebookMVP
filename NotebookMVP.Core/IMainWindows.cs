// nocopy

namespace NotebookMVP.Core
{
    public interface IMainWindows
    {
        string Path { get; }
        string Content { get; set; }
        string Title { get; set; }

        event EventHandler<EventArgs> FileOpen;
        event EventHandler<EventArgs> FileSave;

    }
}
