using System;
using triangle;

public class TEPiramid : TETriangle
{
    public double Height { get; set; }

    // Конструктор без параметрів
    public TEPiramid() : base()
    {
        Height = 1.0;
    }

    // Конструктор з параметрами
    public TEPiramid(double sideLength, double height) : base(sideLength)
    {
        Height = height;
    }

    // Конструктор копіювання
    public TEPiramid(TEPiramid pyramid) : base(pyramid)
    {
        Height = pyramid.Height;
    }

    // Перевизначення методу ToString()
    public override string ToString()
    {
        return $"Трикутна піраміда з довжиною сторони - {SideLength} та висотою - {Height}";
    }

    // Обчислення об’єму піраміди
    public double GetVolume()
    {
        return (1.0 / 3.0) * GetArea() * Height;
    }

    // Введення даних
    public new void Input()
    {
        base.Input();
        do
        {
            Console.Write("Введіть висоту піраміди (більшу за 0): ");
            Height = double.Parse(Console.ReadLine());
            if (Height == 0)
            {
                Console.WriteLine("Висота не може бути 0. Повторіть введення.");
            }
        } while (Height == 0);

        Height = Math.Abs(Height);  // Переконуємося, що висота додатна
    }

    // Виведення даних
    public new void Output()
    {
        Console.WriteLine(ToString());
    }
}