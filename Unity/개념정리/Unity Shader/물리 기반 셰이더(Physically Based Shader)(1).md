## **Lit Shader Graph**

- **물리 기반 셰이더(Physically Based Shader)**
    
    유니티 5.0 때부터 적용된 라이팅 계 산 방식인 '물리 기반 셰이더'를 사용 할 수 있게 해 주는 셰이더가 유니티 URP에서는 **Lit 셰이더**라 부른다. 메터리얼을 만들 때 가장 기본적으로 사용하는 셰이더이기도 하다.
    
    **물리 기반 셰이더**란 기존의 구형 라이팅 시스템과 달리 **주변 환경에 따른 재질의 변화를 물리 법칙에 입각하여 실시간으로 계산해서 표현**해 줄 수 있는 **재질의 표현 방식이**다.
    
    *(SRP 이전 레거시 렌더러에서는 Standard 라고 불렸던 셰이더입니다. 지금은 Universal Render Pipeline - Lit이라는 이름으로 되어 있다. 구형이라고 하지만 보다 단순하고 직관적이어서 지금도 많이 쓰인다. URP에서는 simpleLit이라는 이름으로 여전히 존재)*

    ![image](https://github.com/SShinMJ/TIL/assets/82142527/96322f80-fc8a-4e80-8947-426415de2520)

    Shader Graph에서도 이와 동일한 구조의 라이팅 시스템을 갖추고 있고, Shader Graph인 만큼 다양하게 커스텀이 가능해서 내장되어 있는 Lit 셰이더에서 필요 없는 기능을 제거하거나 없는 기능을 추가할 수도 있다.

    아래에 ShaderGraph의 Lit 그래프를 이용해서 내장 Lit 셰이더와 동일한 기능을 가진 셰이더를 만들어 보고, 물리 기반 셰이더에서 사용하는 텍스쳐들의 사용법과 그 텍스쳐들을 셰이더에서 설정하는 방법에 대해서도 정리한다.

<br><br><br>

- **Lit Shader Graph 만들기**
    
    - Lit Shader Graph 만드는 두 가지 방법
      
      1. URP의 Lit Shader Graph를 바로 만들어 쓰기
  
         ![image](https://github.com/SShinMJ/TIL/assets/82142527/b6785670-ee13-40ba-aabd-da39a74e73f9)
  
      <br><br>
  
      2. Unlit shader Graph를 만들고, Graph Settings의 Material을 Unlit에서 Lit으로 바꾸어 주기
  
         이렇게 하면 Fragment에 Base Color만 있던 Unlit과는 달리 Smoothness, Normal, Metallic, Emission, Ambient Occlusion이 생긴다. 이 셰이더를 적용하면 드디어 이전에 사용하던 Unlit 셰이더와는 다르게 빛에 반응하고, 그림자가 지는 것을 확인해 볼 수 있다.
  
         하지만, 내장되어 있는 기본 셰이더인 Lit 셰이더에 있는 기능들은 하나도 없다. 
        
         따라서 하나씩 만들어야 하므로 하나씩 정리해 본다.
  
         ![image](https://github.com/SShinMJ/TIL/assets/82142527/b418f9cc-7411-4ffb-8bda-cb6fde145049)
  
         Fragment에 있는 각 요소들은 드래그 앤 드롭으로 서로 순서를 바꿀 수 있습니다.
         
    <br><br>

    - Lit Shader Graph 사용하기

      Lit Shader Graph가 만들어졌으면, 이제 PBR(물리 기반 렌더링)에 맞춰진 텍스쳐를 가진 모델링을 이용해서 작업을 할 준비가 되었다는 것이다.
      
      <br>
      
      - **Asset 준비하기**
      
        Asset Store를 열고, 무료 Asset인 Sci-it Pistol을 다운 받는다.
  
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/2c5079fa-695b-4aaf-ac1a-cbce19c82a28)
  
        *('Sci-if Pistol을 구할 수 없다면, PBR을 지원하도록 텍스쳐가 만들어진 다른 모델링을 이용해도 된다.)*
  
        다운 받은 Asset의 Prefabs를 확인해 보면, 모두가 마젠타 색이 된 것을 볼 수 있다.
        
        이것은 사용된 셰이더가 URP 이전의 레거시 (빌트인) 파이프라인의 Standard Shader였음을 알 수 있다.
        
        *(실제로 Asset을 받아보면 이런 경우가 꽤 있어서 곤란할 수 있는데, 이것이 그런 경우를 해결하는 매우 좋은 예시이다.)*
  
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/8bff9aa8-4499-432c-a88f-efd8b93f6c45)
  
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/4589dac6-455e-476e-9c16-e2c2f11c7ff8)
  
        <br>
  
        이 총기 Asset의 텍스쳐 구성을 보면 Bullet, Magazine. Pistol 3개로 이루어진 구조를 짐작할 수 있다. (탄창(Magazine)과 총알(Bullet)은 다른 재질 사용)
  
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/b81292a4-896a-40e8-bc33-1fa0216d7d33)
  
        실제로 Asset Store의 데이터를 받아 확인해 보면, 파이프라인이 맞지 않아서 이렇게 마젠타로 나오는 경우가 많이 있다. 셰이더만 해당 파이프라인에 맞춰 바꾸어 주기만 해도 어느 정도 해결되는 경우가 있지만, 많은 경우 약간씩 설정을 바꿔주거나 할 필요가 있다. 이럴 때 어떤 데이터가 어떤 설정으로 어디에 들어가야 하는지 알고 있다면, 당황하지 않고 해당 파이프라인에 맞추어 수동으로 쉽게 변환이 가능할 것이다.
  
        <br>
        
        우선, 총기(Pistol)부터 메터리얼을 적용해본다.
        
        Lit Shader Graph를 만들고 메터리얼을 만들어 적용한 후, 탄창(Magazine)과 총알(Bullet)을 제외한 총기 오브젝트 모두에 같은 메터리얼을 적용해준다.
  
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/800e5526-d054-4ef7-aec5-f77a96578231)
  
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/693e7c24-f7b5-41d5-9c06-347d958752d3)
  
        탄창(Magazine)과 총알은 지금 당장 작업할 생각이 없으므로, 비활성화 시켜 놓는다.
  
        <br><br>
  
      - **Base Color 적용하기**
  
        Base Color는 '물체가 가진 순수한 색' 이다.
  
        우선, PistolDiffuse 텍스쳐를 드래그해서 Shader Graph에 넣고, 이를 Base Color에 연결한다.\
  
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/ec31ae60-d016-47a5-aa5c-c106e9aaa893)
  
        최종으로 이렇게 완성하면 안 되겠지만, 빠르게 결과를 볼 수 있기 때문에 임시로 작업물을 테스트하면서 결과물까지 동시에 확인하는 방법으로 사용하기는 나쁘지 않다.
        
        <br>
  
        *여기서 텍스쳐 이름은 Diffuse이지만, 사실 물리 기반 셰이더에서 는 Diffuse라는 이름은 잘 쓰지 않는 것이 일반적이다.*
        
        *(Diffuse는 물리 기반 셰이더가 나오기 이전 셰이더에서 물체의 컬러를 나타내는 용어로 많이 사용하던 용어)*
        
        Diffuse는 확산 즉, 빛에 의해 난반사된 결과물이라는 의미가 있어서 빛에 의한 결과물이라는 의미가 아닌, 순수하게 물체가 가지고 있는 색상이라는 의미의 텍스쳐를 넣기 원하는 물리 기반 셰이더에서는 일반적으로 '**Albedo**'라고 부르는 것이 좀 더 자연스러우며,
        
        이것을 **유니티에서는 Base Map**이라고 부르기도 한다.
        
        <br>
        
        이 총기의 Diffuse Texture를 보면 빛의 영향은 전혀 그려져 있지 많고
        
        순수하게 물체의 색상이 그려진 전형적인 PBR 구조의 Albedo인 것을 볼 수 있다.
        
        <br>
        
        또한 Base Map은 유니티 Lit 셰이더에서 컬러를 곱해서 색상을 조절할 수 있는 기능이 있다.
        
        지금은 Lit 셰이더와 동일한 동작을 하는 셰이더를 만들 것이기 때문에 여기에도 색을 곱해준다.
        
        기본은 아무 변화가 없기를 기대하므로 흰색(1)을 초기값으로 둔다.
  
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/c152bf74-94d6-4c8e-a92f-50031b7f28d0)
  
        Color도 일단 만들어 놓고 나중에 Property로 올리도록 한다.
        
        <br><br>

      - **메탈릭(Metallic)과 스무스니스(Smoothness)**
     
        - Metallic

          Metallic은 이 재질이 금속이냐 아니냐를 결정하는 부분(0 이면 비금속, 1 이면 금속 재질)
  
          즉, 수치로도 넣을 수 있고, 흑백의 텍스쳐로도 넣을 수 있다.
          
          (물리기반 셰이더에서 메탈릭이 0 이면 스페큘러 컬러가 흑백(흰 빛을 비추었을 때)이 되며, 메탈릭이 1이면 스페큘러 컬러가 Albedo에 넣은 색이 된다. 금속은 고유의 스페큘러 컬러를 가지고 있기 때문)
          
          금속과 비금속의 차이는 굉장히 이질적이며, 그 차이는 크게 둘로 설명할 수 있다.
          
          - 비금속의 스페큘러(정반사 : 하이라이트) 컬러는 조명의 색이다. 하얀 빛이라면 흰색의 스페큘러가 반사된다.
              
              하지만 금속은 하얀 빛을 비춰도 자신의 고유 스페큘러 색이 반사되어 나온다.
              
          
          - 비금속은 기울어질수록 반사가 강해집니다. 비금속 공을 보면 공을 바라보는 정면보다 기울어진 옆면이 될수록 반사가 심해진다는 것을 알 수 있다.
              
              하지만 금속은 금속마다 어느 정도 차이가 있지만, 일반적으로 정면과 기울어진 면의 반사차는 크지 않다.
              
              (거울을 생각해 보면 좀 더 이해가 빠를 것 같습니다. 거울은 유리 뒤에 금속(은색 금속)이 발라져 있어서 정면에서 바라보아도 반사가 잘 된다)
  
          ![image](https://github.com/SShinMJ/TIL/assets/82142527/4f2e7b43-5a36-442e-9c06-d8f86b5017a5)
  
          (메탈과 비메탈의 반사 방식과 반사 색상의 차이)

          <br>
     
        - Smoothness

          **Smoothness**는 **재질의 매끄러움/ 거침 여부**를 결정하는 부분이다.
  
          *0*이면 완벽히 **거칠어서 난반사**만 일어나고, **1**이면 완벽히 **매끄러워서 정반사**만 일어나게 되며, 텍스쳐로 넣을 수도 있고 수치로도 넣을 수 있다.
          
          실제 주변 사물은 전부 약간이라도 정반사를 가지고 있고, 거의 모두는 이 둘을 적절하게 섞어서 가지고 있기 때문에, 0이나 1로 만들지 않는 것이 좋다.(세상의 물건 중 완벽히 0이나 완벽히 1인 물체는 없다)
          
          난반사가 일어나는 이유는 '거친 표면'이며, 특히 겉으로는 부드러워 보이더라도 미세 표면 단계에서의 거칠기 때문에 (거의 분자 단위로 일어납니다) 피부나 천의 경우에는 스페큘러가 적어 보이는 것이다.
          
          정리하면, **재질이 매끈하면 난반사(Diffuse) 연산보다 정반사(Specular) 연산이 늘어나며, 이것을 조절할 수 있는 것이 Smoothness 인자**이다.
  
          <br>
  
          유니티에서 Lia Shader라고 부르는 '물리 기반 렌더링의 기본 원리는 '에너지 보존 법칙'이다. 즉, **"나가는 빛의 양은 들어온 빛의 양을 넘을 수 없다**"
  
          아래 그림처럼 재질의 거칠기에 따라 난반사와 정반사의 비율이 결정되므로 정반사가 높아지면 그만큼 난반사는 줄어들게 된다.
          
          이런 재질의 올바른 사용법을 위해서 유니티에서는 아래와 같이 Metallic Value Chart를 제공한다.
  
          ![image](https://github.com/SShinMJ/TIL/assets/82142527/aaed7430-c6b0-4701-87fd-82609e6cb813)
  
          이 차트를 찾다 보면, Unity Specular Chart 라는 또 하나의 차트를 찾으실 수 있다. 이 차트는 Metallic이 아닌 Specular Setup 을 위한 차트로, 물리 기반 셰이더를 이용해서 스페큘러 컬러가 자동적으로 결정되는 Metallic Setup과는 다르게 물리 기반 셰이더 이면서도 스페큘러 컬러를 자유롭게 사용할 수 있도록 만든 셰이더를 위한 차트이다.
  
          ![image](https://github.com/SShinMJ/TIL/assets/82142527/3c330e60-c2a2-4bd1-a489-ed99bb9cdd37)
     
        <br><br>

        그럼 지금까지의 내용을 이해했으면, 이제 주어진 텍스쳐를 분석해본다. Pistol Metallic 텍스처는 다음과 같다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/7ef06e45-ee07-406c-bce4-177c6f7d7c3c)

        흰색 부분은 Metal 부분을 의미하며, 검은 부분은 Metal이 아닌 부분을 의미한다.

        이론적으로 Metallic Texture는 중간색이 없는 흰색 혹은 검은색만 사용하는 것이 옳다. '금속과 비금속의 중간적인 물체'는 존재하지 않기 때문이다.
        
        *(그럼에도 불구하고 Metallic에서 0이나 1이 아닌 중간색을 쓰는 경우는, 미세하게 기름이나 비금속의 투명한 무엇이 묻어서 애매한 결과가 나오는 케이스를 표현하거나, 텍스쳐의 사이즈 문제로 금속과 비금속의 경계면의 안티알리아싱을 표현하기 위해 쓰일 때이다.)*
     
        <br>
        
        그리고 임시로 이 Metallic 맵의 R 채널을 Base Color에 넣어 본다.(어차피 흑백이라 RGB 어느 것 하나만 넣어도 똑같기 때문)
        
        총의 어느 부분이 금속이고 어느 부분이 비금속(페인트가 칠해졌거나 플라스틱일 것 경우)인지 확인할 수 있다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/d97e1ce8-2eba-42cb-b540-46d47a90bb53)

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/a102dadf-7a5f-46ab-a3e0-99228f9c2f95)
     
        흰색으로 나오는 총의 슬라이드와 트리거 부분이 금속이고, 검은색으로 나오는 하단 부분이 비금속임을 알 수 있다.(아마도 페인트가 칠해져 있을 것이다)
        
        <br>

        이제 어느 부분이 금속인지 알게 되었으니 제대로 작업해본다.
        
        역시 Metallic 텍스처의 R 채널을 Metallic에 연결시켜 주면 금속과 비금속이 구분된다. 그런데 아무래도 색이 검은색인 부분은 차이가 확 나진 않는다. (은색은 이제 곧 차이가 날 것)

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/5a00666e-2a3a-4cd4-a542-1899fd4a7d8a)

        <br>

        이어서 Smoothness 작업을 한다. Smoothness 맵은 Metallic 맵의 A 채널에 있. 즉, Metallic 맵의 A 채널을 Smoothness에 연결해 주기만 하면 된다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/96e42cc7-446e-45e7-9428-d91f5d8b1747)

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/b6b237e7-57ad-466f-8016-8066f970a55c)

        <br>

        희미하게 구분되던 Smoothness가 좀 더 명확하게 나뉘면서, 반짝이는 부분과 반짝이지 않는 부분이 좀 더디테 일 하게 나뉘었다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/b2568473-6f59-435b-9a55-68d324b3a168)

        <br>

        이것은 유니티 기본의 Lit 셰이더에서도 동일하게 되어 있다.

        Smoothness의 Source를 보시면. Metallic Alpha를 사용하겠다고 되어 있는 것을 볼 수 있ek.
        
        즉, Metallic 맵에 텍스쳐를 넣으면 그 알파채널이 Smoothness로 사용되도록 되어 있다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/140bb709-5059-403c-b883-5d65fae3499c)]
     
        <br>

        예를 들어 붉은 페인트칠이 되어 있는 소화기는 금속일까요 비금속일까? 이 경우 소화기는 분명 금속으로 되어있지만 비금속의 페인트가 칠해져 있으므로 그 겉 재질은 결국 비금속인 것이다.
        
        **Metallic map은 컬러 텍스쳐가 아닌 데이터 텍스쳐**다.
        
        그렇다면 감마 코렉션의 원리에 따르면 sRGB를 체크 해제해서 Linear 텍스쳐로 만들어 주어야 할 텐데, 위에서는 하지 않았어도 별 차이가 없다.(이유 생각해보기)
        
