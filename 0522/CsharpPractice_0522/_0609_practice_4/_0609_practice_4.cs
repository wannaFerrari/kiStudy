using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0609_practice_4
{
    static class NewStaticClass
    {
        public static void PrintArray(this int[,] array)
        {
            //for(int i = 0; i < array.GetLength(0); i++)
            //{
            //    for(int j = 0; j < array.GetLength(1); j++)
            //    {
            //        Console.WriteLine($"({array[i,j]})");

            //    }
            //}

            foreach(int item in GetItems(array))
            {
                //foreach(int item2 in item)
                //{
                //    Console.WriteLine(item2.ToString());
                //}
                Console.WriteLine(item.ToString());
            }
        }

        public static void PrintString(this List<string> list)
        {
            foreach (string item in GetStrings(list))
            {
                //foreach(int item2 in item)
                //{
                //    Console.WriteLine(item2.ToString());
                //}
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<int> GetItems(int[,] array)
        {
            for(int i = 0;  i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    yield return (int)array[i,j];

                }
            }
        }

        public static IEnumerable<string> GetStrings(List<string> list)
        {
            for(int i = 0; i < list.Count;i++)
            {
                if(list[i] == "그만")
                {
                    yield break;
                }
                yield return list[i];
            }
        }
    }
    internal class _0609_practice_4
    {
        
        static void Main(string[] args)
        {
            int[,] matrix = new int[2, 2] { { 2,3}, { 3,5} };
            matrix.PrintArray();

            List<string> stringList = new List<string>();
            stringList.Add("집에");
            stringList.Add("보내");
            stringList.Add("주세요");
            stringList.Add("이제");
            stringList.Add("그만");
            stringList.Add("쉬고");
            stringList.Add("그냥");
            stringList.Add("집으로");
            stringList.Add("떠나고");
            stringList.Add("싶어요");
            stringList.PrintString();
        }
    }
}
