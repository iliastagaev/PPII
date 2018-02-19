using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snake
{
    

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();

            Console.SetWindowSize(80, 30);
            Random rnd = new Random();
            int level = 1;
            int n = rnd.Next(2, 75);
            int m = rnd.Next(2, 24);
            Wall wall = new Wall(level);
            Snake snake = new Snake();
            food eat = new food();
            
            while (!eat.testsnake(snake) || !(eat.testwall(wall)))
            {
                n = rnd.Next(2, 75);
                m = rnd.Next(2, 24);
                eat = new food(n, m);
            }
            wall.Draw();
            snake.Draw();
            eat.Showfood(n, m);



            while (true)
            {

                ConsoleKeyInfo a = Console.ReadKey();

                if (a.Key == ConsoleKey.DownArrow)
                    snake.Motion(0, 1);
                if (a.Key == ConsoleKey.UpArrow)
                    snake.Motion(0, -1);
                if (a.Key == ConsoleKey.LeftArrow)
                    snake.Motion(-1, 0);
                if (a.Key == ConsoleKey.RightArrow)
                    snake.Motion(1, 0);
                if (a.Key == ConsoleKey.Q)
                {
                    int scoreofplayer = 0;
                    for (int i = 1; i < level; i++)
                    {
                        scoreofplayer += level * 5;
                    }
                    scoreofplayer += snake.a.Count - 1;
                    StreamReader sr = new StreamReader(@"D:\snakelevels\highestscore.txt");
                    string h = sr.ReadToEnd();
               
                    string[] b = h.Split('\n');
                    bool k = false;
                    for (int i = 0; i < b.Length; i++)
                    {
                        int index = b[i].IndexOf(' ');
                        string testname = b[i].Substring(0, index);
                        int currentscore = Convert.ToInt32(b[i].Substring(index + 1, b[i].Length - index - 1));
                        
                       
                        if (testname == name)
                        {
                            k = true;
                            
                            if (scoreofplayer > currentscore)
                            {
                                sr.Close();
                                StreamWriter sw = new StreamWriter(@"D:\snakelevels\highestscore.txt");
                                sw.WriteLine(name + ' ' + scoreofplayer);
                            }
                        }
                    }
                    if(k == false)
                    {
                        sr.Close();
                            StreamWriter sw = new StreamWriter(@"D:\snakelevels\highestscore.txt");
                            sw.WriteLine(name + ' ' + scoreofplayer);
                        
                    }

                }
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
               eat.Showfood(n, m);
                snake.Draw();
                wall.Draw();
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