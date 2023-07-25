using L230725;
using System;
using System.Collections.Generic;

namespace L20230725
{
    class Engine
    {
        // 오브젝트 리스트 생성. (생성자 안에 구현하는 게 좋다.)
        protected Engine()
        {
            gameObjects = new List<GameObject>();
            isRunning = true;
        }

        // 소멸자.
        ~Engine()
        {

        }

        // 엔진을 하나만 만들게 하여야 한다.
        protected static Engine instance;

        public static Engine GetInstance()
        {
            // 따라서 인스턴스가 존재하지 않을 때만 생성되게 한다.
            if (instance == null)
            {
                instance = new Engine();
            }

            return instance;
        }

        // 오브젝트 리스트에 추가한다.
        public void Instanciate(GameObject newGameObject)
        {
            gameObjects.Add(newGameObject);
        }

        List<GameObject> gameObjects;

        // 실행 함수
        public void Run()
        {
            GameLoop();
        }

        // 실행되는 로직
        protected void GameLoop()
        {
            // 처음 한번만 start가 실행된다.
            AllGameObjectinComponents_Start();

            // isRunning이 true인 동안에만 반복된다.
            while (isRunning)
            {
                // 입력 값 받기 > Update > Render 가 무한 반복된다.
                ProcessInput();
                AllGameObjectinComponents_Update();
                AllGameObjectinMeshRenderer_Render();
            }
        }

        // 키 입력을 받아 input 클래스로 넘겨준다.
        protected void ProcessInput()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            Input.key = info.Key;
        }

        // 모든 오브젝트를 START, UPDATE한다. 
        // 모든 오브젝트는 반드시 START와 UPDATE가 존재하므로
        // 존재 여부 판단 없이 실행.
        protected void AllGameObjectinComponents_Start()
        {
            foreach (var gameObject in gameObjects)
            {
                foreach (var component in gameObject.components)
                {
                    component.Start();
                }
            }
        }

        protected void AllGameObjectinComponents_Update()
        {
            foreach (var gameObject in gameObjects)
            {
                foreach (var component in gameObject.components)
                {
                    component.Update();
                }
            }
        }

        // RENDER의 경우 오브젝트마다 존재유무가 다르므로,
        // 모든 오브젝트를 탐색해야 한다.
        // 'is'로 MeshRederer가 있는지 체크하고
        // 있다면, MeshRederer의 Rednder()함수를 실행한다.
        protected void AllGameObjectinMeshRenderer_Render()
        {
            foreach (var gameObject in gameObjects)
            {
                foreach (var component in gameObject.components)
                {
                    bool result = component is MeshRenderer;
                    if (result)
                    {
                        MeshRenderer temp = component as MeshRenderer;
                        temp.Render();
                    }
                }
            }
        }

        protected static bool isRunning;

        public static void Quit()
        {
            isRunning = false;
        }

        public static GameObject Find(string name)
        {
            foreach(var gameObject in GetInstance().gameObjects)
            {
                if (gameObject.name.Equals(name))
                {
                    return gameObject;
                }
            }

            return null;
        }
    }
}
