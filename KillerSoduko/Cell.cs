using System;
using System.Dynamic;
using System.Text.RegularExpressions;


namespace KillerSoduko
{
	public class Cell
	{
		private int row;
		private int col;
		private int square;
		private int groupId; 
		private int value;

		public Cell(int row, int col)
		{
			this.row = row;
			this.col = col;
			this.square = 3 * (int)(row / 3) + (int)(col / 3);
			this.groupId = 0;
			this.value = 0;
		}

		public void setGroup(int groupId)
        {
			this.groupId = groupId;
        }

		public int getGroup ()
        {
			return this.groupId;
        }

		public int getRow()
		{
			return this.row;
		}

		public int getCol()
		{
			return this.col;
		}

		public int getValue()
		{
			return this.value;
		}

		public void setValue(int a)
        {
			this.value = a;
        }
	}
}