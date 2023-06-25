# Unity 3D - 힘을 이용하여 물체 움직이기

RigidBody를 사용하여 움직여본다. 

움직이기는 스크립트로 조절하며, RigidBody 관련 코드는 Update()가 아닌 FixedUpdated()에 작성해야 한다!

<br>

- [RigidBody](https://docs.unity3d.com/kr/530/ScriptReference/Rigidbody.html) 초기화하기
    
    [GetComponent](https://docs.unity3d.com/kr/530/ScriptReference/Component.GetComponent.html) : 자신의 <>안에 선언된 타입의 컴포넌트를 가져온다.
    
    ```csharp
    Rigidbody rigid;
    rigid = GetComponent<Rigidbody>();
    ```

<br>
    
- 속도 조절하기
    
    보통은 비현실적으로 동작하게 되므로, 1인칭 슈팅 게임에서 점프할 때처럼 속도의 즉각적인 변경을 원하는 경우에만 사용한다.
    
    [velocity](https://docs.unity3d.com/kr/530/ScriptReference/Rigidbody-velocity.html) : 현재 이동 속도
    
    ```csharp
    rigid.velocity = Vector3.right; // 오른쪽으로 이동한다.
      Vector3.left;  // 왼쪽으로 이동한다.
      new Vector3(x값, y값, z값); // 커스텀 입력
    ```

<br>

- 힘으로 밀기
    
    [AddForce](https://docs.unity3d.com/kr/530/ScriptReference/Rigidbody.AddForce.html)(Vector3 **force**, ForceMode **mode**= ForceMode.Force) : Vec의 방향과 크기로 힘을 준다.
    
    ([ForceMode](https://docs.unity3d.com/kr/530/ScriptReference/ForceMode.html) : 힘을 주는 방식(가속, 무게 반영))
    
    ```csharp
    // 캐릭터 점프시 아래 코드가 주로 쓰인다.
    // RigidBody의 무게(mass) 값이 클수록 움직이는데 더 많은 힘이 필요해진다.
    rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
    ```

    <br>
    
    점프와 이동 구현하기
    
    ```csharp
    Rigidbody rigid;
    
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }
    
        void FixedUpdate()
        {
            // 점프 구현하기
            if(Input.GetButtonDown("Jump"))
            {
                rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
                Debug.Log(rigid.velocity);
            }
            
            // 상하좌우 이동 구현하기
            Vector3 vec = new Vector3(
                Input.GetAxisRaw("Horizontal"),
                0,
                Input.GetAxisRaw("Vertical"));
    
            rigid.AddForce(vec, ForceMode.Impulse);
        }
    ```

<br>
    
- 회전력
    
    [AddTorque](https://docs.unity3d.com/kr/530/ScriptReference/Rigidbody.AddTorque.html)(Vec) : Vec 방향을 축으로 회전력이 생긴다. 축에 따른 이동방향 주의 필요.
    
    ```csharp
    // Vector3.back(x축 기준 -방향), fwd(x축, +), rigt(z), left(z), up(y), down(y)
    rigid.AddTorque(Vector3.back);
    ```
