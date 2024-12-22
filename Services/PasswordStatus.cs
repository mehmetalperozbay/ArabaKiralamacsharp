using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.Services
{
    public class PasswordStatus
    {
        public static bool password(string password)
        {
            if (!password.Any(ch => Char.IsDigit(ch))){ // !password false olursa calısmasını ısaret eder. .Any herhangi bir indexte varmı yokmu kontrol eder. Char.IsDigit ise Sayı varmı yokmu cevabını verir. Eğer yoksa false degeri dondurulur

                return false;
            }else if(!password.Any(ch => Char.IsUpper(ch))) // IsUpper ise indexte büyük harf varmı yokmu kontrol eder yoksa return dondurur
            {
                return false;
            }else if (password.Length <= 6) // password'Un uzunlugu en az 6 haneli olmalıdır.
            {
                return false;
            }
            return true;
        }
    }
}
