using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Saper
{
    class Drawing
    {
        public static void ShowNumber(Button button)
        {
            var number = Int32.Parse(button.Text);
            switch (number)
            {
                case -1:
                        button.Image = Image.FromFile("vzriv.png");
                        button.Text = "";
                        foreach (var but in FormSaper.buttons)
                            if (but.Text == "-1")
                            {
                                but.Image = Image.FromFile("bomba.png");
                                but.Text = "";
                            }
                        FormSaper.soundOfExpozion.Play();
                    break;
                case 0:
                    button.ForeColor = Color.White;
                    button.BackColor = Color.White;
                    break;
                case 1:
                    button.ForeColor = Color.Green;
                    button.BackColor = Color.White;
                    break;
                case 2:
                    button.ForeColor = Color.DarkBlue;
                    button.BackColor = Color.White;
                    break;
                case 3:
                    button.ForeColor = Color.Red;
                    button.BackColor = Color.White;
                    break;
                case 4:
                    button.ForeColor = Color.Purple;
                    button.BackColor = Color.White;
                    break;
                case 5:
                    button.ForeColor = Color.DarkRed;
                    button.BackColor = Color.White;
                    break;
                case 6:
                    button.ForeColor = Color.Brown;
                    button.BackColor = Color.White;
                    break;
                case 7:
                    button.ForeColor = Color.DarkOrange;
                    button.BackColor = Color.White;
                    break;
                case 8:
                    button.ForeColor = Color.Indigo;
                    button.BackColor = Color.White;
                    break;
                    //default:
                    //    button.BackColor = Color.Gray;
                    //    break;
            }
        }
    }
}
