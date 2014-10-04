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

            //register events
            panelBoard.Paint += pictureBoxBoard_Paint;
            panelBoard.MouseClick += panelBoard_MouseClick;

            //initialize board
            board = new Board(6, 6, new Player("Sonic", Color.Blue), new Player("Mario", Color.Red));
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

        void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            drawBoard(e.Graphics, board);
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
