using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Mannik
{
    public static class Serializer
    {
        private static readonly XmlSerializer Xs = new XmlSerializer(typeof(Manik));
        public static Manik LoadFromFile(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                return (Manik)Xs.Deserialize(fileStream);
            }
        }
        public static void WriteToFile(string fileName, Manik data)
        {
            using (var fileStream = File.Create(fileName))
            {
                Xs.Serialize(fileStream, data);
            }
        }
    }
}

