using FSM.Generic;
using UnityEngine;

namespace FSM
{
    // 인터페이스를 상속 받으므로, 무조건 구현한다.
    // 다양한 상태 변화에 대한 추상화 클래스.
    public abstract class StateBase : IState
    {
        // 인터페이스에 따라 get은 반드시 구현되고,
        // 해당 클래스에서만 수정 가능하게(private)하는 set을 추가한다.
        public int id { get; private set; }

        // 추가할 내용 없이 현재 수정 실행 중임을 알리면 되므로
        // 람다식으로 true를 리턴한다.
        public virtual bool canExecute => true;

        protected PlayerController controller;
        protected StateMachine machine;
        protected Transform transform;
        protected Rigidbody rigidbody;
        protected Animator animator;

        // 생성자. id 값과
        public StateBase(int id, StateMachine machine)
        {
            this.id = id;
            this.machine = machine;
            this.controller = machine.owner.GetComponent<PlayerController>();
            this.transform = machine.owner.GetComponent<Transform>();
            this.rigidbody = machine.owner.GetComponent<Rigidbody>();
            this.animator = machine.owner.GetComponent<Animator>();
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnFixedUpdate()
        {
        }

        public virtual int OnUpdate()
        {
            return id;
        }
    }
}
