using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* adatbázis
 * jobb alma
 * random dolgot csináló kocka(minusz egy hossz, gyorsaság, plusz hossz, lefagy)
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

        int supriseFrequent = 30;
        int nextLevelLength = 5;

        int playerCount = 0;



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
        bool freez1 = false;
        int freez1count;

        int dirX2 = -1;
        int dirY2 = 0;
        int headX2 = 1260;
        int headY2 = 100;
        int lastX2;
        int lastY2;
        int length2;
        int point2;
        bool freez2 = false;
        int freez2count;

        Timer timer = new Timer();
        Random rnd = new Random();

        static List<SnakePiece> snakePieces1 = new List<SnakePiece>();
        static List<SnakePiece> snakePieces2 = new List<SnakePiece>();

        List<Apple> apples = new List<Apple>();
        List<Poison> poisons = new List<Poison>();
        List<SupriseFood> suprises = new List<SupriseFood>();

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

            if (!freez1)
            {
                headX1 += dirX1 * SnakePiece.snakeSize;
                headY1 += dirY1 * SnakePiece.snakeSize;
            }
            if (!freez2)
            {
                headX2 += dirX2 * SnakePiece.snakeSize;
                headY2 += dirY2 * SnakePiece.snakeSize;
            }


            CheckingHiting(headX1, headY1, winnerLabel, restartButton, snakePieces1, "player 2", level, playerCount);
            if (playerCount == 2)
            {
                CheckingHiting(headX2, headY2, winnerLabel, restartButton, snakePieces2, "player 1", level, playerCount);
            }

            //moving snakes
            if (!freez2 && playerCount == 2)
            {
                CutOffSnakePiece(snakePieces2);
                AddSnakePiece(headX2, headY2, snakePieces2);
            }

            if (!freez1)
            {
                CutOffSnakePiece(snakePieces1);
                AddSnakePiece(headX1, headY1, snakePieces1);
            }

            freez1count++;
            freez2count++;

            //check freez end
            if (freez1count == 20)
            {
                freez1 = false;
            }
            if (freez2count == 20)
            {
                freez2 = false;
            }

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

            //new suprise
            if (moves % supriseFrequent == 0)
            {
                NewSuprise(level);
            }

            //speeding
            if (moves % 20 == 0 && speed > 100) { speed -= 20; timer.Interval = speed; }

            //draw snake
            DrawSnake(snakePieces1);
            if (playerCount == 2)
            {
                DrawSnake(snakePieces2);
            }

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
                    Winner2();
                }
                else if (poison.Left == headX2 && poison.Top == headY2)
                {
                    Winner1();
                }
                else
                {
                    Controls.Add(poison);
                }
            }

            //add suprise or do something
            foreach (SupriseFood suprise in suprises)
            {
                if (suprise.Left == headX1 && suprise.Top == headY1)
                {
                    suprises.Remove(suprise);
                    Controls.Remove(suprise);
                    int s = rnd.Next(3);
                    if (s == 0)
                    {
                        AddNewSnakePiece(snakePieces1, lastX1, lastY1);
                    }
                    if (s == 1)
                    {
                        if (snakePieces1.Count() == 1)
                        {
                            Winner2();
                        }
                        else
                        {
                        CutOffSnakePiece(snakePieces1);
                        length1--;
                        }
                    }
                    if (s == 2)
                    {
                        freez1 = true;
                        freez1count = 0;
                    }
                    return;
                }
                else if (suprise.Left == headX2 && suprise.Top == headY2)
                {
                    suprises.Remove(suprise);
                    Controls.Remove(suprise);
                    int s = rnd.Next(3);
                    if (s == 0)
                    {
                        AddNewSnakePiece(snakePieces2, lastX2, lastY2);
                    }
                    if (s == 1)
                    {
                        if (snakePieces2.Count() == 1)
                        {
                            Winner1();
                        }
                        else
                        {
                            CutOffSnakePiece(snakePieces2);
                            length2--;
                        }
                    }
                    if (s == 2)
                    {
                        freez2 = true;
                        freez2count = 0;
                    }
                    return;
                }
                else
                {
                    Controls.Add(suprise);
                }
            }


            if (playerCount == 2)
            {
                if (snakePieces1[snakePieces1.Count - 1].Top == snakePieces2[snakePieces2.Count - 1].Top &&
                    snakePieces1[snakePieces1.Count - 1].Left == snakePieces2[snakePieces2.Count - 1].Left)
                {
                    timer.Stop();
                    winnerLabel.Text = "It's draw!!";
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;

                    return;
                }
            }


            //check crushing - TODO - egybe a checkHitingel
            if (playerCount == 2)
            {
                foreach (SnakePiece item in snakePieces1)
            {
                if (headY2 == item.Top && headX2 == item.Left && item != snakePieces1[0])
                {
                    Winner1();
                }
            }

                foreach (SnakePiece item in snakePieces2)
            {
                if (headY1 == item.Top && headX1 == item.Left && item != snakePieces2[0])
                {
                    Winner2();
                }
            }
            }

            //writing labels
            if (playerCount == 2)
            {
                score1Label.Text = $"Snake 1 length: {length1 + 2}   Snake 2 length: {length2 + 2}";
                pointLabel.Text = $"Snake 1 points: {point1}   Snake 2 points: {point2}";
            }

            if (playerCount == 2)
            {
                if (length1 == nextLevelLength)
                {
                    Winner1(true);
                }
                if (length2 == nextLevelLength)
                {
                    Winner2(true);
                }
            }

            //drawing levels
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
            if (e.KeyCode == Keys.Up && dirY1 != 1) { dirX1 = 0; dirY1 = -1; }
            if (e.KeyCode == Keys.Down && dirY1 != -1) { dirX1 = 0; dirY1 = 1; }
            if (e.KeyCode == Keys.Left && dirX1 != 1) { dirX1 = -1; dirY1 = 0; }
            if (e.KeyCode == Keys.Right && dirX1 != -1) { dirX1 = 1; dirY1 = 0; }

            if (e.KeyCode == Keys.W && dirY2 != 1) { dirX2 = 0; dirY2 = -1; }
            if (e.KeyCode == Keys.S && dirY2 != -1) { dirX2 = 0; dirY2 = 1; }
            if (e.KeyCode == Keys.A && dirX2 != 1) { dirX2 = -1; dirY2 = 0; }
            if (e.KeyCode == Keys.D && dirX2 != -1) { dirX2 = 1; dirY2 = 0; }
        }//TODo -if (e.KeyCode == Keys.W && dirY1 != 1 && snakePieces1[0].Top - 20 != snakePieces1[1].Top && snakePieces1[0].Left != snakePieces1[1].Left) { dirX1 = 0; dirY1 = -1;  

        //snake methods
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
        


        //drawings
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


        //new foods
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

        public void NewSuprise(int level)
        {
            if (level == 1)
            {
                SupriseFood suprise = new SupriseFood();
                suprise.Left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                suprise.Top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                suprises.Add(suprise);
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
                SupriseFood suprise = new SupriseFood();
                suprise.Left = left;
                suprise.Top = top;
                suprises.Add(suprise);
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
                SupriseFood suprise = new SupriseFood();
                suprise.Left = left;
                suprise.Top = top;
                suprises.Add(suprise);
            }
        }


        //others
        public void CheckingHiting(int headX, int headY, Label winnerLabel, Button restartButton, List<SnakePiece> snakeList, string winner, int level, int playerCount)
        {
            bool point = false;
            if (level == 1)
            {
                foreach (SnakePiece item in snakeList)
                {
                    if (((item.Top == headY && item.Left == headX) ||
                        headY < 60 || headY == screenHeight + 60 ||
                        headX < 60 || headX == screenWidth + 60) && item != snakeList[snakeList.Count()-1]) //TODO-screen size-hoz igazítás
                    {
                        timer.Stop();
                        winnerLabel.Text = winner + " is the winner4.";
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
                        ((headY == 200 || headY == 600) && headX >= 200 && headX < 1320) && playerCount == 2) //TODO-screen size-hoz igazítás
                    {
                        timer.Stop();
                        if (winner == "player 2" && !point) { point2++; point = true; }
                        if (winner == "player 1" && !point) { point1++; point = true; }
                        winnerLabel.Text = winner + " is the winner4.";
                        winnerLabel.Visible = true;
                        restartButton.Visible = true;
                    }
                    if ((item.Top == headY && item.Left == headX) ||
                        headY < 60 || headY == screenHeight + 60 ||
                        headX < 60 || headX == screenWidth + 60 ||
                        ((headY == 200 || headY == 600) && headX >= 200 && headX < 1320) && playerCount == 1) //TODO-screen size-hoz igazítás
                    {
                        timer.Stop();
                        winnerLabel.Text = "You lost. Your score: " + (length1+2);
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
                        winnerLabel.Text = winner + " is the winner4.";
                        winnerLabel.Visible = true;
                        restartButton.Visible = true;
                    }
                }
            }
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

            foreach (SupriseFood supriseFood in suprises)
            {
                Controls.Remove(supriseFood);
            }
        }


        //winners
        public void Winner1(bool nextLevel = false)
        {
            timer.Stop();
            point1++;
            winnerLabel.Text = "Player 1 is the winner.";
            winnerLabel.Visible = true;
            if (nextLevel) { nextLevelButton.Visible = true; }
            else { restartButton.Visible = true; }
        }

        public void Winner2(bool nextLevel = false)
        {
            timer.Stop();
            point2++;
            winnerLabel.Text = "Player 2 is the winner.";
            winnerLabel.Visible = true;
            if (nextLevel) { nextLevelButton.Visible = true; }
            else { restartButton.Visible = true; }
        }


        //buttons
        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                playerCount = int.Parse(playerList.Text);
            }
            catch (Exception)
            {
                errorLabel.Text = "set the player count";
                errorLabel.Visible = true;
                errorLabel.ForeColor = Color.Red;
            }

            if (playerCount > 0)
            {
                errorLabel.Visible = false;
                playerLabel.Visible = false;
                playerList.Visible = false;
                timer.Start();
                startButton.Visible = false;
            }
            if (playerCount == 1) { snakePieces2.Clear(); level = 2; }
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
            suprises.Clear();


            headX1 = 180;
            headY1 = 100;
            dirX1 = 1;
            dirY1 = 0;
            length1 = 0;
            freez1 = false;

            headX2 = 1260;
            headY2 = 100;
            dirX2 = -1;
            dirY2 = 0;
            length2 = 0;
            freez2 = false;

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
            suprises.Clear();


            headX1 = 180;
            headY1 = 100;
            dirX1 = 1;
            dirY1 = 0;
            length1 = 0;
            freez1 = false;

            headX2 = 1260;
            headY2 = 100;
            dirX2 = -1;
            dirY2 = 0;
            length2 = 0;
            freez2 = false;

            StartingSnakePieces(160, 100, 180, 100, 1280, 100, 1260, 100);

            winnerLabel.Visible = false;
            restartButton.Visible = false;

            timer.Start();
        }
    }
}

