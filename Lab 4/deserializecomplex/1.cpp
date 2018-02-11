using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace ConsoleApp5
{

    public class Complex
    {
        public int z, l;
        public Complex() { }
        public Complex(int x, int y)
        {
            z = x;
            l = y;

        }
      
        public override string ToString()
        {
            if (l == 0)
            {
                return "0" + '\n';
            }
            else if (z == 0)
            {
                return "not divisiby by 0" + '\n';
            }
            else if (l == 1)
            {
                return Convert.ToString(z);
            }
            else if (l == z)
            {
                return "1" + '\n';
            }
            else if ((l > 0 && z > 0) || (l < 0 && z < 0))
            {
                return Convert.ToString(z) + '/' + Convert.ToString(l) + '\n';
            }

            else
            {
                return "-" + Convert.ToString(Math.Abs(z)) + '/' + Convert.ToString(Math.Abs(l)) + '\n';
            }

        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            List<Complex> list = new List<Complex>();
            FileStream fs = new FileStream("a.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(List<Complex>));

            try
            {
                list = xs.Deserialize(fs) as List<Complex>;

            }
            catch (Exception j)
            {
                Console.WriteLine(j.ToString());

            }
            finally
            {
                fs.Close();
            }

            foreach (Complex a in list)
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();
        }
    }
}