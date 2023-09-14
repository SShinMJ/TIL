using System.Collections;

namespace Collections
{

    // 버켓을 사용할 타입 생성
    public struct KeyValuePair<T, K>
        where T : IComparable<T>
        where K : IComparable<K>
    {
        // 변수선언 시 '타입?' : NULLABLE 표시로, 해당 변수에 NULL을 대입할 수 있다는 명시.
        public T? key;
        public K? value;

        public KeyValuePair(T key, K value)
        {
            this.key = key;
            this.value = value;
        }
    }

    // where : 제한자. 타입을 제한할 때 사용하는 키워드.
    // (where T : IComparable<T> == T에 대입할 타입은 반드시 IComparable<T> 혹은
    //                              해당 타입을 상속받은 타입이여야 한다.)
    // IComparable<T> : 인스턴스를 정렬하는 형식 고유의 비교 메서드를 만들기 위해
    //                  값 형식 또는 클래스에서 구현하는 일반화된 비교 메서드
    //                  객체가 대상 객체보다 작으면 0보다 작은 값을, 같으면 0, 크면 0보다 큰 값을 반환
    public class MyHashtable<Tkey, TValue> : IEnumerable<KeyValuePair<Tkey, TValue>>
            where Tkey : IComparable<Tkey>
            where TValue : IComparable<TValue>
    {
        public TValue this[Tkey key]
        {
            get
            {
                // key 값의 인덱스를 Hash 함수로 찾고, 해당 인덱스의 버켓들을 담는다.
                var bucket = _buckets[Hash(key)];

                // 해당 버켓이 비어있다면, 해당 키 값이 저장된 적도 없다는 것이므로, 반환.
                if (bucket == null)
                    throw new Exception($"[MyHashtable<{nameof(Tkey)}, {nameof(TValue)}>] : Key {key.ToString()} has not been registered");
                
                // 해당 key 값의 인덱스의 버켓 리스트에서 Key값과 같은 key를 갖는 버켓을 찾는다.
                for(var i = 0; i < bucket.Count; i++)
                {
                    // 찾았다면 해당 버켓의 value값을 리턴한다.
                    if (bucket[i].key.CompareTo(key) == 0)
                    {
                        return bucket[i].value;
                    }
                }

                throw new Exception($"[MyHashtable<{nameof(Tkey)}, {nameof(TValue)}>] : Key {key.ToString()} has not been registered");
            }
            set
            {
                // key 값의 인덱스를 Hash 함수로 찾고, 해당 인덱스의 버켓들을 담는다.
                var bucket = _buckets[Hash(key)];

                // 해당 버켓이 비어있다면, 해당 키 값이 저장된 적도 없다는 것이므로, 반환.
                if (bucket == null)
                    throw new Exception($"[MyHashtable<{nameof(Tkey)}, {nameof(TValue)}>] : Key {key.ToString()} has not been registered");

                // 해당 key 값의 인덱스의 버켓 리스트에서 Key값과 같은 key를 갖는 버켓을 찾는다.
                for (var i = 0; i < bucket.Count; i++)
                {
                    // 찾았다면 해당 버켓의 value 값을 입력값으로 변경하여 저장한다.
                    if (bucket[i].key.CompareTo(key) == 0)
                    {
                        bucket[i] = new KeyValuePair<Tkey, TValue>(key, value);
                    }
                }
            }
        }

        // 모든 버킷의 키 값을 순환한다. 단, 유효한 키값만 리턴.
        public IEnumerable<Tkey> Keys
        {
            get
            {
                MyDynamicArray<Tkey> array = new MyDynamicArray<Tkey>();
                for(int i = 0; i < _validIndexList.Count; i++)
                {
                    for(int j = 0; j < _buckets[_validIndexList[i]].Count; j++)
                    {
                        array.Add(_buckets[_validIndexList[i]][j].key);
                    }
                }
                return array;
            }
        }

        // 모든 버킷의 value 값을 순환한다. 단, 유효한 값만 리턴.
        public IEnumerable<TValue> Values
        {
            get
            {
                MyDynamicArray<TValue> array = new MyDynamicArray<TValue>();
                for (int i = 0; i < _validIndexList.Count; i++)
                {
                    for (int j = 0; j < _buckets[_validIndexList[i]].Count; j++)
                    {
                        array.Add(_buckets[_validIndexList[i]][j].value);
                    }
                }
                return array;
            }
        }


        // 테이블로 사용할 동적배열(버켓들을 담는 리스트) 생성
        // 체이닝 기법에도 쓰일 수 있는 배열이 된다. 
        // 버켓 최대 개수 100으로 제한
        private const int DERAULT_CAPACITY = 100;
        private MyDynamicArray<KeyValuePair<Tkey, TValue>>[] _buckets = new MyDynamicArray<KeyValuePair<Tkey, TValue>>[DERAULT_CAPACITY];
        
        // 유효한(버킷이 존재하는) 인덱스 리스트만 담는 자료구조
        private MyDynamicArray<int> _validIndexList = new MyDynamicArray<int>();
        // 유효한 인덱스의 키들을 담는다.
        private MyDynamicArray<Tkey> _validKeyList = new MyDynamicArray<Tkey>();

        // key, value 버켓 추가
        public bool TryAdd(Tkey key, TValue value)
        {
            int index = Hash(key);
            var bucket = _buckets[index];

            // 해당 인덱스의 버킷이 존재하지 않는다면
            if(bucket == null)
            {
                // 새 버킷 배열 생성.
                _buckets[index] = new MyDynamicArray<KeyValuePair<Tkey, TValue>>();
                // 버킷이 존재하는 인덱스만 저장.
                _validIndexList.Add(index);
            }
            // hashtable은 동일한 키 값이 존재할 수 없다. 따라서 이미 존재한다면 값을 덮어 씌운다.
            else
            {
                // 해당 인덱스의 버킷들 중 해당 KEY를 가지는 버킷이 있나 확인한다.
                for(int i = 0; i < _buckets[index].Count; i++)
                {
                    // 똑같은 key를 가지는 버킷이 있다면,
                    if (_buckets[index][i].key.CompareTo(key) == 0)
                    {
                        // 이미 등록된 것이므로 실패 리턴.
                        return false;
                    }
                }
            }

            // 버킷 배열에 hash 구조체(key, value)를 추가한다.
            _buckets[index].Add(new KeyValuePair<Tkey, TValue>(key, value));

            return true;
        }

        // key에 해당하는 value값 반환 (bool 리턴과 out으로 value값을 리턴)
        public bool TryGetValue(Tkey key, out TValue value)
        {
            int index = Hash(key);
            var bucket = _buckets[index];

            // 해당 인덱스의 버킷이 존재하지 않는다면
            if (bucket != null)
            {
                // 해당 인덱스의 버킷들 중 해당 KEY를 가지는 버킷이 있나 확인한다.
                for (int i = 0; i < _buckets[index].Count; i++)
                {
                    // 똑같은 key를 가지는 버킷이 있다면,
                    if (_buckets[index][i].key.CompareTo(key) == 0)
                    {
                        // 해당 키값의 value 값 리턴
                        value = _buckets[index][i].value;
                        return true;
                    }
                }
            }

            value = default;

            return false;
        }

        // key, value 버킷 삭제
        public bool Remove(Tkey key)
        {
            var bucket = _buckets[Hash(key)];

            // 해당 인덱스의 버킷이 존재한다면
            if (bucket != null)
            {
                // 해당 인덱스의 버킷들 중 해당 KEY를 가지는 버킷이 있나 확인한다.
                for (int i = 0; i < bucket.Count; i++)
                {
                    // 똑같은 key를 가지는 버킷이 있다면,
                    if (bucket[i].key.CompareTo(key) == 0)
                    {
                        // 해당 버킷 삭제
                        bucket.RemoveAt(i);
                        return true;
                    }
                }
            }

            // 지울 수 있는 버킷이 없으므로 에러 리턴
            return false;
        }


        // 해시테이블의 Key값의 index를 계산한다.
        public int Hash(Tkey key)
        {
            // key값을 문자열로 변환하여 저장한다.
            string keyName = key.ToString();

            // 각 스펠링의 아스킷 코드값을 더해준다.
            int hashResult = 0;
            for(int i = 0; i < keyName.Length; i++)
            {
                hashResult += keyName[i];
            }

            // 모듈러 연산(key의 아스킷코드 합이 너무 커질 수 있기 때문에,
            //              제한값으로 나눈 나머지를 저장한다.)
            hashResult %= DERAULT_CAPACITY;

            // 그 값이 해당 KEY값의 해시 테이블에서의 INDEX 값이 된다. 
            return hashResult;
        }

        public IEnumerator<KeyValuePair<Tkey, TValue>> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<KeyValuePair<Tkey, TValue>>
        {
            public object Current => _data[_index];

            KeyValuePair<Tkey, TValue> IEnumerator<KeyValuePair<Tkey, TValue>>.Current => _data[_index];

            private MyDynamicArray<KeyValuePair<Tkey, TValue>> _data;
            private int _index;

            public Enumerator(MyHashtable<Tkey, TValue> data)
            {
                _data = new MyDynamicArray<KeyValuePair<Tkey, TValue>>();
                for (int i = 0; i < data._validIndexList.Count; i++)
                {
                    for (int j = 0; j < data._buckets[data._validIndexList[i]].Count; j++)
                    {
                        _data.Add(new KeyValuePair<Tkey, TValue>(data._buckets[data._validIndexList[i]][j].key, 
                                                                 data._buckets[data._validIndexList[i]][j].value));
                    }
                }

                _index = -1;
            }


            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _data.Count;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
