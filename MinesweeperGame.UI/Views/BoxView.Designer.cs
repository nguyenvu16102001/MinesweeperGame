
namespace MinesweeperGame.UI.Views
{
    partial class BoxView
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
            this.btnBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBox
            // 
            this.btnBox.BackColor = System.Drawing.Color.Silver;
            this.btnBox.BackgroundImage = global::MinesweeperGame.UI.Properties.Resources.Box;
            this.btnBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBox.Location = new System.Drawing.Point(0, 0);
            this.btnBox.Name = "btnBox";
            this.btnBox.Size = new System.Drawing.Size(150, 150);
            this.btnBox.TabIndex = 0;
            this.btnBox.UseVisualStyleBackColor = false;
            // 
            // BoxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBox);
            this.Name = "BoxView";
            this.Load += new System.EventHandler(this.BoxView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBox;
    }
}
