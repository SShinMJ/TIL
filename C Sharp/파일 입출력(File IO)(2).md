# 파일 입출력(File IO)

## Stream

- 파일을 다룰 때 "데이터가 흐르는 통로"를 뜻한다.
- 데이터를 옮길 때, 먼저 이 스트림을 만들어 둘 사이를 연결한다.

- 메모리 <-> 하드디스크와 같이 저장 매체에 데이터를 저장/불러오기 할 때 스트림을 만들어 둘 사이를 연결한 뒤 데이터를 바이트 단위로 옮긴다.
  
  ![image](https://github.com/SShinMJ/TIL/assets/82142527/b6e97eaa-ddc4-4daf-8914-9a96f4e319e9)

<br>

### Stream Class (using System.IO)

- 입력 스트림, 출력 스트림의 역할을 모두 할 수 있다.
- 파일을 읽고 쓰는 방식으로 순차접근 방식, 임의 접근 방식을 모두 지원한다.
- Stream 클래스는 추상 클래스로 이 클래스의 인스턴스를 직접 만들어 사용할 수 없고, 이 클래스로부터 파생된 클래스를 이용해야 한다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/4d946f76-1bb2-4aaf-8d19-4846b73a89df)

  <br>

  - FileStream Class
    - 파일에 데이터를 저장하거나 불러올 때 사용하는 클래스
    - 파일 스트림 인스턴스(객체) 생성 및 메모리 할당
    - FileStream 클래스는 메모리를 할당할 때 생성자의 첫 번째 매개변수에 파일 경로, 파일명, 확장자를 설정하고, 두 번째 매개변수에 파일 모드를 설정할 수 있다.

      ```csharp
      // 새 파일 생성
      Stream stream = new FileStream("fileName.dat", FileMode.Create);

      // 파일 열기
      Stream stream = new FileStream("fileName.dat", FileMode.Open);

      // 파일을 열거나 파일이 없으면 생성
      Stream stream = new FileStream("fileName.dat", FileMode.OpenOrCreate);

      // 파일을 비워서 열기
      Stream stream = new FileStream("fileName.dat", FileMode.Treuncate);

      // 덧붙이기 모드로 열기
      Stream stream = new FileStream("fileName.dat", FileMode.Append);
      ```

      <br>

      - Stream 클래스로부터 물려받은 오바라이딩 된 메소드
        - 파일에 데이터 쓰기
          
          ```csharp
          // array : 쓸 데이터가 담겨있는 byte 배열
          // offset : byte 배열 내의 시작 오프셋
          // count : 기록할 데이터의 총 길이(단위는 바이트)
          public override void Write(byte[] array, int offset, int count);

          // value : 쓸 데이터가 담겨 있는 byte 변수
          public override void WriteByte(byte value);
          ```

        <br>

        - 파일로부터 데이터 읽기

          ```csharp
          // array : 읽을 데이터가 담겨있는 byte 배열
          // offset : byte 배열 내의 시작 오프셋
          // count : 읽을 데이터의 최대 바이트 수
          public override int Read(byte[] array, int offset, int count);

          public override int ReadByte();
          ```

    <br>

    - BitConverter Class
      - C#에서 다루는 다양한 데이터 형식을 byte 배열로 변환
      - byte 배열을 다양한 데이터 형식으로 변환
      - System 이름공간에 포함되어 있기 때문에 using System; 정의 후 사용
      - BitConverter 클래스 메소드
        - byte > bool / char / string / float / double / short / int / long / ushort / uint / ulong

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/f3fc6e70-46d1-4a96-8816-d2c867c08efe)

  <br><br>

  - BinaryWriter, BinaryReader 이진 데이터 처리
    - 장점 : FileStream을 바로 사용할 경우 BitConverter 클래스를 이용해 Byte 단위로 변환하는 과정을 거쳐야 하지만 이진 데이터 처리에서는 Byte 단위 변환 없이 스트림에 이진 데이터를 기록하거나 불러올 수 있다.

    <br>

    - BinaryWriter : 스트림에 이진 데이터를 기록하기 위한 클래스

      | 메소드 | 기능 |
      |-------|-------|
      | void Write(..) | 매개변수에 입력된 데이터를 파일에 저장한다.<br>매개변수로 C#에 있는 모든 타입의 기본 데이터가 들어갈 수 있다. |

      <br>

    - BinaryReader : 스트림으로부터 이진 데이터를 읽어 오기 위한 클래스

      | 메소드 | 기능 |
      |-------|-------|
      | void Read()<br>bool ReadBoolean()<br>char ReadChar()<br>int ReadInt32()<br>float ReadSingle()<br>string ReadString() | 파일로부터 해당 데이터 형식의 데이터를 읽어와서 반환<br>어떤 데이터를 읽어오는 지에 따라 Read 뒤에 데이터 형식 이름을 추가한다. |
   
  <br><br>

  - StreamWriter, StreamReader 텍스트 파일 처리

    - 텍스트 파일의 경우 ASCII 인코딩에선 각 바이트가 문자 하나를 나타내기 때문에 바이트 오더의 문제에서도 벗어날 수 있고, 이로 인해 플랫폼에 관계없이 생성하고 읽을 수 있다.
    - 프로그램이 생성한 파일의 내용을 편집기로 열면 사람이 바로 읽을 수도 있다.

    <br>

    - StreamWriter : 스트림에 텍스트 데이터를 기록하기 위한 클래스

      | 메소드 | 기능 |
      |-------|-------|
      | void Write(..) | 매개변수에 입력된 데이터를 파일에 저장한다.(줄바꿈 적용 안됨)<br>매개변수로 C#에 있는 모든 타입의 기본 데이터가 들어갈 수 있다. |
      | void WriteLine(..) | 매개변수에 입력된 데이터를 파일에 저장한다.<br>매개변수로 C#에 있는 모든 타입의 기본 데이터가 들어갈 수 있다. |

      <br>

    - StreamReader : 스트림으로부터 텍스트 데이터를 읽어 오기 위한 클래스

      | 메소드 | 기능 |
      |-------|-------|
      | string ReadLine() | 현재 커서가 있는 위치의 데이터 한 줄을 읽어서 반환한다. |
      | string ReadToEnd() | 현재 커서가 있는 위치부터 파일의 끝까지 데이터를 읽어서 반환 |
      | bool EndOfStream | 스트림의 끝에 도달했는지 검사한다. |
   
