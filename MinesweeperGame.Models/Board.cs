using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.Models
{
    public class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public MinesBox[,] mines { get; set; }
        public int number_Of_Mines { get; set; }//Số lượng mìn
    }
}
