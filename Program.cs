using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using ConsoleApp8.MySql;
using System.Threading;
using ConsoleApp8.Api;
using ConsoleApp8.Services;
using System.Drawing.Printing;
namespace ConsoleApp8
{
    class Program // Programdaki herşeyi çağıran Kısım
    {

        public static void Main()
        {
            Console.Title = "SahibindenElite";
            DatabaseRun.DataRunner(); // Database başlatıcı. Insert ve Create gibi kodlar bu modülde calısacak. Tüm arabalar eklenecektir.

            bool donguanahtari = false;
            while (!donguanahtari) // false ise calısan while dongusu.
            {
                DatabaseRun.DataRunner();
                Console.Clear();

                Console.WriteLine("SahibindenElite Rent a Car Uygulamasına Hoş Geldiniz.\n");
                Console.Write("1 - Kayıt\n2 - Giriş\n3 - Araç Sorgu Paneli\n4 - Admin Panel\n\nSeçim :  ");


                if (int.TryParse(Console.ReadLine(), out int intdeger) && intdeger >= 0 && intdeger <= 4)
                {
                    if (intdeger == 1)
                    {
                        donguanahtari = true;
                        int response = Register.Menu();

                        if (response != -1)
                        {

                            Console.Clear();

                            string CustomerName = Sorgu.CustomerIdAdSorgu(response);
                            if (CustomerName != null)
                            {
                                Console.Clear();
                                Console.WriteLine($"SahibindenElite Rent a Car Uygulamasına Hoş Geldin {CustomerName}.\n");
                                Console.Write("1 - Araba Kirala\n2 - Plaka Sorgu\n3 - Akaryakıt Fiyatları\n4 - Sikayet / Oneri Geri Bildirimi\n5 - Cikis\n\nSecim :  ");

                                if (int.TryParse(Console.ReadLine(), out int secim) && secim >= 0 && secim <= 5)
                                {
                                    if (secim == 1)
                                    {
                                        Console.Clear();
                                        string carbrandresponse = Car.Brand();

                                        if (carbrandresponse != "hata")
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Sayın {CustomerName} Seçtiğiniz Arabanın Bilgileri : ");
                                            Sorgu.CarIdSorgu(carbrandresponse);

                                            Console.WriteLine("\nKiralamak istediğiniz paketi seciniz. Gün olarak kiralamak istiyorsanız kaç gün kiralamak istediğinizi yazınız. Örnek : ('4' / 'Günlük' / 'Haftalık' / 'Aylık')\nSecim :  ");
                                            string input = Console.ReadLine();
                                            string response1 = response.ToString();
                                            if (input.ToLower() == "günlük")
                                            {
                                                RentCar.Rent(carbrandresponse, response1, 1);
                                                Console.WriteLine("Araba Kiralandı.");
                                            }
                                            else if (input.ToLower() == "haftalık")
                                            {
                                                RentCar.Rent(carbrandresponse, response1, 7);
                                                Console.WriteLine("Araba Kiralandı.");

                                            }
                                            else if (input.ToLower() == "aylık")
                                            {
                                                RentCar.Rent(carbrandresponse, response1, 30);
                                                Console.WriteLine("Araba Kiralandı.");

                                            }
                                            else if (int.TryParse(input, out int intinput))
                                            {
                                                if (intinput != 0 && intinput >= 0)
                                                {
                                                    RentCar.Rent(carbrandresponse, response1, intinput);
                                                    Console.WriteLine("Araba Kiralandı.");

                                                }
                                                else
                                                {
                                                    Console.WriteLine("bir sorun oluştu.");
                                                }
                                            }
                                        }

                                    }
                                    Console.Clear();
                                    string carbrandresponse2 = Car.Brand();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Bir Sorun Oluştu");
                            }




                        }
                    }
                    else if (intdeger == 2)
                    {
                        Console.Clear();
                        var loginmenu = Login.LoginMenu();
                        string id = Sorgu.CustomerIdSorgu(loginmenu.tc, loginmenu.password);
                        Console.WriteLine($"SahibindenElite Rent a Car Uygulamasına Hoş Geldin {loginmenu.response}.\n");
                        Console.Clear();
                        string carbrandresponse = Car.Brand();

                        if (carbrandresponse != "hata")
                        {
                            Console.Clear();
                            Console.WriteLine($"Sayın {loginmenu.response} Seçtiğiniz Arabanın Bilgileri : \n");
                            Sorgu.CarIdSorgu(carbrandresponse);
                            Console.WriteLine("\nKiralamak istediğiniz paketi seciniz. Gün olarak kiralamak istiyorsanız kaç gün kiralamak istediğinizi yazınız. Örnek : ('4' / 'Günlük' / 'Haftalık' / 'Aylık')\nSecim :  ");
                            string input = Console.ReadLine();

                            if (input.ToLower() == "günlük")
                            {
                                RentCar.Rent(carbrandresponse, id, 1);
                                Console.WriteLine("Araba Kiralandı!");

                                Console.ReadLine();

                            }
                            else if (input.ToLower() == "haftalık")
                            {
                                RentCar.Rent(carbrandresponse, id, 7);
                                Console.WriteLine("Araba Kiralandı!");
                                Console.ReadLine();

                            }
                            else if (input.ToLower() == "aylık")
                            {
                                RentCar.Rent(carbrandresponse, id, 30);
                                Console.WriteLine("Araba Kiralandı!");

                                Console.ReadLine();

                            }
                            else if (int.TryParse(input, out int intinput))
                            {
                                if (intinput != 0 && intinput >= 0)
                                {
                                    RentCar.Rent(carbrandresponse, id, intinput);
                                    Console.WriteLine("Araba Kiralandı!");

                                    Console.ReadLine();

                                }
                                else
                                {
                                    Console.WriteLine("bir sorun oluştu.");
                                }
                            }

                        }


                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş yaptınız. Program 3 saniye içinde yeniden başlayacaktır.");
                        Thread.Sleep(3000);
                        donguanahtari = false;
                    }


                }



            }
        }
    }
}
