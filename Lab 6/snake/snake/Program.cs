using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace snake
{
    

    class Program
    {
        static int n, m;
        static int direction = 1;
        static int level = 1;
        static Snake snake = new Snake();
        static Wall wall = new Wall(1);
        static int speed = 250;
        static food eat = new food();
        static ConsoleKeyInfo a;
       static  Random rnd = new Random();
        public static void Thread_func()
        {
            while (true)
            {
                if (direction == 1)
                    snake.Motion(1, 0);
                if (direction == 2)
                    snake.Motion(-1, 0);
                if (direction == 3)
                    snake.Motion(0, 1);
                if (direction == 4)
                    snake.Motion(0, -1);

                if (a.Key == ConsoleKey.R)
                {
                    level = 1;
                    snake = new Snake();
                    wall = new Wall(level);
                    eat = new food();
                    while (!eat.testsnake(snake) || (!eat.testwall(wall)))
                    {
                        n = rnd.Next(2, 75);
                        m = rnd.Next(2, 24);
                        eat = new food(n, m);
                    }

                }
                if (a.Key == ConsoleKey.S)
                {
                    FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    FileStream fs_1 = new FileStream("data1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    List<int> list = new List<int>();
                    list.Add(level);
                    list.Add(n);
                    list.Add(m);
                    XmlSerializer xml = new XmlSerializer(typeof(Snake));
                    XmlSerializer xml_1 = new XmlSerializer(typeof(List<int>));
                    xml.Serialize(fs, snake);
                    xml_1.Serialize(fs_1, list);
                    fs.Close();
                    fs_1.Close();
                }
                if (a.Key == ConsoleKey.E)
                {

                    FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    FileStream fs_1 = new FileStream("data1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    XmlSerializer xml = new XmlSerializer(typeof(Snake));
                    XmlSerializer xml_1 = new XmlSerializer(typeof(List<int>));
                 
                    snake = xml.Deserialize(fs) as Snake;
                    List<int> list = xml_1.Deserialize(fs_1) as List<int>;
                    fs.Close();
                    fs_1.Close();
                    level = list[0];
                    n = list[1];
                    m = list[2];
                    wall = new Wall(level);
                    eat = new food(n, m);
                   

                }
                if (snake.CollisionWithFood(eat))
                {
                    snake.AddMember();
                    eat = new food();
                    while (!eat.testsnake(snake) || (!eat.testwall(wall)))
                    {
                        n = rnd.Next(2, 75);
                        m = rnd.Next(2, 24);
                        eat = new food(n, m);
                    }

                }
                if (snake.CollisionWithWall(wall) || snake.Collision())
                {
                    Console.Clear();
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("GAME OVER!!!!");
                    Console.ReadKey();
                    snake = new Snake();
                    level = 1;
                    eat = new food();
                    while (!eat.testsnake(snake) || (!eat.testwall(wall)))
                    {
                        n = rnd.Next(2, 75);
                        m = rnd.Next(2, 24);
                        eat = new food(n, m);
                    }


                    wall = new Wall(level);

                }
                if (snake.UpLevel(level))

                {

                    direction = 1;
                    level++;
                    snake = new Snake();
                    wall = new Wall(level);
                    eat = new food();
                    while (!eat.testsnake(snake) || (!eat.testwall(wall)))
                    {
                        n = rnd.Next(2, 75);
                        m = rnd.Next(2, 24);
                        eat = new food(n, m);
                    }

                }

                Console.Clear();
                wall.Draw();
                snake.Draw();
                eat.Showfood(n, m);

                Console.SetCursorPosition(0, 27);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Your Level: " + level + " You must dial " + level * 5);
                Console.SetCursorPosition(0, 28);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Score: " + (snake.a.Count - 1));
                if (snake.UpLevel(level))
                    speed = Math.Max(100, speed - 50);
                Thread.Sleep(speed);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();

            Thread thread = new Thread(Thread_func);
            thread.Start();
            Console.SetWindowSize(80, 30);
            
             level = 1;
             n = rnd.Next(2, 75);
           m = rnd.Next(2, 24);
           
            
            
            while (!eat.testsnake(snake) || !(eat.testwall(wall)))
            {
                n = rnd.Next(2, 75);
                m = rnd.Next(2, 24);
                eat = new food(n, m);
            }
           


            while (true)
            {
                a = Console.ReadKey();

                if (a.Key == ConsoleKey.DownArrow && direction != 4)
                    direction = 3;
                if (a.Key == ConsoleKey.UpArrow)
                    direction = 4;
                if (a.Key == ConsoleKey.LeftArrow)
                    direction = 2;
                if (a.Key == ConsoleKey.RightArrow)
                    direction = 1;

                if (a.Key == ConsoleKey.R)
                {
                    level = 1;
                    snake = new Snake();
                    wall = new Wall(level);
                    eat = new food();
                    while (!eat.testsnake(snake) || (!eat.testwall(wall)))
                    {
                        n = rnd.Next(2, 75);
                        m = rnd.Next(2, 24);
                        eat = new food(n, m);
                    }
                }
                if (a.Key == ConsoleKey.S)
                {
                    FileStream fs = new FileStream("data.txt", FileMode.Create, FileAccess.Write);
                    FileStream fs_1 = new FileStream("data1.txt", FileMode.Create, FileAccess.Write);
                    List<int> list = new List<int>();
                    list.Add(level);
                    list.Add(n);
                    list.Add(m);
                    XmlSerializer xml = new XmlSerializer(typeof(Snake));
                    XmlSerializer xml_1 = new XmlSerializer(typeof(List<int>));
                    xml.Serialize(fs, snake);
                    xml_1.Serialize(fs_1, list);
                    fs.Close();
                    fs_1.Close();
                }
                if (a.Key == ConsoleKey.E)
                {
                    FileStream fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
                    FileStream fs_1 = new FileStream("data1.txt", FileMode.Open, FileAccess.Read);
                    XmlSerializer xml = new XmlSerializer(typeof(Snake));
                    XmlSerializer xml_1 = new XmlSerializer(typeof(List<int>));

                    snake = xml.Deserialize(fs) as Snake;
                    List<int> list = xml_1.Deserialize(fs_1) as List<int>;
                    level = list[0];
                    n = list[1];
                    m = list[2];
                    wall = new Wall(level);
                    eat = new food(n, m);
                    fs.Close();
                    fs_1.Close();

                }
                if (a.Key == ConsoleKey.Q)
                {
                    int scoreofplayer = 0;
                    for (int i = 1; i < level; i++)
                    {
                        scoreofplayer += (level) * 5;
                    }
                    scoreofplayer += snake.a.Count - 1;
                    StreamReader sr = new StreamReader(@"D:\snakelevels\highestscore.txt");
                    string h = sr.ReadToEnd();
                    sr.Close();
                    string[] b = h.Split('\n');
                    bool k = false;
                    for (int i = 0; i < b.Length; i++)
                    {
                        int index = b[i].IndexOf(" ");
                        string testname = b[i].Substring(0, index);
                        int currentscore = Convert.ToInt32(b[i].Substring(index + 1, b[i].Length - index - 1));


                        if (testname == name)
                        {
                            k = true;

                            if (scoreofplayer > currentscore)
                            {
                                b[i] = "";
                                b[i] = name + " " + scoreofplayer;
                            }
                        }
                    }
                    string s = "";
                    for (int i = 0; i < b.Length; i++)
                    {
                        s += b[i] + '\n';
                    }

                    if (k == false)
                    {
                        s += name + " " + scoreofplayer;
                    }
                    StreamWriter sw = new StreamWriter(@"D:\snakelevels\highestscore.txt");
                    sw.WriteLine(s);
                    sw.Close();
                }

                if (snake.CollisionWithFood(eat))
                {
                    snake.AddMember();
                    eat = new food();
                     while (!eat.testsnake(snake) || (!eat.testwall(wall)))
                    {
                        n = rnd.Next(2, 75);
                        m = rnd.Next(2, 24);
                        eat = new food(n, m);
                    }
                  
                }
                if (snake.CollisionWithWall(wall) || snake.Collision())
                {
                    direction = 1;
                    Console.Clear();
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("GAME OVER!!!!");
                    Console.ReadKey();
                    snake = new Snake();
                    level = 1;
                    eat = new food();
                    while ( !eat.testsnake(snake) || (!eat.testwall(wall)))
                    {
                        n = rnd.Next(2, 75);
                        m = rnd.Next(2, 24);
                        eat = new food(n, m);
                    }

                    
                    wall = new Wall(level);
              
                }
                if (snake.UpLevel(level))
                {
                    direction = 1;
                    level++;
                    snake = new Snake();
                    wall = new Wall(level);
                    eat = new food();
                    while (!eat.testsnake(snake) || (!eat.testwall(wall)))
                    {
                     
                        n = rnd.Next(2, 75);
                        m = rnd.Next(2, 24);
                        eat = new food(n, m);
                    }

                }


                snake.Draw();
                wall.Draw();
                eat.Showfood(n, m);
                Console.SetCursorPosition(0, 27);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Your Level: " + level + " You must dial " + level * 5);
                Console.SetCursorPosition(0, 28);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Score: " + (snake.a.Count - 1));

            }
        }
    }
}