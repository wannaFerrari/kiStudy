using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0610_2
{
    internal class _0610_2
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            Queue queue = new Queue();
            bool end = false;
            while(end == false)
            {
                Console.WriteLine("데이터를 입력하세요");
                string input = Console.ReadLine();
                stack.Push(input);
                queue.Enqueue(input);
                if(input == "그만")
                {
                    end = true;
                }
            }
            Console.Write("Stack : ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
            Console.Write("Queue : ");

            while (queue.Count > 0)
            {
                Console.Write(queue.Dequeue());
            }
        }
    }
}
