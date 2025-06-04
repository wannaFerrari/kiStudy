using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace CollectionsWithGeneric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //기존에 배열 크기가 가변적으로 변할때 썼던 Collection Class
            ArrayList arrayList = new ArrayList();

            arrayList.Add(1);
            arrayList.Add("하이");
            arrayList.Add(4.4);

            foreach (object item in arrayList)
            {
                //int value = item + 1;
            }

            //ArrayList의 요소 자료형을 지정하여 자료형을 안전하게 참조할 수 있는 Generic List
            List<int> intList = new List<int>();
            intList.Add(1);
            //intList.Add("gg"); // 문자열 안됨
            //intList.Add(4.4); // float도 안됨
            intList.Add(3);
            intList.Add(82);
            foreach (int item in intList)
            {
                int value = item + 1;
                Console.WriteLine(value);
            }

            //1. Dictionary : Hashtable의 TypeSafe 버전
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("이성준", 1);
            dic.Add("삼성준", 2);
            dic.Add("사성준", 3);
            dic.Add("오성준", 4);
            dic.Add("육성준", 5);
            foreach (KeyValuePair<string, int> kvp in dic)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            //2. HashSet
            HashSet<int> hash = new HashSet<int>();
            hash.Add(1);
            hash.Add(2);
            hash.Add(3);
            hash.Add(4);
            hash.Add(5);
            foreach (int i in hash)
            {
                Console.Write(" {0}", i);
            }

            Console.WriteLine();
            //3. LinkedList
            LinkedList<float> linkedList = new LinkedList<float>();
            linkedList.AddFirst(1.1f);
            linkedList.AddLast(2.1f);
            linkedList.AddFirst(3.1f);
            linkedList.AddLast(4.1f);
            linkedList.AddFirst(5.1f);   // 5.1, 3.1, 1.1, 2.2, 4.1
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(linkedList.Last.Value);
                linkedList.RemoveLast();
            }

            //4. Stack
            Stack<double> stack = new Stack<double>();
            stack.Push(1.0);
            stack.Push(2.0);
            stack.Push(3.0);
            stack.Push(4.0);
            stack.Push(5.0);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(stack.Pop());
            }
            //5. Queue
            Queue<decimal> queue = new Queue<decimal>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }

            //위 다섯가지 Collections.Generic 클래스에 데이터를 각 5개씩 넣고 빼는 연습해보기
        }
    }
}
