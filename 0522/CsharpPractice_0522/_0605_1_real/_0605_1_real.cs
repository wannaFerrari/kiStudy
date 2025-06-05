using System;

namespace _0605_1_real
{
    //1. 사칙연산 체이닝
    //두 수를 입력받으면 +, -, *, / 를 차례로 수행하는 델리게이트를 호출하세요
    //1-1 : 정수형(int)
    //1-2 : 실수형 (float)
    //주의 : 체이닝을 해야 하므로 해당 메소드들은 반환형이 있는 Func 대신 Action을 사용하여 콘솔에 출력하세요
    internal class _0605_1_real
    {
        static Action<int, int> actionInt;
        static Action<float, float> actionFloat;

        static void Plus(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void Plus(float a, float b)
        {
            Console.WriteLine(a + b);

        }

        static void Sub(int a, int b)
        {
            Console.WriteLine(a - b);

        }

        static void Sub(float a, float b)
        {
            Console.WriteLine(a - b);

        }

        static void Multi(int a, int b)
        {
            Console.WriteLine(a * b);

        }

        static void Multi(float a, float b)
        {
            Console.WriteLine(a * b);

        }

        static void Divid(int a, int b)
        {
            Console.WriteLine(a / b);

        }

        static void Divid(float a, float b)
        {
            Console.WriteLine(a / b);

        }
        static void Main(string[] args)
        {
            Console.WriteLine("1.정수계산기 2.실수계산기");
            int choice1 = Convert.ToInt32(Console.ReadLine());
            if (choice1 == 1)
            {
                Console.WriteLine("첫번째 정수를 입력하세요");
                int firstNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("두번째 정수를 입력하세요");
                int secondNum = Convert.ToInt32(Console.ReadLine());
                actionInt += Plus;
                actionInt += Sub;
                actionInt += Multi;
                actionInt += Divid;
                actionInt?.Invoke(firstNum, secondNum);
            }
            else
            {
                Console.WriteLine("첫번째 실수를 입력하세요");
                float firstNum = float.Parse(Console.ReadLine());
                Console.WriteLine("두번째 실수를 입력하세요");
                float secondNum = float.Parse(Console.ReadLine());
                actionFloat += Plus;
                actionFloat += Sub;
                actionFloat += Multi;
                actionFloat += Divid;
                actionFloat?.Invoke(firstNum, secondNum);
            }

        }
    }
}
