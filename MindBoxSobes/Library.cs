namespace MindBoxLib
{
    public abstract class Figure
    {
        public double square;
        public double Square
        {
            set { square = value; }
            get { return square; }
        }

        public abstract void computeSquare();
        
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
            computeSquare();
        }

        public override void computeSquare()
        {
            Square= Math.PI * Radius * Radius;
        }


    }

    public class Triangle : Figure
    {

        enum TriangleType
        {
            равносторонний,
            равнобедренный,
            острый,
            прямоугольный,
            тупой,
            неравносторонний
        }

        TriangleType triType;

        double edgeAB;
        double edgeBC;
        double edgeCA;

        double sideA;
        double sideB;
        double sideC;

        public Triangle( double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
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

        public void printTriangle()
        {
            Console.WriteLine($"стороны A={sideA}, B={sideB} ,C={sideC}");
            Console.WriteLine($"углы AB={edgeAB}, BC={edgeBC} ,CA={edgeCA}");
            Console.WriteLine($"тип: {triType}");
            Console.WriteLine($"площадь: {Square}");
        }


        public void computeTriangleType()
        {
            if(edgeBC==90||edgeAB==90||edgeCA==90)
            {
                triType=TriangleType.прямоугольный;
            }
             else if(edgeBC==edgeAB||edgeCA==edgeAB||edgeCA==edgeBC)
            {
                triType=TriangleType.равнобедренный;
            }
            else if(edgeBC==edgeAB&&edgeCA==edgeAB)
            {
                triType=TriangleType.равносторонний;
            }
            else if(edgeBC>90||edgeAB>90||edgeCA>90)
            {
                triType=TriangleType.тупой;
            }
            else if(edgeBC<90&&edgeAB<90&&edgeCA<90)
            {
                triType=TriangleType.острый;
            }
            else
            {
                triType=TriangleType.неравносторонний;
            }
        }

        public override void computeSquare()
        {
                double poluper=0.5*(sideA+sideB+sideC);
                Square=Math.Sqrt(poluper*(poluper-sideA)*(poluper-sideB)*(poluper-sideC));
        }

        

    }
}