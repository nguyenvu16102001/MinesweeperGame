
namespace MinesweeperGame.UI.Views
{
    partial class BoardView
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBoard.Location = new System.Drawing.Point(0, 0);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(995, 788);
            this.pnlBoard.TabIndex = 0;
            // 
            // BoardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlBoard);
            this.Name = "BoardView";
            this.Size = new System.Drawing.Size(995, 788);
            this.Load += new System.EventHandler(this.BoardView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
    }
}
