using MindBoxLib;

class Program
{
 static Circle circle = new Circle(3);

    static Triangle triangle = new Triangle(5,2.757,4.625);
    static void Main(string[] args)
    {
        //Console.WriteLine("Площать круга :" + circle.square);
        triangle.printEdgesAndSides();
    }
}