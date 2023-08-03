# 쉐이더와 URP

프로그래밍적인 정의 : "3D 컴퓨터 그래픽에서 최종적으로 화면에 출력하는 픽셀의 색을 정해주는 함수"

아티스트의 관적의 정의 : "그래픽 데이터의 음영과 색상을 계산하여 다양한 재질을 표현하는 계산 방법"

<br>

유니티는 2018 버전부터 **SRP(Scriptable Render Pipeline)**이라는 **렌더링 파이프라인**을 추가하여 발표했다.

동시에 SRP안에서 구동되는 2가지의 템플릿을 공개하였는데 하나는 **하이엔드 PC, 콘솔** 등을 고려해서 고품질의 비주얼을 구현하는데 적합한 HDRP(High Definition Render Pipeline)이었고, 하나는 **모바일이나 VR과 같이 성능에 민감한 환경**에서 높은 성능을 보이는 LWRP(Lightweight Render Pipeline)이다.

![image](https://github.com/SShinMJ/TIL/assets/82142527/00536bc6-7c1c-4180-85ec-d8e52b54713c)
