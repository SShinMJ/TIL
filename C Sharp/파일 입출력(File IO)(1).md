# 파일 입출력(File IO)

## Directiory, File

### 디렉토리 : 파일이 위치하는 주소로 파일을 담는다. 흔히 폴더라고 부른다.
### 파일 : 컴퓨터 저장 매체에 기록되는 데이터의 묶음.

<br>
 
### - 파일 시스템 메소드

  - **namespace : using System.IO**

    | 클래스 | 설명 |
    |--------|------|
    | Directory | 디렉토리의 생성, 삭제, 이동, 조회를 처리하는 정적 메소드 제공<br>하나의 디렉토리에 한 두가지 작업을 수행할 때 사용한다. |
    | DirectoryInfo | Directory 클래스와 하는 일은 동일하지만 정적 메소드 대신 인스턴스 메소드 제공<br>하나의 디렉토리에 여러 작업을 수행할 때 사용한다. |
    | File | 파일의 생성, 복사, 삭제, 이동, 조회를 처리하는 정적 메소드 제공<br>하나의 파일에 한 두가지 작업을 수행할 때 사용한다. |
    | FileInfo | File 클래스와 동일하나 인스턴스 메소드로 제공<br>하나의 파일에 여러 작업 수행 시 사용한다. |

  <br>

  - 각 클래스에 제공되는 메소드, 프로퍼티

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/b850d95f-b9e1-476f-9e77-8b2be9cbcbc0)

    <br>

    - **File 클래스 정적** 메소드/프로퍼티

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/955b5dd0-bdae-4211-b8e6-c10570c219af)

    <br>

    - **FileInfo 인스턴스 정적** 메소드/프로퍼티
   
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/0193c3cf-0826-49ad-bf1f-a0ef55a1b4ea)

    <br>

    - ![image](https://github.com/SShinMJ/TIL/assets/82142527/99a305d5-1b5e-4ebc-9a67-184ea69360f9)
    
    <br><br>
   
    - **Directory 클래스 정적** 메소드/프로퍼티

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/b96a0c91-d689-455a-86dc-9c9a40c5cb8b)
    
    <br>

    - **DirectoryInfo 인스턴스 정적** 메소드/프로퍼티

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/a1320042-1694-469d-aba3-73d047362a54)
    
    <br>

    - ![image](https://github.com/SShinMJ/TIL/assets/82142527/e6b919f2-9c99-468f-b963-83076d0c3cb7)
