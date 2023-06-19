1. 캔버스 : UI가 그려지는 도화지 역할인 컴포넌트. (2d화면에 하얀 실선이 표시된다.)
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/30bf9e0f-060c-4a44-98b1-1c3ac2328227)
    
<br>

2. 스크린 : 게임이 표시되는 화면, 해상도로 크기가 결정된다.
    
    씬(Scene)화면의 상단 카테고리에서 ‘2D’버튼을 눌러 확인할 수 있다.
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/9df331a2-07c6-434f-9b2f-5347d8b401a2)

    게임에는 World 좌표계(카메라o)와 Screen 좌표계(카메라x)가 존재한다.
    
    (마우스 클릭도 스크린 좌표계에 포함된다.)
  
<br>
    
3. 텍스트(Text) : 무자열을 표시하는 UI
    
    스크린 좌표계에서 표시된다.(UI이기 때문!)
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/936420a3-b83e-4854-84db-b2270575a6f0)    
  
<br>

4. 이미지 UI
    
    이미지 UI에 커스텀 이미지 파일을 적용시키고 싶은 경우, 아래와 같이 커스텀 이미지 파일의 텍스쳐 타입은 스프라이트(2D 및 UI)로 바꾼 후 적용(저장)해야 쓸 수 있다.
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/88ab519e-dd17-4e9b-8126-72b81346bf8a)
    
    <br>

    이후 이미지 UI의 소스 이미지에 커스텀 이미지를 드래그 엔 드롭하면 적용된다!
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/7b5b2b90-d8f5-4dc0-bb21-873671519e10)
  
    <br>

    이 이미지 UI를 이용하여 스킬 재사용 대기시간 UI를 구현할 수 있다. > [링크](https://www.youtube.com/watch?v=k4YUJy-otDs&list=TLPQMTkwNjIwMjNZRbJy5n1PRw&index=4) 11분 25초부터
      
<br>

5. 버튼 UI
    
    Image 컴포넌트의 이미지 타입이 분할(Sliced)로 한다.
    
    Button 컴포넌트
    
    - Interactable : 마우스 클릭 이벤트 등에 반응을 할 지의 여부
    - 전환(Tranration) : 반응을 한다면 어떻게 반응할 지 결정한다.
        - 컬러 틴트 : 색상을 바꾼다.
            - 노말컬러 : 이벤트가 없을 때 색상
            - 하이라이트 컬러 : 마우스가 올려졌을 때 색상
            - 눌려진 컬러 : 클릭했을 때 색상
            - 비활성화된 컬러 : Interactable이 꺼져있을 때 색상
            - 컬러 멀티플라이어 : 색상 변환 강도
    - OnClick 이벤트
        
        해당 부분에서 클릭 이벤트를 처리할 수 있다.
        
        오른쪽 하단의 + 를 눌러 특정 오브젝트에 포함된 스크립트의 특정 함수를 실행하게 할 수 있다.
        
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/c909371d-03e1-4c32-926c-be7166d20671)
        
        드래그앤드롭으로 특정 오브젝트를 파란 박스안에 넣고, 
        
        ![image](https://github.com/SShinMJ/TIL/assets/82142527/639eae54-bf65-4bae-916e-42f0adbba16c)
        
        특정 스크립트에 있는 특정 함수를 지정할 수 있다. (이 때 함수는 public이어야 한다.)
  
<br>
    
6. 앵커
  
    사용자의 화면 해상도(크기)에 따라 UI 위치가 변하면 안되므로, UI가 위치할 기준점을 맞춰야한다. 이를 앵커로 맞출 수 있다.
        
    <br>

    UI는 오브젝트와 다르게 Transform이 아닌 Rect Transform을 가진다.
    
    이 Rect Tranform의 왼쪽 상단의 앵커 프리셋를 클릭한다.
    
    ![image](https://github.com/SShinMJ/TIL/assets/82142527/a6b28a91-41bf-4ec5-9776-d473bcfb26ee)
        
    shift를 누를 경우 파란점으로 컴포넌트에서의 기준점을 변경할 수 있다.
    
    alt를 누르면 중앙네모 컴포넌트 위치가 알아서 맞춰진다.
