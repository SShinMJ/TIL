using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.AnimatorController
{
    public class StateBase : StateMachineBehaviour
    {
        protected CharacterController controller;
        // 초기화
        public virtual void Initialize(CharacterController controller)
        {
            this.controller = controller;
        }

        // 해당 애니메이션이 끝난 상태라면
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            // 다른 애니메이션 실행이 끝난 것이므로 isDirty를 false로 한다.
            animator.SetBool("isDirty", false);
        }

        // 상태가 변환되야하면 상태값을 변경하고,
        // isDirty를 true로 하여 중복 변경되지 않게 한다.
        public void ChangeState(Animator animator, State newState)
        {
            animator.SetInteger("state", (int)newState);
            animator.SetBool("isDirty", true);
        }
    }
}
