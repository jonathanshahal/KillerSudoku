using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerSoduko
{
    public class Group
    {
        private int sumOfGroup;
        private String backColor;

        public Group(int sum, String color)
        {
            this.sumOfGroup = sum;
            this.backColor = color;
        }
    }
}


