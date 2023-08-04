# UV

- UV의 기본개념

  3D로 이루어진 오브젝트에 2D그림을 입히기 위해서 벗겨내어 펼쳐 놓은 것과 비슷하다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/72c2a0d5-8ce7-485f-b8ef-3e6ca3906497)

  3ds Max에서는 EditUVWs라는 이름의 창이 있고, 그 창의 사각형 안쪽에 오브젝트를 펼쳐서 배열한 후 Vertex를 움직여 UV를 정렬한다

  UV 좌표는 XYZ중 XY와 동일하게 취급된다. 그리고 XYZ는 RGB와도 같으므로, UV=XY=RG.

  3차원 좌표로 이루어진 UVW 텍스쳐 좌표계도 존재하나, 일반적으로는 2차원을 사용한다.

  (굵은 사각형의 가로는 U이고, 세로는 V)

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/ed476651-57ea-4788-ba48-8b56e7929c48)

  > UV는 사실 Vector2 (Float2)로 이루어져있다! (범위는 역시 0~1)

  어떤 이미지라도 이 단위 안에 넣을 수 있다.

  어떤 사이즈의 이미지라고 하더라도 결국엔 이미지의 가로세로 0~ 100% 사이로 정의할 수 있을 테니, UV에서 0~1로 할당을 하면 어떤 비례의, 어떤 크기의 이미지이든 UV에 할당을 해서 모델링에 입힐 수 있다는 의미이다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/ce592990-b03c-4b8f-be2e-fdfa3c878994)

  <br>

  - 각 엔진이나 툴마다 UV 배치는 조금 다를 수 있다

    언리얼 엔진이나 DirectX는 왼쪽 위가 Vector2 (0,0)인데 비해,

    유니티 엔진이나 OpenGL은 왼쪽 아래가 Vector2 (0,0) 이다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/4bb7cc2c-99ac-4863-896c-b503a8eb7d3f)

  <br>

  만약 아래와 같이 3ds Max에서 UV를 배열했고 이를 유니티로 넘겼다면, 각 버텍스에는 0에서 1사이의 Vector2의 숫자가 들어가 있는 것과 같다고 생각하면 된다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/110ac696-48a8-4f1c-ab63-87eaccfb8bc6)

  텍스와 버텍스 사이에는 버텍스와 버텍스 사이값으로 보간된다.(Lerp 개념)

<br>

- UV를 시각적으로 해석

  Shader Graph에서는 UV가 이미 시각적으로 표현되어 있다. 이를 어떻게 해석하는지 알아본다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/d6a2ed1d-cadc-45b2-938d-c96b9c6dc3d8)

  텍스쳐 한 장 받는 것 외엔 아무 기능이 없는 셰이더를 만들고, 이것을 메터리 얼에 적용한 후, Quad을 하나 만들어 적용하고, 적절한 텍스쳐를 넣는다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/1923a69f-d843-459e-ad7e-693724b78d32)

  현재 이 Quad의 네 귀퉁이의 Vertex에 들어 있는 UV 숫자는 다음과 같다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/2e4fd459-c02f-4a85-b4d8-58ae3140bad7)

  <br>

  - U(x)

    XY에서 X와 U는 같은 것이라고 했으므로 '가로방향' 을 의미하며, 가로방향은 X축이므로 (X,Y) 형식으로 작성된 숫자 중 앞자리의 숫자를 의미하며, 왼쪽은 0. 오른쪽은 1인 것을 알 수 있다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/de063588-1669-4324-995d-1e10d9b32b4a)

    UV 노드를 꺼내서 Split으로 분해해준 다음, U에 해당하는 R을 출력한다.

    UVW, XYZ, RGB는 동일한 취급이니까 R이 곧 U이다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/37e8b9da-03b4-489f-b007-2c10b6349a68)

    출력 후 저장해 보면, 왼쪽이 0이고 오른쪽이 1인 Linear 그라데이션이 보인다.

    UV에서 U를 이렇게 눈으로 볼 수 있다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/1f60ace8-10e1-4cd4-9e66-4f891155a0c3)

  <br>

  - V(y)

    V는 두 번째 숫자이고, Y축을 의미하므로 세로축이다. (1.0,1.0)

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/25bc51e7-809c-4932-8b0c-7f9c9fc67330)

    Split으로 나눠서 G를 출력하면 된다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/69e8fa4b-b9e9-4e0e-a85c-8d3c15d41ea1)

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/4ac9d12a-9598-4a12-ab4f-a93e01780f85)

  <br>

  - U와 V를 Combine

    U는 R이기도 하기 때문에 R자리에 넣고, V는 G이기도 하기 때문에 G자리에 넣는다. (B에는 들어갈 값이 없습니다. 그냥 0이라고 생각하면 된다.)

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/e495b555-330f-4495-8bbb-c5d395c811c3)

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/e4ca8858-c82b-4215-adf2-89b0b84b655e)

  <br>

  - UV에 숫자 연산

    V는 텍스쳐가 어느 위치에 찍힐 것인가를 나타내는 0~1 사이의 숫자이다. 따라서 덧셈이나 곱셈 등의 연산을 할 수 있다.

    Split으로 UV의 각 요소를 나누고 Combined 로 U와 V만 합쳐서 Vector2를 굳이 만들어 연결해 준다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/1b4e0e72-a284-4be2-8741-5218ca875fa6)

    <br>

    - 덧셈(이동(Offset))

      UV 0.5를 더해주면 어떻게 될까?

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/15e43ee3-78e7-4928-b85e-35a8778854b5)

      Blackboard에서 U이동과 V이동이라는 이름의 Float 입력값이 만들어져 있고, 그 두 개의 Float 입력값을 드래그해서 배치해 주고, ADD 노드로 연결해준 것이다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/eb87e66b-174b-467d-81e0-86000f311085)

      0.5를 더하면 텍스쳐가 왼쪽 아래로 내려온다. 동시에 오른쪽 아래에 계속 연속되어 있던 텍스쳐 역시 밀려 내려와서 보인다.

      - 만약 단색이나 줄무늬의 이상한 그림이 나온다면?

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/ec6854f2-cd71-4d43-ab36-cd59abd20174)

        만약, 이 텍스쳐가 아니고 다른 텍스쳐를 넣었는데, 밀려 내려가지 않고, 단색이나 줄무늬의 이상한 그림이 나온다면 텍스쳐의 Filter 옵션이 Clamp가 아닌지 확인해 봐야한다.

        텍스쳐의 Filter 옵션이 Repeat 이면 텍스쳐가 UV를 벗어나는 영역에서도 계속 반복되어 UV를 이동시켜도 계속 연결되어 보일 것이다.

        Mirror는 좌우 반전되면서 반복되는 것이고, Mirror Once는 한 번만 좌우 반복된다. Per-axis는 U방향과 V 방향에 다른 옵션을 선택할 수 있다. 만약 Clamp라면 마지막 픽셀의 색이 연속되어 늘어나게 보인다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/c7b66843-6454-4b80-9567-4950213498a2)

      <br>

      **텍스쳐가 이동하는 것처럼 보이나 UV가 이동하는 것이다.**

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/8a2dbc74-efcd-4a3c-82ac-f675b5a99d02)

      모든 Vertex에 있는 UV의 값이 0.5씩 증가했음으로 아래와 같이 UV의 값이 변했기 때문이다. 즉, 결과적으로는 왼쪽 아래로 이동한 것처럼 되었다는 것을 알 수 있다.

    <br>

    - 곱셈(타일링(Tilling))

      UV에 각각 2를 곱한다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/8e3b4a62-18e8-43bc-8ab3-05050d4f6c60)

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/a6872d39-b679-4e54-884d-84c7dfdba8f9)

      곱하면 타일링이 된다. (위는 10x10)

      직접 계산해 보면 답은 쉽게 알 수 있다. (0.0)에는 무슨 숫자를 곱해도 0이 되니 변화가 없을 것이고, (1.1)인 부분에 2를 곱하면 (2.2)가 된다.

    <br>

    그래서 텍스처의 Tilling and Offset의 기본 수치가 각각 1. 1과 0.0이었던 것이다. 덧셈은 0을 더해야 변화가 없고, 곱셈은 1을 곱해야 변화가 없기 때문이다.

    <br>

    - UV에 0.5를 더했을 때와 2를 곱했을 때의 UV 컬러는 다르다

      셰이더는 디버깅하기가 굉장히 힘들기 때문에, 실제로 '컬러'를 출력해서 맞는 값이 들어 갔는지를 보는 경우가 많다. 따라서 컬러를 보고 숫자를 짐작하는 훈련이 필요하다.

    <br>

    - 두 연산을 합쳐서 곱셈과 덧셈을 각각 Property 로 제어할 수 있도록 만들어서, 하나의 셰이더에서 모두 돌아갈 수 있게 만들 수 있다.(Tiling And Offset )
   
    <br>

  - Time으로 UV가 자동으로 흘러가게 만들기 (Time, Negate)

    UV에 숫자를 더하면 이미지가 이동하는 것을 알고 있으므로, 내장된 노드인 Time을 사용하면 시간값이 계속 변하며 UV값을 자동으로 계속 변하게 만들 수 있다는 점을 이용한다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/35811707-f679-402c-b0c7-ef3d0313319a)

    > TIME                         시간 값을 출력합니다.
    > SINE TIME                  Sine 타임 값을 출력합니다.
    > COSINE TIME              Cosine 타임 값을 출력합니다.
    > DELTA TIME                현재 프레임의 타임 값인 델타 타임을 출력합니다.
    > SMOOTH DELTA          스무스 델타 타임 값을 출력합니다.

    UV에 시간을 더하면 된다. 위의 표에 따르면 Time(1)이 일반적인 시간이므로 이것을 더한다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/9ef5db40-9c34-4a00-b1f6-eacfe18111fc)

    Time을 더하면 미리보기에서 이미지가 흘러가는 것을 확인할 수 있다.

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/8f240a7c-2ee9-4e68-925a-692b7a7e397b)

    (만약 안 움직인다면, Always Refresh가 활성화 확인!)

    U에 더하면 가로로 흘러가고, V에 더하면 세로로 흘러가서 결과적으로는 대각선으로 흘러가게 된다. 즉, **가로로만 흘러가게** 하고 싶다면 **U**에만 더해 주고, **세로로만 흘러가게** 하고 싶다면 **V**에만 더해주면 됩니다.

    <br>

    - 이미지가 좌측 아래로 흘러가는 이유

      U 와 V 즉, X와 Y축에 모두 시간을 더해줬기 때문.

      다시 말해서, 이것을 U나 V에만 더해준다면 가로 혹은 세로로만 흘러가게 할 수도 있다.

      만약 텍스쳐가 물 모양 이고 물의 메쉬 UV가 사각형으로 펴져 있다면 이것을 이용 해서 특정 방향으로 자동으로 흘러가게 할 수도 있다. (실제로 자주 사용한다.)
 
    <br>

    - 반대 방향으로 흘러가게 하기(Negate)

      숫자가 더해지면 점점 숫자가 커지므로 반대로 흘러가게 하려면 점점 숫자가 작아지게 하면된다.

      즉, Time에 -1을 곱해서 음수로 만들어 주면 Time이 점점 작아지므로, 반대로 흘러가게 할 수 있다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/2cb92ca4-f8df-4314-8614-6a972dee1d80)

      (음수와 양수를 바꾸는 행동도 자주하는 행동이므로, 독립된 노드로 만들어져 있다.)

      Negate 노드를 만들고 Time에 연결해 주면, -1을 곱해준 것과 동일한 결과를 얻을 수 있다.

      ![image](https://github.com/SShinMJ/TIL/assets/82142527/81da470e-a3b7-41bf-92a6-06d9f2d14cc5)

    <br>

    - [실습] UV를 이용해서 불 이펙트 만들기

      - 셰이더 없이 만드는 방법

        셰이더 기술 없이 불 이펙트를 만들려면 두 가지 방법을 쓸 수 있다.(섞어 쓰기도 한다)

        <br>

        1. 파티클을 사용

           파티클의 개수를 많이 사용하면 매우 자연스러운 불을 만들 수 있지만, 저사양의 기기에서 심각한 부하를 일으킬 수 있다.

           ![image](https://github.com/SShinMJ/TIL/assets/82142527/64315583-e705-4710-97cc-cf9ed2143056)

        <br>

        2. **시퀀스 이미지**를 사용

           불 애니메이션 이미지를 반복해서 Plane에 플레이를 시키는 방법이다.

           ![image](https://github.com/SShinMJ/TIL/assets/82142527/6ee0da0c-3f86-4fd9-a917-e4b867eabe45)

           이 방법은 좋은 소스를 여러장 가지고 있으면 좋은 품질의 결과물을 만들 수 있는 장점이 있지만, 최적화를 위해서 시퀀스의 숫자를 줄여 버리면 급격히 품질이 저하되는 단점이 있다.

        <br>
        
        > 두 방법의 장단점 때문에 이 두 가지의 방법을 적절히 응용해서 사용한다.

      <br>

      - 셰이더를 이용해서 불 이펙트를 만들기

        - 세팅

          아래와 같이 세팅해준다.

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/a429049c-bec4-43d3-baa2-2000f32d429c)

          일단 Unlit 셰이더를 만들었기 때문에 어두운 곳에서도 빛나고, 빛이 있다고 해도 더 밝아지는 일도 없다. 또한 Unlit은 불과 같은 이펙트에게는 매우 많이 사용되는 옵션이고, 실제로 빛 연산이 없기 때문에 가볍다.

          하지만 현 상태에선 움직이지도 않고, 배경이 투명하지도 않으므로 아래와 같은 처리가 필요하다.

        <br>

        - Graph Setting을 바꾸고 Alpha를 활성화

          Graph Inspector를 열고, Graph Setting을 선택한다.

          Node Setting이 선택한 노드의 세팅을 바꾸는 것이라면, Graph Setting은 셰이더 전체의 세팅을 바꾸는 것이다.

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/35718cda-2e48-4e4e-bb60-0c602a0bc9f7)

          **Material**은 여전히 Unlit으로 둔다. (Lit으로 바꾸면 조명을 받을 수 있는 상태)

          Sprite나 Decal에서 쓸 수 있는 셰이더로 바꿀 수 있는 옵션을 선택도 가능하다.
          
          **Surface Type** Opaque (불투명)에서 **Transparent(투명)**으로 바꿉니다.
          
          그래야 반투명이 활성화되면서, 알파 채널을 넣을 수 있게 된다.

          <br>

          Sample Texture2D의 A 채널을 Alpha에 연결하면 알파 채널대로 배경이 투명해진다.

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/221638c2-24fe-4079-b1e3-d9fd6e9fbf24)

          <br>

          **Blending Mode**는 Transparent가 활성화되면 나오는 선택 모드입니다. Additive가 되면 배경과 덧셈이 되면서 밝아지게 된다.

          **Render Face**는 앞면과 뒷면의 어떤 면에 렌더링 되어질지 결정해 주는 기능이다. 이펙트 계열은 대부분 양면 렌더링을 원하기 때문에 Both로 바꾸어 준다.

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/a89fd4bc-5b46-481c-8b45-0b77c82de16e)

        <br>

        - 이미지를 위로 흘러가게 만들기

          기존 이미지와 별개로 다른 한 장의 텍스쳐를 추가한다.

          첫 번째 텍스쳐와 동일한 방식으로 또 하나의 텍스쳐를 추가하고, 이 텍스쳐를 연결해 출력한다.

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/48245b74-ba80-4462-91e0-f949facf7b1a)

          잘 보면 이 두 번째 이미지는 위아래가 이어지게 생겼다. 즉, 이 이미지를 위로 흘러가게 만든다면 끊임없이 연속적으로 흘러가는 이미지를 만들 수 있다는 것이다.

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/62fb270a-2a89-406c-b7d5-4dda326129d5)

          <br>

          **두 이미지를 합쳐 불을 완성**
          
          두 이미지를 곱해서, 움직이는 불을 만들 수 있다.
          
          첫 번째 이미지와 두 번째 이미지의 rgb 이미지를 곱하고, 다시 첫 번째 이미지와 두 번째 이미지의 알파 이미지도 곱하면 위로 흘러가는 불 모습이 된다.

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/3d65e0cd-be97-48a9-b1c5-fb45301ff0a8)

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/d4d2222c-f5b9-415b-80ac-1fdc1a7bca24)

        <br>

        - HDR Bloom을 활성화

          Standard(URP)로 만들었다면 Post Processing이 활성화되어 있는 상태이다.

          (Post Processing이 활성화되어 있고, Bloom 이 활성화되어 있는지 확인하려면 Hierarchy 에 Global Volume이 있고, 이를 선택했을 때 Bloom의 활성화 여부를 확인하면 된다.)
          
          Post Processing과 Bloom이 활성화되어 있다면, 방금 만들 불 결과물의 RGB 값에 1이상의 숫자를 곱하여, 결과적으로 1보다 큰 색이 나오도록 만든다.

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/cff8abb1-2a27-4799-aa7f-2b71a196d06f)

          <br>

          큰 숫자의 색이 들어가면서 Bloom이 가동되는 것을 볼 수 있다.

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/633f9949-e76a-4d85-8775-db859c244986)

          ![image](https://github.com/SShinMJ/TIL/assets/82142527/ce1c7a41-5d30-48c0-a31e-ffe92cee46d7)

        <br>

        - 좀 더 멋지게 만들기

          - 기본 설정

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/b6d552e5-cf8b-4ea6-a9f3-60628ed6749f)

            새로운 셰이더를 만들고, 불 이미지 한 장을 받도록 만든 후, 앞서 설명대로 '반투명'이 가동되도록한다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/3e176c12-b0a8-4275-a704-dc8d39064df3)

            이번에는 이미지를 곱하지 않는다. 대신 두 번째 이미지에, 아래처럼 검은색을 넣는다. 지금 두 번째 텍스쳐는 검은색, 즉 검은색(0.0.0) 이다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/bdc1312d-07cc-48e4-8b3f-742e515d1044)

          <br>

          - 이미지를 이용해 UV를 움직여 보기

            효과를 확실히 보기 위해서 첫 번째 이미지였던 불 이미지를 체크무늬로 바꾼다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/48a3f864-62d0-4493-b46e-9c60da280592)

            아래처럼 노드를 만든다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/a24ef785-9b08-421c-8f8b-f5bf4033c009)

            우리는 첫 번째 텍스쳐의 UV에다가 각각 일정 숫자를 더해준 적이 있다.

            그런데 이번에는, UV에 숫자가 아니라 검은 텍스쳐의 R 채널을 더해주었다.

            하지만 검은 텍스쳐의 R 채널은 전부 0이다. 즉, 0을 더해준 것과 같은 결과가 나왔으므로, 결과물은 변화가 없다는 것을 쉽게 알 수 있다.

            그렇다면, 만약 두 번째 텍스쳐가 검은색이 아니라면 무슨 일이 일어날까?

            두 번째 텍스쳐가 회색이라면 0.5를 더해준 것과 마찬가지 이므로 텍스쳐 전체 이미지의 절반 정도 이동할 것이고, 두 번째 텍스쳐가 흰색이라면 1.0 이므로 텍스쳐가 전체 이미지만큼 왼쪽 아래로 이동해서 원래 이미지와 똑 같아 보이게 될 것이다.

            <br>

            - 실습

              두 번째 이미지에 회색 텍스쳐를 넣는다.

              ![image](https://github.com/SShinMJ/TIL/assets/82142527/f0b7a59c-0ff3-4b1d-a35f-e2dd00d862b7)

              회색을 넣었는데 0.5 만큼 즉, 절반만큼 움직이지 않는다.

              이것은 '**감마**' 때문이다.

              이 텍스쳐는 현재 SRGB 상태이지만 우리가 원하는 건 '회색'을 원하는게 아니라 '0.5' 라는 데이터를 출력하기를 원하는 것이므로, Linear 텍스쳐로 만들어 주어야 한다. 즉, **텍스쳐를 선택하고 sRGB 선택을 꺼주어야 한다**.

              ![image](https://github.com/SShinMJ/TIL/assets/82142527/44dc3ea1-e61c-4faf-b049-fc2e28f589e6)

            <br>

            그러므로 아래와 같은 이미지를 넣으면 다음과 같이 보이게 된다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/2caa5ff0-3c8b-4f7f-9170-61ada4a136eb)

            가운데 부분만 이동하였다! 

            즉, 이미지의 밝기에 따라 이동하는 것이 다르다는 것을 알 수 있다.

          <br>

          - 이미지를 흐르면서 구겨지게 만들기

            이미지를 구기고 있는 노이즈 이미지를 Time으로 흐르게 하면, 결과물도 흐른다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/5abb421a-1545-4afe-a8af-64854abcc00e)

            첫 번째 이미지를 체커 이미지에서 불 이미지로 바꾼다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/99b566fa-dab1-46ac-9587-9280394eeb0e)

            방향이 대각선 아래이므로 노이즈 이미지의 UV에 Time을 단순 더하기하여 생긴 문제이니, 노이즈 이미지를 위로 흘러가게 만들면 해결된다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/9b40ce24-d1cb-4a5f-8777-72c4ef655fda)












































