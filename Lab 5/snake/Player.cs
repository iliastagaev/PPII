using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Player
    {
        string name;
        int score;
        public Player()
        {
            name = "";
            score = 0;
        }
        public Player(string name, int score)
        {
            this.name = name;
            this.score = score; 
        }

    }
}
