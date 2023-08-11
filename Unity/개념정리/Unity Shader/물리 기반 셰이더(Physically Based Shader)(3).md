## VertexColor Shader 배경을 Lit Shader로 만들기

이제 지형 셰이더를 PBR 구조에 맞추어 개조해 볼 수 있다.

![image](https://github.com/SShinMJ/TIL/assets/82142527/9459d836-2859-4cba-925e-c918e37c17ca)

4개의 지형이 섞이면서 느낌이 그럴 듯하지만 Unlit 셰이더이므로, 그저 **텍스쳐만 붙여져 있는 느낌**일 뿐 **빛이나 그림자에도 제대로 반응하지 않고, 재질의 느낌은 거의 없는 상태**이다.

<br><br>

- **Unit으로 되어 있는 Shader를 Lit으로 바꾼다.**
    
    Graph Inspector에서 Graph Setting을 선택하고 Unlit Material을 Lit Material 로 바꿔준다.
    
    이러면 Fragment에 각종 입력 블록이 생긴다.

    <br>  

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/dba543fa-cf22-43ed-981c-554dd33fd2d9)

    Lit으로 바꿨다. 그러나 그래프는 이미 충분히 복잡하고, 천천히 생각을 해 보니 텍스쳐 하나에 저만큼의 그래프인데 저 Lerp 작업을 Metallic. Smoothness, Normal, Emission, Ambient Occlusion에 각각 다 해야 하므로 비효율적이다.

    이것은 노드를 이용한 비주얼 코딩의 대표적인 단점이다.
    
    *(코딩으로는 몇 줄만으로 가능한 것이 노드로는 모니터 하나를 가득 채울 만큼 의 양이 되기도 한다. 게다가 그렇게 양이 많아지면, 전체적으로 한눈에 들어오지도 않아서 어디가 어떻게 꼬였는지 이해할 수 없게 된다.)*

<br><br>

- Sub Graph를 만든다.

  이런 노드 구조의 단점 때문에 노드 에디터들은 비슷한 기능을 가지고 있다. 이것을 코딩에서는 '함수 (function)'라고 하며, Unity Shader Graph에서는 Sub Graph라고 부른다.

  ‘그냥 두면 너무 길어져서 알아보기 힘들기 때문에 반복되는 부분을 모아서 노드 하나로 압축해 버린다'는 느낌으로 접근하면 간단하다.

  <br>
  
  Vertex Color로 4장의 텍스쳐를 lerp하는 부분.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/d301f4ec-517e-4b17-b2d0-5a09694a9fa1)

  <br>
  
  이 부분을 6번 반복해야 하기 때문에 Sub Graph로 바꾸어 본다. 바꾸는 방법은 단순하다.
  
  Sub Graph로 바꾸고 싶은 부분을 선택하 고 오른 클릭 후, Convert to> Sub Graph 를 선택해 주면 된다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/f4ec31df-cf8a-45c4-904f-cd1253f78f0b)

  <br>

  이름을 지정해주고 저장을 눌러주면, 방금 선택한 노드들이 노드 하나로 압축된다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/c3ea917c-6004-479c-85d9-2d2fce85ab3b)

  <br>

  아까 선택했던 '버텍스 컬러를 이용해 4장을 Lerp해 주는 노드들'은 Lerp4TextureByVC 라는 Sub Graph로 저장되었으며, 우리는 이것을 어떤 셰이더에서라도 노드처럼 사용 할 수 있게 된 것이다. 또한, 이 Sub Graph *.shadersubgraph 파일로 저장되어 다른 프로젝트에서도 사용할 수 있다.

  <br>
  
  - 텍스쳐 순서 정리
  
    새로 만들어진 Sub Graph에 입력되는 텍스쳐의 순서가 마음에 안 든다면 아래와 같이 수정할 수 있다. (2, 3, 4, 1로 연결된 것을 1, 2, 3, 4 순으로 들어가게 할 수 있다.
      
    만들어진 Sub Graph를 수정하려면, 간단히 그 노드를 더블 클릭하기만 하면 된다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/c9bb6d22-8a90-42b3-9401-87c3913e8505)

    더블 클릭을 하니 아까 선택해서 Sub Graph로 만든 노드들만 모인 새로운 셰이더가 열린다.
    
    <br>

    이것이 **Sub Graph** 이며, **보통의 Shader Graph와 같지만, 다른 점은 출력이 Output**이라는 것입니다.
    
    입력 부위는 Blackboard로 자동으로 들어가 있다.
  
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/f04db5c5-07ec-4888-8803-f7f718621842)
    
    <br>

    일단 알아보기 편하게 정리한다. Sub Graph로 들어가는 입력부분이 꼬여 있던 것은, Sub Graph의 Blackboard의 순서를 수정하는 것만으로 간단히 수정 가능하다.

    Blackboard를 열고, 드래그 앤 드롭 해서 순서를 제대로 맞춘다. 하는 김에 이름을 바꾸면 더 깔끔하게 정리할 수 있다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/cd8cc124-edc4-4fe3-948e-b58bde7e57ee)

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/aed07bec-a813-4fa2-8cc4-d908a2508e77)

    <br>

    저장 후 다시 원래의 셰이더로 돌아가 보면 순서가 깔끔하게 정리된 것을 볼 수 있다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/7fceaed3-993e-4557-b870-d6070f23f377)

  <br><br>

  Sub Graph는 이렇게 만들어져 있는 노드를 Sub Graph로 변환하는 것도 가능하지만, 아무것도 없는 상태에서 만들 수도 있다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/1029b33c-bcb5-449f-82d2-d4f898e278cd)

  <br>

  예를 들어 이런 것도 가능하다. 

  (아래의 Sub Graph는 4개의 숫자를 받아 모두 더해주는 기능이다. 기본값은 0이며, 이름은 Add4.)

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/b33d176f-a621-4f06-85d5-c1ad2c067eaa)

  <br>

  Texture Sampler2D까지 Sub Graph로 묶지 않은 이유는, 나중에 텍스쳐가 아닌 값 (예를 들어 Metallic에 그냥 숫자 0을 넣을 경우, 혹은 Color를 넣어야 하는 경우)에 대응하기 위해서다.
  
  이렇게 Sub Graph를 만들 때에는 이 기능이 사용되는 범위에 맞게 잘 생각해서 만들어야 한다.
  
  이렇게 Sub Graph로 만들어 놓으면 Shader Graph에서 오른 클릭으로 노드를 생성할 수 있게 되며, 검색으로도 찾을 수 있게 된다. 그러면 이런 기능의 노드가 만들어진 것을 볼 수 있다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/fe7798d7-b2cf-48a9-96af-d6a071f764ed)

  <br>

  기존의 Add는 두 노드끼리만 더할 수 있었기 때문에 3 개나 4개의 값을 더하려면 계속 Add를 추가해서 지저 분하게 그래프를 늘려가야 했었는데, Add4 노드를 만들어 놓으면 최대 4개의 값을 노드 하나로 더할 수 있게 된다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/e1a5a804-7738-4d04-b3c3-c5ca2a7bc914)

  <br>

  이런 식으로 **자신이 자주 사용하는 새로운 노드를 만들 수 있는 것이 Sub Graph**이다.

  *(프로그래밍에서의 함수와 동일한 개념. 자주 쓰는 기능이 있다면 직접 Sub Graph를 만들어 쓴다. 아니면, 아티스트들에게 기본 구조를 만들어 Sub Graph를 만들어 배포해준 다음에, 나머지 응용 부분만 직접 들수 있도록 해주기도 한다)*

<br><br>

- Metallic과 Smoothness의 값 넣기

  이제 Shader Graph가 보기 심플해졌으므로, 본격적으로 작업을 해도 무리가 없을 것이다. 다음으론 물리 기반 셰이더에 입각한 데이터 값을 넣어 본다.

  예제를 보면, Metallic에는 넣을 텍스쳐가 없다.
    
  지금의 지형은 모두 금속이 아니기 때문이다. 이럴 때에는 그냥 숫자 0으로 두면 된다.
    
  Smoothness는 무척 중요하므로 모두 값을 넣어주어야 한다. 조심해야 할 점은, Smoothness 텍스쳐들은 모두 Linear 텍스쳐이기 때문에 모두 SRGB 옵션을 주어야 한다는 것이다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/f5fb76e2-439d-4462-bdbb-5fe04756f4e6)

  <br>

  Smoothness 텍스쳐를 넣어주자. 텍스쳐가 반짝이기 시작한다.(8장의 텍스쳐가 들어간 것)

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/85f0122f-cf0f-4c58-989d-7eed7a9f1964)

  '너무 많은 텍스쳐가 들어가는 것은 곤란하므로 나중에 포토샵에서 채널별로 합쳐주는 것도 좋은 선택이다. 예를 들어, 4장의 smoothness는 각 RGBA 채널에 넣어서 한 장의 텍스쳐로 합쳐줄 수도 있다.

<br><br>

- Normal도 마찬가지 방법으로 4장을 추가하고 넣어 본다.

  **Normal 주의**!
  
  일단 Normal map 텍스쳐는 전부 Normal map 타입으로 되어 있는지 확인 해야한다. 외부에서 불러 오는 텍스쳐는 이름에 따라서 자동으로 변환될 수도 있지만, 많은 경우 자동으로 변환되지 않고 Default로 되어 있기 때문이다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/cfe59617-cb2e-490c-af86-8070e6b6e8b2)

  <br>

  그리고 텍스처 샘플에서도 Type을 Normal로 해 주어야 노말맵으로 인식한다.

  또한 출력에서도 RGB가 모두 필요하기 때문 에 RGBA로 출력해야 한다는 것을 기억해야 한다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/d2d8470d-791e-45da-b9e9-75e8189cf7e1)

  <br>

  Ambient Occlusion도 동일하게 작업해 준다.

  Terrain을 표현하는 셰이더는 무척 무거운 셰이더입니다. Texture Array 같은 기술을 동원해서 텍스쳐의 샘플링을 줄여준다든가 하는 기술을 이용하는 것이 이 이유이다.
  
  AO 텍스쳐도 sRGB를 꺼서 Linear로 만들어 주어야 하는가? 라는 생각이 들 것이다. 이론적으로야 Linear로 만들어 주는 것이 옳겠지만, AO의 경우에는 끄지 않는 것이 보기 좋은 경우도 있어서 취향으로 선택하면 된다. (보기 좋게 만드는 것이 중요하기 땨문)
  
  <br>

  Emission도 넣어 본다.
  
  여기서 주의할 것은, Emission이 들어가는 텍스쳐는 딱 하나뿐이라는 것이다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/d9da30de-0d35-40e5-ac02-dd19ea9a42ce)

  <br>

  **주의!**
  
  다른 3장의 텍스쳐에는 아무것도 넣지 않을 것이기 때문에, '아무것도 들어가지 않았을 때의 기본값'을 설정해 주는 것이 무척 중요하다. 아무것도 들어가 지 않았을 때의 기본값을 White로 해 준다면, 아무것도 넣지 않았을 때 모든 Emission에 흰색 텍스쳐가 들어간 것처럼 되어 버린다.
  
  그러므로 잊지 말고 **Emission은 초기값을 전부 Black**으로 해야 한다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/20cc4a20-b448-481a-a149-3d849a47bc02)

  Emission은 결과의 느낌을 강조하기 위해 10을 곱해주었다.

  나중에 원하는 대로 Color나 수치를 곱하는 Property를 추가해 보는 것도 좋은 방법이다.

  <br>
  
  이러면 완성이다!
  
  Emission텍스처를 넣은 4번 텍스쳐는 빛이 나고, 나머지 텍스쳐는 그대로 출력되는 것을 볼 수 있다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/5a894efa-32d6-429f-b996-771e52638204)

<br><br>

- (추가) Sub Graph로 만든 그래프가 들어 있는 Shader Graph도 또 한 번 Sub Graph를 만들 수 있다.

  즉 Sub Graph 안에 Sub Graph가 들어있는 Shader Graph를 만들 수 있다는 것이다. Sub Graph라고는 하지만 사실 Shader Graph안에서는 그냥 노드 하나일 뿐이다.

  이를 이용해서 위 Shader Graph를 더 축약할 수도 있다.

  - 위 Shader에서는 저번 시간에 배운 Lit Shader 기능에 비해 많은 기능이 축약되어 만들어져 있다. 텍스쳐의 Tilling이나 Offset도 없고, Normal이나 AO(Ambient Occlusion)의 강도조절 기능도 없다. 또한 Emission의 색상 곱하기 기능도 없다. 위 기능을 전부 넣어서 풀버전의 Lit 지형 셰이더를 만들어 보면 좋다.
  - 실제로 저렇게 텍스쳐를 많이 넣으면 샘플 비용이 비싸지고, 안 쓰는 텍스쳐 채널이 낭비되게 된다. 포토샵에 서 텍스처를 어떻게 합쳐서 넣으면 좀 더 텍스쳐 장수가 적어질 것인지 고민하여 해결하면 좋을 것이다.
  
  노말맵의 A가 비었다고 그곳을 사용하는 것은 피해야 한다. 노말맵의 A는 Packing에서 사용하기 때문에, 그곳은 사용할 수 없다. *(물론 노말맵의 Packing을 커스텀으로 만든다면 사용할 수 있다.)*

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/16c34c9c-0927-4d5c-81d6-def099b57002)
