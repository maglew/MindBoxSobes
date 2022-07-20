using MindBoxLib;
//using MindBoxMain;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        Circle circle1 = new Circle(3);//периметр: 18.84956 площадь:  28.2743
        Circle circle2 = new Circle(1.5);//периметр: 9.42478 площадь: 7.0686
        Circle circle3 = new Circle(6);//периметр: 37.69911 площадь: 113.0973

        Triangle triangle1 = new Triangle(21, 29, 20);//периметр: 70 углы: 43.6|46.4|90 площадь: 210 тип: прямоугольный
        Triangle triangle2 = new Triangle(5, 5, 8);//периметр: 18 углы: 106.26|36.87|36.87 площадь: 12 тип: равнобедренный
        Triangle triangle3 = new Triangle(4, 9, 6);//периметр: 19 углы: 32.09|20.74|127.17  площадь: 9.56 тип: разносторонний

        [TestMethod]
        public void TestMethod1()
        {
            circleleTest(circle1, 18.84956, 28.2743);
            circleleTest(circle2, 9.42478, 7.0686);
            circleleTest(circle3, 37.69911, 113.0973);
            triangleTest(triangle1, 70, 210, 43.6, 46.4, 90, Triangle.EdgeType.прямоугольный);
            triangleTest(triangle2, 18, 12, 106.26, 36.87, 36.87, Triangle.EdgeType.тупой);
            triangleTest(triangle3, 19, 9.56, 32.09, 20.74, 127.17, Triangle.EdgeType.тупой);

        }


        public void circleleTest(Circle circle, double exper,double exsquare)//функция для тестирования окружностей и вывода ожидаемых и полученных значений
        {
            Assert.AreEqual(exper, circle.Perimeter, 0.001, "Perimeter not correct");
            Assert.AreEqual(exsquare, circle.Square, 0.001, "Square not correct");
            Console.WriteLine($"тест окружности--------------------------------");
            Console.WriteLine($"ожидаемые значения: периметр={exper} площадь={exsquare}");
            Console.WriteLine($"полученные значения: периметр={circle.Perimeter} площадь={circle.Square}");
        }

        public void triangleTest(Triangle triangle, double exper, double exsquare, double exedgeAB, double exedgeBC, double exedgeCA, Enum extype)//функция для тестирования треугольников и вывода ожидаемых и полученных значений
        {
            Assert.AreEqual(exper, triangle.Perimeter, 0.1, "Perimeter not correct");
            Assert.AreEqual(exsquare, triangle.Square, 0.1, "Square not correct");
            Assert.AreEqual(exedgeAB, triangle.edgeAB, 0.1, "edgeAB not correct");
            Assert.AreEqual(exedgeBC, triangle.edgeBC, 0.1, "edgeBC not correct");
            Assert.AreEqual(exedgeCA, triangle.edgeCA, 0.1, "edgeCA not correct");
            Assert.AreEqual(extype, triangle.edgeType, "triType not correct");

            Console.WriteLine($"тест треугольника--------------------------------");
            Console.WriteLine($"ожидаемые значения: периметр={exper} площадь={exsquare} exedgeAB={exedgeAB} exedgeBC={exedgeBC} exedgeCD={exedgeCA} extype={extype}");
            Console.WriteLine($"полученные значения: периметр={triangle.Perimeter} площадь={triangle.Square} edgeAB={triangle.edgeAB} edgeBC={triangle.edgeBC} edgeCD={triangle.edgeCA} type={triangle.edgeType}");


        }



    }
}