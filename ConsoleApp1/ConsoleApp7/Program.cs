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
    static List<Task> addTask(List<Task> tasks)
    {
        try
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

            Console.WriteLine("Теперь введите дату и время, до которого вы хотите успеть выполнить задачу");
            Console.Write("Год: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Месяц: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("День: ");
            int day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Час: ");
            int hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("Минута: ");
            int minute = Convert.ToInt32(Console.ReadLine());

            var endDate = new DateTime(year, month, day, hour, minute, 0).ToUniversalTime();
            long unixTime = ((DateTimeOffset)endDate).ToUnixTimeSeconds();

            newTask.timestamp = unixTime;
        
            tasks.Add(newTask);

            Console.WriteLine("Задача добавлена.\n");
            
            saveTasks(tasks);
            
            return tasks;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка! Возможно, вы ввели недоступное значение. Попробуйте заново\n" +
                              $"Код ошибки: {e.Message}");
            return tasks;
        }
    }
    
    static void removeTask(List<Task> tasks)
    {
        listTasks(tasks);

        while (true)
        {
            Console.Write("Введите номер задачи, которую вы хотите удалить (введите 0 для отмены): ");
            int to_remove_index = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (to_remove_index == 0)
                {
                    return;
                }
                tasks.RemoveAt(to_remove_index-1);
                Console.WriteLine($"Задача {to_remove_index} успешно удалена.\n");
                saveTasks(tasks);
                return;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Такой задачи не существует!");
            }
        }
    }

    static void editTask(List<Task> tasks)
    {
        listTasks(tasks);

        while (true)
        {
            Console.Write("Введите номер задачи, которую вы хотите отредактировать (введите 0 для отмены): ");
            int to_edit_index = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (to_edit_index == 0)
                {
                    return;
                }

                Console.Write("Выберите, что вы хотите отредактировать:\n" +
                                  "1 - Название\n" +
                                  "2 - Описание\n" +
                                  "3 - Дату\n" +
                                  "Ваш выбор: ");
                
                //добавить эдит задачи
                
                
                tasks.RemoveAt(to_edit_index-1);
                Console.WriteLine($"Задача {to_edit_index} успешно удалена.\n");
                saveTasks(tasks);
                return;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Такой задачи не существует!");
            }
        }
    }
    
    static void listTasks(List<Task> tasks)
    {
        //добавить выбор на сегодня, завтра и неделю
        for (int i = 0; i < tasks.Count; i++)
        {
            DateTime time = new DateTime(1970, 1, 1);
            time = time.AddSeconds(tasks[i].timestamp).ToLocalTime();
            Console.WriteLine($"Задача {i+1}\n" +
                              $"Название: {tasks[i].name}\n" +
                              $"Описание: {tasks[i].desc}\n" +
                              $"До: {time}\n");
        }
    }

    static void saveTasks(List<Task> tasks)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        
        string json = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText("tasks.json", json);
    }

    static List<Task> loadTasks()
    {
        string textJson = File.ReadAllText("tasks.json");
        List<Task> tasks = JsonSerializer.Deserialize<List<Task>>(textJson);

        return tasks;
    }
    
    static void Main()
    {
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

        var tasks = loadTasks();
        
        while (true)
        {
            Console.Write("Что вы хотите сделать?\n" +
                          "1 - добавить задачу\n" +
                          "2 - удалить задачу\n" +
                          "3 - редактировать задачу\n" +
                          "4 - просмотреть задачи\n" +
                          "0 - выйти\n");
            Console.Write("Действие: ");
            int choose = Convert.ToInt32(Console.ReadLine());

            switch (choose)
            {
                case 0:
                    Console.Clear();
                    saveTasks(tasks);
                    return;
                
                case 1:
                    Console.Clear();
                    tasks = loadTasks();
                    addTask(tasks);
                    break;
                
                case 2:
                    Console.Clear();
                    removeTask(tasks);
                    break;
                
                case 3:
                    Console.Clear();
                    Console.WriteLine(3);
                    break;
                
                case 4:
                    Console.Clear();
                    listTasks(tasks);
                    break;
                
                default:
                    Console.Clear();
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