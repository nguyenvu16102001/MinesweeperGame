using MinesweeperGame.Models;
using MinesweeperGame.UI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame.UI.ViewModels
{
    public class BoardViewModel
    {
        BoardView view;
        public int size;
        public int number_Of_Mines;
        BoxView[,] boxes;
        private bool gameOver = false;

        public BoardViewModel(BoardView view, int size, int number_Of_Mines)
        {
            this.view = view;
            this.size = size;
            this.number_Of_Mines = number_Of_Mines;
            boxes = new BoxView[size, size];
            Load();
        }
        public void Load()
        {
            Panel pnlBoard = GetControl.Get<Panel>(view, "pnlBoard");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    MinesBox box = new MinesBox();
                    boxes[i, j] = new BoxView(box);
                    boxes[i, j].Location = new Point(i * 40, j * 40);
                    boxes[i, j].box.x = i;
                    boxes[i, j].box.y = j;
                    boxes[i, j].Size = new Size(40, 40);
                    GetControl.Get<Panel>(view, "pnlBoard").Controls.Add(boxes[i, j]);
                    int x = i;
                    int y = j;
                    Button btn = GetControl.Get<Button>(boxes[i, j], "btnBox");
                    btn.MouseClick += (sender, EventArgs) => { btn_Click(sender, EventArgs, boxes[x, y].box); };
                }
            }
            Create_MinesBox();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    Count_Mines_Around(i, j);
        }

        private void btn_Click(object sender, MouseEventArgs eventArgs, MinesBox box)
        {
            Button btn_mines = sender as Button;
            Draw draw = new Draw(box, btn_mines);
            if (!gameOver)
            {
                if (box.states == -1)
                {
                    draw.Open();
                    if (box.count_Mines_Around == 0 && !box.is_Mines)
                    {
                        Spreads(box);
                    }
                    else if (box.is_Mines)
                    {
                        gameOver = true;
                        GameLose();
                    }
                }
                if (box.states == 1 && box.count_Mines_Around == Count_Flag_Around(box.x, box.y))
                {
                    Spreads(box);
                }
            }
        }

        private void Spreads(MinesBox box)
        {
            Queue<MinesBox> my_queue = new Queue<MinesBox>();
            my_queue.Enqueue(box);
            while (my_queue.Count > 0)
            {
                MinesBox mines = my_queue.Dequeue();
                int x = mines.x;
                int y = mines.y;
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if ((i < size && j < size) && (i >= 0 && j >= 0) && (i != x || j != y))
                            if (boxes[i, j].box.states != 1 && !boxes[i, j].box.is_Mines)
                            {
                                if (boxes[i, j].box.count_Mines_Around == 0)
                                    my_queue.Enqueue(boxes[i, j].box);
                                Draw draw_temp = new Draw(boxes[i, j].box, GetControl.Get<Button>(boxes[i, j], "btnBox"));
                                draw_temp.Open();
                            }
                    }
                }
            }
        }

        private void GameLose()
        {
            if(gameOver)
            {
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        if (boxes[i, j].box.is_Mines && boxes[i,j].box.states == -1)
                        {
                            Draw draw = new Draw(boxes[i, j].box, GetControl.Get<Button>(boxes[i, j], "btnBox"));
                            draw.Draw_Mines();
                        }
                        if (!boxes[i,j].box.is_Mines && boxes[i,j].box.states == 0)
                        {
                            Draw draw = new Draw(boxes[i, j].box, GetControl.Get<Button>(boxes[i, j], "btnBox"));
                            
                        }
                    }
                }
            }
        }
        private void Create_MinesBox()//Khởi tạo ngẫu nhiên các ô chứa mìn
        {
            Random random = new Random();
            int count = 0;
            while (count < number_Of_Mines)
            {
                int i = random.Next(size);
                int j = random.Next(size);
                if (!boxes[i, j].box.is_Mines)
                {
                    boxes[i, j].box.is_Mines = true;
                    count++;
                }
            }
        }
        private void Count_Mines_Around(int x, int y)//Đếm số mìn xung quanh của một MinesBox
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                    if ((i < size && j < size) && (i >= 0 && j >= 0) && (i != x || j != y))
                        if (boxes[i, j].box.is_Mines)
                            count++;
            boxes[x, y].box.count_Mines_Around = count;
        }

        private int Count_Flag_Around(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                    if ((i < size && j < size) && (i >= 0 && j >= 0) && (i != x || j != y))
                        if(boxes[i,j].box.states == 0)
                        {
                            count++;
                        }
            return count;
        }
    }
}
