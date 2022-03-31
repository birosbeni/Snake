using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        //screen sizes(must be divisibly by 30)
        public static int screenWidth = 1500;
        public static int screenHeight = 900;

        Timer timer = new Timer();
        Random rnd = new Random();

        int moves;
        int dirX = 1;
        int dirY = 0;
        int headX = 60;
        int headY = 30;
        int lastX;
        int lastY;
        int speed = 300;

        List<SnakePiece> snakePieces = new List<SnakePiece>();
        List<Apple> apples = new List<Apple>();

        public Form1()
        {
            InitializeComponent();

            //starting snake snakePieces
            SnakePiece sp1 = new SnakePiece();
            sp1.Left = 30;
            sp1.Top = 30;
            SnakePiece sp2 = new SnakePiece();
            sp2.Left = 60;
            sp2.Top = 30;

            snakePieces.Add(sp1);
            snakePieces.Add(sp2);

            //timer settings
            timer.Interval = speed;
            timer.Tick += Timer_Tick;
            timer.Start();

            KeyDown += Form1_KeyDown;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = screenWidth;
            this.Height = screenHeight;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            moves++;
            Text = $"{moves}.lépés, sebesség:{speed}, headX:{headX}, headY:{headY}, hossz:{snakePieces.LongCount()}";

            headX += dirX * SnakePiece.snakeSize;
            headY += dirY * SnakePiece.snakeSize;

            foreach (SnakePiece item in snakePieces)
            {
                if ((item.Top == headY && item.Left == headX) || 
                    headY < 0 || headY == screenHeight || 
                    headX < 0 || headX == screenWidth) //TODO-screen size-hoz igazítás
                {
                    timer.Stop();
                }

            }

            //last snake piece remove
            CutOffSnakePiece();

            //new snake piece add
            AddSnakePiece(headX, headY);

            //new apple
            if (moves % 2 == 0)
            {
                Apple apple = new Apple();
                apple.Left = rnd.Next(0, screenWidth / 30) * 30 - 30;
                apple.Top = rnd.Next(0, screenHeight / 30) * 30 - 30;
                apples.Add(apple);
            }

            //speeding
            if (moves % 20 == 0) { speed -= 20; }


            foreach (SnakePiece piece in snakePieces)
            {
                Controls.Add(piece);
            }

            foreach (Apple apple in apples)
            {
                if (apple.Left == headX && apple.Top == headY)
                {
                    apples.Remove(apple);
                    Controls.Remove(apple);

                    List<SnakePiece> newSnakePieces = new List<SnakePiece>();

                    //TODO-AddSnakePiece akármilyen listára
                    SnakePiece newPiece = new SnakePiece();
                    newPiece.Left = lastX;
                    newPiece.Top = lastY;
                    newSnakePieces.Add(newPiece);
                    foreach (SnakePiece piece in snakePieces)
                    {
                        newSnakePieces.Add(piece);
                    }

                    snakePieces = newSnakePieces;                 

                    return;
                }
                else
                {
                    Controls.Add(apple);
                }

            }

            //saving last position
            foreach (SnakePiece piece in snakePieces)
            {
                lastX = piece.Left; 
                lastY = piece.Top;  
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { dirX = 0; dirY = -1; }
            if (e.KeyCode == Keys.Down) { dirX = 0; dirY = 1; }
            if (e.KeyCode == Keys.Left) { dirX = -1; dirY = 0; }
            if (e.KeyCode == Keys.Right) { dirX = 1; dirY = 0; }
        }

        public void AddSnakePiece(int x, int y)
        {
            SnakePiece newPiece = new SnakePiece();     
            newPiece.Left = x;
            newPiece.Top = y;
            snakePieces.Add(newPiece);
        }

        public void CutOffSnakePiece()
        {
            SnakePiece cutOff = snakePieces[0];
            Controls.Remove(cutOff);
            snakePieces.Remove(cutOff);
        }


    }
}
