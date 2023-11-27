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
 
*/

Random r = new Random();
int months = 12;
int days = 30;
int[,] temperature = new int[months, days];
int min = -35;
int max = -20;

for (int i = 0; i < months; i++)
{
    for (int j = 0; j < days; j++)
    {
        temperature[i, j] = r.Next(min, max);
    }

    min = i < 6 ? min += 10 : min -= 10;
    max = i < 6 ? max += 9 : max -= 9;
}

for (int i = 0; i < months; i++)
{
    for (int j = 0; j < days; j++)
    {
        Console.Write($"{temperature[i, j]} ");
    }

    Console.WriteLine();
}

















/*
for (int i = 0; i < months; i++)
{
    for (int j = 0; j < days; j++)
    {
        temperature[j, i] = r.Next(min, max);
        Console.Write($"{temperature[j, i]}  ");
    }

    min = i < 6 ? min += 8 : min -= 7;
    max = i < 6 ? max += 8 : max -= 7;

    Console.WriteLine();
}*/