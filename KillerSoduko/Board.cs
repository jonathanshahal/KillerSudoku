using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillerSoduko
{
    class Board
    {
        public Cell[,] cells;
        public Group[] groups; //v Todo change to List

        public Board ()
        {
            this.groups = new Group[81];
            
           // Create 2-dim array of cells, each has row' col and square.
           this.cells = new Cell[9,9];
           for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    cells[row, col] = new Cell(row, col);  
                }
            }
        }

        public bool LoadGame(String filename)
        {
            // load the logic of the constrains from a csv file
            bool inCells = true;
            bool inGroups = false;

            using(var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {  
                    String line = reader.ReadLine();

                    if (line.StartsWith("#"))
                    {
                        // Handle comments (lines starting with #), if "Group" is found, switch to read groups.
                        if (line.IndexOf("Group", 0) != -1)
                        {
                            inCells = false;
                            inGroups = true;
                        }
                    }
                    else
                    {
                        // Hanlde line with cell or groups data.
                        var values = line.Split(',');
                        if (inCells)
                        {
                            // Handle cells
                            int row = int.Parse(values[0]);
                            int col = int.Parse(values[1]);
                            int int_group = int.Parse(values[2]);

                            Group group = this.groups[int_group];
                            this.cells[row, col].setGroup(group);
                        }

                        if (inGroups)
                        {
                            // Handle groups
                        }
                    }

                    //MessageBox.Show(line);
                }
            }
            bool rv = true;
        
            return rv;
        }
    }
}
