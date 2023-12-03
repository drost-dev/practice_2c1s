using System.Net;


namespace ConsoleApp8;

public class Program
{
    static void Main(string[] args)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.weather.yandex.ru/v2/forecast?lat=55.75396&lon=37.620393&extra=true");
        request.Method = "GET";
        request.Headers.Add("X-Yandex-API-Key", "73400b68-9299-4e43-9068-8da1156c96ed");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);
        string jsonString = reader.ReadToEnd();

        response.Close();
        Console.WriteLine(jsonString);
    }
}