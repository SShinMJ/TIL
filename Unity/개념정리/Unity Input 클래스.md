## [Unity Input 클래스]

### Input : Unity에서의 모든 입력(마우스/키보드)을 받는 함수.
공식문서 : https://docs.unity3d.com/kr/530/ScriptReference/Input.html

<br>

- 입력받기
        
  [Input 클래스 정적 변수]
        
    - [anyKeyDown](https://docs.unity3d.com/kr/530/ScriptReference/Input-anyKeyDown.html)(반환 값 bool) : 아무 키 입력. 한번의 키 입력에 한 번 카운트.
    - [anyKey](https://docs.unity3d.com/kr/530/ScriptReference/Input-anyKey.html)(반환 값 bool) : 아무 키를 입력 중인지 확인. 한번의 키 입력에서 키다운이 지속되면 계속 카운트.
      
  <br>
  
   [Input 클래스 정적 함수]

  <키보드>

    - `("space")` 와 같이 특정 키를 인식하거나 `([KeyCode.Space](https://docs.unity3d.com/kr/530/ScriptReference/KeyCode.Space.html))` 와 같이 keyCode 사용.

      - “” 사용법
        - 일반 키: “a”, “b”, “c”…
        - 숫자 키: “1”, “2”, “3”, …
        - 화살표 키: “위”, “아래”, “왼쪽”, “오른쪽”
        - 키패드 키: “[1]”, “[2]”, “[3]”, “[+]”, “[=]”
        - 보조 키: “오른쪽 shift”, “왼쪽 shift”, “오른쪽 ctrl”, “왼쪽 ctrl”, “오른쪽 alt”, “왼쪽 alt”, “오른쪽 cmd”, “왼쪽 cmd”
        - 마우스 버튼: “마우스 0”, “마우스 1”, “마우스 2”, …
        - 조이스틱 버튼(모든 조이스틱 포함): “조이스틱 버튼 0”, “조이스틱 버튼 1”, “조이스틱 버튼 2”, …
        - 조이스틱 버튼(특정 조이스틱): “조이스틱 1 버튼 0”, “조이스틱 1 버튼 1”, “조이스틱 2 버튼 0”, …
        - 특수 키: “backspace”, “tab”, “return”, “escape”, “space”, “delete”, “enter”, “insert”, “home”, “end”, “page up”, “ page down ”
        - 기능 키 : “f1”, “f2”, “f3”…
            
      - [keyCode 변수](https://docs.unity3d.com/kr/530/ScriptReference/KeyCode.html)
            
    - [GetKeyDown()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetKeyDown.html) : 키보드를 눌렀는가. 해당 키 입력을 받으면 true.
    - [GetKey()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetKey.html)(반환 값 bool) : 키보드를 누르고 있는가. 해당 키 입력을 받으면 true.
    - [GetKeyUp()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetKeyUp.html) : 누르던 키를 뗐는가. 해당 키 입력을 받으면 true.

  <br>

  <마우스>

    - 괄호안에는 0(왼쪽클릭) 또는 1(오른쪽 클릭), 2(가운데 스크롤버튼)만 입력 가능.
  
      - [GetMouseButtonDown()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetMouseButtonDown.html) : 마우스 클릭. 마우스  버튼 입력을 받으면 ture.
      - [GetMouseButton()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetMouseButton.html) : 마우스 클릭 중. 마우스  버튼 입력을 받으면 ture.
      - [GetMouseButtonUp()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetMouseButtonUp.html) : 마우스 클릭 떼기. 마우스  버튼 입력을 받으면 ture.
       
  <br>
   
  <기기 종류 관계 없이 입력 버튼이 있다면 인식함>

    - Input 버튼 입력을 받으면 true.

      - [GetButtonDown()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetButtonDown.html) : 키 입력.
      - [GetButton()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetButton.html) : 키 누르는 중.
      - [GetButtonUp()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetButtonUp.html) : 키 뗌.
  
<br><br>

- 움직이기

  -> 수평, 수직 버튼 입력을 받으면 동작. 왼쪽은 음수, 오른쪽은 양수. 동시에 누르면 0이다.
        
  - [GetAxis()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetAxis.html)(반환값  float) : 가중치를 포함한 값을 반환한다.
  - [GetAxisRaw()](https://docs.unity3d.com/kr/530/ScriptReference/Input.GetAxisRaw.html) : 왼쪽값은 -1, 오른쪽 값은 1로 고정.
        
    (수평은 “Horizontal”, 수직은 “Vertical”)
