using L20230725;
using System;

namespace L230725
{
    class AIController : Controller
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
                if (PredictMove(transform.x, transform.y - 1))
                {
                    transform.Translate(0, -1);
                }
            }
            if (direction == 1)
            {
                if (PredictMove(transform.x, transform.y + 1))
                {
                    transform.Translate(0, 1);
                }
            }
            if (direction == 2)
            {
                if (PredictMove(transform.x - 1, transform.y))
                {
                    transform.Translate(-1, 0);
                }
}
            if (direction == 3)
            {
                if (PredictMove(transform.x + 1, transform.y))
                {
                    transform.Translate(1, 0);
                }
            }
        }
    }
}
