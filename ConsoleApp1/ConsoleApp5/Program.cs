// ReSharper disable CommentTypo
Console.WriteLine("uncomment code");

/*  №1
string[] nums = File.ReadAllLines("numsTask1.txt")[0].Split(' ');
int minIndex = 0;

for (int i = 0; i < nums.Length; i++)
{
    if (Convert.ToInt32(nums[i]) < Convert.ToInt32(nums[minIndex]))
    {
        minIndex = i;
    }
}

int mult = 1;
for (int i = minIndex+1; i < nums.Length; i++)
{
    mult *= Convert.ToInt32(nums[i]);
}

Console.WriteLine(mult);
*/

//-----------------------------------------------------------------------------

/*  №2
string[] sNums = File.ReadAllLines("numsTask2.txt")[0].Split(';');
double[] nums = new double[sNums.Length];

for (int i = 0; i < sNums.Length; i++)
{
    nums[i] = Convert.ToDouble(sNums[i]);
}

for (int i = 0; i < nums.Length; i++)
{
    for (int j = 0; j < nums.Length-1; j++)
    {
        if (nums[j] > nums[j + 1])
        {
            (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
        }
    }
}

StreamWriter writer = new StreamWriter("numsTask2.txt", false);

string res = "";
foreach (var n in nums)
{
    res += $"{n};";
}
res = res.Remove(res.Length-1, 1);

writer.Write(res);
writer.Close();
*/

//-----------------------------------------------------------------------------

/*  №3
string[] nums = File.ReadAllLines("numsTask3.txt")[0].Split(' ');
int minIndex = 0;

for (int i = 0; i < nums.Length; i++)
{
    if (Convert.ToInt32(nums[i]) < Convert.ToInt32(nums[minIndex]))
    {
        minIndex = i;
    }
}

int sum = 0;
for (int i = 0; i < minIndex; i++)
{
    sum += Convert.ToInt32(nums[i]);
}

Console.WriteLine((double)sum/(double)minIndex);
*/

//-----------------------------------------------------------------------------

/*  №4
string[] nums = File.ReadAllLines("numsTask4.txt")[0].Split(' ');
int max = -100;

foreach (var n in nums)
{
    if (Convert.ToInt32(n) > max)
    {
        max = Convert.ToInt32(n);
    }
}

int sum = 0;
for (int i = 0; i < nums.Length; i++)
{
    if (Convert.ToInt32(nums[i])+1 == max)
    {
        sum += Convert.ToInt32(nums[i]);
    }
}

Console.WriteLine(sum);
*/

//-----------------------------------------------------------------------------

/*  №5
string[] nums = File.ReadAllLines("numsTask5.txt")[0].Split(' ');
int minIndex = 0;
int maxIndex = 0;

for (int i = 0; i < nums.Length; i++)
{
    if (Convert.ToInt32(nums[i]) < Convert.ToInt32(nums[minIndex]))
    {
        minIndex = i;
    }
    if (Convert.ToInt32(nums[i]) > Convert.ToInt32(nums[maxIndex]))
    {
        maxIndex = i;
    }
}

int sum = 0;
int elemNum = 0;
if (minIndex < maxIndex)
{
    for (int i = minIndex + 1; i < maxIndex; i++)
    {
        sum += Convert.ToInt32(nums[i]);
        elemNum++;
    }
}
else
{
    for (int i = maxIndex + 1; i < minIndex; i++)
    {
        sum += Convert.ToInt32(nums[i]);
        elemNum++;
    }
}

Console.WriteLine($"{(double)sum/(double)elemNum}");
*/