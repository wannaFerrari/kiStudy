using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0610_4_b
{
    internal class _0610_4_b
    {
        static void Main(string[] args)
        {
            Console.Write("수를 입력하세요 > ");
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            string[] a = input.Split(',');
            for(int i = 0; i < a.Length; i++) 
            {
                numbers.Add(int.Parse(a[i]));
            }

            Console.Write("목표 숫자를 입력하세요 > ");
            int input2 = int.Parse(Console.ReadLine());
            FindCombinations(numbers, input2, new List<int>(), 0);



        }

        static void FindCombinations(List<int> list, int target, List<int> currentList, int index)
        {
            int sum = 0;
            foreach (int num in currentList)
            {
                sum += num;
            }

            if (sum == target)
            {
                Console.WriteLine($"[{string.Join(", ", currentList)}]");
            }

            if (sum >= target || index >= list.Count)
            {
                return;
            }

            for (int i = index; i < list.Count; i++)
            {
                currentList.Add(list[i]);
                FindCombinations(list, target, currentList, i + 1);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }

    }
}
