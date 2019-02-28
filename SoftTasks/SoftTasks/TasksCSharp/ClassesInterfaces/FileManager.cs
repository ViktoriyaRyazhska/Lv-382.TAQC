using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.ClassesInterfaces
{
    class FileManager : IInputOutputManager
    {
        public string FilePath { get; set; }
        public FileManager(string filePath)
        {
            FilePath = filePath;
        }

        public string Input()
        {
            return File.ReadAllText(FilePath);
        }

        public void Output(object obj)
        {
            File.AppendAllText(FilePath, obj.ToString());
        }


        //private FileStream file;
        //private StreamWriter writer;
        //private StreamReader reader;

        //public FileManager(string filePath)
        //{
        //    file = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

        //    writer = new StreamWriter(file);
        //    reader = new StreamReader(file);
        //}

        //~FileManager()
        //{
        //    if (file != null) file.Dispose();
        //}

        //public string Input()
        //{
        //    return reader.ReadLine();
        //}

        //public void Output(object obj)
        //{
        //    writer.WriteLine(obj);
        //}

    }
}
