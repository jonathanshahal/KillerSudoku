using System;
using System.Dynamic;
using System.Text.RegularExpressions;


namespace KillerSoduko
{
	public class Cell
	{
		private int row;
		private int col;
		private int square; //square that the cell is in
		private Group group; //group that the cell is in
		private int value; //value of cell

		public Cell(int row, int col)
		{
			this.row = row;
			this.col = col;
			this.square = 3 *(row / 3) + (col / 3); 
			this.group = null; 
			this.value = 0; 
		} 

		public void setGroup(Group grp)
        {
			this.group = grp;
        }

		public Group getGroup ()
        {
			return this.group;
        }

		public int getRow()
		{
			return this.row;
		}

		public int getCol()
		{
			return this.col;
		}

		public void setValue(int a)
        {
			this.value = a;
        }
		
		public int getValue()
		{
			return this.value;
		}

		

	}
}