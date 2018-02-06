using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    [Serializable]
    class food
    {
        Random rnd = new Random();

        public int x, y;
        public food() { }
        public bool b = false;
        public food(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
       
        public bool testwall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (p.x == x && p.y == y)
                {
                    return false;
                }

            }
            return true;
        }
        public bool testsnake(Snake s)
        {
            foreach (Point p in s.a)
            {
                if (p.x == x && p.y == y)
                {
                    return false;
                }
            }
            return true;
        }
       
        public static void Showfood(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("o");          
        }
    }
}
