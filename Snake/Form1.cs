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
    public partial class form1 : Form
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
        int headX2 = 860;
        int headY2 = 100;
        int lastX2;
        int lastY2;
        int score2;

        static List<SnakePiece> snakePieces1 = new List<SnakePiece>();
        static List<SnakePiece> snakePieces2 = new List<SnakePiece>();

        List<Apple> apples = new List<Apple>();
        List<Poison> poisons = new List<Poison>();

        public form1()
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


            StartingSnakePieces(50, 100, 60, 100, 850, 100, 860, 100);

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
            Text = $"{moves}.lépés, sebesség:{speed}, headX1:{headX1}, headY1:{headY1}, headX2:{headX2}, headY2:{headY2}, hossz:{snakePieces1.LongCount()}";

            
            headX1 += dirX1 * SnakePiece.snakeSize;
            headY1 += dirY1 * SnakePiece.snakeSize;

            headX2 += dirX2 * SnakePiece.snakeSize;
            headY2 += dirY2 * SnakePiece.snakeSize;


            foreach (SnakePiece item in snakePieces1)
            {
                if ((item.Top == headY1 && item.Left == headX1) || 
                    headY1 < 0 || headY1 == screenHeight || 
                    headX1 < 0 || headX1 == screenWidth) //TODO-screen size-hoz igazítás
                {
                    timer.Stop();
                    winner = "player2";
                    winnerLabel.Text = "Player 2 is the winner.";
                    winnerLabel.Visible = true;
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
                    winner = "player1";
                    winnerLabel.Text = "Player 1 is the winner.";
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;
                }

            }

            score1Label.Text = $"Score1: {score1}   Score2: {score2}";

            //last snake piece remove
            //CutOffSnakePiece();
            SnakePiece cutOff2 = snakePieces2[0];
            Controls.Remove(cutOff2);
            snakePieces2.Remove(cutOff2);
            SnakePiece cutOff1 = snakePieces1[0];
            Controls.Remove(cutOff1);
            snakePieces1.Remove(cutOff1);

            //new snake piece add
            AddSnakePiece(headX1, headY1, snakePieces1);
            AddSnakePiece(headX2, headY2, snakePieces2);

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
                poison.Top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                poisons.Add(poison);
            }
            
            //speeding
            if (moves % 20 == 0 && speed > 100) { speed -= 20; timer.Interval = speed; }

            //draw snake
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
                    newPiece.Left = lastX2;
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
                    winner = "player2";
                    winnerLabel.Text = "Player 2 is the winner.";
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;
                }
                else if (poison.Left == headX2 && poison.Top == headY2)
                {
                    timer.Stop();
                    winner = "player1";
                    winnerLabel.Text = "Player 1 is the winner.";
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;
                }
                else
                {
                    Controls.Add(poison);
                }

            }

            if (snakePieces1[snakePieces1.Count-1].Top == snakePieces2[snakePieces2.Count-1].Top && 
                snakePieces1[snakePieces1.Count-1].Left == snakePieces2[snakePieces2.Count-1].Left)
            {
                timer.Stop();
                winner = "draw";
                winnerLabel.Text = "It's draw!!";
                winnerLabel.Visible = true;
                restartButton.Visible = true;
            }

            foreach (SnakePiece item in snakePieces1)
            {
                if (headY2 == item.Top && headX2 == item.Left && item != snakePieces1[0])
                {
                    timer.Stop();
                    winner = "player1";
                    winnerLabel.Text = "Player 1 is the winner.";
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;
                }
            }

            foreach (SnakePiece item in snakePieces2)
            {
                if (headY1 == item.Top && headX1 == item.Left && item != snakePieces2[0])
                {
                    timer.Stop();
                    winner = "player2";
                    winnerLabel.Text = "Player 2 is the winner.";
                    winnerLabel.Visible = true;
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
                lastX2 = piece.Left;
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
        
        static void AddSnakePiece(int x, int y, List<SnakePiece> snakeList)
        {
            SnakePiece newPiece = new SnakePiece();     
            newPiece.Left = x;
            newPiece.Top = y;
            snakeList.Add(newPiece);
        }

        static void CutOffSnakePiece(List<SnakePiece> snakeList)
        {
            SnakePiece cutOff = snakeList[0];
            //Controls.Remove(cutOff);
            snakeList.Remove(cutOff);
        }

        static void StartingSnakePieces(int x11, int y11, int x12, int y12, int x21, int y21, int x22, int y22)
        {
            //starting snake snakePieces1
            SnakePiece sp11 = new SnakePiece
            {
                Left = x11,
                Top = y11
            };
            SnakePiece sp12 = new SnakePiece
            {
                Left = x12,
                Top = y12
            };
            snakePieces1.Add(sp11);
            snakePieces1.Add(sp12);

            SnakePiece sp21 = new SnakePiece
            {
                Left = x21,
                Top = y21
            };
            SnakePiece sp22 = new SnakePiece
            {
                Left = x22,
                Top = y22
            };
            snakePieces2.Add(sp21);
            snakePieces2.Add(sp22);
        }


        private void restartButton_Click(object sender, EventArgs e)
        {
            speed = 500;

            headX1 = 60;
            headY1 = 100;
            dirX1 = 1;
            dirY1 = 0;
            score1 = 0;
            headX2 = 860;
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

            StartingSnakePieces(50, 100, 60, 100, 850, 100, 860, 100);
            winnerLabel.Visible = false;

            timer.Start();

            restartButton.Visible = false;
        }
    }
}

