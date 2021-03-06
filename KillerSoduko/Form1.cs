﻿using System;
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
        Board gameboard;
        Board solvedGameboard;
        String game2 = "C:\\Users\\jonat\\source\\repos\\KillerSudoku\\Game2.csv";
        String game3 = "C:\\Users\\jonat\\source\\repos\\KillerSudoku\\Game3.csv";
        String game4 = "C:\\Users\\jonat\\source\\repos\\KillerSudoku\\Game4.csv";
        String activeBoard;
 
        public Form1()
        {
            // Set KeyPreview object to true to allow the form to process 
            // the key before the control with focus processes it.
            this.KeyPreview = true;

            this.activeBoard = game2;
            
            // Associate the event-handling method with the KeyDown event.
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.LoadForm();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int keyValue = e.KeyValue-48;
            if ((this.gameboard.btnInFocus != null) && 
                ((keyValue>=1 && keyValue <=9) || (keyValue == -40)))
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                         if (buttonArray[row, col] == this.gameboard.btnInFocus)
                         {
                            int valueToSet = (keyValue == -40) ? 0 : keyValue;
                            this.gameboard.cells[row,col].setValue(valueToSet);
                            AddValueToCell(row, col);
                         }
                    }
                }
            }

            e.Handled = false;
        }


        public void LoadForm()
        {
            InitializeComponent();
            
            
            this.gameboard = new Board(); 
            this.solvedGameboard = new Board();
            this.gameboard.LoadGame(activeBoard);
            this.solvedGameboard.LoadGame(activeBoard);
            horizontalLine1.BackColor = Color.Black;
            horizontalLine1.Size = new Size(363, 2);
            horizontalLine1.Location = new Point(30, 29);
            
            horizontalLine2.BackColor = Color.Black;
            horizontalLine2.Size = new Size(362, 2);
            horizontalLine2.Location = new Point(31, 150);

            horizontalLine3.BackColor = Color.Black;
            horizontalLine3.Size = new Size(362, 2);
            horizontalLine3.Location = new Point(31, 272);

            horizontalLine4.BackColor = Color.Black;
            horizontalLine4.Size = new Size(363, 2);
            horizontalLine4.Location = new Point(30, 393);


            verticalLine1.BackColor = Color.Black;
            verticalLine1.Size = new Size(2, 362);
            verticalLine1.Location = new Point(30, 31);

            verticalLine2.BackColor = Color.Black;
            verticalLine2.Size = new Size(2, 362);
            verticalLine2.Location = new Point(150, 31);

            verticalLine3.BackColor = Color.Black;
            verticalLine3.Size = new Size(2, 362);
            verticalLine3.Location = new Point(272, 31);

            verticalLine4.BackColor = Color.Black;
            verticalLine4.Size = new Size(2, 366);
            verticalLine4.Location = new Point(393, 29);

            
            MyCheckBox1.Text = "Board 1"; 
            MyCheckBox1.Location = new Point (600,40);
            MyCheckBox1.Checked = (activeBoard == game2); // Calls LoadForm!
            

            MyCheckBox2.Text = "Board 2"; 
            MyCheckBox2.Location = new Point (600,80);
            MyCheckBox2.Checked = (activeBoard == game3); // Calls LoadForm!

            MyCheckBox3.Text = "Board 3"; 
            MyCheckBox3.Location = new Point (600,120);
            MyCheckBox3.Checked = (activeBoard == game4); // Calls LoadForm!

            
            this.DrawCells(true);  
        }

        private void DrawCells(bool ForceNewCells = false)
        {
            bool firstTime = ForceNewCells;
            int startPos = 30;
            int gap = 2;
            
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    
                    if (buttonArray[row, col] == null)
                    {
                        buttonArray[row, col]  = new Button();
                        firstTime = true;
                    }
                    
                    var btn =  buttonArray[row, col];
                    btn.Text = "";                    
                    btn.Image = null;

                    btn.Size = new Size(40, 40);
                    int groupId = this.gameboard.cells[row,col].getGroup();
                    btn.BackColor = this.gameboard.groups[groupId].getbackColor();
                    int x = startPos + (40 * col + gap * (col / 3));
                    int y = startPos + (40 * row) + gap * (row / 3);
                    btn.Location = new Point(x, y);
               

                    // Dispaly group sum if needed
                    if (this.gameboard.groups[groupId].getcellSum() == this.gameboard.cells[row,col])
                    {
                        int newSize = 6;
                        btn.Font = new Font(btn.Font.FontFamily, newSize);
                        btn.Text = this.gameboard.groups[groupId].getgroupSum().ToString();
                        btn.TextAlign = ContentAlignment.TopLeft;
                    }
                    
                    if (firstTime)
                        this.Controls.Add(btn);

                    btn.Click += setButtonInFocus;
                  
                }
            }
            

  
                

        }


        private void DrawValueSumButton(Button button, int sum, int value)
        {
            button.Text = "";
            Bitmap bmp = new Bitmap(button.ClientRectangle.Width, button.ClientRectangle.Height);
            Graphics G = Graphics.FromImage(bmp);
            G.Clear(button.BackColor);

            StringFormat SF = new StringFormat();
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

            // Draw sum
            Font font6 = new Font(button.Font.FontFamily, 6);
            G.DrawString(sum.ToString(), font6, Brushes.Black, 10, 10, SF);

            // Draw value
            Font font10 = new Font(button.Font.FontFamily, 10);
            string strValue = (value == 0)? "" : value.ToString(); 
            G.DrawString(strValue, font10, Brushes.Black, 20, 20, SF);
            
            button.Image = bmp;
            button.ImageAlign = ContentAlignment.MiddleCenter;

        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.gameboard.solveBoard())
            {
                 for (int row = 0; row < 9; row++)
                 {
                    for (int col = 0; col < 9; col++)
                    {
                        AddValueToCell(row, col);
                    }
                 }  
            }
            else
            {
                MessageBox.Show("Not Solvable");
            }
        }

        private void AddValueToCell(int row, int col)
        {
            int groupId = this.gameboard.cells[row,col].getGroup();
            if (this.gameboard.groups[groupId].getcellSum() == this.gameboard.cells[row,col])
            {
                // cell with sum
                int sellSum = this.gameboard.groups[groupId].getgroupSum(); 
                this.DrawValueSumButton(buttonArray[row,col], sellSum, this.gameboard.cells[row,col].getValue());
            }
            else
            {
                // cell without sum
                int value = this.gameboard.cells[row,col].getValue();
                string strValue = (value == 0)? "" : value.ToString();
                buttonArray[row,col].Text =  strValue;
                int newSize = 10;
                buttonArray[row,col].Font = new Font(buttonArray[row,col].Font.FontFamily, newSize);
                buttonArray[row,col].TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    this.gameboard.cells [row,col].setValue(0);
                }
            }

            this.DrawCells();
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            bool isRight = true;
            if (this.solvedGameboard.solveBoard())
            {
                 for (int row = 0; row < 9; row++)
                 {
                    for (int col = 0; col < 9; col++)
                    {
                        AddValueToCell(row, col);
                    }
                 }  
            }

                 for (int row = 0; row < 9; row++)
                 {
                    for (int col = 0; col < 9; col++)
                    {
                       if (this.gameboard.cells [row, col].getValue() != this.solvedGameboard.cells [row, col].getValue())
                       isRight = false;
                    }
                 }  
                    
                if (isRight == true)               
                {
                    MessageBox.Show ("True");
                    
                }   
                 
                else
                {
                   MessageBox.Show ("Wrong");
                }
        }

        private void CheckBox1_CheckedChanged(Object sender, EventArgs e)
        {
            if (activeBoard != game2)
            {
                activeBoard = game2;
                this.gameboard.LoadGame(activeBoard);
                this.Controls.Clear();
                this.LoadForm();
            }
        }

        private void CheckBox2_CheckedChanged(Object sender, EventArgs e)
        {
            if (activeBoard != game3)
            {
                activeBoard = game3;
                this.gameboard.LoadGame(activeBoard);
                this.Controls.Clear();
                this.LoadForm();
            }
        }

         private void CheckBox3_CheckedChanged(Object sender, EventArgs e)
         {
            if (activeBoard != game4)
            {
                activeBoard = game4;
                this.gameboard.LoadGame(activeBoard);
                this.Controls.Clear();
                this.LoadForm();
            }
        }

         private void setButtonInFocus(object sender, EventArgs e)
         {
            Button btn = sender as Button;
            if (btn != null)
            {
                this.gameboard.btnInFocus = btn;
            }
         }
    }
}