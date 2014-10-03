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
        public Player curPlayer { get; private set; }

        private Player player1;
        private Player player2;

        public Board(int width, int height, Player player1, Player player2)
        {
            //check minimal board size
            if (width < 3)
                width = 3;
            if (height < 3)
                height = 3;

            //initialize properties
            this.width = width;
            this.height = height;
            this.fields = new Field[width, height];
            this.player1 = player1;
            this.player2 = player2;

            this.curPlayer = player1; //player1 begins

            //initialize empty fields
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    this.fields[i, j] = new Field(null);

            //initialize starting position
            int x = width / 2;
            int y = height / 2;
            this.fields[x, y] = new Field(player1);
            this.fields[x - 1, y - 1] = new Field(player1);
            this.fields[x - 1, y] = new Field(player2);
            this.fields[x, y - 1] = new Field(player2);            
        }

        //switch to the other player
        private void switchPlayer()
        {
            curPlayer = curPlayer == player1 ? player2 : player1;
        }

        //return if (x,y) is valid on the boards
        public bool IsInBounds(int x, int y)
        {
            return x > 0 && x <= width && y > 0 && y <= height;
        }

        //check if player can move to (x,y) on the board
        public bool IsValidMove(Player player, int x, int y)
        {
            if (player == player1 && x == 3 && y == 1)
                return true;
            return false;
        }

        //player clicked on a field
        public bool FieldClicked(int x, int y)
        {
            if (!IsInBounds(x, y))
                return false;

            if (!IsValidMove(curPlayer, x, y))
                return false;

            //handle the valid move
            fields[x, y] = new Field(curPlayer);
            switchPlayer();
            return true;
        }
    }
}
