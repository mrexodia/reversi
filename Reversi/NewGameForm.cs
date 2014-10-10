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
    public partial class NewGameForm : Form
    {
        public Board board { get; private set; }

        public NewGameForm(Board oldboard)
        {
            InitializeComponent();

            textWidth.Text = oldboard.width.ToString();
            textHeight.Text = oldboard.height.ToString();
            textName1.Text = oldboard.player1.name;
            groupBoxPlayer1.ForeColor = oldboard.player1.color;
            textName2.Text = oldboard.player2.name;
            groupBoxPlayer2.ForeColor = oldboard.player2.color;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                board = new Board(int.Parse(textWidth.Text), int.Parse(textHeight.Text),
                                    new Player(textName1.Text, Color.Blue, Properties.Resources.ImageEllipseBlue),
                                    new Player(textName2.Text, Color.Red, Properties.Resources.ImageEllipseRed));
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input, make sure you specify a number in the size field.");
            }
        }
    }
}
