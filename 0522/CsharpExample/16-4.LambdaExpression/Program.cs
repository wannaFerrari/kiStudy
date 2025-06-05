using System;

namespace LambdaExpression
{
    internal class Program
    {
        //무명메소드 : 이름이 없는 메소드.
        //함수 안에서 정의할 수도 있고, 델리게이트에 대입하기위해 정의할 수도 있다.
        //델리게이트의 문제점 : 해당 델리게이트에 할당되는 함수의 내용을 바로 볼 수가 없음.

        //무명 메소드 정의 형식
        //delegate (파라미터) {(만약 리턴이 있으면) return x; (리턴이 없으면(void)) return; }  -> 리턴 자료형은 알아서 결정됨 
        //델리게이트에 무명메소드를 정의하여 바로 할당
        static Action someAction = delegate () { Console.WriteLine("뭔가 합니다."); };

        //무명 메소드의 람다식 표현
        //(파라미터) => {함수 내용} : 파라미터의 자료형이나, 함수 내용이 한줄일 경우 중괄호 생략 가능
        //무명 메소드를 추론자료형인 var로 선언한 델리게이트에 담으려 할 경우에는 자료형 생략 불가
        //static Func<int, int, string> someFunc = delegate(int x, int y) { return (x + y).ToString(); };    // <>속 맨 마지막은 리턴값 형식
        static Func<int, int, string> someFunc = (x,y) => (x + y).ToString();

        static Func<string, string> someFunc2 = str => {
            string result = "과일";
            result += str[0] + str[2] + str[1];
            return result;
        };
        static void Main(string[] args)
        {
            // someAction = SomeAction;
            someAction?.Invoke();

            Console.WriteLine(someFunc(3, 4));
            Console.WriteLine(someFunc2("코끼리"));

        }
    }
}
