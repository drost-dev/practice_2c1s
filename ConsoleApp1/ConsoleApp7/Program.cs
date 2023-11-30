// ReSharper disable CommentTypo
using System.Text.Json;
using System.Text;


/*
 * https://www.google.com/search?q=%D0%BF%D0%B5%D1%80%D0%B5%D0%B2%D0%B5%D1%81%D1%82%D0%B8+%D0%B4%D0%B0%D1%82%D1%83+%D0%B2+timestamp+c%23&oq=%D0%BF%D0%B5%D1%80%D0%B5%D0%B2%D0%B5%D1%81%D1%82%D0%B8+%D0%B4%D0%B0%D1%82%D1%83+%D0%B2+timestamp+c%23&gs_lcrp=EgZjaHJvbWUyCQgAEEUYORigATIKCAEQIRgWGB0YHjIKCAIQIRgWGB0YHjIKCAMQIRgWGB0YHjIKCAQQIRgWGB0YHjIKCAUQIRgWGB0YHjIKCAYQIRgWGB0YHjIKCAcQIRgWGB0YHjIKCAgQIRgWGB0YHjIKCAkQIRgWGB0YHtIBCDUxNjFqMGo3qAIAsAIA&sourceid=chrome&ie=UTF-8
 * https://ru.stackoverflow.com/questions/1088144/%D0%9A%D0%B0%D0%BA-%D0%BF%D0%B5%D1%80%D0%B5%D0%B2%D0%B5%D1%81%D1%82%D0%B8-%D0%B2%D1%80%D0%B5%D0%BC%D1%8F-%D0%B2-timestamp
 * https://metanit.com/sharp/tutorial/19.1.php
 * https://www.google.com/search?q=timespan+c%23&oq=timespan+&gs_lcrp=EgZjaHJvbWUqDAgAEAAYFBiHAhiABDIMCAAQABgUGIcCGIAEMgwIARAAGBQYhwIYgAQyBggCEEUYOTIMCAMQABhDGIAEGIoFMgwIBBAAGEMYgAQYigUyBwgFEAAYgAQyBwgGEAAYgAQyBwgHEAAYgAQyBwgIEAAYgAQyBwgJEAAYgATSAQgzNjE5ajBqN6gCALACAA&sourceid=chrome&ie=UTF-8
 * https://learn.microsoft.com/ru-ru/dotnet/api/system.timespan?view=net-8.0
 */


namespace ConsoleApp7;

public class Program
{
    List<Task> addTask(List<Task> tasks)
    {
        int timestamp = Int32.MaxValue;
        
        Task newTask = new Task();
        
        Console.Write("Введите название задачи: ");
        string newTaskName = Console.ReadLine();
        if (newTaskName != "")
        {
            newTask.name = newTaskName;
        }
        else
        {
            newTask.name = "Безымянная задача";
        }
        
        Console.Write("Введите описание задачи: ");
        string newTaskDescription = Console.ReadLine();
        if (newTaskDescription != "")
        {
            newTask.desc = newTaskDescription;
        }
        else
        {
            newTask.desc = "Без описания";
        }
        
        return tasks;
    }
    static void Main()
    {
        string text = File.ReadAllText("tasks.json");
        List<Task> tasks = JsonSerializer.Deserialize<List<Task>>(text);
        
        /*
        ------------ Ежедневник ------------

        Функции:
        1. Добавлять задачи
        2. Удалять задачи
        3. Редактировать
        4. Просматривать задачи
            4.1. По временному промежутку
                4.1.1. На сегодня
                4.1.2. На завтра
                4.1.3. На неделю
            4.2. По статусу
                4.2.1. Все
                4.2.2. Невыполненные
                4.2.3. Выполненые

        Структура задачи (json):
        {
            название: "...",
            описание: "...",
            дата: timestamp
        }

        Принцип работы:
        постоянно спрашивать у юзера че он хочет (while), 
        хотелки принимать через ввод из консоли,
        в зависимости от хотелок совершать операции с словарем и json 
        (прочитать словарь из json'а, прочитать/отредачить словарь,
        закинуть обратно в json, сохранить, закрыть файл)

        */

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        
        
        while (true)
        {
            Console.Write("Что вы хотите сделать?\n" +
                          "1 - добавить задачу\n" +
                          "2 - удалить задачу\n" +
                          "3 - редактировать задачу\n" +
                          "4 - просмотреть задачи\n" +
                          "0 - выйти\n\n");
            
            int choose = Convert.ToInt32(Console.ReadLine());

            switch (choose)
            {
                case 0:
                    string json = JsonSerializer.Serialize(tasks, options);
                    File.WriteAllText("tasks.json", json);
                    return;
                
                case 1:
                    Console.WriteLine(1);
                    break;
                
                case 2:
                    Console.WriteLine(2);
                    break;
                
                case 3:
                    Console.WriteLine(3);
                    break;
                
                case 4:
                    Console.WriteLine(4);
                    break;
                
                default:
                    Console.WriteLine("Такого варианта нет, попробуйте ещё раз");
                    break;
            }
        }

        /*
        Task task1 = new Task();
        task1.name = "TestTask1";
        task1.desc = "It is a test task, created for debugging";
        task1.timestamp = 1701369613;

        Task task2 = new Task();
        task2.name = "TestTask2";
        task2.desc = "It is another test task 2, created for debugging";
        task2.timestamp = 1701366613;

        List<Task> tasks = new List<Task>();
        tasks.Add(task1);
        tasks.Add(task2);

        foreach (var t in tasks)
        {
            Console.WriteLine(t.name);
            Console.WriteLine(t.desc);
            Console.WriteLine(t.timestamp);
        }
        
        string json = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText("tasks.json", json);
        //Console.WriteLine(json);
        */

        
        
        
        /*
        string text = File.ReadAllText("tasks.json");
        var tasks = JsonSerializer.Deserialize<List<Task>>(text);
        foreach (var t in tasks)
        {
            Console.WriteLine(t.name);
        }
        */
    }
}