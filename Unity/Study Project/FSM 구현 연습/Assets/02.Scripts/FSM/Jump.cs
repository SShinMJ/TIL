using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public class Jump : StateBase
    {
        // 실행 조건을 override
        // 실행 가능하고 && 땅에 닿아있고 && MOVE 상태일 경우에만 Jump를 실행가능하다.
        public override bool canExecute => base.canExecute &&
                                            controller.isGrounded &&
                                            machine.current == 1;
    
        public Jump(int id, StateMachine machine) : base(id, machine)
        {

        }
    }
}
