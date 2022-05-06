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
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Green;
            this.startButton.Location = new System.Drawing.Point(960, 463);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(176, 65);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Visible = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.Green;
            this.restartButton.Location = new System.Drawing.Point(960, 463);
            this.restartButton.Margin = new System.Windows.Forms.Padding(4);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(176, 65);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Visible = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // score1Label
            // 
            this.score1Label.AutoSize = true;
            this.score1Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.score1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.score1Label.Location = new System.Drawing.Point(84, 9);
            this.score1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.score1Label.Name = "score1Label";
            this.score1Label.Size = new System.Drawing.Size(73, 54);
            this.score1Label.TabIndex = 3;
            this.score1Label.Text = "ds";
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.BackColor = System.Drawing.Color.BurlyWood;
            this.winnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.winnerLabel.Location = new System.Drawing.Point(871, 363);
            this.winnerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(161, 52);
            this.winnerLabel.TabIndex = 4;
            this.winnerLabel.Text = "Winner";
            this.winnerLabel.Visible = false;
            // 
            // pointLabel
            // 
            this.pointLabel.AutoSize = true;
            this.pointLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pointLabel.Location = new System.Drawing.Point(1097, 9);
            this.pointLabel.Name = "pointLabel";
            this.pointLabel.Size = new System.Drawing.Size(86, 54);
            this.pointLabel.TabIndex = 5;
            this.pointLabel.Text = "fsd";
            // 
            // nextLevelButton
            // 
            this.nextLevelButton.BackColor = System.Drawing.Color.Green;
            this.nextLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextLevelButton.Location = new System.Drawing.Point(960, 464);
            this.nextLevelButton.Name = "nextLevelButton";
            this.nextLevelButton.Size = new System.Drawing.Size(176, 65);
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
            this.playerList.Location = new System.Drawing.Point(960, 380);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(121, 24);
            this.playerList.TabIndex = 7;
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerLabel.Location = new System.Drawing.Point(960, 336);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(152, 20);
            this.playerLabel.TabIndex = 8;
            this.playerLabel.Text = "How many players:";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(960, 532);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(44, 16);
            this.errorLabel.TabIndex = 9;
            this.errorLabel.Text = "label1";
            this.errorLabel.Visible = false;
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(262, 300);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(122, 22);
            this.nameTextbox.TabIndex = 11;
            this.nameTextbox.Visible = false;
            // 
            // signInButton
            // 
            this.signInButton.BackColor = System.Drawing.Color.BurlyWood;
            this.signInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.signInButton.Location = new System.Drawing.Point(262, 463);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(122, 47);
            this.signInButton.TabIndex = 12;
            this.signInButton.Text = "sign in";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Visible = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(262, 404);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(122, 22);
            this.usernameTextbox.TabIndex = 13;
            this.usernameTextbox.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AccessibleDescription = "";
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(263, 252);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(70, 25);
            this.nameLabel.TabIndex = 14;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Visible = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usernameLabel.Location = new System.Drawing.Point(257, 363);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(108, 25);
            this.usernameLabel.TabIndex = 15;
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.Visible = false;
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.BurlyWood;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.registerButton.Location = new System.Drawing.Point(262, 464);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(122, 47);
            this.registerButton.TabIndex = 16;
            this.registerButton.Text = "register";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Visible = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // dbLabel
            // 
            this.dbLabel.AutoSize = true;
            this.dbLabel.Location = new System.Drawing.Point(265, 514);
            this.dbLabel.Name = "dbLabel";
            this.dbLabel.Size = new System.Drawing.Size(44, 16);
            this.dbLabel.TabIndex = 21;
            this.dbLabel.Text = "label1";
            this.dbLabel.Visible = false;
            // 
            // newAccountButton
            // 
            this.newAccountButton.BackColor = System.Drawing.Color.BurlyWood;
            this.newAccountButton.Location = new System.Drawing.Point(262, 533);
            this.newAccountButton.Name = "newAccountButton";
            this.newAccountButton.Size = new System.Drawing.Size(122, 31);
            this.newAccountButton.TabIndex = 23;
            this.newAccountButton.Text = "new account";
            this.newAccountButton.UseVisualStyleBackColor = false;
            this.newAccountButton.Visible = false;
            this.newAccountButton.Click += new System.EventHandler(this.newAccountButton_Click);
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(960, 571);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(44, 16);
            this.positionLabel.TabIndex = 24;
            this.positionLabel.Text = "label1";
            this.positionLabel.Visible = false;
            // 
            // setPlayerCountButton
            // 
            this.setPlayerCountButton.BackColor = System.Drawing.Color.Green;
            this.setPlayerCountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.setPlayerCountButton.Location = new System.Drawing.Point(960, 464);
            this.setPlayerCountButton.Name = "setPlayerCountButton";
            this.setPlayerCountButton.Size = new System.Drawing.Size(176, 65);
            this.setPlayerCountButton.TabIndex = 25;
            this.setPlayerCountButton.Text = "Set players";
            this.setPlayerCountButton.UseVisualStyleBackColor = false;
            this.setPlayerCountButton.Click += new System.EventHandler(this.setPlayerCountButton_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1803, 1055);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}

