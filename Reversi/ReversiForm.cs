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
            board = new Board();
            panelBoard.Paint += pictureBoxBoard_Paint;
            panelBoard.MouseMove += pictureBoxBoard_MouseMove;
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
                    e.Graphics.DrawRectangle(Pens.Black, i * w, j * h, w, h);
                }
            }
        }

        private void ReversiForm_ResizeEnd(object sender, EventArgs e)
        {
            panelBoard.Invalidate();
        }
    }
}
