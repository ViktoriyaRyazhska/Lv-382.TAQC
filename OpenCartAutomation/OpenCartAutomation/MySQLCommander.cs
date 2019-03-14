using MySql.Data.MySqlClient;
using System;

namespace OpenCartAutomation
{
    class MySQLCommander
    {
        private MySqlConnection connection;
        private string connectionString;
        string file = @"C:\Users\Lutik\Desktop\GIT\Lv-382.TAQC\OpenCartAutomation\OpenCartAutomation\SQLBackUp";

        public MySQLCommander(string server, string database, string user, string password, string port, string sslM)
        {
            connectionString = connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
            connection = new MySqlConnection(connectionString);
        }

        public void Clone()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                using (MySqlBackup mb = new MySqlBackup(cmd))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    mb.ExportToFile(file);
                    connection.Close();
                }
            }
        }

        public void BackUp()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                using (MySqlBackup mb = new MySqlBackup(cmd))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    mb.ImportFromFile(file);
                    connection.Close();
                }
            }
        }
    }
}
