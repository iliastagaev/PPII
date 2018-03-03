using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ilyas's shop");
            Console.WriteLine("Enter your cash: ");
            long cash = long.Parse(Console.ReadLine());
            long begin = cash;
            Console.Clear();
            int cnt = 0;
      
            Product product = new Product();
            DirectoryInfo di = new DirectoryInfo("Types");
            DirectoryInfo[] di_1 = di.GetDirectories();
            List<Product> list = new List<Product>();
            Shop shop = new Shop(list);
            int shopcnt = 0;
            while (true)
            {

                for (int i = 0; i < di_1.Length; i++)
                {
                    if (i == cnt)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(di_1[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Your cash: " + cash + "tg");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    cnt--;
                    if (cnt == -1)
                    {
                        cnt = di_1.Length - 1;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    cnt++;
                    if (cnt == di_1.Length)
                    {
                        cnt = 0;
                    }
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    DirectoryInfo di_2 = new DirectoryInfo(di_1[cnt].FullName);
                    FileInfo[] fi = di_2.GetFiles();
                    cnt = 0;
                    while (true)
                    {

                        for (int i = 0; i < fi.Length; i++)
                        {
                            if (cnt == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(fi[i].Name.Substring(0, fi[i].Name.IndexOf('.')));
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Your cash: " + cash + "tg");
                        key = Console.ReadKey();
                        if (key.Key == ConsoleKey.UpArrow)

                        {
                            cnt--;
                            if (cnt == -1)
                            {
                                cnt = fi.Length - 1;
                            }
                        }
                        if (key.Key == ConsoleKey.DownArrow)
                        {
                            cnt++;
                            if (cnt == fi.Length)
                            {
                                cnt = 0;
                            }
                        }
                        if (key.Key == ConsoleKey.Enter)
                        {
                            StreamReader sr = new StreamReader(fi[cnt].FullName);
                            Console.Clear();
                            string s = sr.ReadToEnd();
                            string[] s_1 = s.Split('\n');
                            for (int i = 0; i < s_1.Length; i++)
                            {
                                Console.WriteLine(s_1[i]);
                            }
                            long cost = long.Parse(s_1[0].Substring(s_1[0].IndexOf(' '), s_1[0].Length - s_1[0].IndexOf(' ')));
                            Console.WriteLine("Press B to buy or press Esc to exit");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.B)
                            {
                                if (cash >= cost)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You successfully bought the " + fi[cnt].Name.Substring(0, fi[cnt].Name.IndexOf('.')));
                                    product = new Product(fi[cnt].Name, cost);

                                    shop.list.Add(product);
                                    shopcnt++;
                                    cash -= cost;
                                    Console.ReadKey();
                                    cnt = 0;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You haven't enough money!");
                                    Console.ReadKey();
                                    cnt = 0;
                                }
                            }
                            if (key.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                cnt = 0;
                            }
                        }
                        if (key.Key == ConsoleKey.Escape)
                        {
                            cnt = 0;
                            break;
                        }
                        Console.Clear();
                    }
                }
               
                Console.Clear();
                if (key.Key == ConsoleKey.S)
                {
                    break;
                }
            }
            cnt = 0;
            long sum = 0;
            while (true)
            {
                for (int i = 0; i < shopcnt; i++)
                {
                    if (cnt == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(shop.list[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Your cash: " + cash);
                Console.WriteLine("Press R to remove or Press A to end the shop");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)

                {
                    cnt--;
                    if (cnt == -1)
                    {
                        cnt = shopcnt - 1;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    cnt++;
                    if (cnt == shopcnt)
                    {
                        cnt = 0;
                    }
                }
                if (key.Key == ConsoleKey.R)
                {
                    long r = shop.list[cnt].value;
                    cash += r;
                    shop.Remove(cnt);
                    shopcnt--;
                }

                Console.Clear();
                if (key.Key == ConsoleKey.A)
                {
                    foreach (Product b in shop.list)
                    {
                        sum += b.value;
                    }
                    break;
                }
            }
            
            Console.WriteLine("Thank you for shop in our magazine!!!");
            Console.WriteLine("Your cheque: " + sum);
            Console.WriteLine("Your reminder: " + (begin - sum));

            Console.ReadKey();
        }
    }
}
