using ArabaKiralama.Format;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.MySql
{
    class Update
    {
        
        public static void UpdateCarStatus(int value , string boolean)
        {
            
            string format = boolean.ToLower();
            if (format == "true")
            {
                var tosql = $@"Update Cars SET Status = TRUE WHERE Id = {value}";
                RunSqlCommand.RunSql( tosql);
                
                
            }
            else
            {
                var tosql = $@"Update Cars SET Status = FALSE WHERE Id = {value}";
                RunSqlCommand.RunSql(tosql);
            } 
        }
        public static void AddCar(string brand, string model, int year, float KmPerLiter,int TotalKm, int DailyPrice)
        {
            
            var tosql = $@"INSERT INTO Cars  (Brand, Model, Year, KmPerLiter, TotalKm, DailyPrice) Values
                ('{brand}','{model}','{year}',{KmPerLiter},{TotalKm},{DailyPrice},{DailyPrice * 7},{DailyPrice * 30});";
            RunSqlCommand.RunSql(tosql);

        }

        public static void DeleteCar(int value)
        {

            
            var tosql = $@"Delete From Cars WHERE Id = {value}";
            RunSqlCommand.RunSql(tosql);

        }

        public static  int AddUser(string CustomerName,string CustomerSurname,string CustomerPhone,string CustomerTc, string CustomerBirthYear,string CustomerPassword)
        {
            string connect = "Server=localhost;Database=CarRent;User=root;Password=122333;"; // Database baglantisi
            var tosql = $@"INSERT INTO Customer (CustomerName,CustomerSurname,CustomerPhone,CustomerTC,CustomerBirthYear,CustomerPassword) Values 
                ('{CustomerName}','{CustomerSurname}','{CustomerPhone}','{CustomerTc}','{CustomerBirthYear}','{CustomerPassword}');SELECT LAST_INSERT_ID();"; // SELECT LAST_INSERT_ID(); Son yapılan INSERT işleminden sonra otomatik verilen idyi bize veriyor.  

            MySqlConnection connection = new MySqlConnection(connect); // connect
            connection.Open(); // sql databasesini acma (kod bitince kapatılır)
            MySqlCommand cmd = new MySqlCommand(tosql , connection); // sql'e kod gönderme
            
            object a = cmd.ExecuteScalar(); // gelen yanıtı gosterıyor. object yazdım. int veya string yazınca hata alıyorum.
            
            return Convert.ToInt32(a);
            
            


        }
    }
}
