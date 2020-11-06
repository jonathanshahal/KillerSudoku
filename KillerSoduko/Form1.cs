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

            horizontalLine1.BackColor = Color.Black;
            horizontalLine1.AutoSize = false;
            horizontalLine1.Size = new Size(362, 2);
            horizontalLine1.Text = "";
            horizontalLine1.Location = new Point(31, 29);

            
            horizontalLine2.BackColor = Color.Black;
            horizontalLine2.AutoSize = false;
            horizontalLine2.Size = new Size(362, 2);
            horizontalLine2.Text = "";
            horizontalLine2.Location = new Point(31, 150);


            horizontalLine3.BackColor = Color.Black;
            horizontalLine3.AutoSize = false;
            horizontalLine3.Size = new Size(362, 2);
            horizontalLine3.Text = "";
            horizontalLine3.Location = new Point(31, 272);


            horizontalLine4.BackColor = Color.Black;
            horizontalLine4.AutoSize = false;
            horizontalLine4.Size = new Size(362, 2);
            horizontalLine4.Text = "";
            horizontalLine4.Location = new Point(31, 393);


            verticalLine1.BackColor = Color.Black;
            verticalLine1.AutoSize = false;
            verticalLine1.Size = new Size(2, 362);
            verticalLine1.Text = "";
            verticalLine1.Location = new Point(31, 31);

            verticalLine2.BackColor = Color.Black;
            verticalLine2.AutoSize = false;
            verticalLine2.Size = new Size(2, 362);
            verticalLine2.Text = "";
            verticalLine2.Location = new Point(150, 31);

            
            verticalLine3.BackColor = Color.Black;
            verticalLine3.AutoSize = false;
            verticalLine3.Size = new Size(2, 362);
            verticalLine3.Text = "";
            verticalLine3.Location = new Point(272, 31);

            verticalLine4.BackColor = Color.Black;
            verticalLine4.AutoSize = false;
            verticalLine4.Size = new Size(2, 362);
            verticalLine4.Text = "";
            verticalLine4.Location = new Point(393, 31);
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
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
        }

        
     }
}