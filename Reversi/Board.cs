using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Board
    {
        public int Size { get; private set; }
        public Field[,] Fields { get; private set; }

        public Board(int fieldSize = 6)
        {
            this.Size = fieldSize;
            this.Fields = new Field[Size, Size];
        }
    }
}
