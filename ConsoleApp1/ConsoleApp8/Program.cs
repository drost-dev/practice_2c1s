using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Channels;

namespace ConsoleApp8;

public class Program
{
    static void Main(string[] args)
    {
        string city;
        
        if (args.Length == 0)
        {
            try
            {
                string textJson = File.ReadAllText("city.json");
                city = JsonSerializer.Deserialize<string>(textJson);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка! Вы не указали город и/или отсутствует сохраненный город по умолчанию.");
                return;
            }
            
        }
        else
        {
            Console.Write("Хотите установить текущий город как город по умолчанию? (y/n): ");
            string answer = Console.ReadLine();
            
            if (answer == "y")
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(args[0], options);
                File.WriteAllText("city.json", json);
            }

            city = args[0];
        }

        WebRequest reqCoords = WebRequest.Create($"https://geocode-maps.yandex.ru/1.x/?apikey=532aec3d-e0c7-4454-961b-f815686ad07f&geocode={city}&format=json");
        WebResponse respCoords = reqCoords.GetResponse();
        Stream stream = respCoords.GetResponseStream();
        StreamReader sr = new StreamReader(stream);
        string jsonStringCoords = sr.ReadToEnd();
        respCoords.Close();
        
        var jsonCoords = JsonObject.Parse(jsonStringCoords);
        var coords = jsonCoords["response"]["GeoObjectCollection"]["featureMember"][0]["GeoObject"]["Point"]["pos"].ToString().Split(' ');
        var comps = jsonCoords["response"]["GeoObjectCollection"]["featureMember"][0]["GeoObject"]["metaDataProperty"]["GeocoderMetaData"]["Address"]["Components"];
        string cityNameRU = comps[comps.AsArray().Count - 1]["name"].ToString();
        
        WebRequest reqWeather = WebRequest.Create($"https://api.weather.yandex.ru/v2/forecast?lat={coords[1]}&lon={coords[0]}&extra=true");
        reqWeather.Headers.Add("X-Yandex-API-Key", "73400b68-9299-4e43-9068-8da1156c96ed");
        WebResponse respWeather = reqWeather.GetResponse();
        stream = respWeather.GetResponseStream();
        sr = new StreamReader(stream);
        string jsonStringWeather = sr.ReadToEnd();
        respWeather.Close();
        
        var jsonWeather = JsonObject.Parse(jsonStringWeather);
        var p = jsonWeather["forecasts"][0]["parts"];
        
        
        
        Console.WriteLine($"Погода для города {cityNameRU}:\n" +
                          $"\tНочью:\n" +
                          $"В среднем {p["night"]["temp_avg"]}°C (от {p["night"]["temp_min"]}°C до {p["night"]["temp_max"]}°C)\n" +
                          $"По ощущениям {p["night"]["feels_like"]}°C\n" +
                          $"\n" +
                          $"\tУтром:\n" +
                          $"В среднем {p["morning"]["temp_avg"]}°C (от {p["morning"]["temp_min"]}°C до {p["morning"]["temp_max"]}°C)\n" +
                          $"По ощущениям {p["morning"]["feels_like"]}°C\n" +
                          $"\n" +
                          $"\tДнём:\n" +
                          $"В среднем {p["day"]["temp_avg"]}°C (от {p["day"]["temp_min"]}°C до {p["day"]["temp_max"]}°C)\n" +
                          $"По ощущениям {p["day"]["feels_like"]}°C\n" +
                          $"\n" +
                          $"\tВечером:\n" +
                          $"В среднем {p["evening"]["temp_avg"]}°C (от {p["evening"]["temp_min"]}°C до {p["evening"]["temp_max"]}°C)\n" +
                          $"По ощущениям {p["evening"]["feels_like"]}°C");
    }
}