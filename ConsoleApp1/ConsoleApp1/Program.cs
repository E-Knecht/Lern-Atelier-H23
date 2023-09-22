using HtmlAgilityPack;
namespace Websrcaper
{
    class Programm
    {
        static void Main(String[] args)
        {
            try
            {
                string StartURL = "https://www.daswetter.com/wetter_Biberstein-Europa-Schweiz-Aargau--1-188889.html";
                var Httpclient = new HttpClient();
                var html = Httpclient.GetStringAsync(StartURL).Result;
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);



                var Temeraturelement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='dato-temperatura changeUnitT']");
                var temperatur = Temeraturelement.InnerText.Trim();
                Console.WriteLine(temperatur.Replace("&deg;", "°C"));

                var wetterelement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='descripcion']");
                var wetter = wetterelement.InnerText.Trim();
                Console.WriteLine(wetter);
            }
            catch
            {
                Console.WriteLine("Error");
            }




        }



    }
}