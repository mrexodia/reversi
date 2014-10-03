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
            this.Paint += ReversiForm_Paint;
        }

        void ReversiForm_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
