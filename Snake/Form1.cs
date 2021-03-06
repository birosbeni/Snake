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
        int speed = 300;
        int appleFrequent = 15;
        int poisonFrequent = 50;
        int supriseFrequent = 30;
        static int screenWidth = 1400;
        static int screenHeight = 700;

        int maxApples = 5;
        int maxPoisons = 3;
        int maxSuprises = 3;
        int nextLevelLength = 3;

        int playerCount;

        bool signedIn = false;
        bool inGame = false;

        int moves;
        int passedTime;
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
        Player player1;

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
        Timer time = new Timer();
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
            DrawLine(30, 60, 1400, 30, Color.Black); //top
            DrawLine(760, 60, 1400, 30, Color.Black); //bottom
            DrawLine(0, 30, 30, 790, Color.Black); //left
            DrawLine(0, 1460, 30, 790, Color.Black); //right
            //DrawLine(0, 60, 1400, 30, Color.Green);

            moveCountLabel.BackColor = System.Drawing.Color.Transparent;

            //timer settings
            timer.Interval = speed;
            timer.Tick += Timer_Tick;

            time.Interval = 1000;
            time.Tick += Time_Tick;

            KeyDown += Form1_KeyDown;
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            passedTime++;
            timeLabel.Text = $"Passed time: {(passedTime / 60).ToString()}:{(passedTime % 60 < 10 ? "0" + (passedTime % 60).ToString() : (passedTime % 60).ToString()).ToString()}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1540, 860);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            moves++;
            moveCountLabel.Text = "moves: " + moves.ToString();

            if (!freez1)
            {
                headX1 += dirX1 * SnakePiece.snakeSize;
                headY1 += dirY1 * SnakePiece.snakeSize;
            }
            if (!freez2 && playerCount == 2)
            {
                headX2 += dirX2 * SnakePiece.snakeSize;
                headY2 += dirY2 * SnakePiece.snakeSize;
            }

            CheckingHiting(headX1, headY1, winnerLabel, restartButton, snakePieces1, "player 2", level, playerCount);
            if (playerCount == 2) CheckingHiting(headX2, headY2, winnerLabel, restartButton, snakePieces2, "player 1", level, playerCount);

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
            if (freez1count == 20) freez1 = false;
            if (freez2count == 20) freez2 = false;

            //new foods
            if (moves % appleFrequent == 0 && apples.Count < maxApples) NewApple(level);
            if (moves % poisonFrequent == 0 && poisons.Count < maxPoisons) NewPoison(level);
            if (moves % supriseFrequent == 0 && suprises.Count < maxSuprises) NewSuprise(level);

            //speeding
            if (moves % 20 == 0 && speed > 100) { speed -= 20; timer.Interval = speed; }

            //draw snake
            DrawSnake(snakePieces1);
            if (playerCount == 2) DrawSnake(snakePieces2);

            //add apple or grow snake
            foreach (Apple apple in apples)
            {
                if ((apple.Left == headX1 && apple.Top == headY1) || (apple.Left == headX2 && apple.Top == headY2))
                {
                    apples.Remove(apple);
                    Controls.Remove(apple);
                    if (apple.Left == headX1 && apple.Top == headY1) AddNewSnakePiece(snakePieces1, lastX1, lastY1);
                    else AddNewSnakePiece(snakePieces2, lastX2, lastY2);

                    return;
                }
                else Controls.Add(apple);
            }

            //add posion or game end
            foreach (Poison poison in poisons)
            {
                if (poison.Left == headX1 && poison.Top == headY1 && playerCount == 2)
                {
                    Winner(2);
                }
                else if (poison.Left == headX2 && poison.Top == headY2 && playerCount == 2)
                {
                    Winner(1);
                }
                else if (poison.Left == headX1 && poison.Top == headY1 && playerCount == 1)
                {
                    timer.Stop();
                    time.Stop();
                    winnerLabel.Text = "You died. Your score: " + (length1 + 2);
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;
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
                            Winner(2);
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
                            Winner(1);
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
                    time.Stop();
                    winnerLabel.Text = "It's draw!!";
                    winnerLabel.Visible = true;
                    restartButton.Visible = true;

                    return;
                }
            }


            if (playerCount == 2)
            {
                foreach (SnakePiece item in snakePieces1)
                {
                    if (headY2 == item.Top && headX2 == item.Left && item != snakePieces1[0]) { Winner(1); }
                }

                foreach (SnakePiece item in snakePieces2)
                {
                    if (headY1 == item.Top && headX1 == item.Left && item != snakePieces2[0]) { Winner(2); }
                }
            }

            //writing labels
            if (playerCount == 2)
            {
                score1Label.Text = $"Player 1 length: {length1 + 2}   Player 2 length: {length2 + 2}";
                pointLabel.Text = $"Player 1 points: {point1}   Player 2 points: {point2}";
            }
            else
            {
                score1Label.Text = $"{player1.name}'s score: {length1 + 2}";
            }

            if (playerCount == 2)
            {
                if (length1 == nextLevelLength)
                {
                    Winner(1, true);
                }
                if (length2 == nextLevelLength)
                {
                    Winner(2, true);
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

        //-------------------------------------------------------------------------------------------------------------------------------

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (inGame)
            {
                if (e.KeyCode == Keys.W && dirY1 != 1) { dirX1 = 0; dirY1 = -1; }
                if (e.KeyCode == Keys.S && dirY1 != -1) { dirX1 = 0; dirY1 = 1; }
                if (e.KeyCode == Keys.A && dirX1 != 1) { dirX1 = -1; dirY1 = 0; }
                if (e.KeyCode == Keys.D && dirX1 != -1) { dirX1 = 1; dirY1 = 0; }

                if (e.KeyCode == Keys.Up && dirY2 != 1) { dirX2 = 0; dirY2 = -1; }
                if (e.KeyCode == Keys.Down && dirY2 != -1) { dirX2 = 0; dirY2 = 1; }
                if (e.KeyCode == Keys.Left && dirX2 != 1) { dirX2 = -1; dirY2 = 0; }
                if (e.KeyCode == Keys.Right && dirX2 != -1) { dirX2 = 1; dirY2 = 0; }
            }
        }
        //if (e.KeyCode == Keys.W && dirY1 != 1 && snakePieces1[0].Top - 20 != snakePieces1[1].Top && snakePieces1[0].Left != snakePieces1[1].Left) { dirX1 = 0; dirY1 = -1;  

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

        public void StartingSnakePieces(int x11, int y11, int x12, int y12, int x21, int y21, int x22, int y22, int playerCount)
        {
            //starting snake snakePieces1
            SnakePiece sp11 = new SnakePiece { Left = x11, Top = y11 };
            SnakePiece sp12 = new SnakePiece { Left = x12, Top = y12 };
            snakePieces1.Add(sp11);
            snakePieces1.Add(sp12);

            SnakePiece sp21 = new SnakePiece { Left = x21, Top = y21 };
            SnakePiece sp22 = new SnakePiece { Left = x22, Top = y22 };

            if (playerCount == 2)
            {
                snakePieces2.Add(sp21);
                snakePieces2.Add(sp22);
            }
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
            //line.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(line);
        }

        //put out
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


        //new foods  put out
        public List<int> SetBounds(int level)
        {
            int top = 0;
            int left = 0;
            if (level == 1)
            {
                left = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                top = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
            }
            else if (level == 2)
            {
                int testLeft = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                int testTop = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                while ((testTop == 200 || testTop == 600) && testLeft >= 200 && testLeft < 1320)
                {
                    testLeft = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                    testTop = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                }
                left = testLeft;
                top = testTop;
            }

            if (level >= 3)
            {
                int testLeft = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                int testTop = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                while (((testTop == 200 || testTop == 600) && testLeft >= 200 && testLeft < 1320) ||
                    ((testLeft == 300 || testLeft == 1220) && testTop >= 260 && testTop < 560))
                {
                    testLeft = 80 + rnd.Next(0, screenWidth / SnakePiece.snakeSize) * SnakePiece.snakeSize - SnakePiece.snakeSize;
                    testTop = 80 + (rnd.Next(0, screenHeight / SnakePiece.snakeSize - 3) * SnakePiece.snakeSize - SnakePiece.snakeSize);
                }
                left = testLeft;
                top = testTop;
            }
            List<int> list = new List<int>();
            list.Add(left);
            list.Add(top);
            return list;
        }
        public void NewApple(int level)
        {
            List<int> list = SetBounds(level);
            Apple apple = new Apple();
            apple.Left = list[0];
            apple.Top = list[1];
            apples.Add(apple);
        }

        public void NewPoison(int level)
        {
            List<int> list = SetBounds(level);
            Poison poison = new Poison();
            poison.Left = list[0];
            poison.Top = list[1];
            poisons.Add(poison);
        }

        public void NewSuprise(int level)
        {
            List<int> list = SetBounds(level);
            SupriseFood suprise = new SupriseFood();
            suprise.Left = list[0];
            suprise.Top = list[1];
            suprises.Add(suprise);
        }


        //others
        public void CheckingHiting(int headX, int headY, Label winnerLabel, Button restartButton, List<SnakePiece> snakeList, string winner, int level, int playerCount)
        {
            bool point = false;
            if (level == 1)
            {
                foreach (SnakePiece item in snakeList)
                {
                    if (((item.Top == headY && item.Left == headX) || headY < 60 || headY == screenHeight + 60 ||
                        headX < 60 || headX == screenWidth + 60) && item != snakeList[snakeList.Count() - 1]) 
                    {
                        Hit(point, winner);
                    }
                }
            }
            if (level == 2)
            {
                bool saveScore = false;
                foreach (SnakePiece item in snakeList)
                {
                    if (((item.Top == headY && item.Left == headX) || headY < 60 || headY == screenHeight + 60 || headX < 60 || headX == screenWidth + 60 ||
                        ((headY == 200 || headY == 600) && headX >= 200 && headX < 1320)) && playerCount == 2 && item != snakeList[snakeList.Count() - 1]) 
                    {
                        Hit(point, winner);
                    }
                    if (((item.Top == headY && item.Left == headX) || headY < 60 || headY == screenHeight + 60 || headX < 60 || headX == screenWidth + 60 ||
                        ((headY == 200 || headY == 600) && headX >= 200 && headX < 1320)) && playerCount == 1 && item != snakeList[snakeList.Count() - 1]) 
                    {
                        timer.Stop();
                        time.Stop();
                        winnerLabel.Text = "You lost. Your score: " + (length1 + 2);
                        winnerLabel.Visible = true;
                        restartButton.Visible = true;
                        saveScore = true;
                    }
                }
                if (saveScore)
                {
                    int position = 1;
                    int lastId = 0;
                    List<Score> list = dbManager.GetScores();
                    foreach (Score score in list)
                    {
                        if (score.id > lastId) { lastId = score.id; }
                        if (length1 + 2 <= score.score) { position++; }
                    }
                    dbManager.AddScore(++lastId, player1.id, length1 + 2, DateTime.Now);
                    positionLabel.Text = "Your position is: " + position.ToString();
                    positionLabel.Visible = true;
                    List<Score> topScores = dbManager.GetTopScores();
                    topScoresLabel.Text = "";
                    foreach (Score score in topScores)
                    {
                        topScoresLabel.Text += $"Top {topScores.IndexOf(score) + 1} score: {score.score}\n";
                    }
                    topScoresLabel.Visible = true;
                }
            }
            if (level >= 3)
            {
                foreach (SnakePiece item in snakeList)
                {
                    if (((item.Top == headY && item.Left == headX) || headY < 60 || headY == screenHeight + 60 || headX < 60 || headX == screenWidth + 60 || 
                        ((headY == 200 || headY == 600) && headX >= 200 && headX < 1320) || ((headX == 300 || headX == 1220) && headY >= 260 && headY < 560)) 
                        && item != snakeList[snakeList.Count() - 1]) 
                    {
                        Hit(point, winner);
                    }
                }
            }
        }

        public void Hit(bool point, string winner)
        {
            timer.Stop();
            time.Stop();
            if (winner == "player 2" && !point) { point2++; point = true; }
            if (winner == "player 1" && !point) { point1++; point = true; }
            winnerLabel.Text = winner + " is the winner.";
            winnerLabel.Visible = true;
            restartButton.Visible = true;
        }

        public void ControlsRemove()
        {
            foreach (SnakePiece piece in snakePieces1) Controls.Remove(piece);

            foreach (SnakePiece piece in snakePieces2) Controls.Remove(piece);

            foreach (Apple piece in apples) Controls.Remove(piece);

            foreach (Poison piece in poisons) Controls.Remove(piece);

            foreach (SupriseFood supriseFood in suprises) Controls.Remove(supriseFood);
        }

        public void Winner(byte player, bool nextLevel = false)
        {
            if (player == 1)
            {
                point1++;
                winnerLabel.Text = "Player 1 is the winner.";
            }
            else
            {
                point2++;
                winnerLabel.Text = "Player 2 is the winner.";
            }
            timer.Stop();
            time.Stop();
            winnerLabel.Visible = true;
            if (nextLevel) { nextLevelButton.Visible = true; }
            else { restartButton.Visible = true; }
        }

        public void SetDbLabel(bool vis, Color color, string text = "")
        {
            dbLabel.Text = text;
            dbLabel.ForeColor = color;
            dbLabel.Visible = vis;
        }

        public void setLoginVisible(bool b)
        {
            nameLabel.Visible = b;
            nameTextbox.Visible = b;
            usernameLabel.Visible = b;
            usernameTextbox.Visible = b;
        }

        //click events
        private void setPlayerCountButton_Click(object sender, EventArgs e)
        {
            try
            {
                playerCount = int.Parse(playerList.Text);
                errorLabel.Visible = false;
            }
            catch (Exception)
            {
                errorLabel.Text = "set the player count";
                errorLabel.Visible = true;
                errorLabel.ForeColor = Color.Red;
            }
            if (playerCount > 0)
            {
                startButton.Visible = true;
                setPlayerCountButton.Visible = false;
            }
            if (playerCount == 1)
            {
                setLoginVisible(true);
                newAccountButton.Visible = true;
                signInButton.Visible = true;
            }
            if (playerCount > 2 || playerCount == 0)
            {
                errorLabel.Text = "set valid player count(1 or 2)";
                errorLabel.Visible = true;
                errorLabel.ForeColor = Color.Red;
                startButton.Visible = false;
                setPlayerCountButton.Visible = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (playerCount == 1 && !signedIn)
            {
                errorLabel.Text = "You need to sign in.";
                errorLabel.Visible = true;
                errorLabel.ForeColor = Color.Red;
            }
            if (signedIn || playerCount == 2)
            {

                if (playerCount > 0)
                {
                    errorLabel.Visible = false;
                    playerLabel.Visible = false;
                    playerList.Visible = false;
                    startButton.Visible = false;
                    newAccountButton.Visible = false;
                    dbLabel.Visible = false;
                    timer.Start();
                    time.Start();
                    inGame = true;
                }
                if (playerCount == 1) { level = 2; }
                StartingSnakePieces(160, 100, 180, 100, 1280, 100, 1260, 100, playerCount);
                setLoginVisible(false);
                signInButton.Visible = false;
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            speed = 300;
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

            StartingSnakePieces(160, 100, 180, 100, 1280, 100, 1260, 100, playerCount);

            winnerLabel.Visible = false;
            restartButton.Visible = false;
            topScoresLabel.Visible = false;
            positionLabel.Visible = false;

            timer.Start();
            passedTime = 0;
            time.Start();
        }

        private void nextLevelButton_Click(object sender, EventArgs e)
        {
            nextLevelButton.Visible = false;
            speed = 300;
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

            StartingSnakePieces(160, 100, 180, 100, 1280, 100, 1260, 100, playerCount);

            winnerLabel.Visible = false;
            restartButton.Visible = false;

            timer.Start();
            passedTime = 0;
            time.Start();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            List<Player> list = dbManager.GetPlayers();
            bool exist = false;
            string n = "";
            string un = "";
            try
            {
                n = nameTextbox.Text;
                un = usernameTextbox.Text;
            }
            catch (Exception)
            {
                Console.WriteLine("hiba");
            }

            foreach (Player item in list)
            {
                if (item.name == n && item.username == un)
                {
                    player1 = item;
                    signedIn = true;
                    SetDbLabel(true, Color.Black, "You are signed in");
                    break;
                }
                else
                {
                    SetDbLabel(true, Color.Red, "Nem létező felhasználó");
                }
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            List<Player> list = dbManager.GetPlayers();
            string n = "";
            string un = "";
            n = nameTextbox.Text;
            un = usernameTextbox.Text;
            if (n.Length > 0 && un.Length > 0)
            {
                int lastId = 0;
                foreach (Player player in list) { if (player.id > lastId) { lastId = player.id; } }

                bool freeName = true;
                bool freeUsername = true;
                foreach (Player player in list)
                {
                    if (player.username == un)
                    {
                        SetDbLabel(true, Color.Red, "The username is taken.");
                        freeUsername = false;
                    }
                    if (player.name == n)
                    {
                        SetDbLabel(true, Color.Red, "The name is taken.");
                        freeName = false;
                    }
                }
                if (freeUsername && freeName)
                {
                    dbManager.AddPlayer(++lastId, n, un);
                    signInButton.Visible = true;
                    registerButton.Visible = false;
                    SetDbLabel(true, Color.Black, "Succesfull registration. Sign in.");
                }
            }
            else
            {
                SetDbLabel(true, Color.Red, "Add a name and username.");
            }

        }

        private void newAccountButton_Click(object sender, EventArgs e)
        {
            signInButton.Visible = false;
            registerButton.Visible = true;
        }
    }
}

