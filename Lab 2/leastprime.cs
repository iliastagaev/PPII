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
            
            long min = 1100000000;
            for(int i = 0; i < a.Length; i++)
            {
                bool k = true;
                int test = int.Parse(a[i]);
                for (int j = 2; j * j <= test; j++)
                {
                    if (test % j == 0)
                    {
                        k = false;
                        break;
                    }
                }
                if(k && test != 1)
                {
                    if(test < min)
                    {
                        min = test;
                    }
                }
            }
            
            Console.WriteLine(min);
            Console.ReadKey();
        }
    }
}