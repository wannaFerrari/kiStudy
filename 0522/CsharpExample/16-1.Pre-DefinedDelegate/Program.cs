using System;

namespace Pre_DefinedDelegate
{
    internal class Program
    {
        //Dotnet에서는 개발자들이 주로 사용하는 형태의 델리게이트를
        //굳이 정의하지 않고, 자료형을 가변적으로 사용할 수 있는 데릭게이트를 제공함.
        //Generic문법을 사용함.

        //1.Action : 반환이 없는 델리게이트. <>안에 자료형 개수로 파라미터 개수 및 자료형을 지정.
        //2.Func : 반환이 있는 델리게이트. <반환형, 파라미터 ....>
        //3.Predicate : 1개의 매개변수와 bool형의 리턴이 있는 델리게이트.
        //특수한 경우에 쓰임. 예를들면, List같은 클래스에서 특정 조건에 맞는 요소만 따로 엉더올 경우, 조건 검사를 위한 메소드를 지정할때.


        static void SomeAction()
        {
            Console.WriteLine("SomeAction이 호출되었습니다.");
        }

        static void SomeActionWithMessage(string message)
        {
            Console.WriteLine($"파라미터 {message}와 함께 SomeAction이 호출되었습니다.");
        }

        static void SomeActionWithManyInts(int x, int y, int z)
        {
            Console.WriteLine($"{x}, {y}, {z}");
        }

        static int SomeFuncWithIntReturn()
        {
            return 54321;
        }

        static float Plus(float x, float y) => x + y;

        static bool IsLength5(string str)
        {
            if(str.Length > 5)//문자열 매개변수의 길이가 5를 넘으면  false, 
            {
                return false;
            }
            return true;//아니면 true를 반환
        }

        static void Main(string[] args)
        {
            Action action = SomeAction;
            action();

            //델리게이트 Action<>의 제네릭은 파라미터 자료형 
            Action<string> actionWithMessage = SomeActionWithMessage;
            actionWithMessage("안녕하세요");


            Action<int, int, int> actionWithManyInts = SomeActionWithManyInts;
            actionWithManyInts(3, 2, 1);

            Func<int> func = SomeFuncWithIntReturn;
            Console.WriteLine(func());

            Func<float, float, float> func2 = Plus;
            Console.WriteLine(func2(1.1f,1.2f));

            Predicate<string> predicate = IsLength5;
            Console.WriteLine(predicate("안녕하세요."));
        }
    }
}
