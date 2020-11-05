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
        //bool boo = true;
        Board gameboard;

        public Form1()
        {
            InitializeComponent();
            //create board
            this.gameboard = new Board();
        
            this.gameboard.LoadGame("C:\\Users\\jonat\\source\\repos\\KillerSudoku\\Game2.csv");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int cnt = 0;
            int startPos = 30;
            int gap = 2;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    var btn = new Button();
                    buttonArray[row, col] = btn;
                    btn.Name = "button_" + cnt;
                    //btn.Tag = (int)(row / 3) * 3 + (int)(col / 3);
                    btn.Size = new Size(40, 40);
                    int x = startPos + (40 * col + gap * (col / 3));
                    int y = startPos + (40 * row) + gap * (row / 3);
                    btn.Location = new Point(x, y);
                    btn.BackColor = this.gameboard.cells[row,col].getGroup().getbackColor();

                    if (this.gameboard.cells[row,col].getGroup().getcellSum() == this.gameboard.cells[row,col])
                    {
                        int newSize = 6;
                        btn.Font = new Font(btn.Font.FontFamily, newSize);
                        btn.Text = this.gameboard.cells[row,col].getGroup().getgroupSum().ToString();

                        btn.TextAlign = ContentAlignment.TopLeft;
                    }
                    this.Controls.Add(btn);
                    cnt++;
                }
            }

                    var label = new Label();
                    label.Text = "";
                    label.BorderStyle = BorderStyle.Fixed3D;
                    label.AutoSize = false;
                    label.Height = 2;
                    label.Location = new System.Drawing.Point(80,80);
                    label.BackColor = Color.Black;

                    this.Controls.Add(label);


        }

        
        private void button1_Click(object sender, EventArgs e)
        {
        }

        
     }
}