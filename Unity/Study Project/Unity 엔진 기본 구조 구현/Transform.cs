
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
            if (checkWall(addX, addY))
            {
                x += addX;
                y += addY;
            }
        }

        public bool checkWall(int addX, int addY)
        {
            if ((x < 2 && addX == -1) || (y < 2 && addY == -1)
                || (x > 17 && addX == 1) || (y > 7 && addY == 1))
            {
                return false;
            }

            return true;
        }
    }
}
