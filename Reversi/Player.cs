using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Reversi
{
    class Player
    {
        public Player(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }

        public string name { get; private set; }
        public Color color { get; private set; }
    }
}
