using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class FormSaper : Form
    {
        public static Button[] buttons;
        public static Button[,] matrixButtons;
        public static Dictionary<Point, Point> dictionary;
        public static SoundPlayer soundOfExpozion;
        public static int countOfMines;
        public FormSaper()
        {
            InitializeComponent();
            countOfMines = MatrixMaker.countOfMines;
            var matrix = MatrixMaker.numMatrix;
            int iterator = 0;
            buttons = new Button[400];
            matrixButtons = new Button[20,20];
            dictionary = new Dictionary<Point, Point>();
            foreach (var control in Controls)
            {
                var btn = control as Button;
                buttons[iterator] = btn;
                iterator++;
            }
            iterator = 0;
            foreach (var btn in buttons)
            {
                var i = (int) iterator / 20;
                var j = iterator - i * 20;
                btn.Text = matrix[i, j].ToString();
                iterator++;
            }
            iterator = 0;
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    matrixButtons[i, j] = buttons[iterator];
                    dictionary.Add(matrixButtons[i, j].Location, new Point(i,j));
                    iterator++;
                }
            
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].MouseClick += new MouseEventHandler(ButtonMap_Click);

            for (int i = 0; i < buttons.Length; i++)
                buttons[i].MouseDown += new MouseEventHandler(ButtonMap_Down);

            soundOfExpozion = new SoundPlayer("sound.wav");
        }

        private void ButtonMap_Down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var button = sender as Button;
                if (button.ForeColor == Color.Black)
                {
                    button.BackColor = Color.Blue;
                    button.ForeColor = Color.Blue;
                    button.Image = null;
                }
                else if (button.BackColor == Color.Blue)
                {
                    button.Image = Image.FromFile("flag.png");
                    button.ForeColor = Color.Black;
                }
            }
            
        }

        private void ButtonMap_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var countOfWhites = 0;
            if (button.ForeColor != Color.Black)
            {
                if (button.Text == "0")
                {
                    Point current = new Point();
                    dictionary.TryGetValue(button.Location, out current);
                    WorkWithButoons.ShowNearestButtons(current);
                }
                Drawing.ShowNumber(button);
            }
            foreach (var btn in buttons)
            {
                if (btn.BackColor == Color.White)
                {
                    countOfWhites++;
                }
            }
            if (countOfWhites == 400 - countOfMines)
                MessageBox.Show("Вы выиграли. Поздравляем!");
        }       

        private void FormSaper_Load(object sender, EventArgs e)
        {

        }
    }
}