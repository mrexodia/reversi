using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class ReversiForm : Form
    {
        Board board;
        Board oldboard;
        bool displayOldBoard;
        bool gameOver;

        public ReversiForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //start new game
            newGame();

            //register events
            panelBoard.Paint += pictureBoxBoard_Paint;
            panelBoard.MouseClick += panelBoard_MouseClick;
            panelBoard.MouseDown += panelBoard_MouseDown;
            panelBoard.MouseUp += panelBoard_MouseUp;
        }

        void newGame()
        {
            board = new Board(6, 6, new Player("Sonic", Color.Blue), new Player("Mario", Color.Red));
            oldboard = null;
            displayOldBoard = false;
            gameOver = false;
            updateScores(board);
        }

        void drawBoard(Graphics g, Board board)
        {
            int w = panelBoard.Width / board.width;
            int h = panelBoard.Height / board.height;
            const int pad = 1;

            for (int i = 0; i < board.width; i++)
            {
                for (int j = 0; j < board.height; j++)
                {
                    int x = i * w;
                    int y = j * h;

                    //draw grid
                    g.DrawRectangle(Pens.Black, x, y, w, h);

                    //draw player
                    if (!board.fields[i, j].IsEmpty())
                        g.FillEllipse(new SolidBrush(board.fields[i, j].owner.color), x + pad, y + pad, w - pad * 2, h - pad * 2);

                    if (!checkBoxHelp.Checked)
                        continue; //skip drawing help

                    //draw help
                    if (board.IsValidMove(board.curPlayer, i, j))
                        g.DrawEllipse(new Pen(board.curPlayer.color), x + w / 4 + pad * 2, y + h / 4 + pad * 2, w / 2 - pad * 2, h / 2 - pad * 2);
                }
            }
        }

        void updateScores(Board board)
        {
            labelPlayer1.Text = String.Format("{0}: {1}", board.player1.name, board.GetPlayerScore(board.player1));
            labelPlayer1.ForeColor = board.player1.color;
            labelPlayer2.Text = String.Format("{0}: {1}", board.player2.name, board.GetPlayerScore(board.player2));
            labelPlayer2.ForeColor = board.player2.color;

            if (gameOver)
            {
                int score1 = board.GetPlayerScore(board.player1);
                int score2 = board.GetPlayerScore(board.player2);
                if (score1 > score2) //player1 wins
                {
                    labelGameStatus.Text = String.Format("{0} won!", board.player1.name);
                    labelGameStatus.ForeColor = board.player1.color;
                }
                else if (score2 > score1) //player2 wins
                {
                    labelGameStatus.Text = String.Format("{0} won!", board.player2.name);
                    labelGameStatus.ForeColor = board.player2.color;
                }
                else //draw
                {
                    labelGameStatus.Text = "It's a draw...";
                    labelGameStatus.ForeColor = Color.Black;
                }
            }
            else
            {
                labelGameStatus.Text = String.Format("It is {0}'s turn.", board.curPlayer.name);
                labelGameStatus.ForeColor = board.curPlayer.color;
            }
        }

        void panelBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                displayOldBoard = false;
                panelBoard.Invalidate();
            }
        }

        void panelBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                displayOldBoard = true;
                panelBoard.Invalidate();
            }
        }

        void panelBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int w = panelBoard.Width / board.width;
                int h = panelBoard.Height / board.height;
                Board old = board.Clone();
                switch (board.FieldClicked(e.X / w, e.Y / h))
                {
                    case Board.ClickStatus.ValidMove:
                        oldboard = old;
                        panelBoard.Invalidate();
                        break;

                    case Board.ClickStatus.GameOver:
                        gameOver = true;
                        oldboard = old;
                        panelBoard.Invalidate();
                        break;

                    default:
                        break;
                }
            }
        }

        void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            if (displayOldBoard && oldboard != null)
            {
                drawBoard(e.Graphics, oldboard);
            }
            else
            {
                updateScores(board);
                drawBoard(e.Graphics, board);
            }

        }

        private void checkBoxHelp_CheckedChanged(object sender, EventArgs e)
        {
            panelBoard.Invalidate();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            newGame();
            panelBoard.Invalidate();
        }
    }
}
