public class Task 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Categories Category { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string name, Categories category, bool isCompleted)
    {
        Name = name;
        Category = category;
        IsCompleted = isCompleted;
    }

    public override string ToString()
    {
        return $" \n Task Name: {Name}\nCategory: {Category}\nIs Completed: {IsCompleted} \n";
    }
}

public enum Categories
{
    Personal,
    Work,
    Errends,
    School
}

public class Program
{
    private static List<Task> taskList = new List<Task>();

    public static Categories TaskCatagory { get; private set; }

    public static void Main()
    {
        Console.WriteLine("Welcome to Your Task Manager :)");
        
        while (true)
        {
            Console.WriteLine("Please Enter a Task You want to add (or enter 'exit' to finish)");
            string taskName = Console.ReadLine();

            if (taskName.ToLower() == "exit")
            {
                break;
            }

            Console.WriteLine("Please Enter the Category (Personal, Work, Errends, School)");
            string categoryInput = Console.ReadLine();
            Categories category;
            Enum.TryParse(categoryInput, out category);

            Console.WriteLine("Please Enter the Completion Status (true/false)");
            string completionStatusInput = Console.ReadLine();
            bool completionStatus;
            bool.TryParse(completionStatusInput, out completionStatus);

            var task = new Task(taskName, category, completionStatus);
            taskList.Add(task);
        }

        Console.WriteLine("Task List:");
        foreach (var task in taskList)
        {
            Console.WriteLine(task);
        }

        Console.WriteLine("Select a category to view tasks (Personal, Work, Errends, School)");
        string selectedCategoryInput = Console.ReadLine();
        Categories selectedCategory;
        Enum.TryParse(selectedCategoryInput, out selectedCategory);

        var selectedTasks = taskList.Where(task => task.Category == selectedCategory);
        Console.WriteLine($"Tasks in the {selectedCategory} category:");
        foreach (var task in selectedTasks)
        {
            Console.WriteLine(task);
        }
    }
}
