using System;
using System.Linq;
using System.Threading;
using ConsoleApp8.Api;
using ConsoleApp8.MySql;

namespace ConsoleApp8.Services
{
    class Register
    {
        public static int Menu()
        {
            Console.Clear();
            bool donguanahtari = false;
            while (!donguanahtari)
            {
                donguanahtari = true;
                Console.Clear();
                Console.WriteLine("SahibindenElite Rent a Car Kayıt Ekranı\n");

                Console.Write("Adınızı yazınız. (Gerçek Adınızı Giriniz Eğer Adınız özel karakter içeriyorsa lütfen giriniz. Soyad Bölümü Sonradan Açılacaktır. Örnek Ayça / Ömer\nSeçim : ");
                string ad = Console.ReadLine();

                if (ad != null)
                {
                    Console.Write("Soyadınızı yazınız. (Gerçek Soyadınızı Giriniz. Eğer Soyadınız özel karakter içeriyorsa lütfen giriniz. Örnek Özbay / Fidan\nSeçim : ");
                    string soyad = Console.ReadLine();

                    if (soyad != null)
                    {
                        Console.Write("Tc Kimlik Numaranızı Eksiksiz Giririniz.\nSeçim : ");
                        string tc = Console.ReadLine();

                        if (tc.Length == 11) // tc 11 hanelidir
                        {
                            Console.Write("Bir sifre belirleyiniz. En az 6 haneli olmalı, rakam içermeli ve büyük harf içermelidir.(Ornek :  Sagopa1978)\nSecim : ");
                            string password = Console.ReadLine();

                            if (PasswordStatus.password(password) == true)
                            {
                                Console.Write("Doğum Yılınızı Giriniz. Gerçek Doğum Yılınız Değilse Hata Verecektir.\nSeçim : ");
                                string dogumyili = Console.ReadLine();

                                if (dogumyili.Length == 4) // doğum yılının 4 haneli olması için
                                {
                                    Console.Write("Telefon Numaranızı Yazınız. (Başında 0 Olmadan Ornek 5075555555)\nSeçim : ");
                                    string telefon = Console.ReadLine();

                                    if (telefon[0] != '0' && telefon.Length == 10)
                                    {
                                        Console.WriteLine("Verdiğiniz Bilgilerin Doğruluğu Kabul Ediliyor...");

                                        string a = dogrulama.TcDogrulama(tc, ad, soyad, dogumyili);
                                        if (a == "true")
                                        {
                                            int response = Update.AddUser(ad, soyad, telefon, tc, dogumyili, password);
                                            Console.WriteLine(response);
                                            Thread.Sleep(1000);
                                            return response; // id'yi döndürüyoruz
                                        }
                                        else
                                        {
                                            return 0;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Girdiğiniz Değerler Yanlıştır. Lütfen Tekrar Deneyiniz.");
                                        Console.WriteLine("Program 3 Saniye İçinde Yeniden Başlayacaktır.");
                                        Thread.Sleep(3000);
                                        donguanahtari = false;
                                        return 0;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Girdiğiniz Değerler Yanlıştır. Lütfen Tekrar Deneyiniz.");
                                    Console.WriteLine("Program 3 Saniye İçinde Yeniden Başlayacaktır.");
                                    Thread.Sleep(3000);
                                    donguanahtari = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Girdiğiniz Değerler Yanlıştır. Lütfen Tekrar Deneyiniz.");
                                Console.WriteLine("Program 3 Saniye İçinde Yeniden Başlayacaktır.");
                                Thread.Sleep(3000);
                                donguanahtari = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Girdiğiniz Değerler Yanlıştır. Lütfen Tekrar Deneyiniz.");
                            Console.WriteLine("Program 3 Saniye İçinde Yeniden Başlayacaktır.");
                            Thread.Sleep(3000);
                            donguanahtari = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz Değerler Yanlıştır. Lütfen Tekrar Deneyiniz.");
                        Console.WriteLine("Program 3 Saniye İçinde Yeniden Başlayacaktır.");
                        Thread.Sleep(3000);
                        donguanahtari = false;
                    }
                }
                else
                {
                    Console.WriteLine("Girdiğiniz Değerler Yanlıştır. Lütfen Tekrar Deneyiniz.");
                    Console.WriteLine("Program 3 Saniye İçinde Yeniden Başlayacaktır.");
                    Thread.Sleep(3000); // bekleme
                    donguanahtari = false; // döngüyü tekrar başlatma
                }
            }
            return -1; // -1 çoğunlukla hata kodu olarak kullanılır
        }
    }
}
