using UnityEngine;
using PlayerMachine = FSM.PlayerMachine;

public class PlayerController : MonoBehaviour
{
    // 땅을 감지하기 위해 필요.
    public bool isGrounded
    {
        // 물리연산과 같이 비용이 큰 것은 get으로 잘 쓰진 않는다.
        get; private set;
    }
    [SerializeField] private Vector3 _groundDetectCenter;
    [SerializeField] private float _groundDetectRadius;
    [SerializeField] private LayerMask _groundDetectMak;

    private PlayerMachine _machine;
    //private FSM.Generic.PlayerMachine _playerMachine;

    private void Awake()
    {
        _machine = new PlayerMachine(gameObject);
        //_playerMachine = new FSM.Generic.PlayerMachine(gameObject);
    }

    private void Update()
    {
        _machine.Update();
        //_playerMachine.Update();

        // 점프키(Space)를 누르면 상태값이 바뀐다.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _machine.ChangeState(2);
        }
    }

    private void FixedUpdate()
    {
        // 물리 연산이므로 FixedUpdate에서 수행된다.
        DetectGround();

        _machine.FixedUpdate();
        //_playerMachine.Update();
    }

    // 땅에 닿았는지 확인하는 함수.
    private void DetectGround()
    {
        // 읽어올 때는 Rigdbody나 transform이나 비슷하다.
        // Physics.OverlapSphere() : 중점과 반지름으로 가상의 원을 만들어 추출하려는 반경 이내에 들어와 있는 콜라이더들을 반환하는 함수
        Collider[] cols = Physics.OverlapSphere(transform.position + _groundDetectCenter,
                                                _groundDetectRadius,
                                                _groundDetectMak);
        isGrounded = cols.Length > 0;
    }

    // OnDrawGizmos : Unity에서 런타임 시 실행되는 기즈모를 그릴 수 있는 함수
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + _groundDetectCenter,
                              _groundDetectRadius);
    }
}
