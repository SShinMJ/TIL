using System;

namespace L20230725
{
    class MeshRenderer : Component
    {
        protected MeshFilter meshFilter;
        public MeshRenderer()
        {

        }
        ~MeshRenderer() { }

        // Rederer 컴포넌트의 경우 MeshFilter값을 받아와야 하므로
        // 오버라이딩한 것이다.
        public override void Start()
        {
            foreach (var component in gameObject.components)
            {
                if (component is MeshFilter)
                {
                    meshFilter = (component as MeshFilter);
                }
            }
        }

        // 오브젝트의 위치값(부모가 gameObject이므로 위치값을 받아올 수 있다.)에 맞게
        // meshFilter.shape에 담긴 모양을 출력한다.
        public virtual void Render()
        {
            Console.SetCursorPosition(transform.x, transform.y);
            Console.WriteLine(meshFilter.Shape);
        }
    }
}
