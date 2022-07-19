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
            Equilateral,
            Isosceles,
            Scalene,
            Right,
            Obtuse,
            Acute
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
            //computeTriangleType();
            //computeSquare();
        }
        public void computeTriangleEdges()
        {
            edgeBC = Math.Acos((sideB * sideB + sideC * sideC - sideA * sideA) / (2 * sideC * sideB));
            edgeAB = Math.Acos((sideB * sideB + sideA * sideA - sideC * sideC) / (2 * sideA * sideB));
            edgeCA = 180 - (edgeBC+ edgeAB);
        }

        public void printEdgesAndSides()
        {
            Console.WriteLine($"углы AB={edgeAB}, BC={edgeBC} ,CA={edgeCA}", edgeAB, edgeBC, edgeCA);
        }


        public void computeTriangleType()
        {
        
        }

        public override void computeSquare()
        {
            // Square = Math.PI * Radius * Radius;
            switch (triType)
            {
                case TriangleType.Equilateral:
                    
                break;

                case TriangleType.Isosceles:

                break;

                case TriangleType.Scalene:

                break;

                case TriangleType.Right:

                break;

                case TriangleType.Obtuse:

                break;

                case TriangleType.Acute:

                break;

                default:
                    Console.WriteLine("что то не так");
                break;
            }
        }

        

    }
}