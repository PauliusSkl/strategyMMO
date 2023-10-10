using WarGame.Forms.Decorator;

namespace WarGame
{
    partial class LobbyForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainLabel = new LobbyLabel();
            button1 = new Button();
            textBox1 = new TextBox();
            playerCountLabel = new Label();
            labelPlayerCount = new Label();
            SuspendLayout();
            // 
            // MainLabel
            // 
            MainLabel.AutoSize = true;
            MainLabel.Enabled = false;
            MainLabel.Location = new Point(495, 9);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(162, 15);
            MainLabel.TabIndex = 0;
            MainLabel.Text = "Hello! Welcome to the Game!";
            // 
            // button1
            // 
            button1.Location = new Point(536, 62);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 1;
            button1.Text = "Start game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(523, 35);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(110, 23);
            textBox1.TabIndex = 2;
            // 
            // playerCountLabel
            // 
            playerCountLabel.AutoSize = true;
            playerCountLabel.Location = new Point(33, 23);
            playerCountLabel.Name = "playerCountLabel";
            playerCountLabel.Size = new Size(0, 15);
            playerCountLabel.TabIndex = 4;
            // 
            // labelPlayerCount
            // 
            labelPlayerCount.AutoSize = true;
            labelPlayerCount.Location = new Point(313, 52);
            labelPlayerCount.Name = "labelPlayerCount";
            labelPlayerCount.Size = new Size(0, 15);
            labelPlayerCount.TabIndex = 5;
            // 
            // LobbyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 417);
            Controls.Add(labelPlayerCount);
            Controls.Add(playerCountLabel);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(MainLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LobbyForm";
            Text = "War Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AbstractLabel MainLabel;
        private Button button1;
        private TextBox textBox1;
        private Label playerCountLabel;
        private Label labelPlayerCount;
    }
}