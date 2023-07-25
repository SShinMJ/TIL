using L20230725;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L230725
{
    class AIController : Component
    {
        public AIController() { }
        ~AIController() { }

        public override void Update()
        {
            GameObject player = Engine.Find("player");

            if (player.transform.x == transform.x &&
                player.transform.y == transform.y)
            {
                Console.WriteLine("Game Over..");
                Engine.Quit();
                return;
            }

            // 매 입력마다 Monster가 한칸씩 랜덤하게 이동하게 한다.
            Random random = new Random();
            int direction = random.Next(0, 4);

            if (direction == 0)
            {
                transform.Translate(0, -1);
            }
            if (direction == 1)
            {
                transform.Translate(0, 1);
            }
            if (direction == 2)
            {
                transform.Translate(-1, 0);
            }
            if (direction == 3)
            {
                transform.Translate(1, 0);
            }
        }
    }
}
