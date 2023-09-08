namespace Collections
{
    // 제릭타입(T)을 받는 클래스.
    // IEnumerable<T>를 상속받는다. foreach 등에서 사용됨.
    internal class MyDynamicArray<T> : IEnumerable<T>
    {
        // T타입을 반환하는 인덱서
        public T this[int index]
        {
            get
            {
                // index가 배열의 크기를 벗어나거나 0보다 작다면 "벗어남"에러 출력
                if ( index >= _count || index < 0 )
                    throw new IndexOutOfRangeException();
                else
                    return _items[index];
            }
            set
            {
                // index가 배열의 크기를 벗어나거나 0보다 작다면 "벗어남"에러 출력
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();
                else
                    _items[index] = value;
            }
        }

        // 가장 마지막 위치(다음 배열이 들어갈 위치를 위함. pivot)
        public int Count => _count;
        // 배열의 크기
        public int Capacity => _items.Length;

        private const int DEFAULT_SIZE = 1;
        private T[] _items = new T[DEFAULT_SIZE];
        private int _count;

        // 배열에 데이터 추가. List.Add(T);
        public void Add(T item)
        {
            // 현재 배열의 공간이 꽉 찾을 경우
            if(_count >= _items.Length)
            {
                // 현재 배열의 공간의 두배를 가지는 새 배열을 만들고
                T[] tmp = new T[_count * 2];
                // 기존 배열의 데이터를 새 배열에 전체 복사.
                Array.Copy(_items, tmp, _count);
                // 기존 배열의 참조를 새 배열로 변경.
                // 참조를 잃어버린 기존 배열은 가비지컬렉터(GC)가 알아서 삭제해줌.
                _items = tmp;
            }

            _items[_count++] = item;
        }

        // 특정 아이템의 인덱스 값을 반환해주는 함수
        public int IndexOf(T item)
        {
            for(int i = 0; i < _count; i++)
            {
                // _items[i] == item (x)
                // 제네릭 타입은 == 연산자로 비교할 수 없다.(컴파일러가 못함)
                // 따라서 아래와 같이 사용. -1이면 작다. 0이면 같다. 1이면 크다.
                if (Comparer<T>.Default.Compare(_items[i], item) == 0);
                {
                    return i;
                }
            }
            return -1;
        }

        // 찾고자 하는 아이템 반환 함수
        // Predicate : 대리자. 조건 집합을 정의하고 지정된 개체가 이러한 조건을
        //              충족하는지 여부를 확인하는 메서드
        public T Find(Predicate<T> match)
        {
            for(int i = 0; i< _count; i++)
            {
                // 조건을 충족하면 해당 데이터 반환.
                if (match(_items[i]))
                    return _items[i];
            }
            // 충족하는 데이터가 없다면 default(null) 반환.
            return default;
        }

        // 찾고자 하는 아이템의 인덱스 반환 함수.
        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < _count; i++)
            {
                // 조건을 충족하면 해당 데이터 반환.
                if (match(_items[i]))
                    return i;
            }
            // 충족하는 데이터가 없다면 default(null) 반환.
            return -1;
        }

        // 배열의 데이터 삭제 함수. 특정 인덱스의 데이터를 지운다.
        public void RemoveAt(int index)
        {
            // index 위치의 값부터 그 다음 값으로 차례로 끝까지 덮어 씌운다.
            for (int i = index; i < _count-1; i++)
            {
                _items[i] = _items[i + 1];
            }

            // 전체 크기 감소
            _count--;
        }

        // 배열의 데이터 삭제 함수. 특정 아이템의 데이터를 지운다.
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if(index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        // IEnumerator<T> 반환. 대체로 이게 사용된다.
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // IEnumerator 반환. IEnumerable를 캐스팅 하면 이 함수가 사용된다.(안씀)
        // GET인데 Private이므로 안쓴단 의미. 편의를 위해서 상속받고 구현됨.
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // IEnumerator는 보통 구조체이므로 구조체로 생성.
        public struct Enumerator : IEnumerator<T>
        {
            // 제네릭 타입 GET
            public T Current => _data._items[_index];

            // object 타입 GET
            object IEnumerator.Current => _data._items[_index];

            // 재참조를 위한 변수
            private MyDynamicArray<T> _data;
            private int _index;

            // MyDynamicArray의 데이터로 인식.
            public Enumerator(MyDynamicArray<T> data)
            {
                _data = data;
                // 책 표지를 넘기며(MoveNext()) 시작하므로 -1부터 시작한다.
                _index = -1;
            }

            public void Dispose()
            {
            }

            // 다음 인덱스를 가리킨다.
            public bool MoveNext()
            {
                _index++;
                
                // 범위를 벗어나는 지 여부를 리턴.
                return _index < _data._count;
            }

            // 처음으로 초기화
            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
