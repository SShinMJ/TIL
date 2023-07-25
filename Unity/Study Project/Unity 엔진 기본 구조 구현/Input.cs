using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L230725
{
    internal class Input
    {
        public Input()
        {

        }

        ~Input()
        {

        }

        public static ConsoleKey key;
        
        public static bool GetKeyDown(ConsoleKey checkKey)
        {
            if(key == checkKey)
            {
                return true;
            }

            return false;
        }
    }
}
