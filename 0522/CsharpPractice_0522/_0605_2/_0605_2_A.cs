using System;
using System.Collections.Generic;

namespace _0605_2
{
    internal class _0605_2_A
    {
        static void Main(string[] args) // A문제
        {
            List<string> list = new List<string>();
            list.Add("크크루삥뽕");
            list.Add("나는 코드를 진짜 못치겠어요");
            list.Add("잘 좀 하고싶은데 머리가 굳었네요");
            list.Add("Hello world 그치만 난 안녕못해요");
            list.Add("일단 대충 '가'가 들어간 문자열이긴 합니다");
            list.Add("짧");

            Console.WriteLine("4글자 이상만 출력해봅니다");
            List<string> over4List = list.FindAll(x => x.Length >= 4);
            foreach (string str in over4List)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            Console.WriteLine("\'가\'가 들어간 문자열만 출력합니다");
            List<string> hasGaList = list.FindAll(x => x.Contains("가"));
            foreach (string str in hasGaList)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            Console.WriteLine("\'Hello\'가 들어간 문자열만 출력합니다");
            string hasHello = list.Find(x => x.Contains("Hello"));

            Console.WriteLine(hasHello);


        }


    }
}
