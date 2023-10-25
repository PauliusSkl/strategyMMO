namespace WarGame.Forms
{
    partial class GameEndForm
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
            label1 = new Label();
            GG = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(302, 78);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // GG
            // 
            GG.AutoSize = true;
            GG.BackColor = Color.Transparent;
            GG.Location = new Point(324, 164);
            GG.Name = "GG";
            GG.Size = new Size(23, 15);
            GG.TabIndex = 1;
            GG.Text = "GG";
            // 
            // GameEndForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(GG);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GameEndForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            Load += GameEndForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label GG;
    }
}