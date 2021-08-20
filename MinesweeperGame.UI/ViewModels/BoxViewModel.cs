using MinesweeperGame.Models;
using MinesweeperGame.UI.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame.UI.ViewModels
{
    public class BoxViewModel
    {
        BoxView view;
        public BoxViewModel(BoxView view)
        {
            this.view = view;
            Load();

        }
        public void Load()
        {
            //Button btn = GetControl.Get<Button>(view, "btnBox");
            //btn.MouseUp += (sender, EventArgs) => { btn_Click(sender, EventArgs, view.box); };
        }

        /*private void btn_Click(object sender, MouseEventArgs eventArgs, MinesBox box)
        {
            Button button = sender as Button;
            if(eventArgs.Button == MouseButtons.Right)
            {
                if(box.states == -1)
                {
                    box.states = 0;//Chuyển sang trạng thái cắm cờ.
                    Draw draw = new Draw(box, button);
                    draw.Draw_Flag();
                }
                else if(box.states == 0)
                {
                    box.states = -1;
                    Draw draw = new Draw(box, button);
                    draw.Draw_Button();
                } 
            }
        }*/
    }
}
