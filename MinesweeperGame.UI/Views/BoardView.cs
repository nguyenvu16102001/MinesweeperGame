using MinesweeperGame.Models;
using MinesweeperGame.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame.UI.Views
{
    public partial class BoardView : UserControl
    {
        BoardViewModel viewModel;
        public BoardView()
        {
            InitializeComponent();
        }

        private void BoardView_Load(object sender, EventArgs e)
        {
            viewModel = new BoardViewModel(this, 9, 10);
        }
    }
}
