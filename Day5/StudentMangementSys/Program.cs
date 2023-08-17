using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;



public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int RollNumber { get; }
    public string Grade { get; set; }

    public Student(string name, int age, int rollNumber, string grade)
    {
        Name = name;
        Age = age;
        RollNumber = rollNumber;
        Grade = grade;
    }
}


public class StudentList<T>
{
    private List<T> students;

    public StudentList()
    {
        students = new List<T>();
    }

    public void Add(T student)
    {
        students.Add(student);
    }

    public List<T> SearchByName(string name)
    {
        return students.Where(s => ((Student)(object)s).Name.Contains(name)).ToList();
    }

    public List<T> SearchByRollNumber(int rollNumber)
    {
        return students.Where(s => ((Student)(object)s).RollNumber == rollNumber).ToList();
    }

    public List<T> GetAllStudents()
    {
        return students;
    }

    public void SaveToFile(string fileName)
    {
        string json = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(fileName, json);
    }

    public void LoadFromFile(string fileName)
    {
        string json = File.ReadAllText(fileName);
        students = JsonConvert.DeserializeObject<List<T>>(json);
    }
}



class Program
{
    static void Main(string[] args)
    {
        StudentList<Student> studentList = new StudentList<Student>();

        while (true)
        {
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Search for a student by name");
            Console.WriteLine("3. Search for a student by ID");
            Console.WriteLine("4. Display all students");
            Console.WriteLine("5. Save student data to file");
            Console.WriteLine("6. Load student data from file");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent(studentList);
                    break;
                case "2":
                    SearchByName(studentList);
                    break;
                case "3":
                    SearchByRollNumber(studentList);
                    break;
                case "4":
                    DisplayAllStudents(studentList);
                    break;
                case "5":
                    SaveToFile(studentList);
                    break;
                case "6":
                    LoadFromFile(studentList);
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddStudent(StudentList<Student> studentList)
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter student age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter student roll number: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter student grade: ");
        string grade = Console.ReadLine();

        Student student = new Student(name, age, rollNumber, grade);
        studentList.Add(student);

        Console.WriteLine("Student added successfully.");
    }

    static void SearchByName(StudentList<Student> studentList)
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        List<Student> result = studentList.SearchByName(name);

        Console.WriteLine("Search Results:");
        foreach (Student student in result)
        {
            Console.WriteLine("Name: {0}, Age: {1}, Roll Number: {2}, Grade: {3}", student.Name, student.Age, student.RollNumber, student.Grade);
        }
    }

    static void SearchByRollNumber(StudentList<Student> studentList)
    {
        Console.Write("Enter student roll number: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        List<Student> result = studentList.SearchByRollNumber(rollNumber);

        Console.WriteLine("Search Results:");
        foreach (Student student in result)
        {
            Console.WriteLine("Name: {0}, Age: {1}, Roll Number: {2}, Grade: {3}", student.Name, student.Age, student.RollNumber, student.Grade);
        }
    }

    static void DisplayAllStudents(StudentList<Student> studentList)
    {
        List<Student> students = studentList.GetAllStudents();

        Console.WriteLine("All Students:");
        foreach (Student student in students)
        {
            Console.WriteLine("Name: {0}, Age: {1}, Roll Number: {2}, Grade: {3}", student.Name, student.Age, student.RollNumber, student.Grade);
        }
    }

    static void SaveToFile(StudentList<Student> studentList)
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();

        studentList.SaveToFile(fileName);

        Console.WriteLine("Student data saved to file successfully.");
    }

    static void LoadFromFile(StudentList<Student> studentList)
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();

        studentList.LoadFromFile(fileName);

        Console.WriteLine("Student data loaded from file successfully.");
    }
}
