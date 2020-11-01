using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillerSoduko
{
    public partial class Form1 : Form

    {
        Button[,] buttonArray = new Button[9,9];
        bool boo = true;
        //Board gameboard;

        public Form1()
        {
            InitializeComponent();
            //create board
            //gameboard = new Board();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int cnt = 0;
            int startPos = 30;
            int gap = 2;

            for (int row = 0; row < 9; row++)
                for (int col = 0; col < 9; col++)
                {
                    var btn = new Button();
                    buttonArray[row, col] = btn;
                    btn.Name = "button" + cnt;
                    btn.Tag = "" + row + col;
                    btn.Size = new Size(40, 40);
                    int x = startPos + (40 * col + gap * (col / 3));
                    int y = startPos + (40 * row) + gap * (row / 3);
                    btn.Location = new Point(x, y);
                    this.Controls.Add(btn);
                    cnt++;
                }

            

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (boo == true)
            {
                for (int row = 0; row < 9; row++)
                    for (int col = 0; col < 9; col++)
                    {
                        buttonArray[row, col].Text = i.ToString();
                    }
            }
            else
            {
                for (int i = 0; i < 81; i++)
                {
                    buttonArray[i].Text = "";
                }
            }
            boo = !boo;
        }
    } */
}