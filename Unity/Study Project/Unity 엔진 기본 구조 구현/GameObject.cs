using System;
using System.Collections.Generic;

namespace L20230725
{
    /// <summary>
    /// 자료관리, 이름에 대한 책임(Entity), 컴포넌트 검색
    /// </summary>
    class GameObject
    {
        public GameObject()
        {
            components = new List<Component> ();
            name = String.Empty;
            transform = new Transform();
            AddComponent(transform);
        }

        // 모든 컴포넌트 삭제
        ~GameObject() 
        {
            components.Clear();
        }

        public List<Component> components; // 오브젝트가 가진 컴포넌트를 담는 리스트.
        public string name; // 오브젝트.
        public Transform transform; // 오브젝트 위치 값.
        public void AddComponent(Component newComponent)
        {
            newComponent.transform = transform;
            newComponent.gameObject = this;
            components.Add(newComponent);
        }

        public void RemoveComponent(Component removeComponent)
        {
            components.Remove(removeComponent);
        }

    }
}
