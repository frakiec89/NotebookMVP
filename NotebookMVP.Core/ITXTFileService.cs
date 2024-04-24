// track

using System.Text;

namespace NotebookMVP.Core
{
    public interface ITXTFileService
    {
        string GetContent(string path);
        string GetContent(string path, Encoding encoding);
        void SaveContent(string content, string path);
        void SaveContent(string content, string path, Encoding encoding);
    }
}

