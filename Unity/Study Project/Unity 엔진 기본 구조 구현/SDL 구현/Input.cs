using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20230725
{
    class Input
    {
        public Input() 
        {
        }

        ~Input() 
        {
        }

        public static ConsoleKey key;

        public static bool GetKeyDown( ConsoleKey checkKey )
        {
            if (checkKey == key )
            {
                return true;
            }

            return false;
        }

        public static bool GetKeyDown( SDL.SDL_Keycode keyCode ) 
        {
            if (Engine.GetInstance().myEvent.key.keysym.sym == keyCode)
            {
                return true;
            }
            return false;
        }
    }
}
