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
            GetControl.Get<Panel>(view, "pnlDisplay").Controls.Add(new DisplayView());
            BoardView boardView = new BoardView();
            GetControl.Get<Panel>(view, "pnlGame").Controls.Add(boardView);
            var viewModel = new BoardViewModel(view, new Board() { rows = 9, columns = 9, number_Of_Mines = 10 });
        }
    }
}
