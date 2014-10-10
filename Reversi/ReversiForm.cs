using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi
{
    public partial class ReversiForm : Form
    {
        private Board board;
        private Board oldboard;
        private Bitmap boardImage;
        private bool displayOldBoard;
        private bool gameOver;

        public ReversiForm()
        {
            InitializeComponent();

            //start new game
            newGame();

            //register events
            panelBoard.Paint += pictureBoxBoard_Paint;
            panelBoard.MouseClick += panelBoard_MouseClick;
            panelBoard.MouseDown += panelBoard_MouseDown;
            panelBoard.MouseUp += panelBoard_MouseUp;
        }

        private void newGame()
        {
            board = new Board(6, 6, new Player("Sonic", Color.Blue, Properties.Resources.ImageEllipseBlue),
                new Player("Mario", Color.Red, Properties.Resources.ImageEllipseRed));
            oldboard = null;
            displayOldBoard = false;
            gameOver = false;
            updateScores(board);
            redraw();
        }

        private Bitmap drawBoard(Board b)
        {
            Bitmap bitmap = new Bitmap(panelBoard.Width, panelBoard.Height);
            Graphics g = Graphics.FromImage(bitmap);
            int drawWidth = (panelBoard.Width - 1) / b.width;
            int drawHeight = (panelBoard.Height - 1) / b.height;
            const int pad = 3;

            for (int boardX = 0; boardX < b.width; boardX++)
            {
                for (int boardY = 0; boardY < b.height; boardY++)
                {
                    int drawX = boardX * drawWidth;
                    int drawY = boardY * drawHeight;

                    //draw grid
                    g.DrawRectangle(Pens.Black, drawX, drawY, drawWidth, drawHeight);

                    //draw player
                    if (!b.fields[boardX, boardY].IsEmpty())
                        g.DrawImage(b.fields[boardX, boardY].owner.image, drawX, drawY, drawWidth, drawHeight);

                    if (checkBoxHelp.Checked)
                    {
                        //draw help
                        if (b.IsValidMove(b.curPlayer, boardX, boardY))
                            g.DrawEllipse(new Pen(b.curPlayer.color), drawX + drawWidth / 4 + pad + 1, drawY + drawHeight / 4 + pad + 1, drawWidth / 2 - pad * 2,
                                drawHeight / 2 - pad * 2);
                    }
                }
            }

            return bitmap;
        }

        private void updateScores(Board b)
        {
            labelPlayer1.Text = String.Format("{0}: {1}", b.player1.name, b.GetPlayerScore(b.player1));
            labelPlayer1.ForeColor = b.player1.color;
            labelPlayer2.Text = String.Format("{0}: {1}", b.player2.name, b.GetPlayerScore(b.player2));
            labelPlayer2.ForeColor = b.player2.color;

            if (gameOver)
            {
                int score1 = b.GetPlayerScore(b.player1);
                int score2 = b.GetPlayerScore(b.player2);
                if (score1 > score2) //player1 wins
                {
                    labelGameStatus.Text = String.Format("{0} won!", b.player1.name);
                    labelGameStatus.ForeColor = b.player1.color;
                }
                else if (score2 > score1) //player2 wins
                {
                    labelGameStatus.Text = String.Format("{0} won!", b.player2.name);
                    labelGameStatus.ForeColor = b.player2.color;
                }
                else //draw
                {
                    labelGameStatus.Text = "It's a draw...";
                    labelGameStatus.ForeColor = Color.Black;
                }
            }
            else
            {
                labelGameStatus.Text = String.Format("It is {0}'s turn.", b.curPlayer.name);
                labelGameStatus.ForeColor = b.curPlayer.color;
            }
        }

        private void redraw()
        {
            if (displayOldBoard && oldboard != null)
            {
                boardImage = drawBoard(oldboard);
            }
            else
            {
                updateScores(board);
                boardImage = drawBoard(board);
            }

            // Triggers the form to redraw the panel, which
            // acquires the board bitmap and puts it on the
            // screen.
            panelBoard.Invalidate();
        }

        private void panelBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                displayOldBoard = false;
                redraw();
            }
        }

        private void panelBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                displayOldBoard = true;
                redraw();
            }
        }

        private void panelBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int w = (panelBoard.Width - 1) / board.width;
                int h = (panelBoard.Height - 1) / board.height;
                Board old = board.Clone();
                switch (board.FieldClicked(e.X / w, e.Y / h))
                {
                    case Board.ClickStatus.ValidMove:
                        oldboard = old;
                        checkBoxHelp.Checked = false; //help is only for the current turn
                        redraw();
                        break;

                    case Board.ClickStatus.GameOver:
                        gameOver = true;
                        oldboard = old;
                        redraw();
                        break;
                }
            }
        }

        private void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(boardImage, 0, 0);
        }

        private void checkBoxHelp_CheckedChanged(object sender, EventArgs e)
        {
            redraw();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            newGame();
        }
    }
}