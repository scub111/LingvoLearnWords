using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LingvoLearnWords
{
    public class XmlDictionary
    {
        public XmlDictionary(string filePath)
        {
            var dir = Path.GetDirectoryName(filePath);
            FilePath = string.IsNullOrEmpty(dir) ? $"{Path.GetDirectoryName(Application.ExecutablePath)}\\{filePath}" : filePath;
        }

        public XmlDictionary() : this ("Common2016EnRu.xml")
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
        public void LoadFromXml(string filePath = "")
        {
            var filePathInt = FilePath;

            if (!string.IsNullOrEmpty(filePath))
                filePathInt = filePath;

            if (!File.Exists(filePathInt)) return;
            var deserializer = new XmlSerializer(typeof(Dictionary));
            using (TextReader textReader = new StreamReader(filePathInt))
            {
                Dictionary = (Dictionary)deserializer.Deserialize(textReader);
            }
        }

        /// <summary>
        /// Сохранить данные в XML-файл.
        /// </summary>
        public void SaveToXml(string filePath = "")
        {
            var filePathInt = FilePath;

            if (!string.IsNullOrEmpty(filePath))
                filePathInt = filePath;

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var xmlSer = new XmlSerializer(typeof(Dictionary));
            using (TextWriter textWriter = new StreamWriter(filePathInt, false, Encoding.Unicode))
            {
                xmlSer.Serialize(textWriter, Dictionary, ns);
            }
        }
    }
}
