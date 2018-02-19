using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    [Serializable]
    class Snake
    {
        public List<Point> a;
        public int cnt;

        public Snake()
        {
            a = new List<Point>();
            a.Add(new Point(2, 2));
            cnt = 0;
        }

        public void Motion(int dx, int dy)
        {

            for (int i = a.Count - 1; i > 0; i--)
            {
                a[i].x = a[i - 1].x;
                a[i].y = a[i - 1].y;
            }
            a[0].x += dx;
            a[0].y += dy;
            

        }
        public void AddMember()
        {
            a.Add(new Point(0, 0));
        }
        public bool CollisionWithWall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (p.x == a[0].x && p.y == a[0].y)
                    return true;
            }
            return false;
        }
        public bool Collision()
        {
            for (int i = 1; i < a.Count; i++)
            {
                if (a[0].x == a[i].x && a[0].y == a[i].y)
                    return true;
            }
            return false;
        }
        public bool CollisionWithFood(food b)
        {
            if (a[0].x == b.x && a[0].y == b.y)
            {
                return true;

            }
            return false;
        }
        public bool UpLevel(int level)
        {
            if (a.Count > level * 5)
            {
                return true;
            }
            return false;
        }
        public void Draw()
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (i == 0)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.CursorVisible = false;
                Console.SetCursorPosition(a[i].x, a[i].y);
                Console.Write("*");
            }
        }
    }
}