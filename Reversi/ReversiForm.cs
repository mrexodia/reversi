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
        Player player1;
        Player player2;

        public ReversiForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            
            panelBoard.Paint += pictureBoxBoard_Paint;
            panelBoard.MouseClick += panelBoard_MouseClick;

            //initialize variables
            player1 = new Player("Mario", Color.Red);
            player2 = new Player("Link", Color.Green);
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
