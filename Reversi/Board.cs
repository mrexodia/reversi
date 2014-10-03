using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Board
    {
        public int size { get; private set; }
        public Field[,] fields { get; private set; }

        public Board(int size = 6)
        {
            this.size = size;
            this.fields = new Field[size, size];
        }
    }
}
