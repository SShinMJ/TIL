## Lit Shader Graph

- **Lit Shader Graph 만들기**

  - **Lit Shader Graph 사용하기**

    - **Normal Map (노말맵)**

      **Normal Map(노말맵)**이란, **실제 디테일이 없는 부분을 디테일이 있는 것처럼 보이게 만들기 위한 눈속임 맵**이다.

      일반적으로 푸른색을 띠고 있으며, 빛을 속이기 위한 벡터 데이터들로 이루어진 데이터 텍스쳐 파일이다.
      
      Normal Map을 이용해서 빛을 속이게 되면 마치 매우 많은 폴리곤으로 이루어진 오브젝트처럼 디테일이 표현되지만, 실제로 폴리곤이 늘어나는 것은 아니다.
      
      텍스쳐를 이용해서 빛의 음영을 속여 디테일이 늘어난 것처럼 만드는 속임수다.
      
      또한 Normal Map은 그 특이한 구조 때문에 유니티에서는 텍스쳐의 Type이 Normal map으로 되어 있는지를 반드시 확인해 주어야 한다.
      
      *(유니티 내부적으로 노말맵의 RGBA를 뒤섞어 처리한다. 이것을 'Packed' 라고 하고, 이 파일 포맷은 일반적인 텍스쳐의 압축에 의한 Normal Map 품질의 저하를 막기 위해 RGB에서 R과 G만 높은 품질로 가지고 있는 특수한 텍스쳐 포맷이다. (B는 가지고 있지 않다) R과 G는 각각 X와 Y로 변환되어 사용되며, Z는 연산을 통해 수학적으로 생성해낸다)*

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/ce66bc03-37c2-4c8a-a4f7-3d787c064c7a)

      Normal Map인 텍스쳐의 타입을 Normal Map으로 해주지 않으면, 노말 계산이 정상적이지 않게 되면서 이상한 결과물이 나오게 되므로 반드시 신경 써서 체크해야 한다.

      <br>
      
      Normal map(노말엽)은 지브러쉬(Z-Brush)나 머드박스(Mudbox) 같은 스컬프팅(sculpting) 툴을 이용하거나, 3D 프로그램에서 고품질의 하이 폴리곤 모델링을 한 후 렌더 투 텍스처(Render to texture: RTT)로 추출해 내는 방식을 자주 사용하지만, 간 단하게 이미지의 음영을 기반으로 Normal map을 추출해 내는 통인 Crazy bump 또는 B2M 툴을 이용하기도 한다. 혹은 최신버전의 포토샵에도 이 기능이 들어 있기도 하다.
      
      물론 이러한 좋은 툴들을 사용해도 좋지만 유니티에도 음영을 기반으로 노말맵을 추출해 낼 수 있는 기능이 내장되어 있으므로 퀄리티가 크게 중요하지 않을 때 간단하게 사용하기에는 좋다.
      
      일반 텍스처를 선택하고, 인스펙터에서 Texture type을 Normal map으로 바꿔 준 후, Create from Grayscale을 선택하고. Bumpiness Filtening을 적절히 조절해 줍니다. 그 후 Apply를 누르면 일반 텍스쳐가 Normal map으로 변하게 된다.
      
      만약 결과물이 마음에 들지 않는다면. Bumpiness Filtering을 다시 조절해 주고 Apply를 누르면 다시 조절하면 된다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/501b97a5-49c3-4144-9110-d5c0103eff7d)

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/2a29e909-92e4-4164-bcd1-260a5500929e)

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/6aee2585-04c7-4c18-af1c-fe1d8670949b)

      <br>

      이미 외부 툴에서 추출되어 파랗게 된 Normal Map이라면 이전에 말한대로 Texture type을 Normal Map으로 바꾸어 주는 것만으로 끝이다. 만약 파랗게 된 Normal Map을 가져와서 다시 Create from Grayscale을 선택하면, Normal Map을 다시 흑백으로 인식 후 또 다시 Normal Map으로 변환하기 때문에 결과물이 엉망이 될 것이다.

      <br>

      노말맵 텍스쳐를 Normal에 연결해 준다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/395e0886-0068-4f79-9860-6d38e4034cfe)

      <br>

      표면의 디테일이 섬세해져서 더욱 실감나는 재질이 되었다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/c4d172a5-8933-4dd8-83e4-a1f89e80ba18)

      <br>

      또한 Lit Shader에서는 Normal Map의 강도를 조절할 수 있는 기능이 있다. 

      다행스럽게도 Shader Graph에는 Normal Strength Node가 있기 때문에 이를 연결해서 조절할 수 있도록 해주면 Normal Map의 강도를 조절할 수 있다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/9885ce42-da11-436a-b6f0-6e13d5fd5215)

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/1a362ba9-b85d-431b-ae35-a314991a5e0c)

      적당히 푸른색이었던 Normal Map이 셰이더그래프에서 새파란 색이 되었다.

      이전에 Packed되었던 Normal Map이 Unpack 되면서 나온 결과이기 때문에, 문제가 아니고 정상적인 결과다.

    <br><br>

    - **엠비언트 오클루젼 (Ambient Occlusion)**

      엠비언트 오클루젼(Ambient Occlusion)은 구석진 부분의 추가적인 음영을 표현해 주는 기능을 가지고 있다. 일반적으로 환경광(Ambient Color)으로 가득 차 있는 세상에서 그림자가 드리워진 부분도 사방에서 오는 환경광 정도는 받고 있는 것이 일반적이다. 매우 구석져 있거나 복잡한 물체들로 가려져 환경광도 닿지 못하는 부분은 더욱 더 어두워지는데 이 부분을 엠비언트 오클루젼(Ambient Occlusion: 환경 차폐)라고 부른다.

      이 맵 역시 여러 가지 툴에서 추출해 낼 수 있는 텍스쳐이며, Metallic이나 Smoothness처럼 Float 값만 있으면 된다.
      
      이 맵을 사용하면 구석진 부분의 음영이 강조된다.

      <br>
      
      그렇다면 이 AO맵을 실제로 사용해본다.
      
      우선 기본적으로 Ambient Occlusion(AO) 값은 1이 들어 있다.(흰색의 텍스처가 들어 있는 상태와 같다는 의미)

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/17f08a07-7b26-4015-a149-38aee723e40a)

      <br>

      이 상태에서 총을 잘 보면 구석진 부분에도 환경광이 반사되어서 연하게 푸른색의 빛을 받고 있다는 것을 볼 수 있다. 괜찮지만 무언가 좀 가벼운 느낌이다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/b1ab377f-1361-46fa-9496-30bd2b989d6c)

      <br>

      Ambient Occlusion 값을 0으로 하면 아래와 같이 바뀐다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/80519300-2aa3-4917-89a1-7b04e1293ba7)

      총에서 환경광의 영향이 사라지고, 주광의 영향만 남게 된다. 즉, 주광을 받지 못한 부분은 그냥 검은색이 되는 것이다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/5fc3604d-cad3-47cf-9f79-6f567f1fab50)

      <br>

      다른 방법으로 Ambient Occlusion에 아래와 같은 맵(구석진 부분이 검게 되어 있는 텍스쳐)을 넣어본다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/ddfc64e9-f893-4272-9f88-23c27f9568af)

      Ambient Occlusion 텍스처의 채널 하나를 연결해서 직접 확인해 보도록 한다. 총의 구석진 부분이 어두워지는 것을 볼 수 있다. 구석진 부분은 환경광이 닿지 못하게 되어, 중후하고 묵직한 느낌이 되었다. (구석 부분이 확실하게 어두워짐)

      (주광+ 환경광 연산에서 환경광에 AO(Ambient Occlusion)을 곱해서 만들어진 결과이다. 주광+ 환경광 XAO 인 것)

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/08c9d313-4bd0-4cb3-86e6-d1c101c9e4e7)

      <br>

      또한 Ambient Occlusion도 강도를 조절해 줄 수 있다.

      아래와 같이 만들면, 0을 넣으면 변화가 없고, 1에 가까워질수록 Occlusion이 약해지고, 음수가 되면 Occlusion이 강해지도록 만들 수 있다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/61ff5bdb-3aa4-429d-a591-a5efc9b8abbc)
      
      <br>

      Saturate를 넣은 이유는 AO 값은 0~1 사이만 사용하기 때문이다. 이미 검은색에 숫자를 더 빼면 음수가 되어 버리니, 그걸 다시 0으로 돌리기 위해서이다.

      잘 생각해 보면, Metallic 텍스처의 G와 B는 아무것도 사용하지 않고 있고, Ambient Occlusion 맵도 R만 사용하고 있어서 나머지 채널이 낭비가 된다는 것을 알 수 있다.
      
      아시다시피, 게임에서 텍스처 용량을 아끼는 것은 무척 중요하다.
      
      그렇다면, 포토샵을 이용해서 Metallic 텍스처와 Ambient Occlusion 텍스처를 다른 채널에 합쳐서 사용할 수도 있으며, 현재 필요 없는 Base Map의 A 채널을 Ambient Occlusion 맵으로 이용하는 방법도 있다.(각각의 장단점이 있다)

    <br><br>
  
    - **이미션 (Emission)**
  
      Emission은 RGB 이미지로, 빛의 영향을 받지 않는 Unlit 텍스처이다. 그림자의 영향도 받지 않기 때문에, 주로 전구와 같이 스스로 빛나는 부분에 사용한다.
  
      역시 Emission 텍스쳐를 적용하면, 검은색 부분은 빛나지 않고 컬러가 적용된 부분만 빛나게 된다.
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/8a3cb7de-cfd4-4a8c-8056-04aa5fc56e74)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/65c47e2d-55e2-43c2-b83d-debdb47590f8)
  
      <br>
  
      그리고 Emission도 Lit 셰이더에서는 색을 곱해서 조절할 수 있는 기능이 들어가 있으므로 똑같이 따라 만들어 본다.
  
      ColorSpace Conversion 노드 추가
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/3ecf442a-76b8-41ef-82d6-6fc3f9be28dc)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/b77ace89-7066-4891-9a60-60aa1f7c418d)
  
      <br>
  
      여기서 Emission의 색 조절은 Base Map의 색 조절과는 다르게 HDR 옵션을 주는 것이 좋다. Emission은 빛이 날 수 있기 때문에 1보다 큰 색을 곱해주면 더 강하게 빛나는 Emission을 만들 수 있다.
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/1ddabc80-eb55-4786-a0d4-924dcecc3804)
  
      <br>
  
      Emission에 곱해지는 Color를 HDR로 바꿔주고, Intensity를 적당히 큰 수로 올린 후 저장하면 Emission 부분이 더 멋지게 빛나는 총의 모습을 볼 수 있다.
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/6203ed60-38cf-403e-a12c-7dbe918694d8)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/1501a662-2779-41be-82c8-efb7f4a94efa)
  
      추가로 곱셈을 더 만들어 준다면 엄청나게 빛나게도 만들어 줄 수 있다.
  
    <br><br>
  
    - **쉐이더 완성하기**
  
      여기까지 만들었다면 Lit 셰이더에서 사용하는 기능은 Height Map과 Detail Input 외에는 전부 다 구현한 것이다.*(이 두 기능은 사용 빈도가 상대적으로 적다)*
      
      <br>
  
      이제 Property로 올리고 싶은 노드들을 선택해서 오른 클릭 후 Property로 바꿔주고 정리하여 Lit 셰이더처럼 만든다.
      
      텍스쳐 오브젝트를 생성해서 Sampler에 연결하는 법이 있지만, 지금과 같은 경우에는 거꾸로 하는 법도 있다. Sampler의 Texture를 클릭 - 드래그 하면, 생성될 수 있는 노드가 추천되어 나온다.
      
      여기서 Texture2D Asset을 선택해 주면 Sampler에 연결되어 있는 Texture2D Asset을 생성할 수 있다.
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/bf735a7b-c5a1-461f-8bd9-136584a55c9f)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/291c3ef4-091b-46c6-99e5-caad19515850)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/be404db2-d95f-41c2-9b2f-18ce5b3ee294)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/a5973014-08fb-4623-98a1-6081b5223d6a)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/2508d1b4-94e9-4b37-a912-fc47756ede90)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/83ae1acc-a9b2-4c27-b429-8e97761c0a83)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/5a4869b9-3432-402c-ba48-cf1f111b00e7)
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/f1340191-a42c-4021-af9a-4076d4cc7299)
  
    <br><br>
  
    - 배경 바꾸기
      
      물리 기반 셰이더는 '**다른 환경에서도 물리적으로 옳아 보이는 결과물이 나온다**'는 것이 큰 특징이다. **주변 환경에 자동으로 영향받아 색이 변한다**는 의미이다.
  
      <br>
      
      확인을 위해 위해 [https://hdrmaps.com/glazed-patio](https://hdrmaps.com/glazed-patio%EC%97%90%EC%84%9C%C2%A0%EB%AC%B4%EB%A3%8C%C2%A0GLAZED%C2%A0PATIO%C2%A0hdri%27%22%C2%A0%ED%8C%8C%EC%9D%BC%EC%9D%84%C2%A0%EB%8B%A4%EC%9A%B4%EB%B0%9B%EC%8A%B5%EB%8B%88%EB%8B%A4.)  에서 무료 GLAZED PATIO hdri 파일을 다운로드한다.
      
      다운받은 exr 파일을 유니티에 드래그 앤 드롭으로 넣는다.
      
      *(exr 파일은 용량이 무척 큰 고품질의 밝기 영역을 가지는 hdr 텍스쳐이다.)*
      
      이 파일을 Inspector에서 Texture Shape Cube로 바꾸면 일정 시간이 지난 후 변환되어 Cubemap으로 사용할 수 있게 된다.
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/81bd487d-0ee8-4329-ba9f-b5417642aa7f)
  
      <br>
  
      제대로 적용하려면 좀 더 복잡한 방법을 거쳐야 하지만, 당장 간편하게 환경을 바꾸기 위해서는 만들어진 Cubemap 을 빈 하늘에 대충 드래그 앤 드롭 해서 던져 넣기만 하면된다.
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/fd1b92a4-698d-465b-a670-d277d57d8efd)
  
      환경이 바뀌었고, 총의 반사되는 재질도 바뀐 환경의 색의 영향을 받는 것을 알 수 있다. (Cubemap은 배경으로 많이 쓰이는 텍스쳐 형식이다.)
  
    <br><br>
  
    + 지금 만든 쉐이더를 Magazine(탄창)과 Bullet(총알)에도 적용해보자
  
      ![image](https://github.com/SShinMJ/TIL/assets/82142527/a6817be6-1fc8-470d-9c65-d71174ee9eeb)

    
      
