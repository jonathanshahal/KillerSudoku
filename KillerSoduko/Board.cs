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
           this.groups = null;//new Group[81];
            
           // Create 2-dim array of cells, each has row, col and square.
           this.cells = new Cell[9,9];
           for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    cells[row, col] = new Cell(row, col);  
                }
            }
        }

      //function that recieves a name of a csv file and puts the data of groups in the array of groups and the data of cells in the array of cells
          public bool LoadGame(String filename)
        {
            // load the logic of the constrains from a csv file
            bool inCells = false;
            bool inGroups = true;
            
            /*if (!File.Exists(filename))
            {   
                MessageBox.Show(filename + " Does not exists.\nQuitting.");
            }*/
            using(var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {  
                    String line = reader.ReadLine();

                    if (line.StartsWith("#"))
                    {
                        // Handle comments (lines starting with #), if "Group" is found, switch to read groups.
                        if (line.IndexOf("Cells", 0) != -1) 
                        {
                            inCells = true;
                            inGroups = false;
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

                            // cell contains its group
                            this.cells[row, col].setGroup(group);

                            group.addCell(this.cells[row, col]);
                        }

                        if (inGroups)
                        {
                            // Handle groups
                            int groupIndex = int.Parse(values[0]);
                            String backColor = values[1];
                            int groupSum = int.Parse(values[2]);
                            if (this.groups == null)
                            {
                                this.groups = new Group [groupIndex + 1];
                            }
                            this.groups[groupIndex] = new Group(groupSum, backColor, groupIndex);
                            
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
