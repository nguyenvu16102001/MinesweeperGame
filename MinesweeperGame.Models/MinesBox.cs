using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.Models
{
    public class MinesBox
    {
        public bool is_Mines = false;//false không phải mìn, còn true là mìn.
        public int count_Mines_Around;//Số mìn xung quanh nút;
        public int states = -1;//-1 nếu đóng, 0 nếu đặt cờ, 1 nếu mở
        public int x;
        public int y;
    }
}
