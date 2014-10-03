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

        public ReversiForm()
        {
            InitializeComponent();
            board = new Board(6, 6);
            panelBoard.Paint += pictureBoxBoard_Paint;
            panelBoard.MouseMove += pictureBoxBoard_MouseMove;
            panelBoard.MouseClick += panelBoard_MouseClick;
        }

        void panelBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int w = panelBoard.Width / board.width;
            int h = panelBoard.Height / board.height;
            testX = Math.Min(e.X / w, board.width - 1);
            testY = Math.Min(e.Y / h, board.height - 1);
            panelBoard.Invalidate();
        }

        void pictureBoxBoard_MouseMove(object sender, MouseEventArgs e)
        {
            int w = panelBoard.Width / board.width;
            int h = panelBoard.Height / board.height;
            this.Text = String.Format("{0},{1}", e.X / w, e.Y / h);
        }

        void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            int w = panelBoard.Width / board.width;
            int h = panelBoard.Height / board.height;

            for (int i = 0; i < board.width; i++)
            {
                for (int j = 0; j < board.height; j++)
                {
                    int x = i * w;
                    int y = j * h;
                    e.Graphics.DrawRectangle(Pens.Black, x, y, w, h);
                    if (i == testX && j == testY)
                        e.Graphics.FillEllipse(Brushes.Red, x + 1, y + 1, w - 2, h - 2);
                }
            }
        }

        private void ReversiForm_ResizeEnd(object sender, EventArgs e)
        {
            panelBoard.Invalidate();
        }
    }
}
