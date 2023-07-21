# Terrain 에디터를 이용한 레벨 디자인

Terrain은 자연물이 가득한 넓은 평야와 같이 큰 레벨을 디자인하는 경우 사용한다.

큰 레벨의 지형을 모두 모델링하면 퍼포먼스에 문제가 생기며, 작업 효율이 떨어지기 때문이다.

따라서 일반적으로 넓은 자연 지형을 제작할 때는 이에 최적화 기능이 내장되어 있는 Terrian을 이용한다. ( 반대로 작은 지형에서 Terrain을 사용하면 효율이 떨어진다.)

![image](https://github.com/SShinMJ/TIL/assets/82142527/0caab39e-2cd7-4f96-8825-82728a6c3c82)

<br>

### 1. Terrain 생성하기
  
  GameObject > 3D Object > Terrain
  
  ![image](https://github.com/SShinMJ/TIL/assets/82142527/b39c6b02-f24d-4632-bf4a-d2a538d6f910)
   
   - 기본 지형 크기 변경 하는 법
     
     ![image](https://github.com/SShinMJ/TIL/assets/82142527/0c6a813b-fc1c-4bda-b54e-2be4ab79b948)

     ![image](https://github.com/SShinMJ/TIL/assets/82142527/a7a91f78-996a-4792-b9bb-9dbdacc5ed06)

<br>

### 2. 지형(높낮이=산) 만들기(Raise or Lower Terrain)

Paint 모드에서 Raise or Lower Terrain 체크

![image](https://github.com/SShinMJ/TIL/assets/82142527/33dd9115-d1f3-4113-8ec7-0c0bc8459f6a)

브러시 크기 선택(단축키 [ ])와 강도 조절을 할 수 있다.

![image](https://github.com/SShinMJ/TIL/assets/82142527/421acc83-ebc5-4c1f-9b76-ad85c8a1dd0e)

Shift 누른채 드래그하면 그려놓은 지형의 높이거 낮아진다.

![image](https://github.com/SShinMJ/TIL/assets/82142527/65032b06-80e8-4764-b6c1-e04336215667)

<br>

### 3. Create Neighbor 모드에서 Terrain 추가 또는 삭제 가능

![image](https://github.com/SShinMJ/TIL/assets/82142527/d4567004-1977-4592-8c08-220fb857165a)

- Fill Heightmap Using Neighbor 체크 해제 했을 때

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/3a80a190-e585-43dc-be5f-6ead09d22a0c)

  지형에 상관없이 평평한 판이 나온다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/72f42aa1-9ef2-4603-98fb-edf413aea665)

- 체크후 Clamp 옵션

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/0f504497-26a3-41b2-a6cb-7ec105042555)

  옆 지형 모양에 맞게 굴곡이 같이 생성된다.

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/4d44315f-ddba-4a93-9a59-16eacf8fc824)

- Mirror 옵션

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/ffe95fb8-4067-4414-b014-0239b7028f1f)

  지형 모양에 맞게 자동 생성하여 만들어 준다. (가장 자연스럽다!)

  ![image](https://github.com/SShinMJ/TIL/assets/82142527/9b3a7c1f-3bbe-415d-8a84-ff67b2b22181)

<br>

### 4. 지형을 부드럽게 다듬을 때(Smooth Height)

Paint 모드에서 Smooth Height 체크

![image](https://github.com/SShinMJ/TIL/assets/82142527/76630082-2764-4a3d-8843-aeb2beb5cc37)

<br>

### 5. 높낮이를 직접 설정하여 지형(산) 만들기(Stamp Terrain)

Stamp Terrain은 Raise or Lower Terrain과 마찬가지로 Terrain의 높낮이를 조절할 수 있는 기능이지만, 차이점은 브러시 모양으로 도장을 찍듯 지형을 만들 수 있다.

Ctri을 누르고 마우스 휠을 돌리면 높이를 조절할 수 있고, Subtract를 체크하면 높여 놓은 것을 뺄 수도 있다.

Max<-->Add 는 브러쉬의 높이를 유지하면서 찍을 것인지, 현재 지형에 브러시의 높이를 더할 것인지 조절하는 옵션이다.

![image](https://github.com/SShinMJ/TIL/assets/82142527/b970f043-375b-441e-b12b-d4926ddaa9c0)

<br>

### 6. 계곡/강 지형 만들기(Set Height)

Set Height는 지형을 특정 높이로 만든다.

기본 Terrain은 Heightmap 구조이기 때문에 0 미만으로 내려가지 않기 때문에, 움푹 파인 계곡이나 강을 만들기 위해선 처음부터 맵 전체 높이를 일정 높이로 올리고 지형을 제작한다.

![image](https://github.com/SShinMJ/TIL/assets/82142527/0c365cf1-db2d-49f0-a9b9-c3143b299fea)
