/*
Задание:

Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. 
Дополнительно к работоспособности оценим:
-Юнит-тесты
-Легкость добавления других фигур
-Вычисление площади фигуры без знания типа фигуры в compile-time
-Проверку на то, является ли треугольник прямоугольным
*/


namespace MindBoxLib
{
    public abstract class Figure //абстрактынй класс фигур от которого будут наследоваться остальные
    {
        public double square;//площадь фигуры
        public double perimeter;//периметр фигуры

        public double Square
        {
            set { square = value; }
            get { return square; }
        }

        public double Perimeter
        {
            set { perimeter = value; }
            get { return perimeter; }
        }

        public abstract void computeSquare();//функция рассчета площади фигуры
        public abstract void computePerimeter();//функция рассчета периметра фигуры
        public abstract void printParams();//функция вывода на печать параметров фигуры

    }

    public class Circle : Figure
    {
        public double radius;//переменная радиуса для окружности
        public double Radius
        {
            set { radius = value; }
            get { return radius; }
        }

        public Circle(double radius)
        {
            this.radius = radius;


            computePerimeter();
            computeSquare();
        }

        public override void computePerimeter()
        {
            Perimeter = 2 * Math.PI * Radius;//вычисление периметра окружности зная радиус и число пи
        }

        public override void computeSquare()
        {
            Square= Math.PI * Radius * Radius;//вычисление площади окружности зная радиус и число пи
        }



        public override void printParams()
        {
            Console.WriteLine($"периметр= {Perimeter}");
            Console.WriteLine($"радиус= {radius}");
            Console.WriteLine($"площадь= {Square}");
        }


    }

    public class Triangle : Figure
    {

        public enum EdgeType//тип треугольника в зависимости от его углов
        {
            острый,
            прямоугольный,
            тупой
        }

        public enum SideType//тип треугольника в зависимости от его сторон
        {
            равносторонний,
            равнобедренный,
            разносторонний
        }

        public EdgeType edgeType { get; set; }
        public SideType sideType { get; set; }

        public double edgeAB {get; set;}//угол AB треугольника(гамма)
        public double edgeBC { get; set; }//угол ВС треугольника(альфа)
        public double edgeCA { get; set; }//угол СА треугольника(бэта)

        public double sideA { get; set; }//сторона А треугольника
        public double sideB { get; set; }//сторона В треугольника
        public double sideC { get; set; }//сторона С треугольника

        public Triangle( double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;

            computePerimeter();
            computeTriangleEdges();
            computeTriangleType();
            computeSquare();
        }
        public void computeTriangleEdges()//нахождение углов треугольника зная все стороны
        {
            edgeBC = (180.0 / Math.PI)*Math.Acos((sideB * sideB + sideC * sideC - sideA * sideA) / (2 * sideC * sideB));
            edgeAB = (180.0 / Math.PI)*Math.Acos((sideB * sideB + sideA * sideA - sideC * sideC) / (2 * sideA * sideB));
            edgeCA = 180 - (edgeBC + edgeAB);
        }

        public void computeTriangleType()//определение типа треугольника зная углы и стороны
        {
            if(edgeBC==90||edgeAB==90||edgeCA==90)
            {
                edgeType=EdgeType.прямоугольный;
            }
            else if(edgeBC>90||edgeAB>90||edgeCA>90)
            {
                edgeType = EdgeType.тупой;
            }
            else if(edgeBC<90&&edgeAB<90&&edgeCA<90)
            {
                edgeType = EdgeType.острый;
            }

            else if(edgeBC==edgeAB||edgeCA==edgeAB||edgeCA==edgeBC)
            {
                sideType = SideType.равнобедренный;
            }
            else if(edgeBC==edgeAB&&edgeCA==edgeAB)
            {
                sideType = SideType.равносторонний;
            }
            else
            {
                sideType = SideType.разносторонний;
            }
        }


        public override void computePerimeter()//нахождение периметра треугольника методом сложения сторон
        {
            Perimeter = sideA + sideB + sideC;
        }

        public override void computeSquare()//вычисление площади треугольника формулой Герона(универсальная)
        { 
            Square=Math.Sqrt(0.5*Perimeter*(0.5 * Perimeter - sideA)*(0.5 * Perimeter - sideB)*(0.5 * Perimeter - sideC));
        }
        public override void printParams()//вывод параметров треугольника на печать
        {
            Console.WriteLine($"стороны A={sideA}, B={sideB} ,C={sideC}");
            Console.WriteLine($"углы AB={edgeAB}, BC={edgeBC} ,CA={edgeCA}");
            Console.WriteLine($"тип по углам: {edgeType}");
            Console.WriteLine($"тип по сторонам: {sideType}");
            Console.WriteLine($"площадь: {Square}");
        }


        

        

        

    }
}
