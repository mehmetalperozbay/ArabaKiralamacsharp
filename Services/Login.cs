using ConsoleApp8.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.Services
{
    public class Login
    {
        public static (string response, string tc, string password) LoginMenu()
        {
            Console.Clear();
            Console.WriteLine("SahibindenElite Rent a Car Login Sayfasına Hoş Geldiniz.\n");
            Console.Write("Giriş Yapmak İcin TC'nizi giriniz.\nSecim :  ");
            string tc = Console.ReadLine();

            if (tc.Length == 11 && !string.IsNullOrEmpty(tc))
            {
                Console.Write("Şifrenizi Giriniz.\nSecim :  ");
                string password = Console.ReadLine();

                if (!string.IsNullOrEmpty(password))
                {
                    string response = Sorgu.LoginSorgu(tc, password);
                    if (response != null)
                    {
                        
                        Console.WriteLine("Giris Basarili. Yönlendiriliyorsunuz...");
                        Thread.Sleep(500);
                        return (response,tc,password);


                    }
                    else
                    {
                        return ("hata","hata","hata");
                    }
                }
                else
                {
                    return ("hata", "hata", "hata");
                }
            }
            else
            {
                return ("hata", "hata", "hata");
            }

        }
    }
}
