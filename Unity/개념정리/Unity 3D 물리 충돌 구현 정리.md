# Unity 3D - 물리 충돌 이벤트 구현해보기

오브젝트가 충돌했을 때 충돌했음을 표현하는 이벤트를 구현해본다.

이벤트는 충돌당한 오브젝트의 재질이 바뀌도록한다.

<br>

- MeshRenderer로 오브젝트의 재질을 접근하여 변경할 수 있다.

  ```csharp
  MeshRenderer mesh;
  Material mat;
  
    void Start()
    {
       mesh = GetComponent<MeshRenderer>();
       mat = mesh.material;
    }
  ```

<br>

- [OnCollisionEnter](https://docs.unity3d.com/kr/530/ScriptReference/Rigidbody.OnCollisionEnter.html) : 물리적 충돌이 시작할 때 호출되는 함수. (닿기 시작하면 호출)
- [OnCollisionStay](https://docs.unity3d.com/kr/530/ScriptReference/Rigidbody.OnCollisionStay.html) : 물리적 충돌이 지속될 때 호출되는 함수. (닿는 모든 프레임당 한 번씩 호출)
- [OnCollisionExit](https://docs.unity3d.com/kr/530/ScriptReference/Rigidbody.OnCollisionExit.html) : 물리적 충돌이 끝났을 때 호출되는 함수. (접촉을 멈췄을 때 호출)

  ```csharp
  // 충돌시 이벤트
  														// Collision : 충돌 정보 클래스
  private void OnCollisionEnter(Collision collision)
      {
          if (collision.gameObject.name == "Sphere")
            // Color : 기본 색상 클래스, Color32 : 255 색상 클래스
            mat.color = new Color(0, 0, 0);
      }
  
  // 충돌이 끝났을 때 이벤트
  private void OnCollisionExit(Collision collision)
      {
          if (collision.gameObject.name == "Sphere")
              mat.color = new Color(1, 1, 1);
      }
  ```

<br><br>


+ 트리거 이벤트

  특정 오브젝트안에 들어왔을 때 이벤트 발생하게 해보기.

  - [OnTriggerEnter](https://docs.unity3d.com/kr/530/ScriptReference/MonoBehaviour.OnTriggerEnter.html) : 다른 Collider가 트리거에 들어갈 때 호출
  
  - [OnTriggerStay](https://docs.unity3d.com/kr/530/ScriptReference/MonoBehaviour.OnTriggerStay.html) : 트리거에 닿는 다른 Collider마다 프레임당 한 번씩 호출
  
  - [OnTriggerExit](https://docs.unity3d.com/kr/530/ScriptReference/MonoBehaviour.OnTriggerExit.html) : 다른 Collider가 트리거 터치를 중지했을 때 호출
  
  <br>
  
  1. Box Collider(특정 오브젝트의 Collider)에서 트리거(Is Trigger) 체크
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/dfcdc3ca-eace-45d3-a3b1-2e6be545876d)
  
  <br>
  
  2. 트리거에 들어왔을 때 이벤트 처리
  
      ```csharp
      													// 충돌시 이벤트가 아니므로, 콜라이더를 받는다.
      private void OnTriggerEnter(Collider other)
          {
            if(other.name == "Cube")
              rigid.AddForce(Vector3.up * 8, ForceMode.Impulse);
          }
      ```
