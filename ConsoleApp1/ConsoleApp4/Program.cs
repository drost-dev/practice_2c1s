Console.WriteLine("uncomment code");

/*  №1
int n = Convert.ToInt32(Console.ReadLine());
int mult = 1;

for (int i = 3; i <= n; i += 3)
{
    if (i <= n)
    {
        mult *= i;
    }
}

Console.WriteLine(mult);
*/

//-----------------------------------------------------------------------------

/*  №2
string[] nums = File.ReadAllLines("D:\\Rider\\Rider Projects\\practice_2c1s\\ConsoleApp1\\ConsoleApp4\\numsTask2.txt")[0].Split(';');
double sum = 0;

for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] != "0")
    {
        Console.Write($"{nums[i]} ");
        sum = Convert.ToDouble(nums[i]) > 0 ? sum + Convert.ToDouble(nums[i]) : sum;
    }
    else
    {
        break;
    }
}

Console.WriteLine();

Console.WriteLine(Math.Round(sum, 4));
*/

//-----------------------------------------------------------------------------

/*  №3
string[] nums = File.ReadAllLines("D:\\Rider\\Rider Projects\\practice_2c1s\\ConsoleApp1\\ConsoleApp4\\numsTask3.txt")[0].Split(',');
int min = 101;
int max = -101;

for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] != "0")
    {
        if (Convert.ToInt32(nums[i]) > max)
        {
            max = Convert.ToInt32(nums[i]);
        }
        
        if (Convert.ToInt32(nums[i]) < min)
        {
            min = Convert.ToInt32(nums[i]);
        }
    }
    else
    {
        break;
    }
}

Console.WriteLine($"Отношение минимального элемента ({min}) к максимальному ({max}): {(double)min / (double)max}, " +
                  $"отношение максимального к минимальному: {(double)max / (double)min},");
*/

//-----------------------------------------------------------------------------

/*  №4
string[] nums = File.ReadAllLines("D:\\Rider\\Rider Projects\\practice_2c1s\\ConsoleApp1\\ConsoleApp4\\numsTask4.txt")[0].Split(' ');
int sameNums = 1;
int sameNumsMax = 0;
int prevNum = 0;

for (int i = 1; i < nums.Length; i++)
{
    prevNum = Convert.ToInt32(nums[i-1]);
    if (prevNum == Convert.ToInt32(nums[i]))
    {
        sameNums++;
        if (sameNums > sameNumsMax)
        {
            sameNumsMax = sameNums;
        }
    }
    else
    {
        sameNums = 1;
    }
}

Console.WriteLine($"Максимум одинаковых чисел, стоящих рядом: {sameNumsMax}");
*/

//-----------------------------------------------------------------------------

/*  №5
Console.Write("a = ");
double a = Convert.ToDouble(Console.ReadLine());
Console.Write("b = ");
double b = Convert.ToDouble(Console.ReadLine());

int xMin = -1;
int xMax = 3;
int yMin = -2;
int yMax = 4;

if ((xMin <= a && xMax >= a) && (yMin <= b && yMax >= b))
{
    Console.WriteLine($"Точка ({a}; {b}) принадлежит заштрихованной области");
}
else
{
    Console.WriteLine($"Точка ({a}; {b}) не принадлежит заштрихованной области");
}
*/

//-----------------------------------------------------------------------------

/*  №6
Console.Write("a = ");
double a = Convert.ToDouble(Console.ReadLine());
Console.Write("b = ");
double b = Convert.ToDouble(Console.ReadLine());

int x1 = -2;
int x2 = 0;
int x3 = 2;
int y1 = -3;
int y2 = 2;
int y3 = -3;

double m1 = (x1 - a) * (y2 - y1) - (x2 - x1) * (y1 - b);
double m2 = (x2 - a) * (y3 - y2) - (x3 - x2) * (y2 - b);
double m3 = (x3 - a) * (y1 - y3) - (x1 - x3) * (y3 - b);

if ((m1 >= 0 && m2 >= 0 && m3 >= 0) || (m1 <= 0 && m2 <= 0 && m3 <= 0))
{
    Console.WriteLine($"Точка ({a}; {b}) принадлежит заштрихованной области");
}
else
{
    Console.WriteLine($"Точка ({a}; {b}) не принадлежит заштрихованной области");
}
*/