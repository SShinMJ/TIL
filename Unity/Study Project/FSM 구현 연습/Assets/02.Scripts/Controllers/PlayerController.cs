using UnityEngine;
using PlayerMachine = FSM.PlayerMachine;

public class PlayerController : MonoBehaviour
{
    // 수직, 수평 입력 프로퍼티
    public float horizontal => Input.GetAxis("Horizontal");
    public float vertical => Input.GetAxis("Vertical");
    // MOVE 상태에만 움직이게 해야하므로 관련 프로퍼티.
    public bool isMoveable { get; set; }
    public Vector3 move { get; set; }
    [SerializeField] private float _moveSpeed = 1.5f;
    private Rigidbody _rigidbody;

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
        
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 점프키(Space)를 누르면 상태값이 바뀐다.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _machine.ChangeState(2);
        }

        _machine.Update();
        //_playerMachine.Update();

        // 움직일 수 있을 때(점프나, 떨어지는 상태가 아닐때)
        if (isMoveable)
        {
            move = new Vector3(horizontal, 0, vertical);
        }
    }

    private void FixedUpdate()
    {
        // 물리 연산이므로 FixedUpdate에서 수행된다.
        DetectGround();

        _machine.FixedUpdate();
        //_playerMachine.Update();

        // 움직이는 것도 rigidbody.position이 변경되므로 FixedUpdate에 작성되야 한다.
        Move();
    }

    private void LateUpdate()
    {
        _machine.LateUpdate();
    }

    void Move()
    {
        _rigidbody.position += move * _moveSpeed * Time.fixedDeltaTime;
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
