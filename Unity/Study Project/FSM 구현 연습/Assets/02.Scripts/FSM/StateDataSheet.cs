using System.Collections.Generic;

namespace FSM
{
    // 의존성을 가지지 않게 하기 위해서
    //  데이타를 따로 정리해놓고(DB) 가져올 수 있게 한다(아래는 하드코드 예시)
    public static class StateDataSheet
    {
        public static IEnumerable<KeyValuePair<int, IState>> GetPlayerData(StateMachine machine)
        {
            return new Dictionary<int, IState>()
            {
                { 1, new Move(1, machine) },
                { 2, new Jump(2, machine) },
            };
        }
    }
}