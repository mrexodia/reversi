using System;

namespace Reversi
{
    public class Board : ICloneable
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public Field[,] fields { get; private set; }
        public Player player1 { get; private set; }
        public Player player2 { get; private set; }
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
            fields = new Field[width, height];
            this.player1 = player1;
            this.player2 = player2;
            curPlayer = player1; //player1 begins

            //initialize empty fields
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                    fields[x, y] = new Field();
            }

            //initialize starting position
            int midX = width / 2;
            int midY = height / 2;
            fields[midX, midY] = new Field(player1);
            fields[midX - 1, midY - 1] = new Field(player1);
            fields[midX - 1, midY] = new Field(player2);
            fields[midX, midY - 1] = new Field(player2);
        }

        //returns the other player
        private Player otherPlayer(Player player)
        {
            return player == player1 ? player2 : player1;
        }

        //returns if player can make a valid move
        private bool isMovePossible(Player player)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (IsValidMove(player, x, y))
                        return true;
                }
            }
            return false;
        }

        //switch to the other player
        private ClickStatus switchPlayer()
        {
            for (int i = 0; i < 2; i++) //try to switch players at most twice
            {
                curPlayer = otherPlayer(curPlayer);
                if (isMovePossible(curPlayer))
                    return ClickStatus.ValidMove;
            }
            return ClickStatus.GameOver;
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
            for (int dx = -1; dx < 2; dx++) //go over all directions
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    //own fields while there is a field of ours in the current direction
                    for (int xi = x, yi = y; isFieldAt(player, xi, yi, dx, dy); xi += dx, yi += dy)
                        fields[xi, yi] = new Field(player);
                }
            }
        }

        //purely to satisfy the ICloneable interface
        object ICloneable.Clone()
        {
            return Clone();
        }

        //provides a clone functionality
        public Board Clone()
        {
            Board retBoard = (Board)MemberwiseClone();
            retBoard.fields = (Field[,])fields.Clone();
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

            for (int dx = -1; dx < 2; dx++) //go over all directions
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    int i = 1;
                    while (isOwnedByPlayer(otherPlayer(player), x + dx * i, y + dy * i))
                        i++;
                    if (i == 1) //skip if the first field in the current direction is not owned by the other player
                        continue;
                    if (isOwnedByPlayer(player, x + dx * i, y + dy * i))
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
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (isOwnedByPlayer(player, x, y))
                        score++;
                }
            }
            return score;
        }
    }
}
