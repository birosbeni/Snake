using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 1 v 2 player
 * szintek
 * jobb alma, snake
 * nem 20, hanem 5 px-es mozgás
 * random dolgot csináló kocka(minusz egy hossz, gyorsaság, plusz hossz, másik lefagy)
 */

namespace Snake
{
    public partial class form1 : Form
    {
        //screen sizes(must be divisibly by SnakePiece.snakeSize)
        public static int screenWidth = 1400;
        public static int screenHeight = 700;
        int speed = 300;
        int appleFrequent = 10;
        int poisonFrequent = 50;
        int nextLevelLength = 2;

        int moves;
        int level = 1;

        int dirX1 = 1;
        int dirY1 = 0;
        int headX1 = 180;
        int headY1 = 100;
        int lastX1;
        int lastY1;
        int length1;
        int point1;

        int dirX2 = -1;
        int dirY2 = 0;
        int headX2 = 1260;
        int headY2 = 100;
        int lastX2;
        int lastY2;
        int length2;
        int point2;

        Timer timer = new Timer();
        Random rnd = new Random();

        static List<SnakePiece> snakePieces1 = new List<SnakePiece>();
        static List<SnakePiece> snakePieces2 = new List<SnakePiece>();

        List<Apple> apples = new List<Apple>();
        List<Poison> poisons = new List<Poison>();

        public form1()
        {
            InitializeComponent();

            //line drawing
            DrawLine(56, 60, 1400, 4, Color.Black); //top
            DrawLine(756, 60, 1400, 4, Color.Black); //bottom
            DrawLine(56, 60, 4, 700, Color.Black); //left
            DrawLine(56, 1460, 4, 700, Color.Black); //right


            StartingSnakePieces(160, 100, 180, 100, 1280, 100, 1260, 100);

            //timer settings
            timer.Interval = speed;
            timer.Tick += Timer_Tick;

            KeyDown += Form1_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            moves++;
            Text = $"{moves}.lépés, sebesség:{speed}, headX1:{headX1}, headY1:{headY1}, headX2:{headX2}, headY2:{headY2}, hossz1:{snakePieces1.LongCount()}, hossz2:{snakePieces2.LongCount()}";

            headX1 += dirX1 * SnakePiece.snakeSize;
            headY1 += dirY1 * SnakePiece.snakeSize;

            headX2 += dirX2 * SnakePiece.snakeSize;
            headY2 += dirY2 * SnakePiece.snakeSize;

            CheckingHiting(headX1, headY1, winnerLabel, restartButton, snakePieces1, "player 2", level);
            CheckingHiting(headX2, headY2, winnerLabel, restartButton, snakePieces2, "player 1", level);

            //last snake piece remove
            CutOffSnakePiece(snakePieces2);
            CutOffSnakePiece(snakePieces1);

            //new snake piece add
            AddSnakePiece(headX1, headY1, snakePieces1);
            AddSnakePiece(headX2, headY2, snakePieces2);

            //new apple
            if (moves % appleFrequent == 0)
            {
                NewApple(level);
            }

            //new poison
            if (moves % poisonFrequent == 0)
            {
                NewPoison(level);
            }

            //speeding
            if (moves % 20 == 0 && speed > 100) { speed -= 20; timer.Interval = speed; }

            //draw snake
            DrawSnake(snakePieces1);
            DrawSnake(snakePieces2);

            //add apple or grow snake
            foreach (Apple apple in apples)
            {
                if (apple.Left == headX1 && apple.Top == headY1)
                {
                    apples.Remove(apple);
                    Controls.Remove(apple);

                    AddNewSnakePiece(snakePieces1, lastX1, lastY1);

                    return;
                }
                else if (apple.Left == headX2 && apple.Top == headY2)
                {
                    apples.Remove(apple);
                    Controls.Remove(apple);

                    AddNewSnakePiece(snakePieces2, lastX2, lastY2);

                    return;
                }
                else
                {
                    Controls.Add(apple);
                }
            }

            //add posion or game end
            foreach (Poison poison in poisons)
            {
                if (poison.Left == headX1 && poison.Top == headY1)
                {
                    timer.Stop();
                    point2++;
                    winnerLabel.Text = "Player 2 is the winner.";
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;
                }
                else if (poison.Left == headX2 && poison.Top == headY2)
                {
                    timer.Stop();
                    point1++;
                    winnerLabel.Text = "Player 1 is the winner.";
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;
                }
                else
                {
                    Controls.Add(poison);
                }

            }

            if (snakePieces1[snakePieces1.Count - 1].Top == snakePieces2[snakePieces2.Count - 1].Top &&
                snakePieces1[snakePieces1.Count - 1].Left == snakePieces2[snakePieces2.Count - 1].Left)
            {
                timer.Stop();
                winnerLabel.Text = "It's draw!!";
                winnerLabel.Visible = true;
                restartButton.Visible = true;

                return;
            }


            //check crushing - TODO - egybe a checkHitingel
            foreach (SnakePiece item in snakePieces1)
            {
                if (headY2 == item.Top && headX2 == item.Left && item != snakePieces1[0])
                {
                    timer.Stop();
                    point1++;
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
                    point2++;
                    winnerLabel.Text = "Player 2 is the winner.";
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;
                }
            }

            //writing labels
            score1Label.Text = $"Snake 1 length: {length1 + 2}   Snake 2 length: {length2 + 2}";
            pointLabel.Text = $"Snake 1 points: {point1}   Snake 2 points: {point2}";


            if (length1 == nextLevelLength)
            {
                timer.Stop();
                point1++;
                winnerLabel.Text = "Player 1 is the winner.";
                winnerLabel.Visible = true;
                nextLevelButton.Visible = true;
            }
            if (length2 == nextLevelLength)
            {
                timer.Stop();
                point2++;
                winnerLabel.Text = "Player 2 is the winner.";
                winnerLabel.Visible = true;
                nextLevelButton.Visible = true;
            }

            DrawLevels(level);

            //saving last position
            foreach (SnakePiece piece in snakePieces1)
            {
                lastX1 = piece.Left;
                lastY1 = piece.Top;
            }
            foreach (SnakePiece piece in snakePieces2)
            {
                lastX2 = piece.Left;
                lastY2 = piece.Top;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && dirY1 != 1) { dirX1 = 0; dirY1 = -1; }
            if (e.KeyCode == Keys.S && dirY1 != -1) { dirX1 = 0; dirY1 = 1; }
            if (e.KeyCode == Keys.A && dirX1 != 1) { dirX1 = -1; dirY1 = 0; }
            if (e.KeyCode == Keys.D && dirX1 != -1) { dirX1 = 1; dirY1 = 0; }

            if (e.KeyCode == Keys.Up && dirY2 != 1) { dirX2 = 0; dirY2 = -1; }
            if (e.KeyCode == Keys.Down && dirY2 != -1) { dirX2 = 0; dirY2 = 1; }
            if (e.KeyCode == Keys.Left && dirX2 != 1) { dirX2 = -1; dirY2 = 0; }
            if (e.KeyCode == Keys.Right && dirX2 != -1) { dirX2 = 1; dirY2 = 0; }
        }//TODo -if (e.KeyCode == Keys.W && dirY1 != 1 && snakePieces1[0].Top - 20 != snakePieces1[1].Top && snakePieces1[0].Left != snakePieces1[1].Left) { dirX1 = 0; dirY1 = -1;  

        public void AddSnakePiece(int x, int y, List<SnakePiece> snakeList)
        {
            SnakePiece newPiece = new SnakePiece();
            newPiece.Left = x;
            newPiece.Top = y;
            snakeList.Add(newPiece);
        }

        public void CutOffSnakePiece(List<SnakePiece> snakeList)
        {
            SnakePiece cutOff = snakeList[0];
            Controls.Remove(cutOff);
            snakeList.Remove(cutOff);
        }

        public void AddNewSnakePiece(List<SnakePiece> snakeList, int lastX, int lastY)
        {
            List<SnakePiece> newsnakePieces = new List<SnakePiece>();

            //TODO-AddSnakePiece akármilyen listára
            SnakePiece newPiece = new SnakePiece();
            newPiece.Left = lastX;
            newPiece.Top = lastY;
            newsnakePieces.Add(newPiece);
            foreach (SnakePiece piece in snakeList)
            {
                newsnakePieces.Add(piece);
            }

            if (snakeList == snakePieces1) { snakePieces1 = newsnakePieces; length1++; }
            else { snakePieces2 = newsnakePieces; length2++; }
        }

        public void DrawSnake(List<SnakePiece> snakeList)
        {
            foreach (SnakePiece piece in snakeList) { Controls.Add(piece); }
        }

        public void DrawLine(int top, int left, int width, int height, Color color)
        {
            Label line = new Label();
            line.Top = top;
            line.Left = left;
            line.Width = width;
            line.Height = height;
            line.BackColor = color;
            line.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(line);
        }

        public void CheckingHiting(int headX, int headY, Label winnerLabel, Button restartButton, List<SnakePiece> snakeList, string winner, int level)
        {
            bool point = false;
            if (level == 1)
            {
                foreach (SnakePiece item in snakeList)
                {
                    if ((item.Top == headY && item.Left == headX) ||
                        headY < 60 || headY == screenHeight + 60 ||
                        headX < 60 || headX == screenWidth + 60) //TODO-screen size-hoz igazítás
                    {
                        timer.Stop();
                        winnerLabel.Text = winner + " is the winner.";
                        if (winner == "player 2" && !point) { point2++; point = true; }
                        if (winner == "player 1" && !point) { point1++; point = true; }
                        winnerLabel.Visible = true;
                        restartButton.Visible = true;
                    }
                }
            }
            if (level == 2)
            {
                foreach (SnakePiece item in snakeList)
                {
                    if ((item.Top == headY && item.Left == headX) ||
                        headY < 60 || headY == screenHeight + 60 ||
                        headX < 60 || headX == screenWidth + 60 ||
                        ((headY == 200 || headY == 600) && headX >= 200 && headX < 1320)) //TODO-screen size-hoz igazítás
                    {
                        timer.Stop();
                        if (winner == "player 2" && !point) { point2++; point = true; }
                        if (winner == "player 1" && !point) { point1++; point = true; }
                        winnerLabel.Text = winner + " is the winner.";
                        winnerLabel.Visible = true;
                        restartButton.Visible = true;
                    }
                }
            }
            if (level >= 3)
            {
                foreach (SnakePiece item in snakeList)
                {
                    if ((item.Top == headY && item.Left == headX) ||
                        headY < 60 || headY == screenHeight + 60 ||
                        headX < 60 || headX == screenWidth + 60 ||
                        ((headY == 200 || headY == 600) && headX >= 200 && headX < 1320) ||
                        ((headX == 300 || headX == 1220) && headY >= 260 && headY < 560)) //TODO-screen size-hoz igazítás
                    {
                        timer.Stop();
                        if (winner == "player 2" && !point) { point2++; point = true; }
                        if (winner == "player 1" && !point) { point1++; point = true; }
                        winnerLabel.Text = winner + " is the winner.";
                        winnerLabel.Visible = true;
                        restartButton.Visible = true;
                    }
                }
            }
        }

        public void StartingSnakePieces(int x11, int y11, int x12, int y12, int x21, int y21, int x22, int y22)
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

        public void ControlsRemove()
        {
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
        }

        public void DrawLevels(int level)
        {
            if (level == 2)
            {
                DrawLine(200, 200, 1120, 20, Color.Black);
                DrawLine(600, 200, 1120, 20, Color.Black);
            }
            if (level >= 3)
            {
                DrawLine(260, 300, 20, 300, Color.Black);
                DrawLine(260, 1220, 20, 300, Color.Black);
            }
        }

        public void NewApple(int level)
        {
            if (level == 1)
            {
                Apple apple = new Apple();
                apple.Left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                apple.Top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                apples.Add(apple);
            }

            if (level == 2)
            {
                int left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                int top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                while ((top == 200 || top == 600) && left >= 200 && left < 1320)
                {
                    left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                    top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                }
                Apple apple = new Apple();
                apple.Left = left;
                apple.Top = top;
                apples.Add(apple);
            }

            if (level >= 3)
            {
                int left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                int top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                while (((top == 200 || top == 600) && left >= 200 && left < 1320) ||
                    ((left == 300 || left == 1220) && top >= 260 && top < 560))
                {
                    left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                    top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                }
                Apple apple = new Apple();
                apple.Left = left;
                apple.Top = top;
                apples.Add(apple);
            }
        }

        public void NewPoison(int level)
        {
            if (level == 1)
            {
                Poison poison = new Poison();
                poison.Left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                poison.Top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                poisons.Add(poison);
            }

            if (level == 2)
            {
                int left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                int top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                while ((top == 200 || top == 600) && left >= 200 && left < 1320)
                {
                    left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                    top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                }
                Poison poison = new Poison();
                poison.Left = left;
                poison.Top = top;
                poisons.Add(poison);
            }

            if (level >= 3)
            {
                int left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                int top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                while (((top == 200 || top == 600) && left >= 200 && left < 1320) ||
                    ((left == 300 || left == 1220) && top >= 260 && top < 560))
                {
                    left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                    top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                }
                Poison poison = new Poison();
                poison.Left = left;
                poison.Top = top;
                poisons.Add(poison);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            startButton.Visible = false;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            speed = 500;
            moves = 0;

            ControlsRemove();

            snakePieces1.Clear();
            snakePieces2.Clear();
            apples.Clear();
            poisons.Clear();


            headX1 = 180;
            headY1 = 100;
            dirX1 = 1;
            dirY1 = 0;
            length1 = 0;

            headX2 = 1260;
            headY2 = 100;
            dirX2 = -1;
            dirY2 = 0;
            length2 = 0;

            StartingSnakePieces(160, 100, 180, 100, 1280, 100, 1260, 100);

            winnerLabel.Visible = false;
            restartButton.Visible = false;

            timer.Start();
        }

        private void nextLevelButton_Click(object sender, EventArgs e)
        {
            nextLevelButton.Visible = false;
            speed = 500;
            level++;

            ControlsRemove();

            snakePieces1.Clear();
            snakePieces2.Clear();
            apples.Clear();
            poisons.Clear();


            headX1 = 180;
            headY1 = 100;
            dirX1 = 1;
            dirY1 = 0;
            length1 = 0;

            headX2 = 1260;
            headY2 = 100;
            dirX2 = -1;
            dirY2 = 0;
            length2 = 0;

            StartingSnakePieces(160, 100, 180, 100, 1280, 100, 1260, 100);

            winnerLabel.Visible = false;
            restartButton.Visible = false;

            timer.Start();
        }
    }
}

