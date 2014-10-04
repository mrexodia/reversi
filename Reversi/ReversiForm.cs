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

        public ReversiForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //initialize board
            board = new Board(6, 6, new Player("Sonic", Color.Blue), new Player("Mario", Color.Red));
            updateScores();

            //register events
            panelBoard.Paint += pictureBoxBoard_Paint;
            panelBoard.MouseClick += panelBoard_MouseClick;
        }

        void panelBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int w = panelBoard.Width / board.width;
            int h = panelBoard.Height / board.height;
            if (board.FieldClicked(e.X / w, e.Y / h))
                panelBoard.Invalidate();
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

        void updateScores()
        {
            labelPlayer1.Text = String.Format("{0}: {1}", board.player1.name, board.GetPlayerScore(board.player1));
            labelPlayer1.ForeColor = board.player1.color;
            labelPlayer2.Text = String.Format("{0}: {1}", board.player2.name, board.GetPlayerScore(board.player2));
            labelPlayer2.ForeColor = board.player2.color;
            labelGameStatus.Text = String.Format("It is {0}'s turn.", board.curPlayer.name);
            labelGameStatus.ForeColor = board.curPlayer.color;
        }

        void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            updateScores();
            drawBoard(e.Graphics, board);
        }

        private void checkBoxHelp_CheckedChanged(object sender, EventArgs e)
        {
            panelBoard.Invalidate();
        }
    }
}
