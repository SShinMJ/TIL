namespace Collections
{
    internal class MyLinkedListNode<T>
    {
        public T Value;
        public MyLinkedListNode<T> Prev;
        public MyLinkedListNode<T> Next;

        // 노드 생성자
        public MyLinkedListNode(T value)
        {
            Value = value;
        }
    }

    internal class MyLinkedList<T> : IEnumerable<T>
    {
        // get 접근자 생성.
        public MyLinkedListNode<T> First => _first;
        public MyLinkedListNode<T> Last => _last;
        // tmp는 연산용.
        private MyLinkedListNode<T> _first, _last, _tmp;

        // 맨 앞에 삽입
        public void AddFirst(T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            // first가 존재하면(기존에 한개 이상의 노드가 존재했다면)
            if(_first != null)
            {
                // 새 노드의 Next가 기존의 첫번째 노드
                _tmp.Next = _first;
                // 기존의 첫번째 노드의 이전 노드가 새 노드
                _first.Prev = _tmp;
            }
            // first가 없다 == Last가 없다 == 아무 노드도 없다.
            else
            {
                // 라스트를 tmp로.
                 _last = _tmp;
            }

            // 현재 노드를 첫번째로 한다.
            _first = _tmp;
        }

        // 맨 뒤에 삽입
        public void AddLast(T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            // first가 존재하면(기존에 한개 이상의 노드가 존재했다면)
            if (_last != null)
            {
                // 새 노드의 Prev가 마지막 노드
                _tmp.Prev = _last;
                // 기존의 마지막 노드의 Next가 새 노드
                _last.Next = _tmp;
            }
            // first가 없다 == Last가 없다 == 아무 노드도 없다.
            else
            {
                // first를 tmp로.
                _first = _tmp;
            }

            // 현재 노드를 마지막 노드로 한다.
            _last = _tmp;
        }

        // 특정 노드 앞에 삽입
        public void AddBefore(MyLinkedListNode<T> node, T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            // 기준 node 앞에 노드가 있다면
            if(node.Prev != null)
            {
                // 기준 노드의 앞 노드의 Next가 새 노드.
                node.Prev.Next = _tmp;
                // 새 노드의 Prev는 기존 노드의 앞 노드.
                _tmp.Prev = node.Prev;
            }
            // 앞에 노드가 없다면 기준 노드가 first이므로
            else
            {
                _first = _tmp;
            }

            // 기준 노드위 Prev와 새 노드의 Next 연결
            node.Prev = _tmp;
            _tmp.Next = node;

        }

        // 특정 노드 뒤에 삽입
        public void AddAfter(MyLinkedListNode<T> node, T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            // 기준 node 뒤에 노드가 있다면
            if (node.Next != null)
            {
                // 기준 노드의 앞 노드의 Next가 새 노드.
                node.Next.Prev = _tmp;
                // 새 노드의 Prev는 기존 노드의 앞 노드.
                _tmp.Next = node.Next;
            }
            // 뒤에 노드가 없다면 기준 노드가 last이므로
            else
            {
                _last = _tmp;
            }

            // 기준 노드의 Next와 새 노드의 Prev 연결
            node.Next = _tmp;
            _tmp.Prev = node;

        }
        
        // 노드 내 특정 값을 value로 가지는 노드 찾기.
        public MyLinkedListNode<T> Find(Predicate<T> match)
        {
            // 처음부터 순환하므로 초기값이 첫 노드다.
            _tmp = _first;

            // 다음 노드가 없을 때까지 반복
            while(_tmp != null)
            {
                // 찾는 값과 같다면
                if(match(_tmp.Value))
                    return _tmp;

                // 찾는 값이 아니라면 tmp가 계속 다음 노드로 넘어간다.
                _tmp = _tmp.Next;
            }

            return null;
        }

        // 노드 내 특정 값을 value로 가지는 노드 찾기.
        public MyLinkedListNode<T> FindLast(Predicate<T> match)
        {
            // 마지막부터 순환하므로 초기값이 마지막 노드다.
            _tmp = _last;

            // 이전 노드가 없을 때까지 반복
            while (_tmp != null)
            {
                // 찾는 값과 같다면
                if (match(_tmp.Value))
                    return _tmp;

                // 찾는 값이 아니라면 tmp가 계속 이전 노드로 넘어간다.
                _tmp = _tmp.Prev;
            }

            return null;
        }

        // 특정 노드 삭제
        public bool Remove(MyLinkedListNode<T> node)
        {
            // 지우고자 하는 노드가 null이면 못 지우니 false 리턴
            if(node == null) 
                return false;

            // 지우고자 하는 노드의 앞에 노드가 있다면,
            if (node.Prev != null)
            {
                // 노드의 앞 노드의 Next를 노드의 다음 노드로.
                // (다음 노드가 없으면 null이 들어가는데, 문제되지 않는다.)
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }
            // 지우는 노드가 첫번째라면 
            else
            {
                // 다음 노드가 첫번째가 된다.
                _first = node.Next;
            }

            // 지우고자 하는 노드의 뒤에 노드가 있다면,
            if (node.Prev != null)
            {
                // 노드의 뒤 노드의 Prev를 노드의 이전 노드로.
                // (이전 노드가 없으면 null이 들어가는데, 문제되지 않는다.)
                node.Next.Prev = node.Prev;
                node.Prev.Next = node.Next;
            }
            // 지우는 노드가 마지막 노드라면
            else
            {
                // 이전 노드가 마지막 노드가 된다.
                _last = node.Prev;
            }

            return true;
        }

        // 특정 값을 가지는 노드를 앞에서 부터 탐색하여 삭제
        public bool Remove(T value)
        {
            // 특정 값을 가지는 노드를 찾아서 삭제한다.
            return Remove(Find(x => Comparer<T>.Default.Compare(x, value) == 0));
        }

        // 특정 값을 가지는 노드를 뒤에서 부터 탐색하여 삭제
        public bool RemoveLast(T value)
        {
            return Remove(FindLast(x => Comparer<T>.Default.Compare(x, value) == 0));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            // 현재 노드의 Value를 반환.
            public T Current => _currentNode.Value;

            // 현재 노드의 Value를 반환.
            object IEnumerator.Current => _currentNode.Value;

            private MyLinkedList<T> _data;
            // 노드를 직접 참조하지 못하므로
            private MyLinkedListNode<T> _currentNode;

            // 생성 시 데이터 초기화
            public Enumerator(MyLinkedList<T> data)
            {
                _data = data;
                _currentNode = null;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                // _currentNode = null;이 디폴트 이므로, 리셋상태란 뜻이다.
                if( _currentNode == null)
                {
                    // 따라서 처음 노드로 시작점을 잡는다.
                    _currentNode = _data.First;
                }
                // 현재 어떤 노드를 가르키고 있다면 다음 노드로 넘어간다.
                else
                {
                    _currentNode = _currentNode.Next;
                }

                // 성공 여부 반환.
                return _currentNode != null;
            }

            public void Reset()
            {
                _currentNode = null;
            }
        }
    }
}
