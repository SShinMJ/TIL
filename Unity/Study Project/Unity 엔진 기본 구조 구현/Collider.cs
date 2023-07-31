using L20230725;
using System;

namespace L230725
{
    internal class Collider : Component
    {
        public Collider() 
        {
            isCollider = true;
        }
        ~Collider() { }

        public bool isCollider;
    }
}
