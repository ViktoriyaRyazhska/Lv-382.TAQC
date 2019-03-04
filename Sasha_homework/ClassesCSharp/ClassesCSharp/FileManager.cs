using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassesCSharp
{
    class FileManager: IInputOutputManager
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
    }
}
