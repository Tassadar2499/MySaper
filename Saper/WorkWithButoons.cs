using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper
{
    class WorkWithButoons
    {
        public static void ShowNearestButtons(Point current)
        {
            var x = current.X;
            var y = current.Y;

            if (x - 1 >= 0)
                WTF(x - 1, y);
            if (x + 1 < 20)
                WTF(x + 1, y);
            if (y - 1 >= 0)
                WTF(x, y - 1);
            if (y + 1 < 20)
                WTF(x, y + 1);

            if ((x - 1 >= 0) && (y - 1 >= 0))
                WTF(x - 1, y - 1);
            if ((x - 1 >= 0) && (y + 1 < 20))
                WTF(x - 1, y + 1);
            if ((x + 1 < 20) && (y - 1 >= 0))
                WTF(x + 1, y - 1);
            if ((x + 1 < 20) && (y + 1 < 20))
                WTF(x + 1, y + 1);
        }

        public static void WTF(int x, int y)
        {
            var flag = false;
            var matrix = FormSaper.matrixButtons;
            if (matrix[x, y].BackColor == Color.Blue) flag = true;
            Drawing.ShowNumber(matrix[x, y]);
            if (matrix[x, y].Text == "0" && flag)
                ShowNearestButtons(new Point(x, y));
        }
    }
}
