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
        int testX = 0, testY = 0;
        Player player1 = new Player("Sonic", Color.Blue);
        Player player2 = new Player("Mario", Color.Red);

        public ReversiForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //register events
            panelBoard.Paint += pictureBoxBoard_Paint;
            panelBoard.MouseClick += panelBoard_MouseClick;

            //initialize board
            board = new Board(6, 6, player1, player2);
        }

        void panelBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int w = panelBoard.Width / board.width;
            int h = panelBoard.Height / board.height;
            if (board.FieldClicked(e.X / w, e.Y / h))
                panelBoard.Invalidate();
        }

        void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
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
                    e.Graphics.DrawRectangle(Pens.Black, x, y, w, h);

                    //draw player
                    if (!board.fields[i, j].IsEmpty())
                        e.Graphics.FillEllipse(new SolidBrush(board.fields[i, j].owner.color), x + pad, y + pad, w - pad * 2, h - pad * 2);

                    if (!checkBoxHelp.Checked)
                        continue; //skip drawing help

                    //draw help
                    if (board.IsValidMove(player1, i, j))
                        e.Graphics.DrawEllipse(new Pen(player1.color), x + w / 4 + pad * 2, y + h / 4 + pad * 2, w / 2 - pad * 2, h / 2 - pad * 2);
                    if (board.IsValidMove(player2, i, j))
                        e.Graphics.DrawEllipse(new Pen(player2.color), x + w / 4 + pad * 2, y + h / 4 + pad * 2, w / 2 - pad * 2, h / 2 - pad * 2);
                }
            }
        }

        private void ReversiForm_ResizeEnd(object sender, EventArgs e)
        {
            panelBoard.Invalidate();
        }

        private void checkBoxHelp_CheckedChanged(object sender, EventArgs e)
        {
            panelBoard.Invalidate();
        }
    }
}
