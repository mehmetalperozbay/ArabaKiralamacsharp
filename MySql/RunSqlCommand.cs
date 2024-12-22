using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.MySql
{

    class RunSqlCommand {

        public static void RunSql(string sqlcommand)
        {
            string connect = "Server=localhost;Database=CarRent;User=root;Password=122333;";

            var connection = new MySqlConnection(connect);
            connection.Open();
            
            var sqlrun = new MySqlCommand(sqlcommand, connection);

            
                        
        }   
    }
}
