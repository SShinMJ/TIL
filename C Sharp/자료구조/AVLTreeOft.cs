namespace Collections
{
    internal class AVLTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public T Value;
            public Node Left;
            public Node Right;
            // 트리 밸런스가 맞는 지 체크하기 위한 높이값.(삽입/삭제 시 갱신된다)
            public int Height;
        }

        private Node _root;


        // 왼쪽/오른쪽 노드만 탐색되므로 시간복잡도는 log(N).
        public bool Contains(T value)
        {
            Node node = _root;
            // 루트 노드부터 탐색
            while (node != null)
            {
                // 기준 노드보다 작다면 왼쪽 자식 노드로.
                if (value.CompareTo(node.Value) < 0)
                    node = node.Left;
                // 기준 노드보다 크다면 오른쪽 자식 노드를 탐색
                else if (value.CompareTo(node.Value) > 0)
                    node = node.Right;
                else
                    return true;
            }
            return false;
        }
        
        // 실제로 쓰이는 노드 추가 호출 함수.
        public void Add(T value)
        {
            // 노드를 추가하고, 추가되어 변경된 노드 트리를 갱신한다.
            _root = Add(_root, value);
        }

        // 내부적으로 노드를 추가하는 함수.
        private Node Add(Node node, T value)
        {
            // 지금 있는 노드 트리의 노드가 비어있다면(넣어야 할 위치를 찾았다면)
            if (node == null)
            {
                // 해당 위치에 노드를 생성하고 리턴. 말단 노드이므로 높이는 1.
                return new Node { Value = value, Height = 1 };
            }

            // 현재 노드의 값과 넣을 값을 비교한다.
            int compare = value.CompareTo(node.Value);
            // 현재 노드보다 작으면
            if (compare < 0)
            {
                // 현재 노드의 왼쪽 자식으로 넘어가 비교한다.
                // 추가되고 자식노드들의 밸런스가 안맞다면 회전한다. 그렇게 변화된
                // 노드를 node의 왼쪽 자식으로 변경한다.
                node.Left = Add(node.Left, value);
            }
            // 현재 노드보다 크면
            else if (compare > 0)
            {
                // 현재 노드의 오른쪽 자식으로 넘어가 비교.
                // 추가되고 자식노드들의 밸런스가 안맞다면 회전한다. 그렇게 변화된
                // 노드를 node의 오른쪽 자식으로 변경한다.
                node.Right = Add(node.Right, value);
            }

            // 높이 값 갱신.
            // 가장 말단에 노드가 추가되고 리턴되어 여기로 온다.
            // 즉, node는 추가된 노드의 부모노드인 상태부터 타고 올라간다.

            // 그러므로 추가된 노드의 부모부터 시작하여 높이값을 변경한다.
            // ?? Null 병합연산자 
            // null 이 아닐경우 왼쪽 값 반환, null 이면 오른쪽 값 반환
            node.Height = 1 + Math.Max(node?.Left?.Height ?? 0, node?.Right?.Height ?? 0);
            
            // 부모노드부터 모든 부모 노드의 왼쪽 오른쪽 자식 노드의 높이 차이를 검사한다.
            int balance = Balance(node);

            // 왼쪽으로 치우쳐져있으면
            if (balance > 1)
            {
                // 자식의 값이 부모의 
                if (value.CompareTo(node.Left.Value) > 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                return RotateRight(node);
            }
            // 오른쪽으로 치우쳐져있으면
            else if (balance < -1)
            {
                if (value.CompareTo(node.Right.Value) < 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                return RotateLeft(node);
            }

            return node;
        }

        // 특정 노드 삭제.
        public void Remove(T value)
        {
            _root = Remove(_root, value);
        }

        private Node Remove(Node node, T value)
        {
            if (node == null)
                return null;

            // 지울 노드 찾기
            int compare = value.CompareTo(node.Value);
            if (compare < 0)
            {
                // 현재 노드의 왼쪽 자식에 왼쪽 자식의 자식중 하나의 노드로 대체된다.
                node.Left = Remove(node.Left, value);
            }
            else if (compare > 0)
            {
                node.Right = Remove(node.Right, value);
            }
            // 찾은 경우
            else
            {
                // 자식이 하나이던지 없던지 체크
                if (node.Left == null)
                {
                    // 오른쪽 자식만 있는 경우
                    //if (node.Right != null)
                    //{
                    //    // 자식의 자식들을 없앤다.
                    //    node.Right.Left = null;
                    //    node.Right.Right = null;
                    //}

                    // 오른쪽 자식을 리턴
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    // 왼쪽 자식만 있는 경우
                    //node.Left.Left = null;
                    //node.Left.Right = null;
                    // 왼쪽 자식을 리턴
                    return node.Left;
                }
                // 자식이 다 있는 경우
                else
                {
                    // 오른쪽 자식의 왼쪽 말단 노드가 현재 노드가 되는 것이 이상적.
                    // 따라서 오른쪽 자식의
                    Node tmp = node.Right;
                    Node tmpParent = tmp;
                    // 왼쪽 자식 중 말단 노드를 찾는다.
                    while (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                        tmpParent = tmp;
                    }
                    // 왼쪽 말단 노드의 값을 옮기고,
                    node.Value = tmp.Value;
                    // 말단 노드의 부모는 자식이 없어졌으므로 null.
                    tmpParent.Left = null;
                }
            }

            node.Height = 1 + Math.Max(node?.Left?.Height ?? 0, node?.Right?.Height ?? 0);

            int balance = Balance(node);

            // 왼쪽으로 치우쳐져있으면
            if (balance > 1)
            {
                if (value.CompareTo(node.Left.Value) > 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                return RotateRight(node);
            }
            // 오른쪽으로 치우쳐져있으면
            else if (balance < -1)
            {
                if (value.CompareTo(node.Right.Value) < 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                return RotateLeft(node);
            }

            return node;
        }

        // 왼쪽 자식과 오른쪽 자식의 높이 차를 반환한다.
        /// <summary>
        /// 기준노드 중심으로 어느쪽으로 자식노드들이 치우쳐져있는지 판단
        /// </summary>
        /// <param name="node"> 기준노드 </param>
        /// <returns> 왼쪽 : > 1 , 오른쪽 : < - 1  </returns>
        private int Balance(Node node)
        {
            return node != null ? ((node?.Left?.Height ?? 0) - (node?.Right?.Height ?? 0)) : 0;
        }

        // 좌회전(노드가 오른쪽으로 치우쳐저 있는 경우).
        private Node RotateLeft(Node node)
        {
            // 노드가 없거나 노드의 오른쪽이 없다면 회전할 필요가 없다.
            if (node == null || node.Right == null)
                return node;

            // 기준 노드의 오른쪽 자식을 새 루트로 만든다.
            Node newRoot = node.Right;
            // 기준 노드의 오른쪽 자식 노드를 새 루트의 왼쪽 자식으로 한다.
            node.Right = newRoot.Left;
            // 기준 노드를 새 루트의 왼쪽 자식으로 넣는다.
            newRoot.Left = node;

            // 높이 갱신.
            // ? : null 체크 연산자로 참조가 null이면 그 뒤 멤버를 접근하지 않는다.
            // ?? : null 병합 연산자로 왼쪽 피연산자가 null이 아닐 경우엔 왼쪽 값 반환, null이면 오른쪽 값 반환.
            // 즉, (부모이므로 자식 높이의 +1) + (왼쪽 자식과 오른쪽 자식의 높이 중 더 큰 값)이 현재 노드의 높이가 된다.
            node.Height = 1 + Math.Max(node?.Left?.Height ?? 0, node?.Right?.Height ?? 0);
            newRoot.Height = 1 + Math.Max(newRoot?.Left.Height ?? 0, newRoot?.Right?.Height ?? 0);
            return newRoot;
        }

        private Node RotateRight(Node node)
        {
            if (node == null || node.Left == null)
                return node;

            Node newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;

            node.Height = 1 + Math.Max(node?.Left?.Height ?? 0, node?.Right?.Height ?? 0);
            newRoot.Height = 1 + Math.Max(newRoot?.Left?.Height ?? 0, newRoot?.Right?.Height ?? 0);
            return newRoot;
        }
    }
}
