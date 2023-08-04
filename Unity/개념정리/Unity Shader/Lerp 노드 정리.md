# Lerp 노드

**Lerp** 노드를 이용해서 텍스쳐 두 장을 섞을 수 있다.

Lerp는 Linear Interpolation을 의미하는 말로, '선형보간'이라고 부르며, 매우 흔하게 사용되는 셰이더 노드이다. ('직선적인 비율로 값이 변환되는 것'을 의미)

대표적인 선형 보간의 예는 '그라데이션' 이미지이다. (한쪽이 0이고 다른 한쪽이 1이라면, 가운데는 0.5)

![image](https://github.com/SShinMJ/TIL/assets/82142527/4be5a951-c95b-4f35-b375-33af1195540e)

![image](https://github.com/SShinMJ/TIL/assets/82142527/3a641c5a-b98d-485e-8c1d-68c94849f749)


- 실습

  새 셰이더와 메터리얼을 만들고 Quad에 적용한다.

  셰이더에는 텍스쳐를 두 장 받을 수 있게 만들어서 놓는다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/28019600-7baf-4f6c-a966-29277724773d)

  Graph Inspector를 열고 각각 Default 이미지에 아래 그림처럼 텍스쳐를 넣어 놓는다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/a1edf5c0-e99b-4596-a3df-4107cfe683d2)

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/7f833e25-f25b-48a7-880d-77fe9d0634b7)

  현재는 첫 번째 텍스쳐를 Base Color 출력에 연결하면 첫 번째 텍스쳐가 나오고,두 번째 텍스쳐를 연결하면 두 번째 텍스쳐가 나오는 상태이다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/09fb91d5-11ec-4864-861a-54a33a59d661)

  Lerp 노드를 꺼낸다. (Math - Interpolation 아래에 있다.)

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/2c959756-5438-476f-8878-8e07edd6b3ca)

  > 사용법<br>
  > - 첫 번째 A에는 첫 번째 텍스쳐를 연결한다.<br>
  > - 두 번째 B에는 두 번째 텍스쳐를 연결한다.<br>
  > - 그리고 세 번째에 있는 T는 Float을 하나 만들어서 연결한다.<br>

  제대로 연결했다면, A에 연결한 텍스쳐가 Main Preview에 나타나고 있는 것을 확인할 수 있다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/403eecf1-0d3f-4f87-b052-de5488448b59)

  Float의 수치를 1로 바꿔보면 B의 텍스쳐가 나오고, 0.5로 바꿔보면 A와 B의 텍스쳐가 절반씩 섞인 결과가 나온다.

  즉, **T 값의 0~1 비율에 따라 A나 B가 나온다**는 것이다.

  T에 연결한 Float 값을 Property로 만들어 아래처럼 Float을 Slider로 만들고 저장한 후,
  
  ![image](https://github.com/SShinMJ/TIL/assets/82142527/1f2afe2a-63ee-4cf6-a539-d69fdf5e9f94)

  메터리얼을 선택 후에 Float의 수치를 조절하면 자연스럽게 A에서 B로 전환되게끔 만들 수 있다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/09a04452-c99d-4574-be77-d7801cf72def)

<br>

- 텍스처의 '알파 채널’ 응용

  이미지의 알파 채널을 확인

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/c417fb1b-1302-42aa-8aea-34090e7442e2)

  알파 채널의 흑백 이미지는 숫자로도 볼 수 있다. (검은 부분은 0. 흰색인 부분은 1, 이미지의 중간중간에 있는 회색 이미지는 0.5)

  Lerp의 T값을 A 텍스쳐의 알파 채널로 넣어 보면, 알파 채널에 맞추어서, 알파채널의 흰 부분에 B 텍스쳐가 나온다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/f3e6dc12-687a-4896-a553-e82fcc162313)

  알파채널의 색은 숫자이고, 검은 부분은 0이니 A 텍스쳐가 나왔고, 흰 부분은 1이니 B 텍스쳐가 나온 것이다. (만약 회색의 알파 채널이 있다면 A텍스쳐와 B 텍스쳐가 반반씩 섞였을 것이다.)

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/6c42921d-576b-444c-a2ca-111237a8458a)

  위와 같이 풀 위에 글씨 무늬가 있게 하려면, A와 B를 뒤바꾸거나 알파채널의 흑백을 One Minus 노드를 통해서 바꿔주면 된다.
