using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

using System.Threading.Tasks;
using ConsoleApp8.MySql;
using MySql.Data.MySqlClient;
using ConsoleApp8.MySql;
using Microsoft.VisualBasic;
using ConsoleApp8.Services;


namespace ConsoleApp8.Services
{
    class Car
    {

        public static string Brand()
        {
            string connectionString = "Server=localhost;Database=CarRent;User=root;Password=122333;"; 

            using (MySqlConnection connect = new MySqlConnection(connectionString)) 
            {
                connect.Open();

                var tosql = $@"SELECT DISTINCT Brand FROM Cars WHERE Status = 1 "; // DISTINCT ile farklı olanları alan sql sorgusu.

                List<string> Models = new List<string>(); // string Liste oluşturma.

                using (MySqlCommand command = new MySqlCommand(tosql,connect))
                using (MySqlDataReader reader = command.ExecuteReader()) // sqlden gelen yanıtı okuma.
                {

                    int i = 1;
                    while (reader.Read()) // sql'den gelen veri bitene kadar calısacak olan while.
                    {
                        string sqlgec = reader["Brand"].ToString(); // sql 'den gelen veriyi okuyucudan 'model' stununu alan kısımdır. stringe dönüstürür 
                        Models.Add(sqlgec); // 
                        Console.WriteLine($"{i} - {sqlgec}");
                        i++;
                    }
                    Console.Write("\nSeçim :  "); // alt alta olmasın diye \n kullandım.

                    if (int.TryParse(Console.ReadLine(), out int secim) && secim <= Models.Count) // Tryparse'Nin Parse ile farkı hata vermemesi. out int secim de int secim = Console.Readline(); ile aynıdır. Count liste'nin indexidir.
                    {
                        string inputdeger = Models[secim - 1];  // İndexler 0'dan başlar. biz i'yi 0 yapsaydık eğer 0 - AUDI olacaktı. ama ilk indexi 1 - AUDI olarak yazdığımız için Models[1] yazarsak 2. indexi alırız. ilk indexi almamız için secim'den 1 çıkarıyoruz.

                        return  CarModel.Model(inputdeger); // modülü cagırma
                    }

                }return "hata";

                    
                    
                
            } 
            
        }
    }
}
