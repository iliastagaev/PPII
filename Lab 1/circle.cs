using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Circle
    {
        public double radius;
        public static float M_PI = 3.14f;
        public Circle()
        {
            radius = 0d;
        }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public static double FindArea(double radius)
        {
            return M_PI * radius * radius;
        }
        public static double FindDiameter(double radius)
        {
            return 2 * radius;
        }
        public static double FindCircuimference(double radius)
        {
            return 2 * M_PI * radius;
        }


    }
    class Program
    {
   
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            Circle a = new Circle(radius);
            Console.WriteLine(Circle.FindArea(a.radius) + " m^2");
            Console.WriteLine(Circle.FindDiameter(a.radius) + " m");
            Console.WriteLine(Circle.FindCircuimference(a.radius) + " m");
            Console.ReadKey();
        }
    }
}