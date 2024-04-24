using ComputerClub.View_Models;
using Newtonsoft.Json;
using System.IO;

namespace ComputerClub
{
    public class GlobalApplicationSystem : Singleton
    {
        public static GlobalApplicationSystem Instance => Instance<GlobalApplicationSystem>();
        private GlobalApplicationSystem() { }

        public string JsonPath { get; set; } = "data.json";
        public EventHandler? OnApplicationLoading;
        public EventHandler? OnApplicationClosing;

        public void Serialization<T>(string path, T value)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(JsonConvert.SerializeObject(value));
            }
        }

        //public T Deserialization<T>(string path, T outValue)
        //{
        //    using (StreamReader streamReader = new StreamReader(path))
        //    {
        //        string jsonData = streamReader.ReadToEnd();
        //        if (jsonData == string.Empty)
        //        {
        //            return outValue;
        //        }
        //        outValue = JsonConvert.DeserializeObject<T>(jsonData)
        //            ?? throw new NullReferenceException("Данные файла повреждены повреждены.");
        //    }
        //    return outValue;
        //}
        public T Deserialization<T>(string path, T outValue, AdminConverter? converter = null)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string jsonData = streamReader.ReadToEnd();
                if (jsonData == string.Empty)
                {
                    return outValue;
                }
                if (converter == null)
                {
                    outValue = JsonConvert.DeserializeObject<T>(jsonData)
                        ?? throw new NullReferenceException("Данные файла повреждены повреждены.");
                }
                else
                {
                    outValue = JsonConvert.DeserializeObject<T>(jsonData, converter)
                        ?? throw new NullReferenceException("Данные файла повреждены повреждены.");
                }
            }
            return outValue;
        }
    }
}
