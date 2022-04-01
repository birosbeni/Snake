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
        //screen sizes(must be divisibly by SnakePiece.snakeSize)
        public static int screenWidth = 1400;
        public static int screenHeight = 800;
        int speed = 100;

        Timer timer = new Timer();
        Random rnd = new Random();

        int moves;
        int dirX = 1;
        int dirY = 0;
        int headX = 60;
        int headY = 40;
        int lastX;
        int lastY;

        List<SnakePiece> snakePieces = new List<SnakePiece>();
        List<Apple> apples = new List<Apple>();
        List<Poison> poisons = new List<Poison>();

        public Form1()
        {
            InitializeComponent();

            //starting snake snakePieces
            SnakePiece sp1 = new SnakePiece
            {
                Left = 40,
                Top = 40
            };
            SnakePiece sp2 = new SnakePiece
            {
                Left = 60,
                Top = 40
            };

            snakePieces.Add(sp1);
            snakePieces.Add(sp2);

            //timer settings
            timer.Interval = speed;
            timer.Tick += Timer_Tick;

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
            Text = $"Left:{startButton.Left} Top:{startButton.Top} Width:{startButton.Width} Height:{startButton.Height}{moves}.lépés, sebesség:{speed}, headX:{headX}, headY:{headY}, hossz:{snakePieces.LongCount()}";

            headX += dirX * SnakePiece.snakeSize;
            headY += dirY * SnakePiece.snakeSize;

            foreach (SnakePiece item in snakePieces)
            {
                if ((item.Top == headY && item.Left == headX) || 
                    headY < 0 || headY == screenHeight || 
                    headX < 0 || headX == screenWidth) //TODO-screen size-hoz igazítás
                {
                    timer.Stop();
                    restartButton.Visible = true;
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
                apple.Left = rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                apple.Top = rnd.Next(0, screenHeight / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                apples.Add(apple);
            }

            //new poison
            if (moves % 5 == 0)
            {
                Poison poison = new Poison();
                poison.Left = rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                poison.Top = rnd.Next(0, screenHeight / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                poisons.Add(poison);
            }

            //speeding
            if (moves % 20 == 0) { speed -= 20; }

            //add snake
            foreach (SnakePiece piece in snakePieces)
            {
                Controls.Add(piece);
            }

            //add apple or grow snake
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

            foreach (Poison poison in poisons)
            {
                if (poison.Left == headX && poison.Top == headY)
                {
                    timer.Stop();
                    restartButton.Visible = true;
                }
                else
                {
                    Controls.Add(poison);
                }

            }

            //saving last position
            foreach (SnakePiece piece in snakePieces)
            {
                lastX = piece.Left; 
                lastY = piece.Top;  
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            startButton.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && dirY != 1 &&
                snakePieces[0].Top - 20 != snakePieces[1].Top && snakePieces[0].Left != snakePieces[1].Left) { dirX = 0; dirY = -1; }
            if (e.KeyCode == Keys.S && dirY != -1 &&
                snakePieces[0].Top + 20 != snakePieces[1].Top && snakePieces[0].Left != snakePieces[1].Left) { dirX = 0; dirY = 1; }
            if (e.KeyCode == Keys.A && dirX != 1 &&
                snakePieces[0].Top != snakePieces[1].Top && snakePieces[0].Left - 20 != snakePieces[1].Left) { dirX = -1; dirY = 0; }
            if (e.KeyCode == Keys.D && dirX != -1 &&
                snakePieces[0].Top != snakePieces[1].Top && snakePieces[0].Left + 20 != snakePieces[1].Left) { dirX = 1; dirY = 0; }
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

        private void restartButton_Click(object sender, EventArgs e)
        {
            speed = 500;

            headX = 60;
            headY = 40;
            dirX = 1;
            dirY = 0;

            foreach (SnakePiece piece in snakePieces)
            {
                Controls.Remove(piece);
            }

            foreach (Apple piece in apples)
            {
                Controls.Remove(piece);
            }

            foreach (Poison piece in poisons)
            {
                Controls.Remove(piece);
            }

            snakePieces.Clear();
            apples.Clear();
            poisons.Clear();

            SnakePiece sp1 = new SnakePiece
            {
                Left = 40,
                Top = 40
            };
            SnakePiece sp2 = new SnakePiece
            {
                Left = 60,
                Top = 40
            };

            snakePieces.Add(sp1);
            snakePieces.Add(sp2);

            timer.Start();

            restartButton.Visible = false;
        }
    }
}
