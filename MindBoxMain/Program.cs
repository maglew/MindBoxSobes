using MindBoxLib;

class Program
{
 
    static Circle circle = new Circle(3);
    static Triangle triangle = new Triangle(21,29,20);
    static void Main(string[] args)
    {
        //Console.WriteLine("Площать круга :" + circle.square);
        circle.printParams();
        triangle.printParams();


    }

}