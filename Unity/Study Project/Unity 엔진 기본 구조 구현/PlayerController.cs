using L20230725;
using System;

namespace L230725
{
    internal class PlayerController : Controller
    {
        public PlayerController() 
        { 
        }

        ~PlayerController()
        {

        }

        // w, a, s, d의 입력으로 상하좌우 이동이 되게 한다.
        public override void Update()
        {
            if (Input.GetKeyDown(ConsoleKey.W))
            {
                if(PredictMove(transform.x, transform.y-1))
                {
                    transform.Translate(0, -1);
                }
            }
            if (Input.GetKeyDown(ConsoleKey.S))
            {
                if (PredictMove(transform.x, transform.y+1))
                {
                    transform.Translate(0, 1);
                }
            }
            if (Input.GetKeyDown(ConsoleKey.A))
            {
                if (PredictMove(transform.x-1, transform.y))
                {
                    transform.Translate(-1, 0);
                }
            }
            if (Input.GetKeyDown(ConsoleKey.D))
            {
                if (PredictMove(transform.x+1, transform.y))
                {
                    transform.Translate(1, 0);
                }
            }
        }
    }
}
