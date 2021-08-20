
namespace MinesweeperGame.UI.Views
{
    partial class DisplayView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTimer = new System.Windows.Forms.Label();
            this.lbMines = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTimer
            // 
            this.lbTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer.Location = new System.Drawing.Point(28, 32);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(261, 51);
            this.lbTimer.TabIndex = 0;
            this.lbTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMines
            // 
            this.lbMines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbMines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMines.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMines.Location = new System.Drawing.Point(28, 123);
            this.lbMines.Name = "lbMines";
            this.lbMines.Size = new System.Drawing.Size(261, 51);
            this.lbMines.TabIndex = 2;
            this.lbMines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisplayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbMines);
            this.Controls.Add(this.lbTimer);
            this.Name = "DisplayView";
            this.Size = new System.Drawing.Size(330, 220);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Label lbMines;
    }
}
