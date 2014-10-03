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
            pictureBoxBoard.Paint += pictureBoxBoard_Paint;
        }

        void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            int w = e.ClipRectangle.Width / board.Size;
            int h = e.ClipRectangle.Height / board.Size;

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, i * w, j * h, w, h);
                }
            }
        }

        private void ReversiForm_ResizeEnd(object sender, EventArgs e)
        {
            pictureBoxBoard.Invalidate();
        }
    }
}
