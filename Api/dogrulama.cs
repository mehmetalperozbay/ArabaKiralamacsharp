using System;
using System.Net.Http;
using System.Text;

namespace ConsoleApp8.Api
{
    public class dogrulama
    {
        public static string TcDogrulama(string tckimlik, string name, string surname, string dogumyili)
        {
            string ad = name.ToUpper();
            string soyad = surname.ToUpper();

            // XML verisini hazırlıyoruz.
            string soapRequest = $@"<?xml version=""1.0"" encoding=""utf-8""?>
    <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
      <soap:Body>
        <TCKimlikNoDogrula xmlns=""http://tckimlik.nvi.gov.tr/WS"">
          <TCKimlikNo>{tckimlik}</TCKimlikNo>
          <Ad>{ad}</Ad>
          <Soyad>{soyad}</Soyad>
          <DogumYili>{dogumyili}</DogumYili>
        </TCKimlikNoDogrula>
      </soap:Body>
    </soap:Envelope>";

            var httpclient = new HttpClient();
            var requestcontent = new StringContent(soapRequest, Encoding.UTF8, "text/xml");

            try
            {
                // API'ye senkron istek gönderiyoruz.
                var request = httpclient.PostAsync("https://tckimlik.nvi.gov.tr/service/kpspublic.asmx", requestcontent).Result;
                if (request.IsSuccessStatusCode)
                {
                    string response = request.Content.ReadAsStringAsync().Result;
                    if (response.Contains("<TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult>"))
                    {
                        return "true"; // Başarılı işlem.
                    }
                    else
                    {
                        return "false"; // Hata yanıtı.
                    }
                }
                else
                {
                    // Eğer HTTP isteği başarısızsa.
                    return "false";
                }
            }
            catch
            {
                // Hata yönetimi.
                return "false";
            }
        }
    }
}
