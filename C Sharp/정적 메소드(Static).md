# 정적 메소드 - Static

## static이란?

정적 메소드, 정적 변수는 클래스의 인스턴스가 아닌 클래스 자체에 소속된다.

<br>

- **정적(static) 메소드**
  - 인스턴스 메소드와 달리 클래스로부터 객체를 생성하지 않고 직접 호출한다.
  - 메소드 내부에서 instance 멤버를 참조할 수 없다.
  - new로 만들어진 클래스 객체로부터 호출될 수 없다.

  <br>

  ```csharp
  public class Enemy {
    //static 메소드 정의
    한정자 static 반환형식 메소드이름(매개변수) {...}
  }

  public class GameController {
    private void Awake() {
      // 별도의 class 생성을 할 필요 없이 static 메소드를 호출할 수 있다.
      // 클래스명.static으로 정의된 메소드 이름();
      Enemy.메소드이름();
  }
  ```

<br><br>

- **정적(static) 변수**
  - 인스턴스 변수와 달리 클래스로부터 객체를 생성하지 않고 직접 호출한다.
  - instance 변수는 클래스 instance를 생성할 때마다 메모리에 매번 새로 생성되지만, static 변수는 프로그램 로딩 시 단 한번만 생성되고 재사용한다.

  <br>

  ```csharp
  public class Enemy {
    // instance 변수
    public int numeric;

    // static 변수
    public static string specise;
  }

  public class GameController {
    private void Awake() {
      // 객체 인스턴스를 생성하여 만들어진 객체마다 instance 변수 값이 다르다.
      Enemy enemy01 = new Enemy();
      enemy01.numeric = 0;

      // 반면, static 변수인 species는 어떤 객체 인스턴스도 같은 값을 가지게 된다.
      Enemy.species = "고블린";
  }
  ```

<br><br>

- **정적(static) 클래스**
  - static 클래스는 모든 멤버가 static으로 되어 있어야 한다.
  - static 클래스는 객체를 생성할 수 없기 때문에 public 생성자를 가질 수 없다.
  - 대신 static 생성자를 가지며, 이는 주로 static 변수들을 초기화랄 때 사용한다.
  - 게임 시작 시 static 클래스 생성자가 자동 호출된다.
