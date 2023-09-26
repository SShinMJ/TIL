using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.AnimatorController
{
    // StateMachineBehaviour : 각 애니메이션을 모두 모니터링할 수 있는 함수를 제공.
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
            // isDirty : Unity Animator의 bool타입 파라미터
            // 다른 애니메이션 실행이 끝난 것이므로 isDirty를 false로 한다.
            animator.SetBool("isDirty", false);
        }

        // 상태가 변환되야하면 상태값을 변경하고,
        // isDirty를 true로 하여 중복 변경되지 않게 한다.
        public void ChangeState(Animator animator, State newState)
        {
            // Enum으로 구현된 상태에 따라 맞는 상태값이 들어간다.
            animator.SetInteger("state", (int)newState);
            // Any State에 1:n으로 직접 연결되어 있으므로 하나가 실행되면 다른 것이
            // 실행되지 않음이 보장되어야 하므로 isDirty를 사용하는 것.
            animator.SetBool("isDirty", true);
        }
    }
}
