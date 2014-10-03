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

        public Board(int width, int height, Player player1, Player player2)
        {
            if (width < 3)
                width = 3;
            if (height < 3)
                height = 3;
            this.width = width;
            this.height = height;
            this.fields = new Field[width, height];
            //initialize empty fields
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    this.fields[i, j] = new Field(null);
        }

        //return true = repaint
        public bool FieldClicked(int x, int y)
        {
            if (x >= width || y >= height) //out of bounds
                return false;
            return true;
        }
    }
}
