using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Reversi
{
    class Board : ICloneable
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public Field[,] fields { get; private set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Player curPlayer { get; private set; }

        public enum ClickStatus
        {
            InvalidMove,
            ValidMove,
            GameOver
        };

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
            {
                for (int j = 0; j < height; j++)
                    this.fields[i, j] = new Field();
            }

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

        //returns if player can make a valid move
        private bool isMovePossible(Player player)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (IsValidMove(player, i, j))
                        return true;
                }
            }
            return false;
        }

        //switch to the other player
        private ClickStatus switchPlayer(int count = 0)
        {
            if (count == 2)
                return ClickStatus.GameOver;
            curPlayer = otherPlayer(curPlayer);
            if (!isMovePossible(curPlayer))
                return switchPlayer(count + 1);
            return ClickStatus.ValidMove;
        }

        //returns if a field is owned by a player
        private bool isOwnedByPlayer(Player player, int x, int y)
        {
            if (!IsInBounds(x, y))
                return false;

            return fields[x, y].owner == player;
        }

        //returns true if there is a field of the same color at the direction given by dx and dy (empty field on the way = false)
        private bool isFieldAt(Player player, int x, int y, int dx, int dy)
        {
            if ((dx == 0 && dy == 0) || !IsInBounds(x, y) || fields[x, y].IsEmpty())
                return false;

            if (fields[x, y].owner == player)
                return true;

            //walk 'forward' in the direction given
            return isFieldAt(player, x + dx, y + dy, dx, dy);
        }

        //a tile 'moved' to (x,y) from (?,?) => recolor fields
        private void fieldChanged(Player player, int x, int y)
        {
            for (int i = -1; i < 2; i++) //go over all directions
            {
                for (int j = -1; j < 2; j++)
                {
                    //own fields while there is a field of ours in the current direction
                    for (int xi = x, yi = y, dx = i, dy = j; isFieldAt(player, xi, yi, dx, dy); xi += dx, yi += dy)
                        fields[xi, yi] = new Field(player);
                }
            }
        }

        //purely to satisfy the ICloneable interface
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        //provides a clone functionality
        public Board Clone()
        {
            Board retBoard = (Board)this.MemberwiseClone();
            retBoard.fields = (Field[,])this.fields.Clone();
            return retBoard;
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

            for (int i = -1; i < 2; i++) //go over all directions
            {
                for (int j = -1; j < 2; j++)
                {
                    int k = 1;
                    while (isOwnedByPlayer(otherPlayer(player), x + i * k, y + j * k))
                        k++;
                    if (k == 1) //skip if the first field in the current direction is not owned by the other player
                        continue;
                    if (isOwnedByPlayer(player, x + i * k, y + j * k))
                        return true;
                }
            }

            return false;
        }

        //player clicked on a field
        public ClickStatus FieldClicked(int x, int y)
        {
            if (!IsInBounds(x, y))
                return ClickStatus.InvalidMove;

            if (!IsValidMove(curPlayer, x, y))
                return ClickStatus.InvalidMove;

            //handle the valid move
            fields[x, y] = new Field(curPlayer);
            fieldChanged(curPlayer, x, y);
            return switchPlayer();
        }

        //get the number of fields owned by player
        public int GetPlayerScore(Player player)
        {
            int score = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (isOwnedByPlayer(player, i, j))
                        score++;
                }
            }
            return score;
        }
    }
}
