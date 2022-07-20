using MindBoxLib;

class Program
{
 static Circle circle = new Circle(3);

    static Triangle triangle = new Triangle(7,2,8);
    static void Main(string[] args)
    {
        //Console.WriteLine("Площать круга :" + circle.square);
        triangle.printEdgesAndSides();
    }
}