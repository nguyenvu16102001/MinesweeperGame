using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame.UI.ViewModels
{
    class GetControl
    {
        public static TControl Get<TControl>(Control control, string controlName)
        {
            Control res = new Control();
            Queue<Control> queue = new Queue<Control>();
            queue.Enqueue(control);
            while (queue.Count > 0)
            {
                var ctrl = queue.Dequeue();
                if (ctrl.Name == controlName)
                {
                    res = ctrl;
                    break;
                }
                for (int i = 0; i < ctrl.Controls.Count; ++i)
                {
                    queue.Enqueue(ctrl.Controls[i]);
                }
            }
            return (TControl)Convert.ChangeType(res, typeof(TControl));
        }
    }
}
