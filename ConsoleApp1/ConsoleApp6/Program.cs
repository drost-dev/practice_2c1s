// ReSharper disable CommentTypo
//Console.WriteLine("uncomment code");

/*  №1
string[] words = File.ReadAllLines("numsTask1.txt")[0].Split(' ');
foreach (var w in words)
{
    if (w.Length % 2 != 0)
    {
        Console.WriteLine(w);
    }
}
*/

//-----------------------------------------------------------------------------

/*  №2
string[] lines = File.ReadAllLines("numsTask2.txt");
foreach (var l in lines)
{
    Console.Write($"{l} ");
}
*/

//-----------------------------------------------------------------------------

/*  №3
int num = Convert.ToInt32(Console.ReadLine());
if (num % 2 == 0 && num % 10 == 0)
{
    Console.WriteLine($"Число {num} четное и кратно десяти");
}
else
{
    Console.WriteLine($"Число {num} не четное и/или не кратно десяти");
}
*/

//-----------------------------------------------------------------------------

/*  №4
Console.Write("a = ");
int a = Convert.ToInt32(Console.ReadLine());
if (a < 1)
{
    Console.WriteLine("Число a не может быть отрицательным!");
    return;
}

int sum = 0;
Console.WriteLine("Вводите числа, для завершения введите 0:");
int num = Convert.ToInt32(Console.ReadLine());

while (num != 0)
{
    if (num < 0)
    {
        Console.WriteLine("Числа не могут быть отрицательными!");
        return;
    }

    if (num % a == 0)
    {
        sum += num;
    }
    
    num = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine(sum);
*/

//-----------------------------------------------------------------------------

/*  №5
int n = Convert.ToInt32(Console.ReadLine());
int m = Convert.ToInt32(Console.ReadLine());
int[,] a = new int[n, m];
int[,] a2 = new int[n, m + 1];

Random r = new Random();

int onesAmount = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        a[i, j] = r.Next(0, 2);
        a2[i, j] = a[i, j];
        if (a2[i, j] == 1)
        {
            onesAmount++;
        }
        Console.Write($"{a[i, j]} ");
    }

    if (onesAmount % 2 != 0)
    {
        a2[i, m] = 1;
    }
    else
    {
        a2[i, m] = 0;
    }

    onesAmount = 0;

    Console.WriteLine();
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j <= m; j++)
    {
        Console.Write($"{a2[i, j]} ");
    }
    
    Console.WriteLine();
}
*/

//-----------------------------------------------------------------------------

/*  №6
Дан массив со случайным количеством дробных чисел. Из элементов
исходного массива постройте два новых. В первый должны входить только
положительные элементы, а во второй только отрицательные элементы;
*/