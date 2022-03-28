using System;
using System.IO;
using Newtonsoft.Json;
namespace ContactsApp
{
    public class ProectManager
    {
        /// <summary>
        /// Имя файла для сериализации/десериализации данных
        /// Путь для сериализации/десериализации данных
        /// </summary>
        public static string DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                               + "\\ContactsApp";

        public static string DefaultfilePath = DefaultPath + "\\ContactsAppp.note";

        /// <summary>
        /// Метод сериализации данных проекта
        /// </summary>
        /// <param name="project"></param>
        /// <param name="filepath"></param>
        public static void SaveToFile(Project project, string filepath)
        {
            if (!Directory.Exists(DefaultPath))
            {
                Directory.CreateDirectory(DefaultPath);
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(filepath))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer,project);
            }
        }

        public static Project LoadFromFile(string filePath)
        {
            Project project = new Project();
            JsonSerializer serializer = new JsonSerializer();
            
            if (!Directory.Exists(DefaultPath))
            {
                Directory.CreateDirectory(DefaultPath);
            }

            if (System.IO.File.Exists(DefaultfilePath) == false)
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                }
            }
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    project = (Project)serializer.Deserialize<Project>(reader);
                }
            }
            catch
            {
                project = new Project();
            }

            return project ?? new Project();
        }
    }
}