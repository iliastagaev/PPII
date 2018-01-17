using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(Console.ReadLine());
            string[] a = text.Split(new Char[] { ' ', '\n' });
            long max = -1100000000;
            long min = 1100000000;
            for (int i = 0; i < a.Length; i++)
            {

                if (int.Parse(a[i]) > max)
                {
                    max = int.Parse(a[i]);
                }
                if (int.Parse(a[i]) < min)
                {
                    min = int.Parse(a[i]);
                }
            }
            
            Console.WriteLine(max + " " + min);
            Console.ReadKey();
        }
    }
}