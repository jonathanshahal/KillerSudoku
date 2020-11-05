using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace KillerSoduko
{
    public class Group
    {
        private int groupSum;
        private Color backColor;
        private int groupIndex;
        private ArrayList alCells;

        public void addCell (Cell c)
        {
            this.alCells.Add (c);
        }

        public Color getbackColor ()
        {
            return this.backColor;
        }
        
        
        public Group(int sum, String color, int index)
        {
            this.groupSum = sum;
            this.backColor = Color.FromName(color);   
            this.groupIndex = index;
            this.alCells = new ArrayList();
        }
    }
}


