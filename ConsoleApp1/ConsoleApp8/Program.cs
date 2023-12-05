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
        string city = "";
        
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
        
        string cityNameRU = "";
        
        HttpWebRequest request_coords = (HttpWebRequest)WebRequest.Create($"https://geocode-maps.yandex.ru/1.x/?apikey=532aec3d-e0c7-4454-961b-f815686ad07f&geocode={city}&format=json");
        request_coords.Method = "GET";
        request_coords.Headers.Add("Content-type", "application/json; charset=utf-8");
        HttpWebResponse response_coords = (HttpWebResponse)request_coords.GetResponse();
        Stream stream = response_coords.GetResponseStream();
        StreamReader reader = new StreamReader(stream);
        string jsonString_coords = reader.ReadToEnd();
        response_coords.Close();
        var json_coords = JsonObject.Parse(jsonString_coords);
        
        if (json_coords["response"]["GeoObjectCollection"]["metaDataProperty"]["GeocoderResponseMetaData"]["found"].ToString() == "0")
        {
            Console.WriteLine("Город не найден!");
            return;
        }

        var coords = json_coords["response"]["GeoObjectCollection"]["featureMember"][0]["GeoObject"]["Point"]["pos"].ToString().Split(' ');

        var comps =
            json_coords["response"]["GeoObjectCollection"]["featureMember"][0]["GeoObject"]["metaDataProperty"]
                ["GeocoderMetaData"]["Address"]["Components"];
        cityNameRU = comps[comps.AsArray().Count-1]["name"].ToString();
        
        HttpWebRequest request_weather = (HttpWebRequest)WebRequest.Create($"https://api.weather.yandex.ru/v2/forecast?lat={coords[1]}&lon={coords[0]}&extra=true");
        request_weather.Method = "GET";
        request_weather.Headers.Add("X-Yandex-API-Key", "73400b68-9299-4e43-9068-8da1156c96ed");
        HttpWebResponse response_weather = (HttpWebResponse)request_weather.GetResponse();
        stream = response_weather.GetResponseStream();
        reader = new StreamReader(stream);
        string jsonString_weather = reader.ReadToEnd();
        response_weather.Close();
        var json_weather = JsonObject.Parse(jsonString_weather);

        var p = json_weather["forecasts"][0]["parts"];
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
                          $"По ощущениям {p["evening"]["feels_like"]}°C\n" +
                          $"\n");
    }
}