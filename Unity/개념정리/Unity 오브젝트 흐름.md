![image](https://github.com/SShinMJ/TIL/assets/82142527/a921e769-ff28-45c3-a0d4-11fa24793558)

```csharp
public class LifeCycle : MonoBehaviour
{
  // 초기화 영역
    // 게임 오브젝트 생성할 때, 최초 실행(한번만 실행).
    void Awake()
    {
        // 데이터가 준비되었음을 알릴 수 있다.
    }

    // 업데이트 시작 직전, 최소 실행(한번만 실행)
    void Start()
    {
        
    }

  // 초기화와 물리 영역 사이에서 오브젝트가 활성화 된다.
    // 게임 오브젝트가 활성화 되었을 때
    private void OnEnable()
    {
        // 켜고 끌 때마다 실행.
        // ex) 플레이어 로그인 표시 등
    }

  // 물리 영역
    // 물리 연산 업데이트.
    private void FixedUpdate()
    {
        // 50프레임
        // 고정된 실행주기로 cpu를 많이 사용한다. 부하 발생 주의.
        // ex) 플레이어 이동 관련 로직.
    }

  // 게임 로직
    // 게임 로직 업데이트
    void Update()
    {
        // 60프레임
        // 물리연산 외 주기적으로 변하는 로직.
        // 환경에 따라 실행 주기가 떨어질 수 있다.
        // ex) 몬스터 사냥
    }

    // 모든 업데이트가 끝난 후 실행
    private void LateUpdate()
    {
        // 카메라나 후처리(경험치 획득) 로직.
    }

  // 비활성화 영역. 오브젝트가 비활성화/삭제 될 때 실행된다.
    // 게임 오브젝트가 비활성화 되었을 때
    private void OnDisable()
    {
        
    }

  // 해체(초기화 영역의 반대)
    // 게임 오브젝트 해체
    private void OnDestroy()
    {
        // 플레이어 데이터 해체
        // 기존 에셋을 삭제할 때 실행된다.
    }
}
```
