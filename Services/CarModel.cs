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
using System.Reflection.Metadata.Ecma335;
namespace ConsoleApp8.Services
{
    class CarModel
    {

        public static string Model(String Brand)
        {
            string connectionString = "Server=localhost;Database=CarRent;User=root;Password=122333;"; //Runsqlcommand.cs 'İ kullanmaya calısıyordum fakat cok fazla hata aldım. oyuzden her classda bunu tekrardan yazıyorum.

            using (MySqlConnection connect = new MySqlConnection(connectionString)) // baglanma not : sadece kullanırken. ondan sonra kapatmasını saglıyor. 'using'
            {
                connect.Open();// Databaseyi calıstırma

                Console.Clear(); // cls clear ile aynı şey. Konsol Temizleme.

                var tosql = $@"SELECT Brand, Model, MIN(Id) AS Id FROM Cars WHERE Brand = '{Brand}' AND Status = 1 group by Brand,Model"; // kodu ilk yazdıgımda   SELECT Model FROM Cars WHERE Brand = {Brand}" yazmıştım ama calısmadı. String değer olması icin '' tırnakları kullanmam lazım. benim yazdığım gibi sql'e sorgu gitmiyor. DISTINCT Yazmamın nedeni benzersiz olanları yazması. yoksa 200 adet sorgu atıyor. Id otomatik oluşturuldugu ıcın MIN kullandım.
                List<string> id = new List<string>();
                List<string> Models = new List<string>();
                using (MySqlCommand command = new MySqlCommand(tosql, connect))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    

                    int i = 1;
                    while (reader.Read())
                    {
                        string idread = reader["Id"].ToString();
                        string sqlgec = reader["Model"].ToString(); // sql 'den gelen veriyi okuyucudan 'model' stununu alan kısımdır. stringe dönüstürür 
                        id.Add(idread);
                        Models.Add(sqlgec); // 
                        Console.WriteLine($"{i} - {sqlgec}");
                        i++;
                        
                    }

                    Console.Write("\nSeçim :  ");

                    if (int.TryParse(Console.ReadLine(), out int secim) && secim <= Models.Count) // Tryparse'Nin Parse ile farkı hata vermemesi. out int secim de int secim = Console.Readline(); ile aynıdır. Count liste'nin indexidir.
                    {
                        string inputdeger = Models[secim - 1];  // İndexler 0'dan başlar. biz i'yi 0 yapsaydık eğer 0 - AUDI olacaktı. ama ilk indexi 1 - AUDI olarak yazdığımız için Models[1] yazarsak 2. indexi alırız. ilk indexi almamız için secim'den 1 çıkarıyoruz.

                        return id[secim - 1];
                    }
                    else
                    {
                        Console.WriteLine("hatalı secim.");
                        
                    }


                }Console.WriteLine("hata");
                return "hata";




            }

        }
    }
}
