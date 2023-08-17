Console.WriteLine("Please Enter Your name: ");
string StudentName = Console.ReadLine();

Console.WriteLine("Please Enter the Number of Grades: ");
string inputNumberofGrade = Console.ReadLine();
int NumberofGrade = 0;
if (!int.TryParse(inputNumberofGrade, out NumberofGrade))
{
    Console.WriteLine("Invalid input for the number of grades.");
    return;
}

Dictionary<string, int> Grade = new Dictionary<string, int>();
int starting = 0;

while (starting < NumberofGrade)
{
    Console.WriteLine("Enter Name of your grade and its grade separated by a space: ");
    string input = Console.ReadLine();
    string[] parts = input.Split(' ');
    string strValue = parts[0];
    int intValue = int.Parse(parts[1]);

    if (intValue >= 0 && intValue <= 100)
    {
      Grade.Add(strValue, intValue);
    }
    else{
      Console.WriteLine("Please make sure your grade is in the range of 0 and 100!!!");
    }

    starting++;
}

double CalculateAvg(Dictionary<string, int> Grade)
{
    int sum = 0;
    int count = 0;
    foreach (var grade in Grade.Values)
    {
        sum += grade;
        count++;
    }

    if (count > 0)
    {
        return (double)sum / count;
    }
    else
    {
        return 0;
    }
}

double Average = 0; // Variable to store calculated average

Average = CalculateAvg(Grade);

Console.WriteLine("*********************************");
Console.WriteLine("Students Name: " + StudentName);
foreach (KeyValuePair<string, int> kvp in Grade)
{
    string key = kvp.Key;
    int value = kvp.Value;
    Console.WriteLine("Subject: " + key + ", grade: " + value);
}

Console.WriteLine($"Dear {StudentName}, your Average is: " + Average);

