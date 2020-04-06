using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace LiveChartInterface
{
    public class Xml
    { 
        public static T Deserialize<T>(string path, string section = "")
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(section));
                var doc = new XmlDocument();
                doc.Load(path);
                using (var reader = new XmlNodeReader(doc))
                {
                    if(section != string.Empty)
                        reader.ReadToDescendant(section);
                    var temp = (T)serializer.Deserialize(reader);
                    reader.Close(); 
                    return temp;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static bool TryDeserialize<T>(string path, out T result, string section = "")
        {
            try
            {
                result = Deserialize<T>(path);
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }

        public static void Serialize<T>(T type, string path)
        {
            var serialize = new XmlSerializer(typeof(T));
            var writer = new StreamWriter(path);
            serialize.Serialize(writer, type);
            writer.Close();
        }

        public static bool TrySerialize<T>(T type, string path)
        {
            try
            {
                Serialize<T>(type, path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
