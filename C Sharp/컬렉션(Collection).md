# 컬렉션(Collection)

## 컬렉션이란?
- object 타입의 데이터를 담는 자료구조이다.
- 종류
  - **Array**
    
    일반적인 배열이다.
    
  <br>
  
  - **ArrayList**
    - 배열과 가장 흡사한 구조의 컬렉션이다.
    - 요소 접근 시 연산자 []를 사용하며, 원하는 위치에 데이터를 추가하거나 삭제할 수 있다.
    - 배열과 달리 미리 크기를 지정할 필요가 없어, 데이터를 추가/삭제하는데 자유롭다.

      ```csharp
      ArrayList array = new ArrayList();
      array.Add(넣을값);
      array[0];
      ```

    - 메소드
      
      | 메소드 | 기능 |
      |-------|------|
      | int Add(object) | 마지막 요소 뒤에 새로운 요소 추가<br>매개 변수는 추가하는 요소 정보로 object 타입이기 때문에 int, float, string, class 등 원하는 데이터를 추가할 수 있다.<br>반환 값은 추가한 요소의 방 번호(순번) |
      | void insert(int, object) | 첫 번째 매개변수 위치에 두 번째 매개변수 요소 추가 |
      | void AddRange(ICollection) | 여러개의 요소를 한번에 추가<br>매개변수는 ICollection 인터페이스 타입으로<br>대표적으로 Collection<> 데이터를 만들어서 추가 가능 |
      | void Remove(object) | 매개변수에 입력된 데이터와 동일한 데이터 요소 삭제 |
      | void RemoveAt(int) | 매개변수에 입력된 위치의 요소 삭제 |
      | void RemoveRange(int, int) | 첫 번째 매개변수 위치부터 두 번째 매개변수 개수만큼의 요소 삭제 |
      | void Sort() | ArrayList 내의 요소를 오름차순으로 정렬<br>(정수 한정으로 사용 가능. 요소중에 정수가 아닌 데이터가 있으면 에러 발생) |
      | void Clear() | 모든 요소를 삭제. ArrayList 초기화 |
      | int Count | 현재 ArrayList에 저장되어 있는 요소의 개수 반환 |
  
  <br>
  
  - **Queue**
    - 요소 추가와 삭제 위치가 양 끝으로 나뉘어진 자료구조이다.
    - 선입선출(FIFO, First In First Out) : 먼저 들어온 데이터가 먼저 나간다.
    - 따라서 중간에 있는 데이터를 확인/추가/삭제 할 수 없다.
    
    - 메소드
      
      | 메소드 | 기능 |
      |-------|------|
      | void Enqueue(object) | 후단에 새로운 요소 추가<br>매개변수는 추가하는 요소 정보로 object 타입이기 때문에 int, float, string, class 등 원하는 데이터를 추가할 수 있다. |
      | object Peek() | 전단에 있는 요소를 삭제하지 않고, 요소를 반환할 때 사용 |
      | object Dequeue() | 전단에 있는 요소를 삭제하고, 삭제한 요소를 반환 |
      | void Clear() | 큐의 모든 요소를 삭제 |
      | int Count | 현재 큐에 저장된 요소의 개수 반환 |
      
  <br>
  
  - **Stack**
    - 요소 추가와 삭제 위치가 한쪽 끝에서만 가능한 자료구조이다.
    - 선입후출(FILO, First In Last Out) : 먼저 들어온 데이터가 나중에 빠져나간다.
    - 따라서 맨 끝에 있지 않은 모든 데이터를 확인/추가/삭제 할 수 없다.
    
    - 메소드
      
      | 메소드 | 기능 |
      |-------|------|
      | void Push(object) | 최상위에 새로운 요소 추가<br>매개변수는 추가하는 요소 정보로 object 타입이기 때문에 int, float, string, class 등 원하는 데이터를 추가할 수 있다. |
      | object Peek() | 최상위 요소를 삭제하지 않고, 요소를 반환할 때 사용 |
      | object pop() | 최상위 요소를 삭제하고, 삭제한 요소를 반환 |
      | void Clear() | 스택의 모든 요소를 삭제 |
      | int Count | 현재 큐에 저장된 요소의 개수 반환 |
    
  <br>
  
  - **Hashtable**
    - 키(Key)와 값(Value)의 쌍으로 이루어진 데이터를 다룰 때 사용하는 자료구조이다.
    - 해시테이블은 요소에 접근하기 위해 object 타입의 데이터를 사용한다. ( 예 : hashtable["Monster"], hashtable[1.5f], ...)

    - 키(Key)는 int, float, string, class 등 어떤 형식이든 사용 가능하다.

    > 해시테이블과 같은 데이터는 모든 요소를 탐색할 때 foreach를 사용하며, 배열에서 인덱스로 요소 접근하는 것과 속도가 비슷하다.

      ```csharp
      // java의 향상된 for 문 == foreach
      // hashtable의 key의 형식을 알 수 없을 경우 object나 var로 받아 처리할 수 있다.
      foreach( object key in hash.Keys ) {...}
      ```
    
    - 메소드
      
      | 메소드 | 기능 |
      |-------|------|
      | void Add(object, object) | 첫 번째 매개변수를 키, 두 번째 매개변수를 값으로 사용하는 요소 추가<br>매개변수는 추가하는 요소 정보가 object 타입이기 때문에 int, float, string, class 등 원하는 데이터를 추가 할 수 있다. |
      | void Remove(obejct) | 해시 테이블에서 매개변수에 입력된 데이터를 키(Key)로 가지는 요소 삭제 |
      | bool ContainsKey(objec) | 해시테이블에서 매개변수에 입력된 데이터를 키(Key)로 가지는 요소가 있는지 검사<br>있으면 true, 없으면 false 반환 |
      | bool ContainsValue(object) | 해시테이블에서 매개변수에 입력된 데이터를 값(Value)으로 가지는 요소가 있는지 검삭<br>있으면 true, 없으면 false 반환 |
      | ICollection Keys | 해시테이블에 있는 모든 키 정보를 나타내는 프로퍼티 |
      | void Clear() | 해시테이블의 모든 요소를 삭제 |
      | int Count | 현재 해시테이블에 저장된 요소의 개수 |
    
  <br>
  
  - **Dictionary**
    - HashTable 컬렉션의 일반화 버전이다.
    - Hashtable과 다르게 하나의 컬렉션 변수에 하나의 데이터 형식만 담을 수 있다.
    - 키(Key)와 값(Value)의 쌍으로 이루어진 데이터를 다를 때 사용한다.
   
    - Dictionary<TKey, TValue> 메소드
      
      | 메소드 | 기능 |
      |-------|------|
      | void Add(TKey, TValue) | 첫 번째 매개변수를 키, 두 번째 매개변수를 값으로 사용하는 요소 추가 |
      | void Remove(TKey) | 매개변수에 입력된 데이터를 키(Key)로 가지는 요소 삭제 |
      | bool ContainsKey(TKey) | 매개변수에 입력된 데이터를 키(Key)로 가지는 요소가 있는지 검사<br>있으면 true, 없으면 false 반환 |
      | bool ContainsValue(TValue) | 매개변수에 입력된 데이터를 값(Value)으로 가지는 요소가 있는지 검삭<br>있으면 true, 없으면 false 반환 |
      | ICollection Keys | 모든 키 정보를 나타내는 프로퍼티 |
      | void Clear() | 모든 요소를 삭제 |
      | int Count | 저장된 요소의 개수 |
      
