using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = Console.ReadLine();
            StreamReader sr = new StreamReader(s);
            string h = sr.ReadToEnd();
            string[] a = h.Split(new Char[] { ' ', '\n' });
          
            
            int min = 1000000;
            int max = 0;
            for (int i = 0; i < a.Length; i++)
            {
                bool t = true;
                int test = int.Parse(a[i]);
                for (int j = 2; j * j <= test; j++)
                {
                    if (test % j == 0)
                    {
                        t = false;
                        break;
                    }
                }
                if (t && test != 1 && test > 0)
                {
                    min = Math.Min(min, test);
                    max = Math.Max(max, test);
                }
            }
            StreamWriter wr = new StreamWriter(@"C:\Users\админ\Desktop\1.txt");
            wr.WriteLine(max);
            wr.WriteLine(min);
            sr.Close();
            wr.Close();
            Console.ReadKey();
        }
    }
}
