//Console.WriteLine("uncomment code");

/*  №1
int[] arr = new int[100];
int num = 50;

for (int i = 0; i < 100; i++)
{
    arr[i] = num;
    num -= 3;
}
*/

//-----------------------------------------------------------------------------

/*  №2
int[] arr = new int[50];

for (int i = 0; i < 50; i++)
{ 
    arr[i] = i * 2 + 1;
}
*/

//-----------------------------------------------------------------------------

/*  №3
Console.Write("n = ");
int n = Convert.ToInt32(Console.ReadLine());
int[,] m = new int[n, n];

for (int i = 0; i < n; i++)
{
    m[0, i] = 1;
    m[i, 0] = 1;
}

for (int i = 1; i < n; i++)
{
    for (int j = 1; j < n; j++)
    {
        m[i, j] = m[i - 1, j] + m[i, j - 1];
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write($"{m[i, j]} ");
    }

    Console.WriteLine();
}
*/

//-----------------------------------------------------------------------------

/*  №4
static int[] avgTemperature(int[,] temperature)
{
    int[] avgTemps = new int[12];
    int sum = 0;
    
    for (int i = 0; i < 12; i++)
    {
        for (int j = 0; j < 30; j++)
        {
            sum += temperature[j, i];
        }

        avgTemps[i] = sum / 30;
        sum = 0;
    }

    return avgTemps;
}



Random r = new Random();
int months = 12;
int days = 30;
int[,] temperature = new int[days, months];
int min = -35;
int max = -20;

for (int i = 0; i < months; i++)
{
    for (int j = 0; j < days; j++)
    {
        temperature[j,i] = r.Next(min, max);
    }
    
    min = i < 6 ? min += 10 : min -= 10;
    max = i < 6 ? max += 9 : max -= 9;
}

Console.WriteLine("Ежедневная температура за год:");

for (int i = 0; i < days; i++)
{
    for (int j = 0; j < months; j++)
    {
        Console.Write($"{temperature[i, j]} ");
    }

    Console.WriteLine();
}

int[] avgTemps = avgTemperature(temperature);

Console.WriteLine("Средняя температура по месяцам:");

for (int i = 0; i < 12; i++)
{
    Console.Write($"{avgTemps[i]} ");
}

Console.WriteLine();

Array.Sort(avgTemps);

Console.WriteLine("Отсортированная средняя температура по месяцам:");

for (int i = 0; i < 12; i++)
{
    Console.Write($"{avgTemps[i]} ");
}
*/

//-----------------------------------------------------------------------------

/*  №5
static Dictionary<string, int> avgTemperature(Dictionary<string, int[]> dict)
{
    Dictionary<string, int> res = new Dictionary<string, int>();
    int sum = 0;
    
    foreach (var month in dict)
    {
        for (int i = 0; i < 30; i++)
        {
            sum += dict[month.Key][i];
        }
    
        res.Add(month.Key, sum / 30);
        sum = 0;
    }

    return res;
}



Random r = new Random();
Dictionary<string, int[]> monthsDictionary = new Dictionary<string, int[]>()
{
    ["January"] = new int[30],
    ["February"] = new int[30],
    ["March"] = new int[30],
    ["April"] = new int[30],
    ["May"] = new int[30],
    ["June"] = new int[30],
    ["July"] = new int[30],
    ["August"] = new int[30],
    ["September"] = new int[30],
    ["October"] = new int[30],
    ["November"] = new int[30],
    ["December"] = new int[30]
};

int min = -35;
int max = -20;
int monthNum = 0;

foreach (var month in monthsDictionary)
{
    for (int i = 0; i < 30; i++)
    {
        monthsDictionary[month.Key][i] = r.Next(min, max);
    }
    min = monthNum < 6 ? min += 10 : min -= 10;
    max = monthNum < 6 ? max += 9 : max -= 9;
    monthNum++;
}

Console.WriteLine("Ежедневная температура за год:");
foreach (var month in monthsDictionary)
{
    for (int i = 0; i < 30; i++)
    {
        Console.Write($"{monthsDictionary[month.Key][i]} ");
    }
    Console.WriteLine();
}

Dictionary<string, int> avgTemps = avgTemperature(monthsDictionary);

Console.WriteLine("Средняя температура по месяцам:");
foreach (var month in avgTemps)
{
    Console.Write($"{avgTemps[month.Key]} ");
}
*/