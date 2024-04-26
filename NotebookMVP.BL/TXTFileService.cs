using NotebookMVP.Core;
using System.Text;
// nocopy
namespace NotebookMVP.BL
{
   

    /// <summary>
    /// Класс  для  работы  с текстовым  файлом
    /// </summary>
    public class TXTFileService : ITXTFileService
    {
        private Encoding _defEncoding = Encoding.UTF8;

        /// <summary>
        /// получаем контент  из файла  с кодировкой UTF8
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetContent(string path)
        {
            return GetContent(path, _defEncoding);
        }

        /// <summary>
        /// получаем контент  из файла 
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="encoding">кодировка</param>
        /// <returns></returns>
        public string GetContent(string path, Encoding encoding)
        {
            try
            {
                return File.ReadAllText(path, encoding); // обертка
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Сохраняем контент в  файл с кодировкой UTF8
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path"></param>
        public void SaveContent(string content, string path)
        {
            SaveContent(content, path, _defEncoding); // обертка
        }

        /// <summary>
        /// сохраняет  контент  в файл 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public void SaveContent(string content, string path, Encoding encoding)
        {
            try
            {
                File.WriteAllText( path, content,  encoding);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
