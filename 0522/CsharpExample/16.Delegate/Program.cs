using System;


namespace Delegate
{
    internal class Program
    {
        //델리게이트(Delegate, 대리자)
        //함수포인터와 비슷한 역할.
        //형식에 맞는 메소드를 순서에 맞게 호출할 수 있도록
        //인스턴스화 시킬 수 있는 일종의 "변수형 메소드"이다.
        //델리게이트를 정의하고 선언할때에는 반드시 반환자료형, 매개변수의 개수와 자료형이 동일해야만 한다.
        //델리게이트도 클래스 또는 구조체의 멤버로 정의해야 한다.
        //[접근지정자] delegate [반환자료형] 델리게이트명(매개변수);

        public delegate float Operation(float x, float y); // 반환형이 float이고, float형의 매개변수 2개를 받는
                                                           // 메소드를 할당할 수 있는 델리게이트

        //반환형이 없고, string 형의 매개변수 1개를 받는 메소드를 할당할 수 있는 델리게이트
        public delegate void Messaging(string msg);

        //델리게이트에 할당할 메소드

        public static float Plus(float left, float right) => left + right; //람다식 표현, 메소드 내용이 한줄(세미콜론1개)인 메소드는
                                                                           //{return}을 생략하고 => 로 축약 가능

        public static float Minus(float left, float right) => left - right;
        public static float Multi(float left, float right) => left * right;
        public static float Divid(float left, float right) => left / right;

        public static void SendMessage(string message) => Console.WriteLine(message);
        

        static void Main(string[] args)
        {

            Operation delegate1 = new Operation(Plus); //델리게이트 인스턴스 생성
            Messaging delegate2 = SendMessage;

            float plus = delegate1(1.1f, 1.2f);

            Console.WriteLine(plus);

            delegate1 = Minus;

            float minus = delegate1(1.1f, 1.2f);
            Console.WriteLine(minus);

            delegate2("Hello world");

            delegate1 = Multi;

            float multi = delegate1(1.1f, 1.2f);
            Console.WriteLine(multi);

            delegate1 = Divid;

            float divid = delegate1(1.1f, 1.2f);
            Console.WriteLine(divid);
        }
    }
}
