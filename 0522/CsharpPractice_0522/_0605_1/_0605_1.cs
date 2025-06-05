using System;
using System.Text;

namespace _0605_1
{
    internal class _0605_1
    {
        //1번문제 : 프린터 만들기
        static string[] fruits = { "사과", "바나나", "망고" };
        static string[] animals = { "강아지", "고양이", "래서판다", "호랑이", "반달가슴곰", "북극곰" };

        static Action<string[]> printer; //출력 델리게이트. 
        //static Func<float, float, float> calcFunc;

        //1-1. 앞에 번호를 붙여서 줄대로 출력하는 함수.
        static void PrintWithNumber(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {array[i]}");
            }
        }
        //1-2. 한줄로 붙여서 출력하는 함수.
        static void PrintInOneLine(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}");
            }
        }
        //1-3. 글자 사이사이에 공백 " " 을 추가해서 출력하는 함수.
        static void PrintWithSpaceBetween(string[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in array)
            {
                foreach (char ch in str)
                {
                    sb.Append(ch);
                    sb.Append(' ');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }
        static void Main(string[] args)
        {
            //위의 3개의 함수를 체이닝 하여 호출할 수 있도록 하시오.

            printer = PrintWithNumber;
            printer?.Invoke(fruits);
            printer?.Invoke(animals);
            Console.WriteLine();

            printer = PrintInOneLine;
            printer?.Invoke(fruits);
            printer?.Invoke(animals);
            Console.WriteLine();

            printer = PrintWithSpaceBetween;
            printer?.Invoke(fruits);
            printer?.Invoke(animals);

            Console.WriteLine(Calc(0.1f, 1.1f, Plus));

        }

        //2번문제 : 계산기 만들기
        //Calc() 메소드에 3번째 파라미터로 실제 계산할 함수를 받아서 계산 결과를 리턴
        //사칙연산 계산기를 만드세요.
        static float Calc(float a, float b, Func<float, float, float> calcFunc)
        {
            return calcFunc(a, b);
        }

        static float Plus(float a, float b)
        {
            return a + b;
        }


    }
}
