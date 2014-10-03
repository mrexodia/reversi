using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Board
    {
        private int FieldSize { get; set; }
        public Field[,] Fields { get; }

        public Board(int fieldSize = 6)
        {
            this.FieldSize = fieldSize;
            this.Fields = new Field[FieldSize, FieldSize];
        }
    }
}
