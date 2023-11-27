Console.WriteLine("uncomment code");

/*  №1
Random r = new Random();
int[] arr = new int[10];
int minIndex = 0;

for (int i = 0; i < 10; i++)
{
    arr[i] = r.Next(Int32.MinValue, Int32.MaxValue);
    if (arr[i] < arr[minIndex])
    {
        minIndex = i;
    }
}

Console.WriteLine(minIndex);
*/

//-----------------------------------------------------------------------------

/*  №2
List<int> nums = new List<int>();

int num = Convert.ToInt32(Console.ReadLine());
int sum = 0;
int mult = 1;

while (num != 0)
{
    nums.Add(num);
    sum += num;
    mult *= num;
    num = Convert.ToInt32(Console.ReadLine());
}

int avg = sum / nums.Count;
Console.WriteLine($"Сумма всех элементов: {sum}, произведение: {mult}, среднее арифметическое: {avg}");
*/

//-----------------------------------------------------------------------------

/*  №3
List<string> str = new List<string>();

string elem = Console.ReadLine();
string longest = elem;
string shortest = elem;

while (elem != "")
{
    str.Add(elem);
    if (elem.Length > longest.Length) longest = elem;
    if (elem.Length < shortest.Length) shortest = elem;
    elem = Console.ReadLine();
}

Console.WriteLine($"Самый короткий: {shortest}, самый длинный: {longest}");
*/

//-----------------------------------------------------------------------------

/*  №4
static int[] filler(int a, int b)
{
    Random r = new Random();
    
    int arrLen = 5;
    int[] arr = new int[arrLen];
    
    for (int i = 0; i < arrLen; i++)
    {
        arr[i] = r.Next(a, b);
    }

    return arr;
}

int[] arr = filler( -10, 10);
foreach (int element in arr)
{
    Console.Write($"{element} ");   
}
*/

//-----------------------------------------------------------------------------

/*  №5
string s = Console.ReadLine();
int wordsAmount = 1;

Console.WriteLine($"s = \"{s}\"");

foreach (char c in s)
{
    if (c == ' ') wordsAmount++;
}

Console.WriteLine($"Слов: {wordsAmount}");

s = "Start "+s+" End";
wordsAmount += 2;
Console.WriteLine($"s = \"{s}\"");
Console.WriteLine($"Слов: {wordsAmount}");
*/