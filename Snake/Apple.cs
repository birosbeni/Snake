using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class Apple : PictureBox
    {
        public static int appleSize = 30;
        public Apple()
        {
            this.Width = appleSize;
            this.Height = appleSize;

            this.BackColor = Color.Red;
        }
    }
}
