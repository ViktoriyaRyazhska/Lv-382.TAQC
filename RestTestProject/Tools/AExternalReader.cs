using System;

namespace RestTestProject.Tools
{
    public abstract class AExternalReader
    {
        protected const string CONVERT_OBJECT_ERROR = "ConvertToObject Error. {0}\n{1}";
        protected const string PATH_SEPARATOR = "\\";
        protected const string FOLDER_DATA = "Data\\DataSource";
        protected const string FOLDER_BIN = "bin";

        public static string FilePath { get; protected set; }

        protected static string GetPath(string fileDirectory, string filename)
        {
            FilePath = AppDomain.CurrentDomain.BaseDirectory;
            return FilePath.Remove(FilePath.IndexOf(FOLDER_BIN)) + FOLDER_DATA + PATH_SEPARATOR + fileDirectory + PATH_SEPARATOR + filename;
        }
    }
}
