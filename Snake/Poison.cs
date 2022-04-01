using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class Poison : PictureBox
    {
        public static int poisonSize = SnakePiece.snakeSize;
        public Poison()
        {
            this.Width = poisonSize;
            this.Height = poisonSize;

            this.BackColor = Color.Black;
        }
    }
}
