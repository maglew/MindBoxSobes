using MindBoxLib;

class Program
{
 static Circle circle = new Circle(3);

    static Triangle triangle = new Triangle(21,29,20);
    static void Main(string[] args)
    {
        //Console.WriteLine("Площать круга :" + circle.square);
        triangle.printTriangle();
        

    }

/*
    static void writesin(double grad)
    {
        double sin=Math.Sin(grad);
        double arcrad=Math.Asin(sin);
        double arcgrad=RadianToDegree(arcrad);
        Console.WriteLine($"grad: {grad} , otn: {sin} ,arcRad: {arcrad} ,arcGrad: {arcgrad}" );
    }

     static double DegreeToRadian(double angle)
    {
        return Math.PI * angle / 180.0;
    }

     static double RadianToDegree(double angle)
    {
        return angle * (180.0 / Math.PI);
    }*/
}