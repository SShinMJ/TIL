using L20230725;
using System;

namespace L230725
{
    class GoalIn : Component
    {
        public GoalIn() { }
        ~GoalIn() { }

        // 키 입력이 한번 더 주어져야 Update가 되므로 실제론 만난 다음 입력에 게임이 끝난다.
        public override void Update()
        {
            GameObject player = Engine.Find("player");

            // GoalIn 오브젝트의 컴포넌트 이므로 GoalIn의 위치값을 player의 위치값과 비교하면 된다.
            if (player.transform.x == transform.x &&
                player.transform.y == transform.y)
            {
                Console.WriteLine("골인!");
                Engine.Quit();
            }
        }
    }
}
