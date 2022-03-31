using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class SnakePiece : PictureBox
    {
        public static int snakeSize = 30;

        public SnakePiece()
        {
            this.Width = snakeSize;
            this.Height = snakeSize;

            this.BackColor = Color.Green;
            
        }
    }
}
