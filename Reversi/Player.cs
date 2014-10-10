using System.Drawing;

namespace Reversi
{
    public class Player
    {
        public string name { get; set; }
        public Color color { get; set; }
        public Image image { get; set; }

        public Player(string name, Color color, Image image)
        {
            this.name = name;
            this.color = color;
            this.image = image;
        }
    }
}
