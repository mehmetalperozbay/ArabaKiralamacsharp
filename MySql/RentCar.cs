using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.MySql
{
    class RentCar
    {
        public static void Rent(string id,string customerid,int rent)
        {
            string connectionstring = "Server=localhost;Database=CarRent;User=root;Password=122333;";

            using (MySqlConnection connect = new MySqlConnection(connectionstring))
            {
                connect.Open();
                DateTime tamTarih = DateTime.Now;
                DateTime carrentdate = tamTarih.AddDays(rent);
                var tosql = @$"INSERT INTO RENT (CarId , CustomerId , RentDate, ReturnDate) VALUES ({id},{customerid},'{tamTarih}','{carrentdate}');";
                Console.WriteLine("Kiralandığı Tarih : " + tamTarih +  "  /  " + "Teslim Tarihi : " + carrentdate);
                MySqlCommand cmd = new MySqlCommand(tosql, connect);
                cmd.ExecuteNonQuery();


            }
        }
    }
}
