using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LingvoLearnWords
{
    public class XMLDictionary
    {
        public XMLDictionary(string filePath)
        {
            string dir = Path.GetDirectoryName(filePath);

            if (string.IsNullOrEmpty(dir))
                FilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + filePath;
            else
                FilePath = filePath;
        }

        public XMLDictionary() : this ("Common2016EnRu.xml")
        {
        }

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public string FilePath;

        /// <summary>
        /// Основной объект.
        /// </summary>
        public Dictionary Dictionary { get; set; }

        /// <summary>
        /// Загрузить данные из XML-файла.
        /// </summary>
        public void LoadFromXML(string filePath = "")
        {
            string filePathInt = FilePath;

            if (!string.IsNullOrEmpty(filePath))
                filePathInt = filePath;

            if (File.Exists(filePathInt))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Dictionary));
                using (TextReader textReader = new StreamReader(filePathInt))
                {
                    Dictionary = (Dictionary)deserializer.Deserialize(textReader);
                }
            }
        }

        /// <summary>
        /// Сохранить данные в XML-файл.
        /// </summary>
        public void SaveToXML(string filePath = "")
        {
            string filePathInt = FilePath;

            if (!string.IsNullOrEmpty(filePath))
                filePathInt = filePath;

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer xmlSer = new XmlSerializer(typeof(Dictionary));
            using (TextWriter textWriter = new StreamWriter(filePathInt, false, Encoding.Unicode))
            {
                xmlSer.Serialize(textWriter, Dictionary, ns);
            }
        }
    }
}
