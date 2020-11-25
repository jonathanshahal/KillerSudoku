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
        public Group[] groups; //v Todo change to List?

        public Board ()
        {
           this.groups = null;
            
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
            // Clear groups in case we already loaded a game.
            if (this.groups != null)
            {
                Array.Clear(this.groups, 0, this.groups.Length);
                this.groups = null;
            }

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
                        // Handle comments (lines starting with #), if "Cells" is found, switch to read cells.
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

                            // cell contains its group
                            this.cells[row, col].setGroup(int_group);

                            Group group = this.groups[int_group];
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
                }
            }
            return true;
      
         }
          
           public bool solveBoard (int row = 0, int col = 0)
        {        
            int a = 1;
            while (a <= 9)
            {
                this.cells[row, col].setValue(a);
                if (this.isValid(row, col, a))
                {
                    if (row == 8 && col == 8)
                        return true;
                    else
                    {
                        Tuple<int, int> nextCell = this.nextCell(row, col);

                        bool rv = solveBoard (nextCell.Item1, nextCell.Item2);
                        if (rv == false)
                        {
                            this.cells[nextCell.Item1, nextCell.Item2].setValue(0) ;
                            if (a == 9)
                                return false;
                        }
                        else
                            return true;
                    }
                }
                
                a++;
             }

             return false;
        }

        
        public bool isValid (int row, int col, int val)
        {
            //row constraint
            for (int col_index=0; col_index<9; col_index++)
            {
                if ((col_index != col) && (this.cells[row,col_index].getValue() == val))
                    return false;
            }
                    
            
            //col constraint
            for (int row_index =0; row_index<9; row_index++)
            {
                if ((row_index != row) && (this.cells[row_index,col].getValue() == val))
                    return false;
            }

            // sub square constraint
            for (int row_index =0; row_index<9; row_index++)
            {
                if (row / 3 == row_index / 3)
                {
                    for (int col_index=0; col_index<9; col_index++)
                    {
                        if (col / 3 == col_index / 3)
                        {
                            if ((row_index != row) && (col_index != col) && (this.cells[row_index,col_index].getValue() == val))
                                return false;
                        }
                    }
                }
            }

            //group constraint
            int groupId = this.cells[row,col].getGroup();
            Group group = this.groups[groupId];
            int groupSum = group.getgroupSum();
            int aggregatedSum = 0;
            bool doAllCellsHaveValues = true;
            foreach(Cell c in group.getcellList())
            {
                int cellValue = c.getValue();
                aggregatedSum += cellValue;
                if (aggregatedSum > groupSum)
                    return false;
                if (cellValue == 0)
                    doAllCellsHaveValues = false; 
            }

            if (doAllCellsHaveValues && (aggregatedSum < groupSum))
                return false;

           

            return true;
        }
        
        
        public Tuple<int, int> nextCell (int row, int col)
        {
            if (col==8)
                return Tuple.Create(row+1, 0);
            else
                return Tuple.Create(row,col+1);
        } 
    
           
        }
    }
