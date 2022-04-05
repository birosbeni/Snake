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
        int speed = 300;
        int appleFrequent = 10;
        int poisonFrequent = 50;

        Timer timer = new Timer();
        Random rnd = new Random();

        int moves;
        //LAST
        string winner;

        int dirX1 = 1;
        int dirY1 = 0;
        int headX1 = 60;
        int headY1 = 100;
        int lastx1;
        int lastY1;
        int score1;

        int dirX2 = -1;
        int dirY2 = 0;
        int headX2 = 660;
        int headY2 = 100;
        int lastx2;
        int lastY2;
        int score2;

        List<SnakePiece> snakePieces1 = new List<SnakePiece>();
        List<SnakePiece> snakePieces2 = new List<SnakePiece>();

        List<Apple> apples = new List<Apple>();
        List<Poison> poisons = new List<Poison>();

        public Form1()
        {
            InitializeComponent();

            //line drawing
            Label labelSeperator = new Label();
            labelSeperator.Top = 56;
            labelSeperator.Left = 0;
            labelSeperator.Width = 1400;
            labelSeperator.AutoSize = false;
            labelSeperator.BackColor = Color.Black;
            labelSeperator.Height = 4;
            labelSeperator.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(labelSeperator);



            //starting snake snakePieces1
            SnakePiece sp11 = new SnakePiece
            {
                Left = 50,
                Top = 100
            };
            SnakePiece sp12 = new SnakePiece
            {
                Left = 60,
                Top = 100
            };
            snakePieces1.Add(sp11);
            snakePieces1.Add(sp12);

            SnakePiece sp21 = new SnakePiece
            {
                Left = 650,
                Top = 100
            };
            SnakePiece sp22 = new SnakePiece
            {
                Left = 660,
                Top = 100
            };
            snakePieces2.Add(sp21);
            snakePieces2.Add(sp22);




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
            //Text = $"{moves}.lépés, sebesség:{speed}, headX1:{headX1}, headY1:{headY1}, hossz:{snakePieces1.LongCount()}";

            //x2
            headX1 += dirX1 * SnakePiece.snakeSize;
            headY1 += dirY1 * SnakePiece.snakeSize;

            headX2 += dirX2 * SnakePiece.snakeSize;
            headY2 += dirY2 * SnakePiece.snakeSize;

            //x2
            foreach (SnakePiece item in snakePieces1)
            {
                if ((item.Top == headY1 && item.Left == headX1) || 
                    headY1 < 0 || headY1 == screenHeight || 
                    headX1 < 0 || headX1 == screenWidth) //TODO-screen size-hoz igazítás
                {
                    timer.Stop();
                    restartButton.Visible = true;
                }

            }

            foreach (SnakePiece item in snakePieces2)
            {
                if ((item.Top == headY2 && item.Left == headX2) ||
                    headY2 < 0 || headY2 == screenHeight ||
                    headX2 < 0 || headX2 == screenWidth) //TODO-screen size-hoz igazítás
                {
                    timer.Stop();
                    restartButton.Visible = true;
                }

            }

            score1Label.Text = $"Score1: {score1}   Score2: {score2}";

            //last snake piece remove
            CutOffSnakePiece();
            SnakePiece cutOff2 = snakePieces2[0];
            Controls.Remove(cutOff2);
            snakePieces2.Remove(cutOff2);

            //new snake piece add
            AddSnakePiece(headX1, headY1);
            SnakePiece newPiece2 = new SnakePiece();
            newPiece2.Left = headX2;
            newPiece2.Top = headY2;
            snakePieces2.Add(newPiece2);

            //new apple
            if (moves % appleFrequent == 0)
            {
                Apple apple = new Apple();
                apple.Left = rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                apple.Top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize-3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                apples.Add(apple);
            }

            //new poison
            if (moves % poisonFrequent == 0)
            {
                Poison poison = new Poison();
                poison.Left = rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                poison.Top = rnd.Next(0, screenHeight / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                poisons.Add(poison);
            }
            
            //speeding
            if (moves % 20 == 0 && speed > 100) { speed -= 20; timer.Interval = speed; }

            //add snake
            foreach (SnakePiece piece in snakePieces1)
            {
                Controls.Add(piece);
            }

            foreach (SnakePiece piece in snakePieces2)
            {
                Controls.Add(piece);
            }

            //add apple or grow snake
            foreach (Apple apple in apples)
            {
                if (apple.Left == headX1 && apple.Top == headY1)
                {
                    apples.Remove(apple);
                    Controls.Remove(apple);

                    List<SnakePiece> newsnakePieces1 = new List<SnakePiece>();

                    //TODO-AddSnakePiece akármilyen listára
                    SnakePiece newPiece = new SnakePiece();
                    newPiece.Left = lastx1;
                    newPiece.Top = lastY1;
                    newsnakePieces1.Add(newPiece);
                    foreach (SnakePiece piece in snakePieces1)
                    {
                        newsnakePieces1.Add(piece);
                    }

                    snakePieces1 = newsnakePieces1;
                    score1++;

                    return;
                }
                else if (apple.Left == headX2 && apple.Top == headY2)
                {
                    apples.Remove(apple);
                    Controls.Remove(apple);

                    List<SnakePiece> newsnakePieces2 = new List<SnakePiece>();

                    //TODO-AddSnakePiece akármilyen listára
                    SnakePiece newPiece = new SnakePiece();
                    newPiece.Left = lastx2;
                    newPiece.Top = lastY2;
                    newsnakePieces2.Add(newPiece);
                    foreach (SnakePiece piece in snakePieces2)
                    {
                        newsnakePieces2.Add(piece);
                    }

                    snakePieces2 = newsnakePieces2;
                    score2++;

                    return;
                }
                else
                {
                    Controls.Add(apple);
                }
            }

            foreach (Poison poison in poisons)
            {
                if (poison.Left == headX1 && poison.Top == headY1)
                {
                    timer.Stop();
                    restartButton.Visible = true;
                }
                else if (poison.Left == headX2 && poison.Top == headY2)
                {
                    timer.Stop();
                    restartButton.Visible = true;
                }
                else
                {
                    Controls.Add(poison);
                }

            }

            foreach (SnakePiece item in snakePieces1)
            {
                if (headY2 == item.Top && headX2 == item.Left)
                {
                    timer.Stop();
                    restartButton.Visible = true;
                }
            }

            foreach (SnakePiece item in snakePieces2)
            {
                if (headY1 == item.Top && headX1 == item.Left)
                {
                    timer.Stop();
                    restartButton.Visible = true;
                }
            }

            //saving last position
            foreach (SnakePiece piece in snakePieces1)
            {
                lastx1 = piece.Left; 
                lastY1 = piece.Top;  
            }
            foreach (SnakePiece piece in snakePieces2)
            {
                lastx2 = piece.Left;
                lastY2 = piece.Top;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            startButton.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && dirY1 != 1 ) { dirX1 = 0; dirY1 = -1; }
            if (e.KeyCode == Keys.S && dirY1 != -1 ) { dirX1 = 0; dirY1 = 1; }
            if (e.KeyCode == Keys.A && dirX1 != 1 ) { dirX1 = -1; dirY1 = 0; }
            if (e.KeyCode == Keys.D && dirX1 != -1 ) { dirX1 = 1; dirY1 = 0; }

            if (e.KeyCode == Keys.Up && dirY2 != 1) { dirX2 = 0; dirY2 = -1; }
            if (e.KeyCode == Keys.Down && dirY2 != -1) { dirX2 = 0; dirY2 = 1; }
            if (e.KeyCode == Keys.Left && dirX2 != 1) { dirX2 = -1; dirY2 = 0; }
            if (e.KeyCode == Keys.Right && dirX2 != -1) { dirX2 = 1; dirY2 = 0; }
        }//TODo -if (e.KeyCode == Keys.W && dirY1 != 1 && snakePieces1[0].Top - 20 != snakePieces1[1].Top && snakePieces1[0].Left != snakePieces1[1].Left) { dirX1 = 0; dirY1 = -1;  
        
        public void AddSnakePiece(int x, int y)
        {
            SnakePiece newPiece = new SnakePiece();     
            newPiece.Left = x;
            newPiece.Top = y;
            snakePieces1.Add(newPiece);
        }

        public void CutOffSnakePiece()
        {
            SnakePiece cutOff = snakePieces1[0];
            Controls.Remove(cutOff);
            snakePieces1.Remove(cutOff);
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            speed = 500;

            headX1 = 60;
            headY1 = 100;
            dirX1 = 1;
            dirY1 = 0;
            score1 = 0;
            headX2 = 660;
            headY2 = 100;
            dirX2 = -1;
            dirY2 = 0;
            score2 = 0;

            foreach (SnakePiece piece in snakePieces1)
            {
                Controls.Remove(piece);
            }

            foreach (SnakePiece piece in snakePieces2)
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

            snakePieces1.Clear();
            snakePieces2.Clear();
            apples.Clear();
            poisons.Clear();

            SnakePiece sp1 = new SnakePiece
            {
                Left = 40,
                Top = 100
            };
            SnakePiece sp2 = new SnakePiece
            {
                Left = 60,
                Top = 100
            };

            snakePieces1.Add(sp1);
            snakePieces1.Add(sp2);


            SnakePiece sp21 = new SnakePiece
            {
                Left = 650,
                Top = 100
            };
            SnakePiece sp22 = new SnakePiece
            {
                Left = 660,
                Top = 100
            };
            snakePieces2.Add(sp21);
            snakePieces2.Add(sp22);

            timer.Start();

            restartButton.Visible = false;
        }
    }
}
