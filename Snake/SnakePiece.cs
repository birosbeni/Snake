using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public class SnakePiece : PictureBox
    {
        public static int snakeSize = 20;

        public SnakePiece()
        {
            this.Width = snakeSize;
            this.Height = snakeSize;

            this.BackColor = Color.Green;

            this.BackgroundImage = Image.FromFile("snakeInner.png");
        }
    }
}
