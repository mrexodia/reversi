using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Reversi
{
    class Board
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public Field[,] fields { get; private set; }

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.fields = new Field[width, height];
        }
    }
}
