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
    public partial class BoxView : UserControl
    {
        public BoxViewModel viewModel;
        public MinesBox box;
        public BoxView(MinesBox box)
        {
            InitializeComponent();
            this.box = box;
        }

        private void BoxView_Load(object sender, EventArgs e)
        {
            viewModel = new BoxViewModel(this);
        }
    }
}
