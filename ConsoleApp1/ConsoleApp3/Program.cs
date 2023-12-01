Console.WriteLine("uncomment code");

/*  №1 */
StreamWriter output = new StreamWriter("output.txt", true);
string[] lines = File.ReadAllLines("input.txt");
string[] luckyNums = lines[0].Split(' ');
int ticketAmount = Convert.ToInt32(lines[1]);
int winNums = 0;

for (int i = 2; i <= ticketAmount; i++)
{
    string[] nums = lines[i].Split(' ');
    
    foreach (var n in nums)
    {
        if (luckyNums.Contains(n))
        {
            winNums++;
        }
    }

    if (winNums > 2)
    {
        output.WriteLine("Lucky");
        Console.WriteLine("Lucky");
    }
    else
    {
        output.WriteLine("Unlucky");
        Console.WriteLine("Unlucky");
    }

    winNums = 0;
}
output.Close();
/**/

//-----------------------------------------------------------------------------

/*  №2
List<string> numsList = 
    File.ReadAllLines("nums.txt")[0].Split(' ').ToList();
StreamWriter writer =
    new StreamWriter("nums.txt", false);

for (int i = 0; i < numsList.Count; i++)
{
    if (Convert.ToInt32(numsList[i]) % 2 == 0)
    {
        numsList.RemoveAt(i);
        i--;
    }
}

string res = "";
foreach (var n in numsList)
{
    res += n + " ";
}

writer.Write(res);
writer.Close();
*/

//-----------------------------------------------------------------------------

/*  №3
string[] nums = File.ReadAllLines("heights.txt")[0].Split(' ');
int maxV = 0;
int V = 0;
int line1 = 0;
int line2 = 0;

foreach (var n in nums)
{
    Console.WriteLine(n);
}

for (int i = 0; i < nums.Length; i++)
{
    for (int j = 1; j < nums.Length; j++)
    {
        if (Convert.ToInt32(nums[i]) > Convert.ToInt32(nums[j]))
        {
            V = Math.Abs(i - j) * Convert.ToInt32(nums[j]);
        }
        else
        {
            V = Math.Abs(i - j) * Convert.ToInt32(nums[i]);
        }

        if (V > maxV)
        {
            maxV = V;
            line1 = i;
            line2 = j;
        }
    }
}

Console.WriteLine($"{maxV} {line1} {line2}");
*/