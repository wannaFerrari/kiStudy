using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _0610_5
{
    class MyQueue
    {
        private int[] array;
        private int head;
        private int tail;
        public MyQueue(int size)
        {
            array = new int[size];
            head = 0;
            tail = 0;
        }
        public void Enqueue(int value)
        {
            if (tail > array.Length - 1)
            {
                Console.WriteLine("Queue 꽉참");
                Console.WriteLine($"배열 크기 {array.Length}");
            }
            else
            {
                if(head == -1)
                {
                    head = 0;
                }
                array[tail] = value;
                tail++;
                Console.WriteLine($"{value} enqueue");
            }
        }

        public int Dequeue()
        {
            if (head == -1)
            {
                Console.WriteLine("Queue에 요소가 없습니다.");
                return default;
            }
            else
            {
                int temp = array[0];
                for (int i =1; i < tail; i++)
                {
                    array[i-1] = array[i];
                }
                tail--;
                //head--;
                if(head == tail)
                {
                    head = -1;
                    return temp;
                }
                else
                {

                    return temp;
                }
            }
        }
    }

    class MyStack
    {
        private int[] array;
        private int head;
        private int tail;
        public MyStack(int size)
        {
            array = new int[size];
            head = 0;
            tail = 0;
        }

        public void Push(int value)
        {
            if (tail > array.Length - 1)
            {
                Console.WriteLine("Stack 꽉참");
                Console.WriteLine($"배열 크기 {array.Length}");
            }
            else
            {
                if (head == -1)
                {
                    head = 0;
                }
                array[tail] = value;
                tail++;
                Console.WriteLine($"{value} Push");
            }
        }

        public int Pop()
        {
            if (tail == -1)
            {
                Console.WriteLine("Stack에 요소가 없습니다.");
                return default;
            }
            else
            {
                int temp = array[tail-1];
                /*
                for (int i = 1; i < tail; i++)
                {
                    array[i - 1] = array[i];
                }*/
                tail--;
                //head--;
                if (head == tail)
                {
                    tail = -1;
                    return temp;
                }
                else
                {

                    return temp;
                }
            }
        }
    }
    internal class _0610_5
    {
        static void Main(string[] args)
        {
            MyQueue myQueue = new MyQueue(5);
            MyStack myStack = new MyStack(5);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);

            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());





            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            myStack.Push(6);

            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());

        }
    }
}
