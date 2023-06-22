# 입력을 통한 오브젝트 이동 구현

## 1. TransForm 과 Vector3
[Vector3 공식문서](https://docs.unity3d.com/kr/530/ScriptReference/Vector3.html)

오브젝트의 TransForm : 오브젝트 형태에 대한 기본 컴포넌트. 반드시 존재한다.

-> 스크립트에서는 이미 TransForm 클래스가 선언되어 있으므로 따로 선언할 필요 없이 transform을 그냥 사용하면된다.

```csharp
// x, y, z 3차원 값.
Vector3 vec = new Vector3(5, 0, 0)    

// Unity에서 이미 Transform 클래스를 제공하므로
// 따로 선언할 필요 없이 transform 변수를 쓰면 된다.
// 값 변경 함수는 Translate()이며, 입력값은 3차원이므로 Vector3.
// 기존 위치 값에 vec의 입력 값이 더해진다.(상대 위치)
transform.Translate(vec);
```

<br><br>

## 2. 기본 이동(상하좌우로 이동하기)

아래 코드가 적용된 스크립트를 움직일 오브젝트와, 카메라에 넣으면 움직이는 것을 확인할 수 있다.

```csharp
private void Update()
    {
				// 키보드 상하좌우키로 이동되게 한 코드이다.
        Vector3 vec = new Vector3(
            // Time.deltaTime : 이전 프레임의 완료까지 걸린 시간.
            // deltaTime 값은 프레임이 적으면 크고, 프레임이 많으면 작다.
            // 사용자마다 다른 프레임 속도가 플레이에 영향을 끼치지 않도록 위해서 사용.
            Input.GetAxisRaw("Horizontal") * Time.deltaTime,
            Input.GetAxisRaw("Vertical") * Time.deltaTime,
            0);

        transform.Translate(vec);
    }
```

<br><br>

## 3. 목표 지점으로 이동

- [MoveTowards(현재위치, 목표위치, 속도)](https://docs.unity3d.com/kr/530/ScriptReference/Vector3.MoveTowards.html) : 등속이동.

```csharp
// target 위치를 입력한다.
Vector3 target = new Vector3(8, 1.5f, 0);

void Update()
{
    transform.Poposition =
    Vector3.MoveTowards(transform.position, target, 1f);
    // 속도를 올리려면 속도 값을 올리면 된다.
}
```

<br>

- [SmoothDamp(현재위치, 목표위치, 참조속도, 속도)](https://docs.unity3d.com/kr/530/ScriptReference/Vector3.SmoothDamp.html) : 부드러운 감속 이동. 주로 카메라 이동에 쓰인다.

```csharp
// target 위치를 입력한다.
Vector3 target = new Vector3(8, 1.5f, 0);

void Update()
{
		Vector3 velo = Vector3.zero;
    transform.Poposition =
    Vector3.MoveTowards(transform.position, target, ref velo, 1f);
    // SmoothDamp의 속도 증가는 마지막 매개변수의 반비례하여 속도가 증가하므로
    // 0.1f와 같이 낮춰야 움직이는 속도가 증가한다.

    // ref : 참조 접근 > 실시간으로 바뀌는 값 적용이 가능하다.
}
```

<br>

- [Lerp](https://docs.unity3d.com/kr/530/ScriptReference/Vector3.Lerp.html) :  선형 보간, SmoothDamp보다 감속시간이 길다. 해당 지점 사이에서 개체를 점진적으로 이동할 때 쓰인다.

```csharp
// target 위치를 입력한다.
Vector3 target = new Vector3(8, 1.5f, 0);

void Update()
{
    transform.Poposition =
    Vector3.Lerp(transform.position, target, 1f);
    // 1f가 max속도이다. 낮추려면 소수점으로 한다.(0.5f)
}
```

<br>

- [SLerp](https://docs.unity3d.com/kr/530/ScriptReference/Vector3.Slerp.html) : 구면 성형 보간, 호(포물선)를 그리며 이동한다. Lerp와는 달리 벡터가 공간의 점이 아닌 방향으로 취급한다.

```csharp
// target 위치를 입력한다.
Vector3 target = new Vector3(8, 1.5f, 0);

void Update()
{
    transform.Poposition =
    Vector3.Slerp (transform.position, target, 1f);
    // 1f가 max속도이다. 낮추려면 소수점으로 한다.(0.5f)
}
```