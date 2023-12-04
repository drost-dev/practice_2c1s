using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Channels;

namespace ConsoleApp8;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите город: ");
        string city = Console.ReadLine();
        
        HttpWebRequest request_coords = (HttpWebRequest)WebRequest.Create($"https://geocode-maps.yandex.ru/1.x/?apikey=532aec3d-e0c7-4454-961b-f815686ad07f&geocode={city}&format=json");
        request_coords.Method = "GET";
        request_coords.Headers.Add("Content-type", "application/json; charset=utf-8");
        HttpWebResponse response_coords = (HttpWebResponse)request_coords.GetResponse();
        Stream stream = response_coords.GetResponseStream();
        StreamReader reader = new StreamReader(stream);
        string jsonString_coords = reader.ReadToEnd();
        response_coords.Close();
        var json_coords = JsonObject.Parse(jsonString_coords);
        var coords = json_coords["response"]["GeoObjectCollection"]["featureMember"][0]["GeoObject"]["Point"]["pos"].ToString().Split(' ');

        HttpWebRequest request_weather = (HttpWebRequest)WebRequest.Create($"https://api.weather.yandex.ru/v2/forecast?lat={coords[1]}&lon={coords[0]}&extra=true");
        request_weather.Method = "GET";
        request_weather.Headers.Add("X-Yandex-API-Key", "73400b68-9299-4e43-9068-8da1156c96ed");
        HttpWebResponse response_weather = (HttpWebResponse)request_weather.GetResponse();
        stream = response_weather.GetResponseStream();
        reader = new StreamReader(stream);
        string jsonString_weather = reader.ReadToEnd();
        response_weather.Close();
        var json_weather = JsonObject.Parse(jsonString_weather);
        Console.WriteLine($"Сейчас: {json_weather["fact"]["temp"]}°C");
        Console.WriteLine($"Ощущается как: {json_weather["fact"]["feels_like"]}°C");

    }
}