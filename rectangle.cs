using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Rectangle
    {
        public double height, width;
        public Rectangle()
        {
            height = 0;
            width = 0;
        }
        public Rectangle(double a, double b)
        {
            height = a;
            width = b;
        }
        public static double FindArea(double a, double b)
        {
            return a * b;
        }
        public static double FindPerimeter(double a, double b)
        {
            return 2 * (a + b);
        }
        public static double FindDiagonal(double a, double b)
            {
            return Math.Sqrt(a * a + b * b);
            }
    }
    class Program
    {
   
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            Rectangle a = new Rectangle(height, width);
            Console.WriteLine(Rectangle.FindArea(height, width) + " m^2");
            Console.WriteLine(Rectangle.FindPerimeter(height, width) + " m");
            Console.WriteLine(Rectangle.FindDiagonal(height, width) + " m");
            Console.ReadKey();
        }
    }
}
