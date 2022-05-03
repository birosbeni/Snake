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
            this.signInNameTextbox = new System.Windows.Forms.TextBox();
            this.signInButton = new System.Windows.Forms.Button();
            this.signInUsernameTextbox = new System.Windows.Forms.TextBox();
            this.signInNameLabel = new System.Windows.Forms.Label();
            this.signInUsernameLabel = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.registerNameTextbox = new System.Windows.Forms.TextBox();
            this.registerUsernameTextbox = new System.Windows.Forms.TextBox();
            this.registerNameLabel = new System.Windows.Forms.Label();
            this.registerUsernameLabel = new System.Windows.Forms.Label();
            this.signInErrorLabel = new System.Windows.Forms.Label();
            this.registerErrorLabel = new System.Windows.Forms.Label();
            this.newAccountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(960, 463);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(176, 65);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(960, 463);
            this.restartButton.Margin = new System.Windows.Forms.Padding(4);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(176, 65);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Visible = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // score1Label
            // 
            this.score1Label.AutoSize = true;
            this.score1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.score1Label.Location = new System.Drawing.Point(93, 15);
            this.score1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.score1Label.Name = "score1Label";
            this.score1Label.Size = new System.Drawing.Size(0, 54);
            this.score1Label.TabIndex = 3;
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
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
            this.pointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pointLabel.Location = new System.Drawing.Point(1112, 15);
            this.pointLabel.Name = "pointLabel";
            this.pointLabel.Size = new System.Drawing.Size(0, 42);
            this.pointLabel.TabIndex = 5;
            // 
            // nextLevelButton
            // 
            this.nextLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextLevelButton.Location = new System.Drawing.Point(960, 463);
            this.nextLevelButton.Name = "nextLevelButton";
            this.nextLevelButton.Size = new System.Drawing.Size(176, 65);
            this.nextLevelButton.TabIndex = 6;
            this.nextLevelButton.Text = "Next level";
            this.nextLevelButton.UseVisualStyleBackColor = true;
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
            this.playerLabel.Location = new System.Drawing.Point(960, 336);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(121, 16);
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
            // signInNameTextbox
            // 
            this.signInNameTextbox.Location = new System.Drawing.Point(262, 300);
            this.signInNameTextbox.Name = "signInNameTextbox";
            this.signInNameTextbox.Size = new System.Drawing.Size(122, 22);
            this.signInNameTextbox.TabIndex = 11;
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(262, 463);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(100, 47);
            this.signInButton.TabIndex = 12;
            this.signInButton.Text = "sign in";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // signInUsernameTextbox
            // 
            this.signInUsernameTextbox.Location = new System.Drawing.Point(262, 404);
            this.signInUsernameTextbox.Name = "signInUsernameTextbox";
            this.signInUsernameTextbox.Size = new System.Drawing.Size(122, 22);
            this.signInUsernameTextbox.TabIndex = 13;
            // 
            // signInNameLabel
            // 
            this.signInNameLabel.AutoSize = true;
            this.signInNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.signInNameLabel.Location = new System.Drawing.Point(263, 252);
            this.signInNameLabel.Name = "signInNameLabel";
            this.signInNameLabel.Size = new System.Drawing.Size(70, 25);
            this.signInNameLabel.TabIndex = 14;
            this.signInNameLabel.Text = "Name:";
            // 
            // signInUsernameLabel
            // 
            this.signInUsernameLabel.AutoSize = true;
            this.signInUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.signInUsernameLabel.Location = new System.Drawing.Point(257, 363);
            this.signInUsernameLabel.Name = "signInUsernameLabel";
            this.signInUsernameLabel.Size = new System.Drawing.Size(108, 25);
            this.signInUsernameLabel.TabIndex = 15;
            this.signInUsernameLabel.Text = "Username:";
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(262, 463);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(100, 47);
            this.registerButton.TabIndex = 16;
            this.registerButton.Text = "register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Visible = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // registerNameTextbox
            // 
            this.registerNameTextbox.Location = new System.Drawing.Point(262, 300);
            this.registerNameTextbox.Name = "registerNameTextbox";
            this.registerNameTextbox.Size = new System.Drawing.Size(122, 22);
            this.registerNameTextbox.TabIndex = 17;
            this.registerNameTextbox.Visible = false;
            // 
            // registerUsernameTextbox
            // 
            this.registerUsernameTextbox.Location = new System.Drawing.Point(262, 404);
            this.registerUsernameTextbox.Name = "registerUsernameTextbox";
            this.registerUsernameTextbox.Size = new System.Drawing.Size(122, 22);
            this.registerUsernameTextbox.TabIndex = 18;
            this.registerUsernameTextbox.Visible = false;
            // 
            // registerNameLabel
            // 
            this.registerNameLabel.AutoSize = true;
            this.registerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.registerNameLabel.Location = new System.Drawing.Point(263, 252);
            this.registerNameLabel.Name = "registerNameLabel";
            this.registerNameLabel.Size = new System.Drawing.Size(70, 25);
            this.registerNameLabel.TabIndex = 19;
            this.registerNameLabel.Text = "Name:";
            this.registerNameLabel.Visible = false;
            // 
            // registerUsernameLabel
            // 
            this.registerUsernameLabel.AutoSize = true;
            this.registerUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.registerUsernameLabel.Location = new System.Drawing.Point(257, 363);
            this.registerUsernameLabel.Name = "registerUsernameLabel";
            this.registerUsernameLabel.Size = new System.Drawing.Size(108, 25);
            this.registerUsernameLabel.TabIndex = 20;
            this.registerUsernameLabel.Text = "Username:";
            this.registerUsernameLabel.Visible = false;
            // 
            // signInErrorLabel
            // 
            this.signInErrorLabel.AutoSize = true;
            this.signInErrorLabel.Location = new System.Drawing.Point(262, 532);
            this.signInErrorLabel.Name = "signInErrorLabel";
            this.signInErrorLabel.Size = new System.Drawing.Size(44, 16);
            this.signInErrorLabel.TabIndex = 21;
            this.signInErrorLabel.Text = "label1";
            this.signInErrorLabel.Visible = false;
            // 
            // registerErrorLabel
            // 
            this.registerErrorLabel.AutoSize = true;
            this.registerErrorLabel.Location = new System.Drawing.Point(262, 532);
            this.registerErrorLabel.Name = "registerErrorLabel";
            this.registerErrorLabel.Size = new System.Drawing.Size(44, 16);
            this.registerErrorLabel.TabIndex = 22;
            this.registerErrorLabel.Text = "label2";
            this.registerErrorLabel.Visible = false;
            // 
            // newAccountButton
            // 
            this.newAccountButton.Location = new System.Drawing.Point(262, 571);
            this.newAccountButton.Name = "newAccountButton";
            this.newAccountButton.Size = new System.Drawing.Size(122, 23);
            this.newAccountButton.TabIndex = 23;
            this.newAccountButton.Text = "new account";
            this.newAccountButton.UseVisualStyleBackColor = true;
            this.newAccountButton.Click += new System.EventHandler(this.newAccountButton_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1803, 1055);
            this.Controls.Add(this.newAccountButton);
            this.Controls.Add(this.registerErrorLabel);
            this.Controls.Add(this.signInErrorLabel);
            this.Controls.Add(this.registerUsernameLabel);
            this.Controls.Add(this.registerNameLabel);
            this.Controls.Add(this.registerUsernameTextbox);
            this.Controls.Add(this.registerNameTextbox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.signInUsernameLabel);
            this.Controls.Add(this.signInNameLabel);
            this.Controls.Add(this.signInUsernameTextbox);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.signInNameTextbox);
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
        private System.Windows.Forms.TextBox signInNameTextbox;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.TextBox signInUsernameTextbox;
        private System.Windows.Forms.Label signInNameLabel;
        private System.Windows.Forms.Label signInUsernameLabel;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox registerNameTextbox;
        private System.Windows.Forms.TextBox registerUsernameTextbox;
        private System.Windows.Forms.Label registerNameLabel;
        private System.Windows.Forms.Label registerUsernameLabel;
        private System.Windows.Forms.Label signInErrorLabel;
        private System.Windows.Forms.Label registerErrorLabel;
        private System.Windows.Forms.Button newAccountButton;
    }
}

