using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace Cafe_Management_System
{
    class HelperUser<T> where T : class
    {
        public static T ReadFile(string filename)
        {
            var fullpath = Path.Combine(CommonUser.FullPath, filename);
            var data = "";
            using (StreamReader sr = File.OpenText(fullpath))
            {
                data = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(data);
        }
        public static void WriteFile(string filename, object data)
        {
            var serializeObject = JsonConvert.SerializeObject(data);
            var fullpath = Path.Combine(CommonUser.FullPath, filename);
            using (StreamWriter sw = File.CreateText(fullpath))
            {
                sw.WriteLine(serializeObject);
            }
        }
    }
}