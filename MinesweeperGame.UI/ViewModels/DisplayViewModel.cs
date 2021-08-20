using MinesweeperGame.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame.UI.ViewModels
{
    public class DisplayViewModel
    {
        DisplayView view;
        
        public DisplayViewModel(DisplayView view)
        {
            this.view = view;
            Load();
        }

        private void Load()
        {
            GetControl.Get<Label>(view, "lbMines").Text = "10";
            GetControl.Get<Label>(view, "lbTimer").Text = "0";
        }
    }
}
