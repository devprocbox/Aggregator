using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler {
    public static class JsonReader {
        public static T LoadJsonData<T>(string filePath)
        {
            string jsonstring = String.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    jsonstring = reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return JsonConvert.DeserializeObject<T>(jsonstring);
        }
    }
}
