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
        private Cell cellSum; //the cell in the group that shows the sum
        
        public Group(int sum, String color, int index)
        {
            this.groupSum = sum;
            this.backColor = Color.FromName(color);   
            this.groupIndex = index;
            this.alCells = new ArrayList();
            this.cellSum = null;
        }

        public ArrayList getcellList()
        {
            return this.alCells;
        }

        public void addCell (Cell c)
        {
            this.alCells.Add(c);

            // Update the cell that displays the sum if needed
            if (
                // first cell
                (this.cellSum == null) || 

                // new cell is on line above current cell sum
                (c.getRow() < this.cellSum.getRow()) || 

               // new cell is on the left of the current ell sum
               ((c.getRow() == this.cellSum.getRow()) && (c.getCol() < this.cellSum.getCol()))
               )

               {
                    this.cellSum = c;
               }
        }

        public Color getbackColor()
        {
            return this.backColor;
        }
        
        // Returns the group sum
        public int getgroupSum()
        {
            return this.groupSum;
        }
        
        // Returns the Cell that displays the sum
        public Cell getcellSum()
        {
            return this.cellSum;
        }
    }
}


