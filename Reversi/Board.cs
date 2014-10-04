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
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Player curPlayer { get; private set; }

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
                    this.fields[i, j] = new Field();

            //initialize starting position
            int x = width / 2;
            int y = height / 2;
            this.fields[x, y] = new Field(player1);
            this.fields[x - 1, y - 1] = new Field(player1);
            this.fields[x - 1, y] = new Field(player2);
            this.fields[x, y - 1] = new Field(player2);
        }

        //returns the other player
        private Player otherPlayer(Player player)
        {
            return player == player1 ? player2 : player1;
        }

        //switch to the other player
        private void switchPlayer()
        {
            curPlayer = otherPlayer(curPlayer);
        }

        //returns if a field is owned by a player
        private bool isOwnedByPlayer(Player player, int x, int y)
        {
            if (!IsInBounds(x, y))
                return false;
            return fields[x, y].owner == player;
        }

        //returns true if there is a field at the direction given by dx and dy
        private bool isFieldAt(Player player, int x, int y, int dx, int dy)
        {
            if ((dx == 0 && dy == 0) || !IsInBounds(x, y))
                return false;
            if (fields[x, y].owner == player)
                return true;
            return isFieldAt(player, x + dx, y + dy, dx, dy);
        }

        //a tile 'moved' to (x,y) from (?,?) => recolor fields
        private void tileMoved(Player player, int x, int y)
        {
            for (int i = 0; isFieldAt(player, x + i, y, 1, 0); i++) //right
                fields[x + i, y] = new Field(player);
            for (int i = 0; isFieldAt(player, x + i, y + i, 1, 1); i++) //lower-right
                fields[x + i, y + i] = new Field(player);
            for (int i = 0; isFieldAt(player, x, y + i, 0, 1); i++) //down
                fields[x, y + i] = new Field(player);
            for (int i = 0; isFieldAt(player, x - i, y + i, -1, 1); i++) //lower-left
                fields[x - i, y + i] = new Field(player);
            for (int i = 0; isFieldAt(player, x - i, y, -1, 0); i++) //left
                fields[x - i, y] = new Field(player);
            for (int i = 0; isFieldAt(player, x - i, y - i, -1, -1); i++) //upper-left
                fields[x - i, y - i] = new Field(player);
            for (int i = 0; isFieldAt(player, x, y - i, 0, -1); i++) //up
                fields[x, y - i] = new Field(player);
            for (int i = 0; isFieldAt(player, x + i, y - i, 1, -1); i++) //upper-right
                fields[x + i, y - i] = new Field(player);
        }

        //return if (x,y) is valid on the boards
        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        //check if player can move to (x,y) on the board
        public bool IsValidMove(Player player, int x, int y)
        {
            if (!fields[x, y].IsEmpty())
                return false;

            if (isOwnedByPlayer(otherPlayer(player), x + 1, y) && isOwnedByPlayer(player, x + 2, y)) //right
                return true;
            if (isOwnedByPlayer(otherPlayer(player), x + 1, y + 1) && isOwnedByPlayer(player, x + 2, y + 2)) //lower-right
                return true;
            if (isOwnedByPlayer(otherPlayer(player), x, y + 1) && isOwnedByPlayer(player, x, y + 2)) //down
                return true;
            if (isOwnedByPlayer(otherPlayer(player), x - 1, y + 1) && isOwnedByPlayer(player, x - 2, y + 2)) //lower-left
                return true;
            if (isOwnedByPlayer(otherPlayer(player), x - 1, y) && isOwnedByPlayer(player, x - 2, y)) //left
                return true;
            if (isOwnedByPlayer(otherPlayer(player), x - 1, y - 1) && isOwnedByPlayer(player, x - 2, y - 2)) //upper-left
                return true;
            if (isOwnedByPlayer(otherPlayer(player), x, y - 1) && isOwnedByPlayer(player, x, y - 2)) //up
                return true;
            if (isOwnedByPlayer(otherPlayer(player), x + 1, y - 1) && isOwnedByPlayer(player, x + 2, y - 2)) //upper-right
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
            tileMoved(curPlayer, x, y);
            switchPlayer();
            return true;
        }
    }
}
