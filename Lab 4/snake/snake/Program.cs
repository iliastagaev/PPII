using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80,30);
            Random rnd = new Random();
            int n = rnd.Next(2, 75);
            int m = rnd.Next(2, 28);
            int level = 1;
            Wall wall = new Wall(level); 
            Snake snake = new Snake();

            food eat = new food(n, m);
          
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
                if(a.Key == ConsoleKey.S)
                {

                }
               if(a.Key == ConsoleKey.R)
                {
                    level = 1;
                    snake = new Snake();
                    wall = new Wall(level);
                    n = rnd.Next(2, 75);
                    m = rnd.Next(2, 28);
                    eat = new food(n, m);
                }

                if (snake.CollisionWithFood(eat))
                {
                    snake.AddMember();
                    n = rnd.Next(2, 75);
                    m = rnd.Next(2, 28);
                    eat = new food(n, m);
                }
                if (snake.CollisionWithWall(wall) || snake.Collision())
                {
                    Console.Clear();
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("GAME OVER!!!!");
                    Console.ReadKey();
                    snake = new Snake();
                    level = 1;
                    n = rnd.Next(2, 75);
                    m = rnd.Next(2, 28);
                    wall = new Wall(level);
                    eat = new food(n, m);
                }
                if (snake.UpLevel(level))
                {
                    level++;
                    snake = new Snake();
                    wall = new Wall(level);
                    n = rnd.Next(2, 75);
                    m = rnd.Next(2, 28);
                    eat = new food(n, m);
                }
               
                Console.Clear();
                food.Showfood(n, m);
                snake.Draw();
                wall.Draw();
                }
            }
        }
    }


