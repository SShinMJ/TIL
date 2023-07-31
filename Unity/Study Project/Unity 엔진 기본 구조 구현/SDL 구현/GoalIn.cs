using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20230725
{
    class GoalIn : Component
    {
        public GoalIn() { }
        ~GoalIn() { }

        public override void Update()
        {
            GameObject player = Engine.Find("player");

            if (player.transform.x == transform.x &&
                player.transform.y == transform.y)
            {
                Console.WriteLine("성공");
                Engine.Quit();
            }
        }
    }
}
