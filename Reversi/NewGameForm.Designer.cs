namespace Reversi
{
    partial class NewGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGameForm));
            this.textWidth = new System.Windows.Forms.TextBox();
            this.textHeight = new System.Windows.Forms.TextBox();
            this.textName1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelName1 = new System.Windows.Forms.Label();
            this.groupBoxPlayer1 = new System.Windows.Forms.GroupBox();
            this.groupBoxPlayer2 = new System.Windows.Forms.GroupBox();
            this.textName2 = new System.Windows.Forms.TextBox();
            this.labelName2 = new System.Windows.Forms.Label();
            this.groupBoxBoard = new System.Windows.Forms.GroupBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxPlayer1.SuspendLayout();
            this.groupBoxPlayer2.SuspendLayout();
            this.groupBoxBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(87, 19);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(25, 20);
            this.textWidth.TabIndex = 1;
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(136, 19);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(25, 20);
            this.textHeight.TabIndex = 2;
            // 
            // textName1
            // 
            this.textName1.Location = new System.Drawing.Point(50, 19);
            this.textName1.Name = "textName1";
            this.textName1.Size = new System.Drawing.Size(171, 20);
            this.textName1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName1
            // 
            this.labelName1.AutoSize = true;
            this.labelName1.Location = new System.Drawing.Point(6, 22);
            this.labelName1.Name = "labelName1";
            this.labelName1.Size = new System.Drawing.Size(38, 13);
            this.labelName1.TabIndex = 5;
            this.labelName1.Text = "Name:";
            // 
            // groupBoxPlayer1
            // 
            this.groupBoxPlayer1.Controls.Add(this.textName1);
            this.groupBoxPlayer1.Controls.Add(this.labelName1);
            this.groupBoxPlayer1.Location = new System.Drawing.Point(12, 70);
            this.groupBoxPlayer1.Name = "groupBoxPlayer1";
            this.groupBoxPlayer1.Size = new System.Drawing.Size(228, 53);
            this.groupBoxPlayer1.TabIndex = 2;
            this.groupBoxPlayer1.TabStop = false;
            this.groupBoxPlayer1.Text = "Player 1";
            // 
            // groupBoxPlayer2
            // 
            this.groupBoxPlayer2.Controls.Add(this.textName2);
            this.groupBoxPlayer2.Controls.Add(this.labelName2);
            this.groupBoxPlayer2.Location = new System.Drawing.Point(12, 129);
            this.groupBoxPlayer2.Name = "groupBoxPlayer2";
            this.groupBoxPlayer2.Size = new System.Drawing.Size(228, 53);
            this.groupBoxPlayer2.TabIndex = 3;
            this.groupBoxPlayer2.TabStop = false;
            this.groupBoxPlayer2.Text = "Player 2";
            // 
            // textName2
            // 
            this.textName2.Location = new System.Drawing.Point(50, 19);
            this.textName2.Name = "textName2";
            this.textName2.Size = new System.Drawing.Size(171, 20);
            this.textName2.TabIndex = 1;
            // 
            // labelName2
            // 
            this.labelName2.AutoSize = true;
            this.labelName2.Location = new System.Drawing.Point(6, 22);
            this.labelName2.Name = "labelName2";
            this.labelName2.Size = new System.Drawing.Size(38, 13);
            this.labelName2.TabIndex = 5;
            this.labelName2.Text = "Name:";
            // 
            // groupBoxBoard
            // 
            this.groupBoxBoard.Controls.Add(this.labelSize);
            this.groupBoxBoard.Controls.Add(this.textHeight);
            this.groupBoxBoard.Controls.Add(this.textWidth);
            this.groupBoxBoard.Controls.Add(this.label1);
            this.groupBoxBoard.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBoard.Name = "groupBoxBoard";
            this.groupBoxBoard.Size = new System.Drawing.Size(228, 52);
            this.groupBoxBoard.TabIndex = 1;
            this.groupBoxBoard.TabStop = false;
            this.groupBoxBoard.Text = "Board";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(51, 22);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(30, 13);
            this.labelSize.TabIndex = 5;
            this.labelSize.Text = "Size:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(164, 189);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 225);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBoxBoard);
            this.Controls.Add(this.groupBoxPlayer2);
            this.Controls.Add(this.groupBoxPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Game";
            this.groupBoxPlayer1.ResumeLayout(false);
            this.groupBoxPlayer1.PerformLayout();
            this.groupBoxPlayer2.ResumeLayout(false);
            this.groupBoxPlayer2.PerformLayout();
            this.groupBoxBoard.ResumeLayout(false);
            this.groupBoxBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textWidth;
        private System.Windows.Forms.TextBox textHeight;
        private System.Windows.Forms.TextBox textName1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelName1;
        private System.Windows.Forms.GroupBox groupBoxPlayer1;
        private System.Windows.Forms.GroupBox groupBoxPlayer2;
        private System.Windows.Forms.TextBox textName2;
        private System.Windows.Forms.Label labelName2;
        private System.Windows.Forms.GroupBox groupBoxBoard;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Button buttonStart;
    }
}