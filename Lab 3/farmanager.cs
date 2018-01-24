using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace farmanager
{
    class Program
    {
        static void Showpapke(DirectoryInfo a, int pos)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            FileSystemInfo[] fs = a.GetFileSystemInfos();

            for (int index = 0; index < fs.Length; index++)
            {
                FileSystemInfo current = fs[index];
                if (index == pos)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (current.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(current);
            }
           
        }
        
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            DirectoryInfo a = new DirectoryInfo(s);
            int pos = 0;
            int n = a.GetFileSystemInfos().Length;
            Showpapke(a, pos);
            while (true)
            {
                ConsoleKeyInfo x = Console.ReadKey();
                if (x.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if (pos == -1)
                    {
                        pos = n - 1;
                    }
                }
                if (x.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos == n)
                    {
                        pos = 0;
                    }
                }
                if (x.Key == ConsoleKey.Enter)
                {
                    if (a.GetFileSystemInfos()[pos].GetType() == typeof(DirectoryInfo))
                    {
                        a = new DirectoryInfo(a.GetFileSystemInfos()[pos].FullName);
                        pos = 0;
                        n = a.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(a.GetFileSystemInfos()[pos].FullName);
                        string o = sr.ReadToEnd();
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(o);
                        Console.ReadKey();
                    }
                }
                if (x.Key == ConsoleKey.Escape || x.Key == ConsoleKey.Backspace)
                {
                    if (a.Parent != null)
                    {
                       a = a.Parent;
                        pos = 0;
                        n = a.GetFileSystemInfos().Length;
                    }
                    else
                        break;
                }
                Showpapke(a, pos);
            }
        }
      
    }
}