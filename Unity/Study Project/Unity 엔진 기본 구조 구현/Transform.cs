
using L230725;

namespace L20230725
{
    class Transform : Component
    {
        public Transform()
        {
            x = 0;
            y = 0;
        }

        ~Transform()
        {

        }

        public int x;
        public int y;

        // 위치값 변할 때 쓰는 함수.
        public void Translate(int addX, int addY)
        {
            x += addX;
            y += addY;
        }


    }
}
