﻿namespace Reversi
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
            this.pictureBoxBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBoard
            // 
            this.pictureBoxBoard.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxBoard.Name = "pictureBoxBoard";
            this.pictureBoxBoard.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxBoard.TabIndex = 0;
            this.pictureBoxBoard.TabStop = false;
            // 
            // ReversiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 323);
            this.Controls.Add(this.pictureBoxBoard);
            this.MaximizeBox = false;
            this.Name = "ReversiForm";
            this.Text = "Reversi";
            this.ResizeEnd += new System.EventHandler(this.ReversiForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBoard;

    }
}