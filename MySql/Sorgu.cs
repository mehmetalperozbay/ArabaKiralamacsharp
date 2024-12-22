using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.MySql
{
    public class Sorgu
    {
        private static string connectionString = "Server=localhost;Database=CarRent;User=root;Password=122333;";

        public static void CarIdSorgu(string carId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int id = int.Parse(carId);
                connection.Open();
                var tosql = $@"SELECT * FROM Cars WHERE Id = {id}";

                using (MySqlCommand cmd = new MySqlCommand(tosql, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string model = reader["Model"].ToString();
                        string brand = reader["Brand"].ToString();
                        string kmperliter = reader["KmPerLiter"].ToString();
                        string totalkm = reader["TotalKm"].ToString();
                        string dailyprice = reader["DailyPrice"].ToString();
                        string weeklyprice = reader["WeeklyPrice"].ToString();
                        string monthlyprice = reader["MonthlyPrice"].ToString();

                        Console.WriteLine($"Marka: {brand}");
                        Console.WriteLine($"Model: {model}");
                        Console.WriteLine($"Toplam Km: {totalkm}");
                        Console.WriteLine($"100 Km'de Yaktığı Litre: {kmperliter}");
                        Console.WriteLine($"Günlük Kira: {dailyprice}");
                        Console.WriteLine($"Haftalık Kira: {weeklyprice}");
                        Console.WriteLine($"Aylık Kira: {monthlyprice}");
                    }
                    

                    

                    


                }
            }
        }
        public static string CustomerIdAdSorgu(int id)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();
            var tosql = $@"SELECT * FROM Customer WHERE Id = {id}";

            MySqlCommand runsql = new MySqlCommand(tosql,connect);
            
            MySqlDataReader reader = runsql.ExecuteReader();
            

            if (reader.Read())
            {
                string ad = reader["CustomerName"].ToString();
                string soyad = reader["CustomerSurname"].ToString();

                return ad +" "+ soyad;
            }
            else
            {
                return null;
            }



        }

        public static string CustomerIdSorgu(string tc , string password)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();
            var tosql = $@"SELECT * FROM Customer WHERE CustomerTc = '{tc}' and CustomerPassword = '{password}' ";

            MySqlCommand runsql = new MySqlCommand(tosql, connect);

            MySqlDataReader reader = runsql.ExecuteReader();


            if (reader.Read())
            {
                string Id = reader["Id"].ToString();

                return Id;
            }
            else
            {
                return null;
            }



        }

        public static string LoginSorgu(string tc, string password)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            var tosql = $@"SELECT CustomerName,CustomerSurname FROM Customer WHERE CustomerTc = '{tc}' AND CustomerPassword = '{password}';"; // password ve tc bilgisi verdigimiz bir kod. customername ve customersurname stunlarını vermesını sıtıyoruz

            MySqlCommand command = new MySqlCommand(tosql , connection);

            MySqlDataReader response = command.ExecuteReader();

            if (response.Read())
            {
                string customername = response["CustomerName"].ToString();
                string customersurname = response["CustomerSurname"].ToString();
                return customername + " " + customersurname;
            }
            else
            {
                return "0";
            }
        }
    }
}
