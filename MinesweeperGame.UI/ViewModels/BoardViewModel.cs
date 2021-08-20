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
        Control view;
        private BoxView[,] boxes{get; set;}//Mảng chứa các minesbox
        private bool gameOver = false;//Trạng thái của game.
        private int number_Of_Unopen { get; set; }//Số ô chưa được mở.
        private int number_Of_Flagged { get; set; }//Số cờ cắm
        Board board { get; set; }

        public BoardViewModel(Control view, Board board)
        {
            this.board = board;      
            this.view = view;
            Load();
        }
        public void Load()
        {
            GetControl.Get<Label>(view, "lbMines").Text = board.number_Of_Mines.ToString();
            boxes = new BoxView[board.rows, board.columns];
            number_Of_Unopen = board.rows * board.columns - board.number_Of_Mines;
            number_Of_Flagged = board.number_Of_Mines;
            Create();
        }
        private void btn_RightClick(object sender, MouseEventArgs eventArgs, MinesBox box)
        {
            Button btn_mines = sender as Button;
            Draw draw = new Draw(box, btn_mines);
            if (eventArgs.Button == MouseButtons.Right)
            {
                if (box.states == -1 && number_Of_Flagged > 0)
                {
                    number_Of_Flagged--;
                    box.states = 0;//Chuyển sang trạng thái cắm cờ.
                    draw.Draw_Flag();
                }
                else if (box.states == 0 && number_Of_Flagged >= 0)
                {
                    number_Of_Flagged++;
                    box.states = -1;//Chuyển sang trạng thái đóng chưa đc cắm cờ.
                    draw.Draw_Button();
                }
            }
        }

        private void btn_Click(object sender, MouseEventArgs eventArgs, MinesBox box)
        {
            Button btn_mines = sender as Button;
            Draw draw = new Draw(box, btn_mines);
            if (!gameOver)
            {
                if (number_Of_Unopen == (board.rows * board.columns - board.number_Of_Mines))
                {
                    Create_MinesBox(box);
                    for (int i = 0; i < board.rows; i++)
                        for (int j = 0; j < board.columns; j++)
                            Count_Mines_Around(i, j);
                    number_Of_Unopen--;
                    draw.Open();
                    if (box.count_Mines_Around == 0)
                        Spreads(box);
                }
                else
                {
                    if (box.states == -1)
                    {
                        draw.Open();
                        number_Of_Unopen--;
                        if (number_Of_Unopen == 0)
                        {
                            gameOver = true;
                            GameWin();
                        }
                        else if (box.count_Mines_Around == 0 && !box.is_Mines)
                        {
                            Spreads(box);
                        }
                        else if (box.is_Mines)
                        {
                            gameOver = true;
                            GameLose();
                        }
                    }
                    if (box.states == 1 && !box.is_Mines)
                    {
                        if (box.count_Mines_Around == Count_Flag_Around(box.x, box.y))
                        {
                            if (Check_Count_Flag_Around(box.x, box.y))
                                Spreads(box);
                            else
                            {
                                gameOver = true;
                                GameLose();
                            }
                        }
                        /*else
                        {
                            for (int i = box.x - 1; i <= box.x + 1; i++)
                            {
                                for (int j = box.y - 1; j <= box.y + 1; j++)
                                {
                                    if ((i < board.rows && j < board.columns) && (i >= 0 && j >= 0))
                                    {
                                        if()
                                    }
                                }
                            }
                        }*/
                    }
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
                        if ((i < board.rows && j < board.columns) && (i >= 0 && j >= 0) && (i != x || j != y))
                            if (boxes[i, j].box.states != 1 && !boxes[i, j].box.is_Mines)
                            {
                                if (boxes[i, j].box.count_Mines_Around == 0)
                                    my_queue.Enqueue(boxes[i, j].box);
                                Draw draw_temp = new Draw(boxes[i, j].box, GetControl.Get<Button>(boxes[i, j], "btnBox"));
                                draw_temp.Open();
                                number_Of_Unopen--;
                                if (number_Of_Unopen == 0)
                                {
                                    gameOver = true;
                                    GameWin();
                                }
                            }
                    }
                }
            }
        }

        private void GameLose()
        {
            if(gameOver)
            {
                for(int i = 0; i < board.rows; i++)
                {
                    for(int j = 0; j < board.columns; j++)
                    {
                        if (boxes[i, j].box.is_Mines && boxes[i,j].box.states == -1)
                        {
                            Draw draw = new Draw(boxes[i, j].box, GetControl.Get<Button>(boxes[i, j], "btnBox"));
                            draw.Draw_Mines();
                        }
                        if (!boxes[i,j].box.is_Mines && boxes[i,j].box.states == 0)
                        {
                            Draw draw = new Draw(boxes[i, j].box, GetControl.Get<Button>(boxes[i, j], "btnBox"));
                            draw.Draw_Explosive_Flag();
                        }
                    }
                }
            }
        }

        private void GameWin()
        {
            if (gameOver)
            {
                for (int i = 0; i < board.rows; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if(boxes[i,j].box.states == -1 && boxes[i, j].box.is_Mines)
                        {
                            Draw draw = new Draw(boxes[i, j].box, GetControl.Get<Button>(boxes[i, j], "btnBox"));
                            draw.Draw_Flag();
                        }
                    }
                }
            }
        }

        private void Create()
        {
            Panel pnlBoard = GetControl.Get<Panel>(view, "pnlBoard");
            pnlBoard.Controls.Clear();
            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    MinesBox box = new MinesBox();
                    boxes[i, j] = new BoxView(box);
                    boxes[i, j].Location = new Point(i * 40, j * 40);
                    boxes[i, j].box.x = i;
                    boxes[i, j].box.y = j;
                    boxes[i, j].Size = new Size(40, 40);
                    pnlBoard.Controls.Add(boxes[i, j]);
                    int x = i;
                    int y = j;
                    Button btn = GetControl.Get<Button>(boxes[i, j], "btnBox");
                    btn.MouseClick += (sender, EventArgs) => { btn_Click(sender, EventArgs, boxes[x, y].box); };
                    btn.MouseUp += (sender, EventArgs) => { btn_RightClick(sender, EventArgs, boxes[x, y].box); };
                }
            }
        }
        private void Create_MinesBox(MinesBox mines)//Khởi tạo ngẫu nhiên các ô chứa mìn
        {
            Random random = new Random();
            int count = 0;
            while (count < board.number_Of_Mines)
            {
                int i = random.Next(board.rows);
                int j = random.Next(board.columns);
                if (!boxes[i, j].box.is_Mines && !(i == mines.x && j == mines.y))
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
                    if ((i < board.rows && j < board.columns) && (i >= 0 && j >= 0) && (i != x || j != y))
                        if (boxes[i, j].box.is_Mines)
                            count++;
            boxes[x, y].box.count_Mines_Around = count;
        }

        private int Count_Flag_Around(int x, int y)//Đếm số cờ xung quanh một ô.
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                    if ((i < board.rows && j < board.columns) && (i >= 0 && j >= 0) && (i != x || j != y))
                        if(boxes[i,j].box.states == 0)
                        {
                            count++;
                        }
            return count;
        }

        private bool Check_Count_Flag_Around(int x, int y)//Đếm số cờ xung quanh một ô.
        {
            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                    if ((i < board.rows && j < board.columns) && (i >= 0 && j >= 0) && (i != x || j != y))
                        if (boxes[i, j].box.states == 0 && !boxes[i,j].box.is_Mines)
                        {
                            return false;
                        }
            return true;
        }
    }
}
