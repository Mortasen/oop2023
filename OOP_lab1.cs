using System;


public class TCircle
{
    protected double radius;

    public TCircle()
    {
        radius = 0;
    }

    public TCircle(double radius)
    {
        this.radius = radius;
    }

    public TCircle(TCircle other)
    {
        radius = other.radius;
    }

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public void InputRadius()
    {
        Console.Write("Введіть радіус: ");
        radius = Convert.ToDouble(Console.ReadLine());
    }

    public void OutputRadius()
    {
        Console.WriteLine("Радіус: " + radius);
    }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public double CalculateSectorArea(double angle)
    {
        return (angle / 360) * CalculateArea();
    }

    public double CalculateCircumference()
    {
        return 2 * Math.PI * radius;
    }

    public bool Equals(TCircle other)
    {
        return radius == other.radius;
    }

    public static TCircle operator +(TCircle c1, TCircle c2)
    {
        double newRadius = c1.radius + c2.radius;
        return new TCircle(newRadius);
    }

    public static TCircle operator -(TCircle c1, TCircle c2)
    {
        double newRadius = c1.radius - c2.radius;
        return new TCircle(newRadius);
    }

    public static TCircle operator *(TCircle TCircle, double factor)
    {
        double newRadius = TCircle.radius * factor;
        return new TCircle(newRadius);
    }
}

public class TSphere : TCircle
{
    public TSphere() : base() {}

    public TSphere(double radius) : base(radius) {}

    public TSphere(TSphere other) : base(other) {}

    public double CalculateSurfaceArea()
    {
        return 4 * Math.PI * radius * radius;
    }
}




public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Лабораторна робота №1, Дронь Олександр.");

        while (true)
        {
            Console.WriteLine("\nОберіть варіант:");
            Console.WriteLine("1. Створити Коло");
            Console.WriteLine("2. Створити Сферу");
            Console.WriteLine("3. Вийти");

            Console.Write("> ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nСтворюємо Коло:");
                    TCircle circle = new TCircle();
                    circle.InputRadius();
                    ProcessCircle(circle);
                    break;
                case 2:
                    Console.WriteLine("\nСтворюємо Сферу:");
                    TSphere sphere = new TSphere();
                    sphere.InputRadius();
                    ProcessSphere(sphere);
                    break;
                case 3:
                    Console.WriteLine("\nВихід з програми.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
    
    private static TCircle CreateCircle()
    {
        TCircle circle = new TCircle();
        circle.InputRadius();

        return circle;
    }

    private static TSphere CreateSphere()
    {
        TSphere sphere = new TSphere();
        sphere.InputRadius();
        
        return sphere;
    }

    private static void ProcessCircle(TCircle circle)
    {
        while (true)
        {
            Console.WriteLine("\nМеню роботи з колом:");
            Console.WriteLine("1. Вивести Коло");
            Console.WriteLine("2. Обчислити і відобразити площу Кола");
            Console.WriteLine("3. Обчислити і відобразити довжину Кола");
            Console.WriteLine("4. Порівняти з іншим Колом");
            Console.WriteLine("5. Додати радіус іншого Кола");
            Console.WriteLine("6. Відняти радіус іншого Кола");
            Console.WriteLine("7. Помножити радіус на число");
            Console.WriteLine("8. Назад");

            Console.Write("Введіть ваш вибір: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    circle.OutputRadius();
                    break;
                case 2:
                    double area = circle.CalculateArea();
                    Console.WriteLine("Площа Кола: " + area);
                    break;
                case 3:
                    double circumference = circle.CalculateCircumference();
                    Console.WriteLine("Довжина Кола: " + circumference);
                    break;
                case 4:
                    TCircle comparisonTCircle = CreateCircle();
                    bool equal = circle.Equals(comparisonTCircle);
                    Console.WriteLine("Кола рівні: " + equal);
                    break;
                case 5:
                    TCircle addTCircle = CreateCircle();
                    TCircle sum = circle + addTCircle;
                    Console.WriteLine("Сума радіусів: " + sum.Radius);
                    break;
                case 6:
                    TCircle subtractTCircle = CreateCircle();
                    TCircle difference = circle - subtractTCircle;
                    Console.WriteLine("Різниця радіусів: " + difference.Radius);
                    break;
                case 7:
                    Console.Write("Введіть множник: ");
                    double factor = Convert.ToDouble(Console.ReadLine());
                    TCircle multiplied = circle * factor;
                    Console.WriteLine("Помножений радіус: " + multiplied.Radius);
                    break;
                case 8:
                    return;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    private static void ProcessSphere(TSphere sphere)
    {
        while (true)
        {
            Console.WriteLine("\nМеню роботи зі сферою:");
            Console.WriteLine("1. Відобразити деталі Сфери");
            Console.WriteLine("2. Обчислити і відобразити площу поверхні Сфери");
            Console.WriteLine("3. Обчислити і відобразити площу основи Кола");
            Console.WriteLine("4. Назад");

            Console.Write("Введіть ваш вибір: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    sphere.OutputRadius();
                    break;
                case 2:
                    double surfaceArea = sphere.CalculateSurfaceArea();
                    Console.WriteLine("Площа поверхні Сфери: " + surfaceArea);
                    break;
                case 3:
                    double area = sphere.CalculateArea();
                    Console.WriteLine("Площа основи Кола: " + area);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}

