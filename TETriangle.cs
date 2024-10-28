using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangle
{
    public class TETriangle
    {
        public double SideLength { get; set; }

        // Конструктор без параметрів
        public TETriangle()
        {
            SideLength = 1.0;
        }

        // Конструктор з параметрами
        public TETriangle(double sideLength)
        {
            SideLength = sideLength;
        }

        // Конструктор копіювання
        public TETriangle(TETriangle triangle)
        {
            SideLength = triangle.SideLength;
        }

        // Перевизначення методу ToString()
        public override string ToString()
        {
            return $"Рівносторонній трикутник з довжиною сторони: {SideLength}";
        }

        // Метод для введення даних
        public void Input()
        {
            Console.Write("Введіть довжину сторони трикутника: ");
            SideLength = double.Parse(Console.ReadLine());
        }

        // Метод для виведення даних
        public void Output()
        {
            Console.WriteLine(ToString());
        }

        // Обчислення площі трикутника
        public double GetArea()
        {
            return (Math.Sqrt(3) / 4) * Math.Pow(SideLength, 2);
        }

        // Обчислення периметру трикутника
        public double GetPerimeter()
        {
            return 3 * SideLength;
        }

        // Перевантаження операторів для порівняння
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is TETriangle))
            {
                return false;
            }
            TETriangle other = (TETriangle)obj;
            return SideLength == other.SideLength;
        }

        public static bool operator ==(TETriangle t1, TETriangle t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(TETriangle t1, TETriangle t2)
        {
            return !t1.Equals(t2);
        }

        // Перевантаження оператора * для множення сторін на число
        public static TETriangle operator *(TETriangle triangle, double multiplier)
        {
            return new TETriangle(triangle.SideLength * multiplier);
        }

        // Перевантаження оператора * для випадку "число * трикутник"
        public static TETriangle operator *(double multiplier, TETriangle triangle)
        {
            return triangle * multiplier;
        }
    }
}