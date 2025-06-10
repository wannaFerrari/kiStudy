using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Algorithm_DataStructure
{
    
    internal class Program
    {
        //알고리즘 (Algorithm)
        //문제 해결을 위해 만들어진 진행절차 또는 연산방법 등을 알고리즘이라고 함.
        // 컴퓨터에서의 알고리즘ㅇ느 어떠한 행동(연산)을 하기 위해서 만들어진 프로그램 명령어의 집합.

        //알고리즘의 조건
        //1. 입력과 출력이 있어야함 : 입력 - 연산에 필요한 데이터가 주어지고, 출력 - 유의미한 결과가 도출됨
        //2. 명확성 : 수행 과정이 모호하지 않고 명확한 연산 절차를 통해야 함
        //3. 유한성 : 수행 과정이 언젠가는 결과를 도출할 수 있을 정도로 유한해야함.
        //4. 효과성 : 수행과정은 명백하게 수행 가능하여야 한다.

        //알고리즘의 성능
        //하드웨어 성능이랑 별개로 보는 알고리즘 자체 성능.
        //알고리즘 성능의 평가 기준 2가지
        //1. 시간 복잡도 : 알고리즘이 결과를 도출할 때 까지의 소요 시간(시간 자원 소모량) - 연산 횟수를 기준으로..
        //2. 공간 복잡도 : 알고리즘이 결과를 도출하기 위해 필요한 메모리(공간 자원 소모량) - 변수 개수

        //시간 복잡도를 표기하기 위한 지표<Big-O> 표기법
        //데이터 증가에 따른 시간 복잡도 증가량을 표기한다.
        //가장 높은 차수의 계수와 나머지 모든 항을 제거하고 표기한다.

        //Big-O 표기법의 대표적인 표기방법
        // 상수 시간 : O(1) - 데이터가 아무리 증가하더라도 걸리는 시간은 1
        // 선형 시간 : O(n) - 데이터가 증가 하는것에 정비례하여 시간이 증가
        // 로그 시간 : O(log n) - 이진 탐색시
        // 로그 선형 시간 : O(n log n)
        // 이차 시간 : O(n²) - 데이터가 10개면 수행횟수 100회... 대표적으로 버블정렬..
        // 지수 시간 : O(2ⁿ) - 데이터가 4개면 16회, 5개면 32회...브루트 포스 알고리즘(모든 경우의 수 탐색), 백트래킹, DFS 등등
        // 팩토리얼 시간 : O(n!) - 최악의 시간 복잡도

        //만약 내가 어떤 알고리즘을 짰는데, 수행 횟수가 3n + 5 => O(n)

        //O(1) < O(log n) < O(n) < O(nlog n) < O(n²) < O(2ⁿ) < O(n!) 순서로 느려진다
        //상수 표기 알고리즘의 예시
        int GetFirstElement(int[] array)
        {
            return array[0]; // O(1)
            //비교를 딱 6번만 하겠다
            //for(int i = 0; i < i++){} // O(6)
        }



        //알고리즘의 수행시간 분석은 1차원적이지 않다.

        int FindIndex(int[] array, int findValue)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == findValue)
                {
                    return i;
                }
            }
            return -1;
        }
        // 최선의 경우 : O(1)
        // 최악의 경우 : O(n)
        // 평균 : O(n/2) -> 빅오 표기법에서는 지수는 버리므로 결국 O(n)

        //List vs LinkedList
        //List는 index로 데이터를 찾기 때문에 탐색이 빠름.
        //다만 데이터의 삽입, 삭제의 경우 연산 후에 모든 데이터의 값을 이동하는 절차를 거치기 때문에
        //  데이터의 삽입, 삭제가 빈번한 경우 더 비효율적
        //LinkedList는 다음 노드를 순차적으로 찾기 때문에, 데이터 탐색은 느림.
        //다만, 데이터 삽입이나 삭제가 일어날 경우 해당 노드와 앞, 뒤 노드만 접근하면 되므로
        //  삽입, 삭제가 빈번한 경우 더 효율적.

        //브루트 포스 알고리즘
        //Brute-force(주먹구구식)
        //무식하지만 정확도 100%의 알고리즘
        //단점 : 시간 복잡도도 가장 무식하다

        //브루트포스를 빠르게 가능하도록 하기 위한 노력?
        //1. 분할 정복 : 이진트리 등을 활용. 문제를 나눠서 해결하고 합치는 전략.
        //대표적으로 병합정렬, 퀵정렬

        //2. 그리디(탐욕 알고리즘) : 매 단계마다 가장 최선의 선택을 하는 전략.
        //항상 최선이 보장되지는 않음. (최악의 경우 브루트포스보다 느릴 수 있음)
        //대표적으로 다익스트라 알고리즘, A*알고리즘. 

        //3. 휴리스틱 : 정확한 계산에 기반하지 않고, 근사적으로 정답을 빠르게 찾기 위한 경험적 추론 기법.
        // (그리디랑 비슷하면서 연관성도 있지만, 개발자의 추론방식이 많이 개입됨..? 따라서 그리디의 확장판이라고 단정지을순 없음)





        //자료구조 (Data Structure)
        //자료(데이터)를 효율적으로 저장하고 관리(삽입, 삭제, 탐색) 하기위한 형태 또는 방법의 집합.

        //1. 배열(Array) : 고정크기, 인덱스를 가짐.
        //2. 리스트(List) : 배열의 확장버전. 중간 인덱스의 데이터를 삽입, 삭제 할 수 있고, 크기를 유동적으로 조절 가능.
        //      다만, 내부적으로 배열을 가지고 있다.
        //3. 스택(Stack) : 쌓다는 뜻. 먼저 삽입된 데이터가 가장 나중에 나옴. 가장 나중에 삽입된 데이터가 가장 먼저 나온다.
        //4. 큐(Queue) : 기다란 원통이란 뜻. 먼저 삽입된 데이터가 먼저 나옴. (줄세우기)
        // 큐와 스택은 선형 구조로, 중간 데이터를 꺼낼 수 없음.
        //5. 연결리스트(LinkedList) : 리스트와 유사한 형태로 사용할 수 있으나, 내부적으로 노드구조를 가진 데이터구조.
        //      데이터의 삽입/삭제가 빠르고 탐색은 느리다.
        //6. 해쉬테이블 : 키 - 값 구조로 된 데이터 구조. 탐색은 키를 통해 하고 데이터는 값에 저장.
        //6-1. 딕셔너리 : 해쉬테이블의 키와 값의 데이터타입을 명시한 버전.
        //7. HashSet : 중복이 없는 데이터 집합.(중복제거된 List느낌)


        //8. 트리 : 하나의 root로 시작되어, 자식노드가 연결되어 있는 형태의 계층적 구조
        //8-1. 이진 트리 : 부모 노드에 자식 노드가 딱 2개로 제한되는 형태의 트리.
        //9. 그래프 : 노드(정점)와 간선으로 이루어진 그물망 형태의 구조.
        //      노드에 포함된 데이터는 다음 데이터로 이어지는 간선과 방향성, 가중치가 있다.
        //트리도 일종의 그래프라고 할 수 있다.
        //10. 우선순위 큐(힙) : 큐가 데이터의 삽입 순서에 의해 다음 데이터를 결정하는 것과 다르게
        //      데이터 삽입시 우선순위를 함께 결정하여, 다음 데이터는 가장 높은 우선순위의 데이터를 가져오는 형태의 자료구조.

        static void Main()
        {
            //C# 에서의 데이터 구조가 다른 컬렉션 사용 예시.
            //1. 배열
            int[] array = new int[4];

            //2. 리스트
            List<int> list = new List<int> { 10, -1, 6, 12, 4, 7 };
            list.Sort();
            foreach(int item in list)
            {
                Console.Write($"{item}, ");
            }

            //2-1. 자료형이 강제되지 않은 리스트
            ArrayList arrayList = new ArrayList();  //리스트와 똑같지만 <자료형> 이 강제되지 않는것의 차이만 있음

            //3. 스택
            Stack stack = new Stack();
            stack.Push("안녕하세요"); // 스택에 데이터 삽입
            stack.Push(1);
            stack.Push(7.2f);

            Console.WriteLine(stack.Pop()); // 7.2f    스택에서 데이터 꺼내기. 튀어나오다.
            Console.WriteLine(stack.Pop()); // 1

            stack.Push("반갑습니다");

            Console.WriteLine(stack.Pop()); // 반갑습니다
            Console.WriteLine(stack.Pop()); // 안녕하세요

            Stack<int> intStack; // 제네릭으로 스택의 자료형 강제 가능

            //4. 큐
            Queue queue = new Queue();
            queue.Enqueue("가"); //큐에 들어감
            queue.Enqueue("나"); 
            queue.Enqueue("다");
            
            Console.WriteLine(queue.Dequeue()); // 큐에서 나옴
            queue.Enqueue("라");
            while(queue.Count > 0)
            { 
                // 큐에 남은 데이터 개수가 0개 보다 크면 계속 Dequeue
                Console.WriteLine(queue.Dequeue());
            }

            //5. 연결리스트
            LinkedList<int> linkedList = new LinkedList<int>();

            //6. HashSet
            HashSet<int> hashSet = new HashSet<int>();

            //7. 딕셔너리
            Dictionary<string,int> dict = new Dictionary<string, int>();

            //데이터 넣고 빼고 해보기. //삽입 순서가 큰 상관이 없을 경우,
            //  그리고 데이터 삭제가 잘 일어나지 않을 경우에 대부분 List가 효율적
            list.Add(1);
            int someInt = list[0]; // O(1)

            list.Insert(2, 2); //O(n)
            list.RemoveAt(2);  //O(n)
            list.Find(x => x == 2); //O(n)

            //LinkedList의 자료 삽입   O(1)
            LinkedListNode<int> node0 = linkedList.AddLast(5); // 5 
            var node1 = linkedList.AddFirst(7);                 // 7, 5 
            var node2 = linkedList.AddBefore(node0, 3);         // 7, 3, 5
            var node3 = linkedList.AddAfter(node2, 8);         // 7, 3, 8, 5
            //O(1)

            //접근 
            var firstNode = linkedList.First; // 7 찾아옴
            var thirdNode = firstNode.Next.Next; // 8 찾아옴

            Console.WriteLine(thirdNode.Value);

            //삭제 0(1)
            linkedList.Remove(7); // 3, 8, 5
            linkedList.Remove(node3); // 3, 5

            //탐색 : Find
            var someNode = linkedList.Find(3);

            Console.WriteLine(someNode.Value);

            //HashSet : 내부적으로는 해쉬알고리즘등을 통해 비교를 효율적으로 하는 기능이 들어가있지만,
            //사용하는 개발자 입장에서 한마디로 설명하면 "중복 제거된 리스트" 
            list.Clear();
            list.Add(8);
            list.Add(8);
            list.Add(8);
            list.Add(8);
            list.Add(8);
            list.Add(7);
            list.Add(7);
            list.Add(7);


            hashSet.Add(8);
            hashSet.Add(8);
            hashSet.Add(8);
            hashSet.Add(8);
            hashSet.Add(8);
            hashSet.Add(7);
            hashSet.Add(7);
            hashSet.Add(7);

            Console.WriteLine($"list.Count : {list.Count}, hashSet.Count : {hashSet.Count}");

            //값을 인덱스 등 편하고 간편한 방법으로 접근이 불가능. 무조건 탐색을 통해 접근해야 하므로
            //값의 순서가 중요한 데이터를 취급하기에는 적절하지 않다.

            bool isContains8 =  hashSet.Contains(8); // 해쉬셋에 값이 존재하는지 여부

            hashSet.TryGetValue(7, out int findedValue);


            //딕셔너리(==해쉬테이블)
            Hashtable hashTable = new Hashtable();
            Dictionary<object, object> dictionary = new Dictionary<object, object>();

            //인덱서로 키를 추가하면 자동으로 키가 중복체크가 되어
            //키가 없으면 add, 있으면 해당 키에 값을 덮어쓰는 기능
            dictionary[1] = "가";
            hashTable[1] = "가";
            dictionary["가"] = 1;
            hashTable["가"] = 1;

            Console.WriteLine(hashTable["가"]);

            dictionary.Add("c", 3.3f);
            //dictionary.Add("c", 32);  //이미 있으므로 에러뜸
            Dictionary<int, string> intStringDic;
            Dictionary<decimal, string> floatDic;
            //float -> 떠서 날라다닌다. 부동.
            //float 부동소수점, double은 2배의 float
            //float은 소수점을 계산할때 구조상 조금씩 오차 발생.. float를 딕셔너리의 키로 사용하는건 자제
            //decimal : 고정 소수점. 16byte를 사용, 앞의 8바이트는 정수부, 뒤의 8바이트는 소수부

        }

        static void Main1(string[] args)
        {
            int[] numbers = { 10, -1, 6,12, 4, 7 };
            int big = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{i}번째 루프 입니다. 지금 알고있는 가장 큰 수는 {big} 입니다." +
                    $"numbers[{i}]의 수는 {numbers[i]}입니다.");

                if (big < numbers[i])
                {
                    Console.WriteLine($"{numbers[i]} 가 {big} 보다 크네요? 갈아 치웁니다.");
                    big = numbers[i];
                }
                else
                {
                    Console.WriteLine($"{big}이 여전히 제일 큽니다.");
                }
            }
            Console.WriteLine($"배열 안에서 가장 큰 수는 {big} 입니다");
        }
    }
}
