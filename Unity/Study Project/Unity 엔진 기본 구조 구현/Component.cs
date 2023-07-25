
namespace L20230725
{
    class Component
    {
        public Component() { }
        ~Component() { }

        // 기본(필수) 컴포넌트 Start, Update
        public virtual void Start()
        {

        }
        public virtual void Update()
        {

        }

        public Transform transform;
        public GameObject gameObject;
    }
}
