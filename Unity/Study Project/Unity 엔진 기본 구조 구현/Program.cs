
using L230725;
using System;

namespace L20230725
{
    class Program
    {
        static void Main(string[] args)
        {
            // 싱글턴 패턴
            // new 생성자로 직접 생성하지 못하게 막고,
            // 무조건 하나만 생성되게 한다.
            Engine myEngine = Engine.GetInstance();

            int[,] map = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, // [0,x]
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, // [1,x]
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, // [2,x]
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, // [3,x]
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };

            Random rand = new Random();
            int goalX = rand.Next(1, 18);
            int goalY = rand.Next(1, 8);

            //Init
            //Load
            for (int y = 0; y < 10; ++y)
            {
                for(int x = 0; x < 20; ++x)
                {
                    // 오브젝트 생성 과정
                    GameObject floor = new GameObject();
                    floor.name = "floor";
                    floor.transform.x = x;
                    floor.transform.y = y;
                    floor.AddComponent(new MeshFilter('_'));
                    floor.AddComponent(new MeshRenderer());

                    // 만들어진 오브젝트를 엔진에 올려 실행될 수 있게 한다.
                    myEngine.Instanciate(floor);

                    if (map[y, x] == 1)
                    {
                        // 오브젝트 생성 과정
                        GameObject wall = new GameObject();
                        wall.name = "wall";
                        wall.transform.x = x;
                        wall.transform.y = y;
                        wall.AddComponent(new MeshFilter('*'));
                        wall.AddComponent(new MeshRenderer());
                        wall.AddComponent(new Collider());
                        myEngine.Instanciate(wall);
                    }
                }
            }

            // 오브젝트 생성 과정
            GameObject goal = new GameObject();
            goal.name = "goal";
            goal.transform.x = goalX;
            goal.transform.y = goalY;
            goal.AddComponent(new MeshFilter('G'));
            goal.AddComponent(new MeshRenderer());
            goal.AddComponent(new GoalIn());
            myEngine.Instanciate(goal);


            // 오브젝트 생성 과정
            GameObject monster = new GameObject();
            monster.name = "monster";
            monster.transform.x = 10;
            monster.transform.y = 5;
            monster.AddComponent(new MeshFilter('M'));
            monster.AddComponent(new MeshRenderer());
            monster.AddComponent(new AIController());
            myEngine.Instanciate(monster);


            GameObject player = new GameObject();
            player.name = "player";
            player.transform.x = 1;
            player.transform.y = 1;
            player.AddComponent(new MeshFilter('P'));
            player.AddComponent(new MeshRenderer());
            // 키보드 입력 반응 컴포넌트
            player.AddComponent(new PlayerController());
            myEngine.Instanciate(player);

            // 엔진 실행
            myEngine.Run();
        }
    }
}
