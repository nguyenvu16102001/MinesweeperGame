using MinesweeperGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame.UI.ViewModels
{
    public class Draw
    {
        MinesBox box;
        Button btn;
        public Draw(MinesBox box, Button btn)
        {
            this.box = box;
            this.btn = btn;
        }
        public void Draw_Zero()
        {
            btn.BackColor = Color.White;
            btn.BackgroundImage = null;
        }

        public void Draw_Number()
        {
            btn.BackColor = Color.White;
            btn.BackgroundImage = null;
            btn.Text = box.count_Mines_Around.ToString();
        }
        
        public void Draw_Button()
        {
            Image image = Image.FromFile(Application.StartupPath + @"\Images\box.png");
            btn.BackgroundImage = image;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void Draw_Mines()
        {
            btn.BackColor = Color.White;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(40, 40);
            Image image = Image.FromFile(Application.StartupPath + @"\Images\mines.png");
            pictureBox.Image = image;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            btn.Controls.Add(pictureBox);
        }
        public void Draw_Explosive_Mines()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(40, 40);
            Image image = Image.FromFile(Application.StartupPath + @"\Images\ExplosiveMines.png");
            pictureBox.Image = image;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            btn.Controls.Add(pictureBox);
        }

        public void Draw_Explosive_Flag()
        {
            Image image = Image.FromFile(Application.StartupPath + @"\Images\ExplosiveFlag.png");
            btn.BackgroundImage = image;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public void Draw_Flag()
        {
            Image image = Image.FromFile(Application.StartupPath + @"\Images\flag.png");
            btn.BackgroundImage = image;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void Open()
        {
            if (box.is_Mines)
                Draw_Explosive_Mines();
            else
            {
                if (box.count_Mines_Around == 0)
                    Draw_Zero();
                else
                    Draw_Number();
            }
            box.states = 1;
        }
    }
}
