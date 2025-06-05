using System;

namespace DelegateChain
{
    internal class Program
    {
        //델리게이트 체인
        //사실 델리게이트는 인스턴스 안에 하나의 메소드만 참조하는것이 아님.
        //여러개의 메소드를 연속적으로 참조할 수 있다.
        // +=, -= 연산자를 통해 델리게이트에 메소드를 더하거나 뺼 수 있다.
        static void Action1() => Console.WriteLine("Action1");
        static void Action2() => Console.WriteLine("Action2");
        static void Action3() => Console.WriteLine("Action3");

        static float Func1(float x) => x + 1.3f;
        static float Func2(float x) => x + 22.5f;
        static float Func3(float x) => x + 173.2f;

        static void Main(string[] args)
        {
            Action action = Action1; // new Action(action1); 
            action += Action3;
            action += Action2;
            action();

            action -= Action3;
            action();
            action += Action3;
            action();

            action -= Action1;
            action -= Action1; //델리게이트 인스턴스에 참조가 없는 메소드를 제거하려 할 경우 무시됨.
            action();
            //델리게이트 체이닝 사용시 주의사항 1: Null발생 가능

            Console.WriteLine("======Action초기화======");
            action = Action3; //델리게이트의 (단순)대입연산자는 무조건 새로운 인스턴스를 생성함. 즉, 이전에 있던 정보 날아감
            action();

            action -= Action3; //델리게이트 인스턴스에 모든 메소드 참조를 제거하여 null이 될 경우,
                               //NullReferenceException 발생
            //action();

            //방법1. 델리게이트 null 체크
            if(action != null)
            {
                action();
            }

            //방법2. null 체크 연산자 ?. 사용
            //[객체]?.메소드();       >> 객체가 null일 경우 호출 무시.

            action?.Invoke(); // ?.을 붙일수 있도록 Invoke()로 호출 ( 단, Invoke()만 했으면 NullReferenceException 뜸)


            //델리게이트 체이닝 사용시 주의사항 2: 함수의 리턴은 항상 맨 마지막에 체이닝된 함수의 리턴만 적용.
            //따라서 델리게이트 체이닝은 Func에는 잘 안쓰고, Action에 주로 쓴다.
            Func<float, float> func;
            func = Func1;
            func += Func2;
            func += Func3;

            float result = func.Invoke(6.2f);  //179.4 -> 가장 마지막으로 호출된 함수의 결과만 가져오게 됨
            Console.WriteLine(result);
        }
    }
}
