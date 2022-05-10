namespace Snake
{
    partial class form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.score1Label = new System.Windows.Forms.Label();
            this.winnerLabel = new System.Windows.Forms.Label();
            this.pointLabel = new System.Windows.Forms.Label();
            this.nextLevelButton = new System.Windows.Forms.Button();
            this.playerList = new System.Windows.Forms.ComboBox();
            this.playerLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.signInButton = new System.Windows.Forms.Button();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.dbLabel = new System.Windows.Forms.Label();
            this.newAccountButton = new System.Windows.Forms.Button();
            this.positionLabel = new System.Windows.Forms.Label();
            this.setPlayerCountButton = new System.Windows.Forms.Button();
            this.moveCountLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.topScoresLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Green;
            this.startButton.Location = new System.Drawing.Point(720, 376);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(132, 53);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Visible = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.Green;
            this.restartButton.Location = new System.Drawing.Point(720, 376);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(132, 53);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Visible = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // score1Label
            // 
            this.score1Label.AutoSize = true;
            this.score1Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(143)))));
            this.score1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.score1Label.Location = new System.Drawing.Point(57, 0);
            this.score1Label.Name = "score1Label";
            this.score1Label.Size = new System.Drawing.Size(0, 29);
            this.score1Label.TabIndex = 3;
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.BackColor = System.Drawing.Color.BurlyWood;
            this.winnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.winnerLabel.Location = new System.Drawing.Point(685, 309);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(127, 39);
            this.winnerLabel.TabIndex = 4;
            this.winnerLabel.Text = "Winner";
            this.winnerLabel.Visible = false;
            // 
            // pointLabel
            // 
            this.pointLabel.AutoSize = true;
            this.pointLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(143)))));
            this.pointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pointLabel.Location = new System.Drawing.Point(1000, 0);
            this.pointLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pointLabel.Name = "pointLabel";
            this.pointLabel.Size = new System.Drawing.Size(0, 29);
            this.pointLabel.TabIndex = 5;
            // 
            // nextLevelButton
            // 
            this.nextLevelButton.BackColor = System.Drawing.Color.Green;
            this.nextLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextLevelButton.Location = new System.Drawing.Point(720, 377);
            this.nextLevelButton.Margin = new System.Windows.Forms.Padding(2);
            this.nextLevelButton.Name = "nextLevelButton";
            this.nextLevelButton.Size = new System.Drawing.Size(132, 53);
            this.nextLevelButton.TabIndex = 6;
            this.nextLevelButton.Text = "Next level";
            this.nextLevelButton.UseVisualStyleBackColor = false;
            this.nextLevelButton.Visible = false;
            this.nextLevelButton.Click += new System.EventHandler(this.nextLevelButton_Click);
            // 
            // playerList
            // 
            this.playerList.FormattingEnabled = true;
            this.playerList.Items.AddRange(new object[] {
            "1",
            "2"});
            this.playerList.Location = new System.Drawing.Point(724, 309);
            this.playerList.Margin = new System.Windows.Forms.Padding(2);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(92, 21);
            this.playerList.TabIndex = 7;
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerLabel.Location = new System.Drawing.Point(725, 269);
            this.playerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(127, 17);
            this.playerLabel.TabIndex = 8;
            this.playerLabel.Text = "How many players:";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(720, 432);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(35, 13);
            this.errorLabel.TabIndex = 9;
            this.errorLabel.Text = "label1";
            this.errorLabel.Visible = false;
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(196, 244);
            this.nameTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(92, 20);
            this.nameTextbox.TabIndex = 11;
            this.nameTextbox.Visible = false;
            // 
            // signInButton
            // 
            this.signInButton.BackColor = System.Drawing.Color.BurlyWood;
            this.signInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.signInButton.Location = new System.Drawing.Point(196, 376);
            this.signInButton.Margin = new System.Windows.Forms.Padding(2);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(92, 38);
            this.signInButton.TabIndex = 12;
            this.signInButton.Text = "sign in";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Visible = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(196, 328);
            this.usernameTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(92, 20);
            this.usernameTextbox.TabIndex = 13;
            this.usernameTextbox.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AccessibleDescription = "";
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(197, 205);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(55, 20);
            this.nameLabel.TabIndex = 14;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Visible = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usernameLabel.Location = new System.Drawing.Point(193, 295);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(87, 20);
            this.usernameLabel.TabIndex = 15;
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.Visible = false;
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.BurlyWood;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.registerButton.Location = new System.Drawing.Point(196, 377);
            this.registerButton.Margin = new System.Windows.Forms.Padding(2);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(92, 38);
            this.registerButton.TabIndex = 16;
            this.registerButton.Text = "register";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Visible = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // dbLabel
            // 
            this.dbLabel.AutoSize = true;
            this.dbLabel.Location = new System.Drawing.Point(199, 418);
            this.dbLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dbLabel.Name = "dbLabel";
            this.dbLabel.Size = new System.Drawing.Size(35, 13);
            this.dbLabel.TabIndex = 21;
            this.dbLabel.Text = "label1";
            this.dbLabel.Visible = false;
            // 
            // newAccountButton
            // 
            this.newAccountButton.BackColor = System.Drawing.Color.BurlyWood;
            this.newAccountButton.Location = new System.Drawing.Point(196, 433);
            this.newAccountButton.Margin = new System.Windows.Forms.Padding(2);
            this.newAccountButton.Name = "newAccountButton";
            this.newAccountButton.Size = new System.Drawing.Size(92, 25);
            this.newAccountButton.TabIndex = 23;
            this.newAccountButton.Text = "new account";
            this.newAccountButton.UseVisualStyleBackColor = false;
            this.newAccountButton.Visible = false;
            this.newAccountButton.Click += new System.EventHandler(this.newAccountButton_Click);
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.positionLabel.Location = new System.Drawing.Point(720, 464);
            this.positionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(51, 20);
            this.positionLabel.TabIndex = 24;
            this.positionLabel.Text = "label1";
            this.positionLabel.Visible = false;
            // 
            // setPlayerCountButton
            // 
            this.setPlayerCountButton.BackColor = System.Drawing.Color.Green;
            this.setPlayerCountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.setPlayerCountButton.Location = new System.Drawing.Point(720, 377);
            this.setPlayerCountButton.Margin = new System.Windows.Forms.Padding(2);
            this.setPlayerCountButton.Name = "setPlayerCountButton";
            this.setPlayerCountButton.Size = new System.Drawing.Size(132, 53);
            this.setPlayerCountButton.TabIndex = 25;
            this.setPlayerCountButton.Text = "Set players";
            this.setPlayerCountButton.UseVisualStyleBackColor = false;
            this.setPlayerCountButton.Click += new System.EventHandler(this.setPlayerCountButton_Click);
            // 
            // moveCountLabel
            // 
            this.moveCountLabel.AutoSize = true;
            this.moveCountLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(143)))));
            this.moveCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.moveCountLabel.Location = new System.Drawing.Point(538, 0);
            this.moveCountLabel.Name = "moveCountLabel";
            this.moveCountLabel.Size = new System.Drawing.Size(0, 29);
            this.moveCountLabel.TabIndex = 26;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(143)))));
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.Location = new System.Drawing.Point(712, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 29);
            this.timeLabel.TabIndex = 27;
            // 
            // topScoresLabel
            // 
            this.topScoresLabel.AutoSize = true;
            this.topScoresLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.topScoresLabel.Location = new System.Drawing.Point(720, 500);
            this.topScoresLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.topScoresLabel.Name = "topScoresLabel";
            this.topScoresLabel.Size = new System.Drawing.Size(0, 20);
            this.topScoresLabel.TabIndex = 28;
            this.topScoresLabel.Visible = false;
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(143)))));
            this.ClientSize = new System.Drawing.Size(1352, 857);
            this.Controls.Add(this.topScoresLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.moveCountLabel);
            this.Controls.Add(this.setPlayerCountButton);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.newAccountButton);
            this.Controls.Add(this.dbLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.nextLevelButton);
            this.Controls.Add(this.pointLabel);
            this.Controls.Add(this.winnerLabel);
            this.Controls.Add(this.score1Label);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.startButton);
            this.KeyPreview = true;
            this.Name = "form1";
            this.Text = "Í";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label score1Label;
        private System.Windows.Forms.Label winnerLabel;
        private System.Windows.Forms.Label pointLabel;
        private System.Windows.Forms.Button nextLevelButton;
        private System.Windows.Forms.ComboBox playerList;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label dbLabel;
        private System.Windows.Forms.Button newAccountButton;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Button setPlayerCountButton;
        private System.Windows.Forms.Label moveCountLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label topScoresLabel;
    }
}

