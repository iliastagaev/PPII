using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    class Complex
    {
        public int z, l;
        public Complex(int x, int y)
        {
            z = x;
            l = y;

        }
        public static int Great(int a, int b)
        {
            if (b != 0)
            {
                return Great(b, a % b);
            }
            else
            {
                return a;
            }
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            int divisor = (c1.l * c2.l) / Great(Math.Max(c1.l, c2.l), Math.Min(c1.l, c2.l));
            int top = ((divisor / c1.l) * c1.z) - ((divisor / c2.l) * c2.z);
            Complex c = new Complex(top, divisor);
            c.Simplify();
            return c;
        }
        public void Simplify()
        {
            int x = z;
            z /= Great(Math.Max(l, z), Math.Min(l, z));
            l /= Great(Math.Max(l, x), Math.Min(l, x));
        }

        public override string ToString()
        {
            if ((l > 0 && z > 0) || (l < 0 && z < 0))
            {
                return Convert.ToString(z) + '/' + Convert.ToString(l);
            }
            else
            {
                return "-" + Convert.ToString(Math.Abs(z)) + '/' + Convert.ToString(Math.Abs(l));
            }

        }
    }

    class Program
    {


        static void Main(string[] args)
        {


            string s = Console.ReadLine();
            string[] token = s.Split();

            string[] s1 = token[0].Split('/');
            string[] s2 = token[1].Split('/');
            int x = int.Parse(s1[0]);
            int y = int.Parse(s1[1]);
            int o = int.Parse(s2[0]);
            int p = int.Parse(s2[1]);
            Complex a = new Complex(x, y);
            Complex b = new Complex(o, p);
            Complex c = a - b;
            Console.WriteLine(c);
            Console.ReadKey();
        }
    }
}