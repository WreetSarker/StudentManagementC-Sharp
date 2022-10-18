using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace StudentManagement
{

    class SaveFile
    {
        public static void saveToJson(Student student)
        {
            string fileName = String.Format(@"{0}\user.json", Environment.CurrentDirectory);
            string json = JsonConvert.SerializeObject(student, Formatting.Indented);
            using(StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(json);
                sw.Close();
            }
            
        }
    }

}