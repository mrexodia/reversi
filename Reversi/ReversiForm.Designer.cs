namespace Reversi
{
    partial class ReversiForm
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
            this.panelBoard = new System.Windows.Forms.Panel();
            this.checkBoxHelp = new System.Windows.Forms.CheckBox();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelGameStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.Location = new System.Drawing.Point(12, 12);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(250, 250);
            this.panelBoard.TabIndex = 0;
            // 
            // checkBoxHelp
            // 
            this.checkBoxHelp.AutoSize = true;
            this.checkBoxHelp.Location = new System.Drawing.Point(214, 268);
            this.checkBoxHelp.Name = "checkBoxHelp";
            this.checkBoxHelp.Size = new System.Drawing.Size(48, 17);
            this.checkBoxHelp.TabIndex = 1;
            this.checkBoxHelp.Text = "&Help";
            this.checkBoxHelp.UseVisualStyleBackColor = true;
            this.checkBoxHelp.CheckedChanged += new System.EventHandler(this.checkBoxHelp_CheckedChanged);
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(12, 269);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(64, 13);
            this.labelPlayer1.TabIndex = 2;
            this.labelPlayer1.Text = "labelPlayer1";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new System.Drawing.Point(12, 286);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(64, 13);
            this.labelPlayer2.TabIndex = 3;
            this.labelPlayer2.Text = "labelPlayer2";
            // 
            // labelGameStatus
            // 
            this.labelGameStatus.AutoSize = true;
            this.labelGameStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameStatus.Location = new System.Drawing.Point(12, 303);
            this.labelGameStatus.Name = "labelGameStatus";
            this.labelGameStatus.Size = new System.Drawing.Size(102, 13);
            this.labelGameStatus.TabIndex = 4;
            this.labelGameStatus.Text = "labelGameStatus";
            // 
            // ReversiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 323);
            this.Controls.Add(this.labelGameStatus);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.checkBoxHelp);
            this.Controls.Add(this.panelBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReversiForm";
            this.Text = "Reversi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.CheckBox checkBoxHelp;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelGameStatus;


    }
}