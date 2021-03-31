
using System.IO;
using System.Xml.Serialization;

namespace OOP_2
{
    public static class XmlSerializeWrapper
    {
        public static void Serialize<T>(T obj, string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public static T Deserialize<T>(string filename)
        {
            T obj = default(T);
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(T));
                    obj = (T)formatter.Deserialize(fs);
                }
            }
            return obj;
        }
    }
}

