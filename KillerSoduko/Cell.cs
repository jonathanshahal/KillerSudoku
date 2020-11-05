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
		private Group group;

		public Cell(int row, int col)
		{
			this.row = row;
			this.col = col;
			this.square = 3 * (int)(row / 3) + (int)(col / 3);
			this.group = null;
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
	}
}