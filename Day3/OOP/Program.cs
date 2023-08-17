public class Shape
{
    public string Name { get; set; } = "";
    public virtual double CalculateArea()
    {
        return 0;
    }

    public void PrintShapeArea()
    {
        double area = CalculateArea();
        Console.WriteLine("Shape: " + Name);
        Console.WriteLine("Area: " + area);
    }
}
public class Circle : Shape
{
    public double Radius { get; set;}

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set;}
    public double Height { get; set;}

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle :Shape
{
    public double Base { get; set;}
    public double Height { get; set;}

    public override double CalculateArea()
    {
        return (Base * Height) / 2; 
    }   
}
public class Prgram
{
    public static void Main()
    {
        Console.WriteLine("Hello and Wellcome to area Caluculator: ");
        Console.WriteLine("***************************");
        Console.WriteLine("Please Choose between Circle, Rectangle, Triangle");
        
        string? name = Console.ReadLine();

        switch (name?.ToLower())
        {
            case "circle":
                Console.WriteLine("Please Enter Radius: ");
                double radius = Convert.ToDouble(Console.ReadLine());

                Circle circle = new Circle();
                circle.Name = "Circle";
                circle.Radius = radius;
                circle.PrintShapeArea();
                break;
            
            case "rectangle":
                Console.WriteLine("Please Enter Width: ");
                double width = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please Enter Length: ");
                double length = Convert.ToDouble(Console.ReadLine());

                Rectangle rectangle = new Rectangle();
                rectangle.Name = "Rectangle";
                rectangle.Width = width;
                rectangle.Height = length;
                rectangle.PrintShapeArea();
                break;

            case "triangle":
                Console.WriteLine("Please Enter Base: ");
                double triBase = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please Enter Height: ");
                double height = Convert.ToDouble(Console.ReadLine());

                Triangle triangle = new Triangle();
                triangle.Name = "Triangle";
                triangle.Base = triBase;
                triangle.Height = height;
                triangle.PrintShapeArea();
                break;

            default:
                Console.WriteLine("Invalid shape entered.");
                break;
        } 
        
    }
}
