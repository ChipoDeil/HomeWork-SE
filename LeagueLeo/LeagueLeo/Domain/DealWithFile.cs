using Newtonsoft.Json;
using System.IO;

namespace LeagueLeo
{
    internal class DealWithFile
    {
        internal T ReadFromFile<T>(string filePath, string fileName)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            if (!File.Exists(filePath + fileName))
            {
                FileStream  fs = File.Create(filePath + fileName);
                fs.Close();
            }
            StreamReader io = new StreamReader(filePath + fileName);
            string json = io.ReadToEnd();
            T content = JsonConvert.DeserializeObject<T>(json);
            io.Close();
            return content;
        }

        internal void SaveToFile<T>(string filePath, string fileName, T @object)
        {
            string json = JsonConvert.SerializeObject(@object);
            if (!Directory.Exists(filePath)) {
                Directory.CreateDirectory(filePath);
            }
            if (!File.Exists(filePath + fileName)) {
                FileStream fs = File.Create(filePath + fileName);
                fs.Close();
            } 
            StreamWriter sw = new StreamWriter(filePath + fileName);
            sw.Write(json);
            sw.Close();
        }
    }
}
