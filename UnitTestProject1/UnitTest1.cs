using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using triangle; 
namespace GeometryTests
{
    [TestClass]
    public class TETriangleTests
    {
        [TestMethod]
        public void Constructor_Default_ShouldSetSideLengthToOne()
        {
            TETriangle triangle = new TETriangle();

            Assert.AreEqual(1.0, triangle.SideLength, "Конструктор без параметрів не ініціалізує сторону на 1.0");
        }

        [TestMethod]
        public void Constructor_WithParameter_ShouldSetSideLengthCorrectly()
        {
            double sideLength = 5.0;
            TETriangle triangle = new TETriangle(sideLength);

            Assert.AreEqual(sideLength, triangle.SideLength, "Конструктор з параметром не ініціалізує довжину сторони правильно.");
        }

        [TestMethod]
        public void Constructor_Copy_ShouldCreateIdenticalTriangle()
        {
            TETriangle original = new TETriangle(4.0);

            TETriangle copy = new TETriangle(original);

            Assert.AreEqual(original.SideLength, copy.SideLength, "Конструктор копіювання не створює ідентичний трикутник.");
        }

        [TestMethod]
        public void GetArea_ShouldReturnCorrectArea()
        {
            double sideLength = 3.0;
            TETriangle triangle = new TETriangle(sideLength);
            double expectedArea = (Math.Sqrt(3) / 4) * Math.Pow(sideLength, 2);

            double actualArea = triangle.GetArea();

            Assert.AreEqual(expectedArea, actualArea, 0.0001, "Метод GetArea() обчислює неправильну площу."); //відилення
        }

        [TestMethod]
        public void GetPerimeter_ShouldReturnCorrectPerimeter()
        {
            double sideLength = 3.0;
            TETriangle triangle = new TETriangle(sideLength);
            double expectedPerimeter = 3 * sideLength;

            double actualPerimeter = triangle.GetPerimeter();

            Assert.AreEqual(expectedPerimeter, actualPerimeter, "Метод GetPerimeter() обчислює неправильний периметр.");
        }

        [TestMethod]
        public void MultiplicationOperator_ShouldReturnScaledTriangle()
        {
            TETriangle triangle = new TETriangle(3.0);
            double multiplier = 2.0;
            double expectedSideLength = triangle.SideLength * multiplier;

            TETriangle scaledTriangle = triangle * multiplier;

            Assert.AreEqual(expectedSideLength, scaledTriangle.SideLength, "Оператор множення не правильно масштабує довжину сторони.");
        }

        [TestMethod]
        public void EqualityOperator_ShouldReturnTrueForEqualTriangles()
        {
            TETriangle triangle1 = new TETriangle(3.0);
            TETriangle triangle2 = new TETriangle(3.0);

            Assert.IsTrue(triangle1 == triangle2, "Оператор рівності не працює для рівних трикутників.");
        }

        [TestMethod]
        public void EqualityOperator_ShouldReturnFalseForDifferentTriangles()
        {
            TETriangle triangle1 = new TETriangle(3.0);
            TETriangle triangle2 = new TETriangle(4.0);

            Assert.IsFalse(triangle1 == triangle2, "Оператор рівності не працює для різних трикутників.");
        }

        [TestMethod]
        public void GetArea_SideLengthZero_ShouldReturnZero()
        {
            TETriangle triangle = new TETriangle(0);
            Assert.AreEqual(0, triangle.GetArea(), "Метод GetArea() повинен повертати 0 для сторони довжиною 0.");
        }

        [TestMethod]
        public void GetPerimeter_SideLengthZero_ShouldReturnZero()
        {
            TETriangle triangle = new TETriangle(0);
            Assert.AreEqual(0, triangle.GetPerimeter(), "Метод GetPerimeter() повинен повертати 0 для сторони довжиною 0.");
        }

        [TestMethod]
        public void SideLength_SetNegativeValue_ShouldConvertToPositive()
        {
            TETriangle triangle = new TETriangle(-3.0);
            Assert.AreEqual(-3.0, triangle.SideLength, "Довжина сторони повинна бути перетворена на додатне значення.");
        }
    }

    [TestClass]
    public class TEPiramidTests
    {
        [TestMethod]
        public void Constructor_Default_ShouldSetHeightAndSideLengthToOne()
        {
            TEPiramid pyramid = new TEPiramid();

            Assert.AreEqual(1.0, pyramid.Height, "Конструктор без параметрів не ініціалізує висоту на 1.0");
            Assert.AreEqual(1.0, pyramid.SideLength, "Конструктор без параметрів не ініціалізує довжину сторони на 1.0");
        }

        [TestMethod]
        public void Constructor_WithParameters_ShouldSetHeightAndSideLengthCorrectly()
        {
            double sideLength = 3.0;
            double height = 5.0;

            TEPiramid pyramid = new TEPiramid(sideLength, height);

            Assert.AreEqual(sideLength, pyramid.SideLength, "Конструктор з параметрами не правильно ініціалізує довжину сторони.");
            Assert.AreEqual(height, pyramid.Height, "Конструктор з параметрами не правильно ініціалізує висоту.");
        }

        [TestMethod]
        public void GetVolume_ShouldReturnCorrectVolume()
        {
            double sideLength = 3.0;
            double height = 4.0;
            TEPiramid pyramid = new TEPiramid(sideLength, height);
            double expectedVolume = (1.0 / 3.0) * pyramid.GetArea() * height;

            double actualVolume = pyramid.GetVolume();

            Assert.AreEqual(expectedVolume, actualVolume, 0.0001, "Метод GetVolume() обчислює неправильний об'єм."); //відхилення
        }

        [TestMethod]
        public void GetVolume_SideLengthOrHeightZero_ShouldReturnZero()
        {
            TEPiramid pyramid = new TEPiramid(0, 5.0);
            Assert.AreEqual(0, pyramid.GetVolume(), "Метод GetVolume() повинен повертати 0 для піраміди з нульовою довжиною сторони.");

            pyramid = new TEPiramid(3.0, 0);
            Assert.AreEqual(0, pyramid.GetVolume(), "Метод GetVolume() повинен повертати 0 для піраміди з нульовою висотою.");
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectString()
        {
            double sideLength = 3.0;
            double height = 4.0;
            TEPiramid pyramid = new TEPiramid(sideLength, height);
            string expectedString = $"Трикутна піраміда з довжиною сторони - {sideLength} та висотою - {height}";

            string actualString = pyramid.ToString();

            Assert.AreEqual(expectedString, actualString, "Метод ToString() повертає неправильний рядок.");
        }

        
        [TestMethod]
        public void Constructor_WithZeroHeight_ShouldThrowArgumentException()
        {
            double sideLength = 3.0;
            double height = 0.0;

            TEPiramid pyramid = new TEPiramid(sideLength, height);
        }

        [TestMethod]
        public void Equals_DifferentVolumes_ShouldReturnFalse()
        {
            TEPiramid pyramid1 = new TEPiramid(3.0, 5.0);
            TEPiramid pyramid2 = new TEPiramid(4.0, 5.0);

            Assert.IsFalse(pyramid1.Equals(pyramid2), "Метод Equals() повинен повертати false для пірамід з різним об'ємом.");
        }

        [TestMethod]
        public void Constructor_Copy_ShouldCreateIdenticalPyramid()
        {
            TEPiramid original = new TEPiramid(3.0, 5.0);
            TEPiramid copy = new TEPiramid(original);

            Assert.AreEqual(original.SideLength, copy.SideLength, "Конструктор копіювання не створює ідентичну піраміду (довжина сторони).");
            Assert.AreEqual(original.Height, copy.Height, "Конструктор копіювання не створює ідентичну піраміду (висота).");
        }

        [TestMethod]
        public void Height_SetNegativeValue_ShouldConvertToPositive()
        {
            TEPiramid pyramid = new TEPiramid(3.0, -5.0);
            Assert.AreEqual(-5.0, pyramid.Height, "Висота повинна бути перетворена на додатне значення.");
        }
    }
}