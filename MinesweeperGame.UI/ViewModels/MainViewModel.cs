using MinesweeperGame.Models;
using MinesweeperGame.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame.UI.ViewModels
{
    class MainViewModel
    {
        MainForm view;
        public MainViewModel(MainForm view)
        {
            this.view = view;
            Load();
        }
        public void Load()
        {
            Panel pnlGame = GetControl.Get<Panel>(view, "pnlGame");
            pnlGame.Controls.Add(new BoardView());
        }
    }
}
