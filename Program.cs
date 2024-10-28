using System;
using System.Text;
namespace triangle 
{
    class Program
    {
        static void Main()
        {   Console.OutputEncoding=Encoding.UTF8;
            Console.WriteLine("Введення даних для рівностороннього трикутника...\n");
            TETriangle triangle = new TETriangle();
            triangle.Input();  // Виклик методу для введення даних
            Console.WriteLine(triangle.ToString());
            Console.WriteLine($"Площа трикутника: {triangle.GetArea()}");
            Console.WriteLine($"Периметр трикутника: {triangle.GetPerimeter()}");

            //множення сторін на число
            Console.Write("\nВведіть число для множення сторони трикутника: ");
            double multiplier = double.Parse(Console.ReadLine());
            TETriangle largerTriangle = triangle * multiplier;
            Console.WriteLine($"Збільшений трикутник - {largerTriangle.ToString()}");
            Console.WriteLine("Порівняння трикутників:");

            if (triangle.Equals(largerTriangle))
            {
                Console.WriteLine("Трикутники мають однакову площу.");
            }
            else
            {
                Console.WriteLine("Трикутники мають різну площу.");
            }

            //класу-нащадка TEPiramid
            Console.WriteLine("\nВведіть дані для правильної трикутної піраміди:");
            TEPiramid pyramid = new TEPiramid();
            pyramid.Input();  // Виклик методу для введення даних
            Console.WriteLine(pyramid.ToString());
            Console.WriteLine($"Об'єм піраміди: {pyramid.GetVolume()}");
        }
    }
}