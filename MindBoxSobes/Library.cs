namespace MindBoxLib
{
    public abstract class Figure
    {
        public double square;
        public double perimeter;

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

        public abstract void computeSquare();
        public abstract void computePerimeter();
        public abstract void printParams();

    }

    public class Circle : Figure
    {
        public double radius;
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
            Perimeter = 2 * Math.PI * Radius;
        }

        public override void computeSquare()
        {
            Square= Math.PI * Radius * Radius;
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

        /*public enum TriangleType
        {
            равносторонний,
            равнобедренный,
            острый,
            прямоугольный,
            тупой,
            неравносторонний
        }*/

        public enum EdgeType
        {
            острый,
            прямоугольный,
            тупой
        }

        public enum SideType
        {
            равносторонний,
            равнобедренный,
            разносторонний
        }

        //public TriangleType triType { get; set; }

        public EdgeType edgeType { get; set; }
        public SideType sideType { get; set; }

        public double edgeAB {get; set;}
        public double edgeBC { get; set; }
        public double edgeCA { get; set; }

        public double sideA { get; set; }
        public double sideB { get; set; }
        public double sideC { get; set; }

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
        public void computeTriangleEdges()
        {
            edgeBC = (180.0 / Math.PI)*Math.Acos((sideB * sideB + sideC * sideC - sideA * sideA) / (2 * sideC * sideB));
            edgeAB = (180.0 / Math.PI)*Math.Acos((sideB * sideB + sideA * sideA - sideC * sideC) / (2 * sideA * sideB));
            edgeCA = 180 - (edgeBC + edgeAB);
        }

        public void computeTriangleType()
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


        public override void computePerimeter()
        {
            Perimeter = sideA + sideB + sideC;
        }

        public override void computeSquare()
        { 
            Square=Math.Sqrt(0.5*Perimeter*(0.5 * Perimeter - sideA)*(0.5 * Perimeter - sideB)*(0.5 * Perimeter - sideC));
        }
        public override void printParams()
        {
            Console.WriteLine($"стороны A={sideA}, B={sideB} ,C={sideC}");
            Console.WriteLine($"углы AB={edgeAB}, BC={edgeBC} ,CA={edgeCA}");
            Console.WriteLine($"тип по углам: {edgeType}");
            Console.WriteLine($"тип по сторонам: {sideType}");
            Console.WriteLine($"площадь: {Square}");
        }


        

        

        

    }
}