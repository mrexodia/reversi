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
            const int padding = 5;
            int size = (e.ClipRectangle.Width - padding * 2) / board.Size;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, i * size + padding, j * size + padding, size, size);
                }
            }
        }
    }
}
