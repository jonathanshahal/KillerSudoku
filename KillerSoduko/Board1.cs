using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* groups:
 * 
 * 
 * */

namespace KillerSoduko
{
    class Board
    {
        //public List<Group> board; 
        public int[,] board1;
        private int nSize;

        public Board (List<Group> listBoard)
        {
            nSize = 9;
            board1 = new int[nSize, nSize];
            for (int c = 0; c < nSize; c++)
                for (int r = 0; r < nSize; r++)
               

                    board1[r, c] = 0;
                    
        }

    }
}
