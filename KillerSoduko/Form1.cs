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
           this.gameboard = new Board();
        
            this.gameboard.LoadGame("C:\\Users\\jonat\\source\\repos\\KillerSudoku\\Game2.csv");

            horizontalLine1.BackColor = Color.Black;
            horizontalLine1.Size = new Size(362, 2);
            horizontalLine1.Location = new Point(31, 29);
            
            horizontalLine2.BackColor = Color.Black;
            horizontalLine2.Size = new Size(362, 2);
            horizontalLine2.Location = new Point(31, 150);

            horizontalLine3.BackColor = Color.Black;
            horizontalLine3.Size = new Size(362, 2);
            horizontalLine3.Location = new Point(31, 272);


            horizontalLine4.BackColor = Color.Black;
            horizontalLine4.Size = new Size(362, 2);
            horizontalLine4.Location = new Point(31, 393);


            verticalLine1.BackColor = Color.Black;
            verticalLine1.Size = new Size(2, 362);
            verticalLine1.Location = new Point(31, 31);

            verticalLine2.BackColor = Color.Black;
            verticalLine2.Size = new Size(2, 362);
            verticalLine2.Location = new Point(150, 31);

            
            verticalLine3.BackColor = Color.Black;
            verticalLine3.Size = new Size(2, 362);
            verticalLine3.Location = new Point(272, 31);

            verticalLine4.BackColor = Color.Black;
            verticalLine4.Size = new Size(2, 366);
            verticalLine4.Location = new Point(393, 29);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int startPos = 30;
            int gap = 2;
            
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    var btn = new Button();
                    buttonArray[row, col] = btn;
                    btn.Size = new Size(40, 40);
                    btn.BackColor = this.gameboard.cells[row,col].getGroup().getbackColor();
                    int x = startPos + (40 * col + gap * (col / 3));
                    int y = startPos + (40 * row) + gap * (row / 3);
                    btn.Location = new Point(x, y);

                    if (this.gameboard.cells[row,col].getGroup().getcellSum() == this.gameboard.cells[row,col])
                    {
                        int newSize = 6;
                        btn.Font = new Font(btn.Font.FontFamily, newSize);
                        btn.Text = this.gameboard.cells[row,col].getGroup().getgroupSum().ToString();
                        btn.TextAlign = ContentAlignment.TopLeft;
                    }
                    this.Controls.Add(btn);
                    
                }
            }
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.gameboard.solveBoard())
            {
                 for (int row = 0; row < 9; row++)
                 {
                    for (int col = 0; col < 9; col++)
                    {
                        buttonArray[row,col].Text =  this.gameboard.cells[row,col].getValue().ToString();
                        int newSize = 10;
                        buttonArray[row,col].Font = new Font(buttonArray[row,col].Font.FontFamily, newSize);
                        buttonArray[row,col].TextAlign = ContentAlignment.MiddleCenter;
                    }
                 }  
            }
            else
            {
                MessageBox.Show("Not Solvable");
            }
               
    }
        }
    }
