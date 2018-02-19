using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class menu
    {
        public string[] s;

        public void Draw()
        {
            Console.SetCursorPosition(30, 30);
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(i.ToString() + '.' + s[i]);
            }
            }
    }
}
