# UV Wrap(UV 매핑)

오브젝트는 3D, 텍스쳐 이미지는 2D이다.

따라서 2D인 텍스쳐 이미지를 3D인 오브젝트에 씌울 때 처리 과정이 필요한데, 이를 **UV 매핑**이라 한다.

(3D 오브젝트는 가로 x, 세로 y, 깊이 z라고 하지만 **pixel을 가진 2D 텍스처 이미지는 가로 U, 세로 V해서 UV좌표라고 한다.** pixel로 된 이미지를 3D mesh에 덮어 씌우는 것을 UV Wrap이라고 한다.)

간단하게 말하면 3D 모델링의 **'전개도'**를 만드는 것이다.

![image](https://github.com/SShinMJ/TIL/assets/82142527/a09347aa-9c82-4a51-9cb6-0e8bfe09cc1d)

모델링을 하고, UV를 펴고 저장을 하게되면 그 모양 그대로 보존되는 것이 아니라 각각의 버텍스에 위치, UV, Normal, Vertex Color등의 데이터가 저장되고, 엔진에 불러왔을 때 이 데이터를 바탕으로 엔진에서 '재구성'이 이루어진다.

(버텍스에 저장되어있는 데이터를 기반으로 엔진에서 다시 만들기 때문에 버텍스를 겹쳐두거나 쓰레기 버텍스가 있을 경우 엔진에 불러왔을 때 오류가 생기기도 한다.)

<br>

## Material 해상도 조절하기

![image](https://github.com/SShinMJ/TIL/assets/82142527/5b30331d-94bb-45e9-84a2-84a6b488ebe8)

- Tilling : 범위내에 표현할 머테리얼의 갯수를 설정할 수 있다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/0849da89-0b87-409c-a5a5-319f86211b81)

- Offset : 값을 더하면 UV전체에 값이 더해지면서 아래처럼 UV위치가 이동한다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/f6240883-a05c-444f-808b-deac301658d2)
