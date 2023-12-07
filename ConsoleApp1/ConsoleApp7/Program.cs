using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text;
using System.Threading.Channels;

namespace ConsoleApp7;

public class Program
{
    static void addTask(List<Task> tasks)
    {
        try
        {
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

            var endDate = new DateTime(year, month, day, hour, minute, 0);
            long unixTime = ((DateTimeOffset)endDate).ToUnixTimeSeconds();
            newTask.timestamp = unixTime;

            tasks.Add(newTask);
            Console.WriteLine("Задача добавлена.\n");
            
            saveTasks(tasks);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка! Возможно, вы ввели недоступное значение. Попробуйте заново\n" +
                              $"Код ошибки: {e.Message}");
        }
    }
    
    static void removeTask(List<Task> tasks, List<Task> chosenTasks)
    {
        while (true)
        {
            try
            {
                Console.Write("Введите номер задачи, которую вы хотите удалить (введите 0 для отмены): ");
                int to_remove_index = Convert.ToInt32(Console.ReadLine());
                if (to_remove_index == 0)
                {
                    Console.Clear();
                    return;
                }

                tasks.Remove(chosenTasks[to_remove_index-1]);
                Console.Clear();
                Console.WriteLine($"Задача {to_remove_index} успешно удалена.\n");
                saveTasks(tasks);
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Такой задачи не существует!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите целое число!");
            }
        }
    }

    static void editTask(List<Task> tasks, List<Task> chosenTasks)
    {
        while (true)
        {
            try
            {
                Console.Write("Введите номер задачи, которую вы хотите отредактировать (введите 0 для отмены): ");
                int to_edit_index = Convert.ToInt32(Console.ReadLine()) - 1;
                if (to_edit_index + 1 == 0)
                {
                    Console.Clear();
                    return;
                }
                
                Console.Clear();

                Console.Write("Выберите, что вы хотите отредактировать:\n" +
                              "1 - Название\n" +
                              "2 - Описание\n" +
                              "3 - Дату\n" +
                              "Ваш выбор: ");
                
                int to_edit_index_param = Convert.ToInt32(Console.ReadLine());
                string new_param;
                Console.Clear();
                Task t = chosenTasks[to_edit_index];
                switch (to_edit_index_param)
                {
                    case 1:
                        Console.Write($"Старое название: {chosenTasks[to_edit_index].name}\n" +
                                          $"Введите новое название: ");
                        new_param = Console.ReadLine();
                        
                        if (new_param != "")
                        {
                            tasks[tasks.IndexOf(chosenTasks[to_edit_index])].name = new_param;
                        }
                        else
                        {
                            tasks[tasks.IndexOf(chosenTasks[to_edit_index])].name = "Безымянная задача";
                        }
                        
                        break;
                    
                    case 2:
                        Console.Write($"Старое описание: {chosenTasks[to_edit_index].desc}\n" +
                                      $"Введите новое описание: ");
                        new_param = Console.ReadLine();
                        
                        if (new_param != "")
                        {
                            tasks[tasks.IndexOf(chosenTasks[to_edit_index])].desc = new_param;
                        }
                        else
                        {
                            tasks[tasks.IndexOf(chosenTasks[to_edit_index])].desc = "Без описания";
                        }
                        
                        break;
                    
                    case 3:
                        DateTime time = new DateTime(1970, 1, 1);
                        time = time.AddSeconds(chosenTasks[to_edit_index].timestamp).ToLocalTime();
                        Console.Write($"Старая дата: {time}\n");
                        
                        Console.WriteLine("Введите новую дату и время");
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
                        
                        var endDate = new DateTime(year, month, day, hour, minute, 0);
                        long unixTime = ((DateTimeOffset)endDate).ToUnixTimeSeconds();
                        tasks[tasks.IndexOf(chosenTasks[to_edit_index])].timestamp = unixTime;
                        
                        break;
                    
                    default:
                        Console.WriteLine("Такого варианта нет!");
                        break;
                }
                
                Console.Clear();
                saveTasks(tasks);
                Console.WriteLine("Изменения сохранены.");
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Такой задачи не существует!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите целое число!");
            }
        }
    }
    
    static List<Task> listTasks(List<Task> tasks)
    { 
        while (true)
        {
            try
            {
                List<Task> chosenTasks = new List<Task>();
                Console.WriteLine("Какие задачи вы хотите выбрать?\n" +
                                  "1 - на сегодня\n" +
                                  "2 - на завтра\n" +
                                  "3 - на неделю\n" +
                                  "4 - выполненные\n" +
                                  "5 - невыполненные\n" +
                                  "6 - все задачи");
                Console.Write("Ваш выбор: ");
                int choose = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                
                var nowDate = DateTime.Now;
                var todayDate = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day, 0, 0, 0);
                var tomorrowDate = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day+1, 0, 0, 0);
                
                long nowInUnixTime = ((DateTimeOffset)nowDate).ToUnixTimeSeconds();
                long todayInUnixTime = ((DateTimeOffset)todayDate).ToUnixTimeSeconds();
                long tomorrowInUnixTime = ((DateTimeOffset)tomorrowDate).ToUnixTimeSeconds();
                
                switch (choose)
                {
                    case 1:
                        foreach (var t in tasks)
                        {
                            if (t.timestamp >= todayInUnixTime && t.timestamp < tomorrowInUnixTime)
                            {
                                chosenTasks.Add(t);
                            }
                        }

                        for (int i = 0; i < chosenTasks.Count; i++)
                        {
                            DateTime time = new DateTime(1970, 1, 1);
                            time = time.AddSeconds(chosenTasks[i].timestamp).ToLocalTime();
                            Console.WriteLine($"Задача {i+1}\n" +
                                              $"Название: {chosenTasks[i].name}\n" +
                                              $"Описание: {chosenTasks[i].desc}\n" +
                                              $"До: {time}\n");
                        }

                        return chosenTasks;
                    
                    case 2:
                        foreach (var t in tasks)
                        {
                            if (t.timestamp >= tomorrowInUnixTime && t.timestamp < tomorrowInUnixTime+86400)
                            {
                                chosenTasks.Add(t);
                            }
                        }

                        for (int i = 0; i < chosenTasks.Count; i++)
                        {
                            DateTime time = new DateTime(1970, 1, 1);
                            time = time.AddSeconds(chosenTasks[i].timestamp).ToLocalTime();
                            Console.WriteLine($"Задача {i+1}\n" +
                                              $"Название: {chosenTasks[i].name}\n" +
                                              $"Описание: {chosenTasks[i].desc}\n" +
                                              $"До: {time}\n");
                        }

                        return chosenTasks;
                    
                    case 3:
                        foreach (var t in tasks)
                        {
                            if (t.timestamp >= todayInUnixTime && t.timestamp < todayInUnixTime+86400*7)
                            {
                                chosenTasks.Add(t);
                            }
                        }

                        for (int i = 0; i < chosenTasks.Count; i++)
                        {
                            DateTime time = new DateTime(1970, 1, 1);
                            time = time.AddSeconds(chosenTasks[i].timestamp).ToLocalTime();
                            Console.WriteLine($"Задача {i+1}\n" +
                                              $"Название: {chosenTasks[i].name}\n" +
                                              $"Описание: {chosenTasks[i].desc}\n" +
                                              $"До: {time}\n");
                        }

                        return chosenTasks;
                    
                    case 4:
                        foreach (var t in tasks)
                        {
                            if (t.timestamp <= nowInUnixTime)
                            {
                                chosenTasks.Add(t);
                            }
                        }

                        for (int i = 0; i < chosenTasks.Count; i++)
                        {
                            DateTime time = new DateTime(1970, 1, 1);
                            time = time.AddSeconds(chosenTasks[i].timestamp).ToLocalTime();
                            Console.WriteLine($"Задача {i+1}\n" +
                                              $"Название: {chosenTasks[i].name}\n" +
                                              $"Описание: {chosenTasks[i].desc}\n" +
                                              $"До: {time}\n");
                        }

                        return chosenTasks;
                    
                    case 5:
                        foreach (var t in tasks)
                        {
                            if (t.timestamp > nowInUnixTime)
                            {
                                chosenTasks.Add(t);
                            }
                        }

                        for (int i = 0; i < chosenTasks.Count; i++)
                        {
                            DateTime time = new DateTime(1970, 1, 1);
                            time = time.AddSeconds(chosenTasks[i].timestamp).ToLocalTime();
                            Console.WriteLine($"Задача {i+1}\n" +
                                              $"Название: {chosenTasks[i].name}\n" +
                                              $"Описание: {chosenTasks[i].desc}\n" +
                                              $"До: {time}\n");
                        }

                        return chosenTasks;
                    
                    case 6:
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            DateTime time = new DateTime(1970, 1, 1);
                            time = time.AddSeconds(tasks[i].timestamp).ToLocalTime();
                            Console.WriteLine($"Задача {i+1}\n" +
                                              $"Название: {tasks[i].name}\n" +
                                              $"Описание: {tasks[i].desc}\n" +
                                              $"До: {time}\n");
                        }

                        return tasks;
                }

                return tasks;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Такой задачи не существует!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите целое число!");
            }
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
        var tasks = loadTasks();
        
        while (true)
        {
            try
            {
                Console.Write("Что вы хотите сделать?\n" +
                              "1 - добавить задачу\n" +
                              "2 - удалить задачу\n" +
                              "3 - редактировать задачу\n" +
                              "4 - просмотреть задачи\n" +
                              "0 - выйти\n");
                Console.Write("Ваш выбор: ");
                int choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 0:
                        saveTasks(tasks);
                        return;
                
                    case 1:
                        Console.Clear();
                        tasks = loadTasks();
                        addTask(tasks);
                        break;
                
                    case 2:
                        Console.Clear();
                        tasks = loadTasks();
                        removeTask(tasks, listTasks(tasks));
                        break;
                
                    case 3:
                        Console.Clear();
                        tasks = loadTasks();
                        editTask(tasks, listTasks(tasks));
                        break;
                
                    case 4:
                        Console.Clear();
                        tasks = loadTasks();
                        listTasks(tasks);
                        break;
                
                    default:
                        Console.Clear();
                        Console.WriteLine("Такого варианта нет, попробуйте ещё раз.");
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Такой задачи не существует!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите целое число!");
            }
        }
    }
}