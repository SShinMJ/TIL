using L20230725;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L230725
{
    class Controller : Component
    {
        public Controller() 
        {

        }

        ~Controller()
        {

        }

        public bool PredictMove(int newX, int newY)
        {
            foreach (var gameObject in Engine.GetInstance().GetAllGameObjects())
            {
                // 다음으로 갈 곳의 오브젝트 가져오기
                if (gameObject.transform.x == newX &&
                    gameObject.transform.y == newY)
                {
                    // 이 오브젝트의 모든 컴포넌트 가져오기
                    foreach (var componet in gameObject.components)
                    {
                        // Collider 컴포넌트가 있다면 가져오기
                        if (componet is Collider)
                        {
                            Collider checkComponent = componet as Collider;
                            if (checkComponent.isCollider)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
