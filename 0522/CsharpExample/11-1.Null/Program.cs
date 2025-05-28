using System;

namespace Null
{
    //자료형은 크게 값 타입과 참조 타입이 있다.
    //값 타입 : [변수에 실제 값]이 저장됨.
    //값 타입 예시 : int, struct, enum 등등.
    //기본값이 정해져 있음. int:0, float:0.0, 

    //참조 타입 : [변수에 주소]가 저장되며 실제 값은 heap에 동적할당된 메모리에 저장
    //참조 타입 : 직접 만든 클래스를 자료형으로 쓰면 그게 참조타입.
    //  참조 타입 예시 : 배열 ....
    //기본값이 [비어있음]임
    //null 이라는 키워드가 참조 타입의 변수가 비어있음을 뜻함.


    class Myclass
    {
        public int a;
        public void ShowA()
        {
            Console.WriteLine(a);
        }
    }

    class Dog
    {
        public string name;
        public void Bark()
        {
            Console.WriteLine($"{name}이 짖습니다. \"멍멍\"");
        }
    }
    internal class Program
    {
        static Myclass myClass;
        static void Main(string[] args)
        {
            myClass = new Myclass() { a = 320};
            if(myClass == null)
            {
                myClass = new Myclass();
            }
            myClass.ShowA();

            //3항연산자 a?b:c
            //a의 조건이 true, false 여부에 따라
            //true이면 b, false 이면 c를 수행하는 
            //일종의 축약형 if문

            string a = null;

            string output = (a == null ? "비어있음" : a);

            Console.WriteLine(output);

            Dog[] dogs = new Dog[10];

            Console.WriteLine("몇마리의 개를 짖게 하시겠습니까?");
            int count = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < count; i++)
            {
                if (dogs[i] == null)
                {
                    dogs[i] = new Dog();
                }
                dogs[i].Bark();
            }
        }
    }
}
