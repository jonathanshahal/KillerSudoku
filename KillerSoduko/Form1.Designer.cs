using System;

namespace KillerSoduko
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.horizontalLine1 = new System.Windows.Forms.Label();
            this.horizontalLine2 = new System.Windows.Forms.Label();
            this.horizontalLine3 = new System.Windows.Forms.Label();
            this.horizontalLine4 = new System.Windows.Forms.Label();
            this.verticalLine1 = new System.Windows.Forms.Label();
            this.verticalLine2 = new System.Windows.Forms.Label();
            this.verticalLine3 = new System.Windows.Forms.Label();
            this.verticalLine4 = new System.Windows.Forms.Label();
            this.MyCheckBox1 =  new System.Windows.Forms.CheckBox();
            this.MyCheckBox2 =  new System.Windows.Forms.CheckBox();
            this.MyCheckBox3 =  new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Solution
            // 
            this.button1.Location = new System.Drawing.Point(863, 254);
            this.button1.Name = "Solution";
            this.button1.Size = new System.Drawing.Size(153, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Solve Board";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            
            this.button2.Location = new System.Drawing.Point(863, 340);
            this.button2.Name = "Reset";
            this.button2.Size = new System.Drawing.Size(153, 62);
            this.button2.TabIndex = 0;
            this.button2.Text = "Reset Board";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.MyCheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            this.MyCheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            this.MyCheckBox3.CheckedChanged += new System.EventHandler(this.CheckBox3_CheckedChanged);
            // 
            
            // 
           
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 1050);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

            this.Controls.Add(this.horizontalLine1);
            this.Controls.Add(this.horizontalLine2);
            this.Controls.Add(this.horizontalLine3);
            this.Controls.Add(this.horizontalLine4);
            this.Controls.Add(this.verticalLine1);
            this.Controls.Add(this.verticalLine2);
            this.Controls.Add(this.verticalLine3);
            this.Controls.Add(this.verticalLine4);
            this.Controls.Add(this.MyCheckBox1);
            this.Controls.Add(this.MyCheckBox2);
            this.Controls.Add(this.MyCheckBox3);
        }


        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label horizontalLine1;
        private System.Windows.Forms.Label horizontalLine2;
        private System.Windows.Forms.Label horizontalLine3;
        private System.Windows.Forms.Label horizontalLine4;
        private System.Windows.Forms.Label verticalLine1;
        private System.Windows.Forms.Label verticalLine2;
        private System.Windows.Forms.Label verticalLine3;
        private System.Windows.Forms.Label verticalLine4;
        private System.Windows.Forms.CheckBox MyCheckBox1;
        private System.Windows.Forms.CheckBox MyCheckBox2;
        private System.Windows.Forms.CheckBox MyCheckBox3;
    }
}

