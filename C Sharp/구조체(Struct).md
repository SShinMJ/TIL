# 구조체(Struct)

### 구조체란?
- 데이터를 담기위한 자료구조
- 클래스와 유사한 구조를 가지며, 변수와 메소드를 가질 수 있다.

  ```
  public struct 구조체이름 {
    // 변수
    // 메소드
  }
  ```

  | 특징 | 클래스 | 구조체 |
  |------|--------|--------|
  | 키워드 | class | struct |
  | 형식 | 참조 형식 | 값 형식 |
  | 복사 | 얕은 복사 | 깊은 복사 |
  | 인스턴스 생성 | new 연산자와 생성자 필요 | 선언만으로 사용 가능 |

<br>

- 사용 예시

  ```
  // 구조체
  public struct Stats {
    public string ID;
    public int currentHP;
    public int damage;
  }
  
  public class GameController : MonoBehaviour {
    private void Awake() {
      // new 키워드를 통해 내부 모든 변수의 값을 초기화한다.
      Stats player01 = new Stats();

      // new 없이 선언한다면 해당 구조체의 모든 변수의 값을 직접 초기화해줘야 한다. 안하면 에러발생!
      Stats player02;
      player02.ID = "김용사";
      player02.currentHP = 100000;
      player02.damage = 99999;
  }
  ```
      
