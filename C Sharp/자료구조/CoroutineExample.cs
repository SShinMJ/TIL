// 코루틴
// 어떤 루틴 실행 이후 다른 루틴이 실행되도록 하는 ㄴ구조

// 유니티엔진의 코루틴
// Monobegaviour의 update 이후 실행(yield)되는 구조
// (즉, Monobehaviour 비활성화 시 코루틴이 이어서 실행되지 않는다.)
// IEnumerator 로 코루틴이 구현되어있다. -> Update 이후 해당 Enumerator의 MoveNext()가 호출되는 구조.
namespace CoroutineExample
{
    bool _isCorouting;
    Coroutine _coroutine;
    IEnumerator _enumerator; // 가비지컬렉션 최소화
    WaitForSeconds _waitForSeconds;
    float _delay;
    private void Awake()
    {
        _enumerator = C_Refresh();
        _waitForSeconds = new WaitForSeconds(3.5f);
    }

    private void Update()
    {
        if (_isCorouting)
        {
            StopCoroutine(_coroutine);
        }

        // Enumerator 객체를 코루틴으로서 등록한 프레임에는 MoveNext()가 호출이 안된다.
        // -> 코루틴 시작 전 초기화할 내용이 있으면 Enumerator의 생성자에서 초기화 내용을 쓰던지,
        // IEmuerator/IEnumerable 반환 함수에서 yield로 구현했다면 StartCoroutine으로 등록하기 전에 초기화 내용을 호출해야 한다.
        // (쓸 거면 yield 밑에 쓰여야 한다.)
        _isCorouting = true;
        // C_Refresh() : yield를 통해 생성된 IEumerator 객체가 반환된다.
        _coroutine = StartCoroutine(C_Refresh());


        if (_enumerator != null)
        {
            StopCoroutine(_enumerator);
            _enumerator = null;
        }

        _enumerator = C_Refresh();
        StartCoroutine(_enumerator);
    }

    // yield를 통해 IEnumerator 객체가 생성된다.(Enumerable도 가능)
    // yield : Enumerator 객체를 간소화한 표현.
    // 컴파일 타임에 해당 Enumerator 객체를 정의한다.
    IEnumerator C_Refresh()
    {
        yield return null;
        yield return _waitForSeconds;
        yield return new WaitForSeconds(_delay);
        yield return null;
        _coroutine = null;
        _isCorouting = false;
        //return new C_RefreshEnum();
    }
    /* yield를 통해 생성된 객체가 실제로 구현되면 아래와 같다.
    struct C_RefreshEnum : IEnumerator
    {
        public object Current => throw new System.NotImplementedException();
        private int _index;
        // yield가 넘긴 객체들에 대한 참조를 리스트로 가진다.
        // 코루틴이 끝나면 필요가 없으므로 GC가 일어난다.
        // 따라서 이를 최소화하기 위해, 게임 전체해서 똑같은 로직으로 실행된다면,
        // 아래 객체를 전역 데이타로 두어 한번만 생성하고 재사용하게 할 수도 있다.
        // 그러나 객체의 내용이 바뀌어야 한다면 매번 새로 만들어줘야 한다.
        // 즉, 최소화가 안되는 상황이라면, WaitForSeconds만이라도 참조를 미리 만들어 재사용하는 방식으로
        // 최소화할 수 있다.
        // 이와같은 점 때문에 코루틴은 GC가 많이 일어난다.
        private List<object> _objects = new List<object>() { null, new WaitForSeconds(3.5f), null};
        private float _timeMark;

        public bool MoveNext()
        {
            switch (_index)
            {
                case 0:
                    {
                        _index++;
                        _timeMark = Time.time;
                    }
                    break;
                case 1:
                    {
                        if (Time.time - _timeMark >= 3.5f)
                        {
                            _index++;
                        }
                    }
                    break;
                case 2:
                    {
                        _index++;
                    }
                    break;
            }
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }

    */
}
