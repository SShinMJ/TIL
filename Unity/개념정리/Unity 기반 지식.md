# 1. 게임 엔진이란

<br>

![image](https://github.com/SShinMJ/TIL/assets/82142527/831af558-5a95-444f-8070-a430572e9b97)

<br>

**게임 엔진**에는 게임 제작을 위한 모든 요소가 모여 있다. 게임은 3D 모델, 스크립트, 오디오 파일 등 여러 요소를 결합하여 만들 수 있습니다. 3D 모델이나 스크립트, 오디오 파일을 음식 재료에 비유하자면, Unity를 비롯한 여러 게임 엔진은 재료를 넣는 냄비와 같다.

게임 엔진은 게임이 화면에 표시되고, 오브젝트가 다른 오브젝트와 상호 작용하고, 사운드가 들리고, 애플리케이션을 기기에서 실행할 수 있는 형식으로 퍼블리시할 수 있게 한다. 콘텐츠를 만들면 게임 엔진은 원활하게 작동하는 환경에서 콘텐츠를 구현할 수 있는 툴을 제공한다.

### Unity 기반 프로젝트 수행 흐름
[Unity 기반 제작 사이클](https://learn.unity.com/tutorial/silsigan-jejag-saikeul?uv=2019.4&pathwayId=62c27b36edbc2a1cd6fae3aa&missionId=62d8af8aedbc2a352ecbdeb7&projectId=62d8abaaedbc2a352ecbde20#)


<br><br>

# 2. Unity 에셋 스토어

### 개념

인터랙티브 경험의 기본 구성 요소인 오브젝트와 사운드 등의 에셋은 게임 엔진 내에서 제작하지 않는다. 대신 에셋은 DCC(디지털 콘텐츠 제작) 툴이라는 전문 외부 프로그램에서 제작된다. 에셋 임포트 과정을 용이하게 하기 위해 많은 DCC가 Unity와 통합되어 있다.

<br>

![image](https://github.com/SShinMJ/TIL/assets/82142527/8c036bd4-5808-4e3b-8bd9-6c148eca2aa7)

- **3D DCC:** 3D 모델, 애니메이션 캐릭터, 환경을 제작하는 프로그램. <br>
예: [Maya](https://www.autodesk.com/products/maya/overview), [ZBrush](https://pixologic.com/), [Blender](https://www.blender.org/)
- **2D DCC:** 2D 이미지, 일러스트레이션, 텍스처, 인터페이스를 제작하는 프로그램. <br>
예: [Photoshop](https://www.adobe.com/products/photoshop.html), [Illustrator](https://www.adobe.com/products/illustrator.html), [Substance Painter](https://www.substance3d.com/products/substance-painter/), [Gimp](https://www.gimp.org/)
- **오디오 DCC:** 음향 효과와 음악을 녹음, 편집, 믹싱하는 프로그램. <br>
예: [Audition](https://www.adobe.com/products/audition.html), [Logic Pro](https://www.apple.com/logic-pro/), [Reaper](https://www.reaper.fm/), [Audacity](https://www.audacityteam.org/)
- **IDE(통합 개발 환경):** 다양한 언어로 코드를 작성하는 프로그램. <br>
예: [Visual Studio](https://visualstudio.microsoft.com/), [Rider](https://www.jetbrains.com/rider/)
- **실시간 엔진:** 3D 콘텐츠나 애플리케이션을 실시간 개발, 렌더링, 퍼블리시하는 프로그램. <br>
예: [Unity](https://unity.com/), [Unreal](https://www.unrealengine.com/)

  <details>
    <summary>3D DCC란?</summary>
      <div>

        Maya, ZBrush, Blender와 같은 3D DCC(디지털 콘텐츠 제작) 툴을 사용하면 아티스트가 환경, 모델, 캐릭터를 3D로 구현할 수 있다.

        ![image](https://github.com/SShinMJ/TIL/assets/82142527/12eb85f7-6b2c-4c90-83b2-2206557e247f)
        이러한 프로그램에서 아티스트는 3D 오브젝트의 셰이프를 **모델링**하고, 이를 애니메이션화할 수 있도록 **리깅**하고, 특정한 방식으로 움직이도록 **애니메이션화**하고, **텍스처**를 적용해 모델에 컬러와 셰이딩을 설정힌다.
        
        DCC에서 제작된 3D 에셋은 Unity와 같은 실시간 엔진으로 가져와 게임, 시뮬레이션 또는 애니메이션 영화와 같은 더 큰 프로젝트에 통합된다.
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/72ac3a7e-90d6-420d-ab6c-a02873a28c54)
      
      </div>
  </details>

**Unity 에셋 스토어**

DCC 활용법을 배워서 Unity 에셋을 처음부터 새로 만들 필요는 없다. DCC로 제작되어 바로 사용할 수 있는 수많은 에셋을 Unity 에셋 스토어에서 다운로드할 수 있다. Unity ID가 있으면 에셋 스토어 웹사이트와 Unity 에디터의 패키지 관리자를 연결하는 링크를 통해 에셋을 바로 다운로드하고 프로젝트로 임포트할 수 있다.

<br><hr>

### 에셋 스토어에서 에셋 받는 법

에셋 스토어는 전문 에셋 크리에이터가 작품을 공유하거나 판매할 수 있는 편리한 플랫폼으로, 여기에서 실시간 크리에이터는 이미 디자인과 제작이 완료된 에셋을 찾아 바로 사용할 수 있다. 

이러한 에셋에는 3D 모델, 머티리얼, 애니메이션, 로딩 화면, 스크립트 및 프로젝트에 필요한 기타 모든 항목이 포함된다.

**! Unity 계정이 있어야 에셋을 받을 수 있다.**

[Unity 에셋 스토어](https://assetstore.unity.com/?category=3d&version=2022&free=true&orderBy=1) (3D, 무료, Unity 2022 버전)

1. 머티리얼이 포함된 무료 에셋 패키지를 선택합니다. 사용 중인 Unity 버전과 호환되는 에셋을 구해야 한다.
2. 에셋을 다운로드하여 프로젝트로 임포트하는 방법을 전체적으로 소개하는 최신 지침은 [에셋 스토어에서 에셋 임포트](https://learn.unity.com/tutorial/project-setup-processes#60ed7a86edbc2a002520b6f4)를 참조한다.
3. 머티리얼 중 하나를 선택하여 지면의 단상으로 드래그하여 오브젝트에 적용한다.