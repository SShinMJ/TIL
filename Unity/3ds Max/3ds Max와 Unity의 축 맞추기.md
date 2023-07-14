## 3ds Max와 Unity의 축이 다를 때 맞춰서 unity로 보내는 법

3ds Max에서 Unity로 fbs 파일을 보낼 때, x, y, z 축을 Unity에 맞추는 과정이 필요하다!

![image](https://github.com/SShinMJ/TIL/assets/82142527/6b14850e-6789-40a5-ae0f-ba8c06a6c7ce)

위 리스트에서 local이 주전자의 축, world가 기존 세계의 축이다.

![image](https://github.com/SShinMJ/TIL/assets/82142527/86d15bb7-5547-4f6f-ad33-2f2b13442ecc)

1. 오른쪽의 세번째 탭을 클릭하기 > Adjuct Pivot의 파란버튼을 클릭 > 왼쪽의 주전자와 같이 X,Y,Z 축이 생긴다.
2. 이 축을 ‘E’키를 눌러 회전하여 **Unity 축(z가 정면, x가 오른쪽, y가 위)**로 맞추면 된다.<br>(이 때, ‘A’키(Angle Snap Toggle)을 클릭하여 각을 맞춰 회전하면 좋다)