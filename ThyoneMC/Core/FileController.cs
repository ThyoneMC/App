using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace ThyoneMC.Core
{
    internal class FileController
    {
        public static string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "@ThyoneMC");

        private string pathFile;

        public FileController(string fileName)
        {
            this.pathFile = Path.Combine(FileController.AppData, "Data", ((fileName.EndsWith(".cfg")) ? fileName : $"{fileName}.cfg").Replace("/", "\\"));
        }

        // class

        public void BuildFile<MyJsonFormat>()
        {
            FileController.BuildStaticFile(this.pathFile, JsonSerializer.Serialize(FileController.NewTypeObject<MyJsonFormat>()));
        }

        public void EditFile<MyJsonFormat>(MyJsonFormat dataInFile)
        {
            if (!File.Exists(this.pathFile))
            {
                FileController.BuildStaticFile(this.pathFile, JsonSerializer.Serialize(dataInFile));
            }
            else
            {
                FileController.EditStaticFile(this.pathFile, JsonSerializer.Serialize(dataInFile));
            }
        }

        public MyJsonFormat ReadFile<MyJsonFormat>()
        {
            if (!File.Exists(this.pathFile))
            {
                this.BuildFile<MyJsonFormat>();
            }

            return JsonSerializer.Deserialize<MyJsonFormat>(FileController.ReadStaticFile(this.pathFile));
        }

        // static

        private static MyJsonFormat NewTypeObject<MyJsonFormat>()
        {
            return Activator.CreateInstance<MyJsonFormat>();
        }

        private static string[] SplitFolderPath(string myPath)
        {
            List<string> spiltPath = myPath.Split('\\').ToList();

            // drive

            if (spiltPath.ElementAt(0).Contains(":"))
            {
                spiltPath.Insert(0, $"{spiltPath.ElementAt(0)}\\{spiltPath.ElementAt(1)}");
                spiltPath.RemoveAt(1);
                spiltPath.RemoveAt(1);
            }
            spiltPath.RemoveAt(spiltPath.Count - 1);

            // full path

            string oldPath = "";
            List<string> newPath = new List<string>();

            for (int i = 0; i < spiltPath.Count; i++)
            {
                oldPath = Path.Combine(oldPath, spiltPath.ElementAt(i));
                newPath.Add(oldPath);
            }

            return newPath.ToArray();
        }

        public static void BuildStaticFolder(params string[] pathToFolder)
        {
            string path = Path.Combine(FileController.AppData, Path.Combine(pathToFolder));

            foreach (string folderPath in FileController.SplitFolderPath(path))
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
        }

        public static string[] ReadStaticFolder(string pathToFolder)
        {
            string path = Path.Combine(FileController.AppData, Path.Combine(pathToFolder));

            string[] _folders = Directory.GetDirectories(path);
            string[] _files = Directory.GetFiles(path);

            return _folders.Concat(_files).ToArray();
        }

        public static void BuildStaticFile(string pathToFile, string dataInFile)
        {
            string path = Path.Combine(FileController.AppData, pathToFile);

            if (!File.Exists(path))
            {
                FileController.BuildStaticFolder(path);

                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.Write(dataInFile);
                }
            }
        }

        public static void EditStaticFile(string pathToFile, string dataInFile)
        {
            string path = Path.Combine(FileController.AppData, pathToFile);

            File.WriteAllText(path, dataInFile);
        }

        public static string ReadStaticFile(string pathToFile)
        {
            string path = Path.Combine(FileController.AppData, pathToFile);

            return File.ReadAllText(path);
        } 
    }
}
