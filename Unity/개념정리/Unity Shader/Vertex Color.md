## **Vertex Color**

버텍스 컬러는 아무것도 작업하지 않으면 무조건 흰색이다.(Vector4(1, 1, 1, 1))

- 폴리브러쉬 (Polybrush) 준비
    
    버텍스 컬러를 적용하는 법은 크게 두 가지가 있을 수 있는데, 하나는 3ds Max와 같은 3D DCC(Digital Contents Creation) 툴에서 그려오는 것이고, 또 하나는 엔진의 자체 기능을 이용해서 그리는 것이다.
    
    유니티는 기본적으로 Package Manager를 이용하여 폴리브러쉬 (Polybrush)라고 하는 Asset을 다운받을 수 있다.
    
    Window > Package Manager를 열고 Unity Registry Package에서 Polybrush를 선택하여 인스톨한다.
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/a5a9edd9-5902-4c1e-8f48-3ed73fb8dd19)
    
    다운이 완료되면 폴리브러쉬를 실행한다. Tool> Polybrush> Polybrush Window를 열면된다.
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/f6021c5e-4324-4494-9fd5-46bf405f0ab8)

  <br><br>
    
- 폴리브러쉬 (Polybrush) 적용해보기
    
    빈 Scene에 Plane을 만든 다음 폴리브러쉬를 이용하여 버텍스 컬러를 칠해본다.
    
    아래는 붉은 색을 선택하여 칠하려 했으나, 아무것도 보이지 않는다.
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/8b84b0b8-c823-48c4-82ff-a08e72339f54)

    아무것도 보이지 않는 이유는, **버텍스 컬러는 기본적으로 출력되지 않기** 때문이다. 그래서 **셰이더를 만들어서 버텍스 컬러를 보이도록 만들어 주어야 한다**.
    
    Plane에 새 Unlit Shader Graph와 메터리얼을 만들어 적용해 준다.
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/45393404-9dff-42ab-bbf5-d1345d107952)

    Vertex Color 노드를 꺼내서, Base Color에 연결해 주면, 앞에서 그렸던 버텍스 컬러가 출력되는 것을 볼 수 있다.
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/6e1bd2b7-1201-4831-a56c-8fd156f5b331)

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/08588d50-194d-4c12-b05f-515bf92c0240)

    이제 본격적으로 버텍스 컬러를 그릴 준비가 된 것이다.
  
    <br>

    이번에는 버텍스 컬러를 아래 규칙으로 그려본다.
    
    - **검은색이 남아 있어야 합니다.**
    - **붉은색과 녹색, 파란색으로 그리세요. 조금 진하게 그려 두는 것이 나중을 위해서 좋을 것입니다.**

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/abf4877f-bc99-437f-93d1-532a64a136a4)

    *(Polybrush의 브러쉬 동작이 뜻대로 움직이진 않는다. 따라서 실제 사용하려면 외부 3D 룰에서 버텍스 컬러를 그려 오시는 쪽을 추천)*

    '버텍스'가 컬러를 가지고 있기 때문에, 각 컬러를 가진 버텍스들의 사이에 있는 픽셀들은
    
    버텍스 거리에 비례해서 Lerp 로 컬러가 결정된다.

  <br>
    
    - **버텍스 컬러를 이용한 작업을 해보기**
        
        버텍스 컬러를 사용할 수 있게 되었으니, 이 버텍스 컬러를 응용할 수 있다.
        
        간단하게 생각해 보면 텍스쳐와 더하거나 곱해서 색의 변화를 줄 수 있을 것이다.
        
        버텍스 컬러는 버텍스가 기본으로 가지고 있는 녀석이므로 저렴한 비용으로 피부색이나 옷 색을 바꾸어 줄 때에도 사용할 수 있다. 특히, 파티클이나 이펙트에서는 이미 흔하게 사용하고 있으며, 그외에도 다양한 사용 방법이 있다.
        
    <br>
    
    - **버텍스 컬러를 마스킹 기능으로 사용해보기**
        
        버텍스 컬러는 일반적인 컬러와 동일하게 **RGBA로 구성**되어 있다.
        
        그렇지만 버텍스 컬러는 일반적인 텍스쳐가 가지고 있어야 하는 UV와 아무 상관이 없기 때문에, 응용해서 사용할 곳이 아주 많이 있다.(UV가 바퀴어도 버텍스 컬러는 바뀌지 않는다)
        
        여기서는 버텍스 컬러를 마스킹으로 이용해서, 지형 시스템 등에서 자주 사용하는 멀티 텍스쳐링 기능을 만들어 보도록 해보자.
        
        일단, 이전 시간에 만든 버텍스 컬러가 적용되어 있는 Plane에서부터 시작한다.
        
        멀티 텍스쳐 기능을 사용하기 위해서는 여러 장의 텍스쳐를 받아야 한다. 이번에는 텍스쳐를 총 4장을 받을 수 있는 기능을 만들어 본다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/a020d3a0-477a-4f02-bafe-e967af69433b)

        *(사실 Property로 만들어서 Material에서 텍스쳐를 넣게 만들 것이기 때문에 Shader Graph에서 텍스쳐가 보이게 할 필요는 없지만, 알아보기 쉽게 하기 위해 Shader Graph의 Texture Property에 프리뷰용 텍스쳐를 넣어서 하고 있는 것이라 꼭 이렇게 할 필요는 없다.)*

        <br>
        
        첫 번째 텍스처를 출력에 연결하고,
        
        메터리얼에서도 Shader Graph의 프리뷰와 동일하게 텍스쳐를 지정해 주면, 첫 번째 텍스쳐가 출력되게 한다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/aed56e47-b0c6-4fce-9852-b2a19c29dbaa)

        이제 4장의 텍스쳐를 모두 나올 수 있게 해야한다.

        우선, Vertex Color의 R 채널만 출력해서 어떻게 보이는지 확인해 본다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/598d9773-a818-4c04-876e-3de30bf7b14c)

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/ed0d8ad0-248b-4da9-8f0a-e71867be5797)

        RGB로 볼 때는 몰랐지만 R 채널만 보면 흑백으로 보인다.(컬러의 각 채널 하나하나는 0~1의 강도)

        그럼 이젠 이걸 이용해서 멀티 텍스쳐링 작업을 할 수 있다.
      
        <br>
        
        1. Lerp 노드를 사용
            
            첫 번째 텍스쳐와 두 번째 텍스쳐를 Lerp로 섞는데 버텍스 컬러의 R 채널을 이용하였다. Lerp 함수의 특성상 검은색 즉, 0인 부분은 A가 나오고, 흰색 1인 부분은 B가 출력이 되니 버텍스 컬러의 R 채널에 따라 첫 번째 텍스쳐와 두 번째 텍스쳐가 섞여서 출력된다.
            
            그렇다면, 이 방식을 이용해서 나머지 G, B 채널도 이용해 4장의 텍스쳐가 동시에 나오게 할 수도 있다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/63af279e-caa1-4332-8627-b3b301a01712)

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/06f4ad25-90e7-4e52-9c02-7da7bd48cc8b)

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/74b537e5-b934-421b-acad-ba7ddba2ac83)

            이 방식으로 셰이더를 구현해 놓고 나면, 이후에 버텍스 컬러를 다르게 칠해 주는 것만으로 실시간으로 텍스쳐의 블렌딩이 바뀌는 기능을 만들 수 있게 된다.

            *(실제로 Polybrush를 이용하여 Red, Green, Blue, Black 컬러를 이 상태에서 칠해보면서 어떻게 변화가 일어나는지 확인해 보자)*
           
            <br>
            
            이것은 **지형 뿐만 아니라 먼지가 묻거나 파손된 벽 재질을 한 오브젝트를 여러 개를 복사해서 다양하게 표현하는 등 여러 가지 경우에서 응용**할 수 있는 기능이다.

            ![image](https://github.com/SShinMJ/TIL/assets/82142527/015bb34b-43e3-4900-99c8-29f432dc81be)

            <br>

        2. Weight  노드를 사용
        
           위와 동일한 결과물을 내는 또 다른 방식도 있다.
          
           이 방식은 Lerp를 이용한 방식이 아니라 **RGB 각 채널의 강도를 곱해서 더해주는 Weight 방식**이다.

           ![image](https://github.com/SShinMJ/TIL/assets/82142527/7dbcaeff-b753-4a2e-9689-5ead738b38b2)
