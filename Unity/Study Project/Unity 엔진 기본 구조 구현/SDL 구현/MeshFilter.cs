using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20230725
{
    class MeshFilter : Component
    {
        public MeshFilter()
        {
            //' ' == " "
            //" " = ' ' '\0'
            Shape = ' ';
        }
        public MeshFilter(char newShape)
        {
            Shape = newShape;
        }

        ~MeshFilter() 
        {
        }

        public char Shape;
    }
}
