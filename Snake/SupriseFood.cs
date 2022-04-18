using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class SupriseFood : PictureBox
    {
        public static int appleSize = SnakePiece.snakeSize;
        public SupriseFood()
        {
            this.Width = appleSize;
            this.Height = appleSize;

            this.BackColor = Color.BlueViolet;
        }
    }
}
