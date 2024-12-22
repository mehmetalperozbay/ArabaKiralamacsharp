using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp8.Services;


namespace ConsoleApp8.MySql
{
    class ReadSqlCommand
    {
        private static string connectionString = "Server=localhost;Database=CarRent;User=root;Password=122333;";

        public static string Read(string sqlcode)
        {
            using var connection = new MySqlConnection(connectionString);
            using var tosql = new MySqlCommand(sqlcode,connection);
            using var Reader = tosql.ExecuteReader();
            Reader.Read();
            string a = "a";
            return a;
        }
    }
}
