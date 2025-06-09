using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace AdditionalSyntax
{
    //C#으로 개발하면서 보게 될 추가적인(비주류...) 문법들
    //1. 파라미터의 다양한 형태

    class Parameter
    {
        //파라미터 기본형태
        void Profile(int id, string name = "이름 없음", float height = 170.0f)
        {
            Console.WriteLine($"일련번호 : {id}\n이름 : {name}\n키 : {height}");
        }

        //기본값 지정 파라미터(선택적 인수, Optional Paramenter)
        //함수 호출시 기본값이 지정되어있는 메소드를 호출할 때는, 해당 파라미터에 값을 대입하지 않더라도
        //기본값이 대입됨.
        //이 기능이 없는 프로그래밍 언어의 경우 오버로드를 통해 구현 가능.
        //정의 조건 : 기본값이 지정된 파라미터를 포함한 메소드는
        //해당 파라미터를 무조건 뒤에서부터 배치해야함.

        void ErrorMethod(int id = 1, string name = "", float height = 0f)
        {
            //앞의 파라미터가 기본값이 있으면, 뒤 파라미터도 무조건 기본값이 있어야함

        }

        /*
        void Profile(int id, string name)
        {
            float height = 170.0f;
            Profile(id,name,height);
        }

        void Profile(int id)
        {
            string name = "이름 없음";
            Profile(id,name);
        }
        */

        public void Print()
        {
            Profile(1, "홍길동", 170.1f);
            //파라미터는 메소드 호출할 시 전달 순서가 중요한데,
            //사실 파라미터 명을 알고있으면 순서가 상관없을지도 모름..
            //파라미터 순서 상관 없이 특정 파라미터에 데이터를 지정할 수 있음. [파라미터멍] : [값]
            Profile(name: "아무개", height: 144.1f, id: 2);
            Profile(3, "김철수");
            Profile(4);
            Profile(5, height: 130f);
        }

        //params 키워드 : 파라미터 배열 (배열 파라미터)
        //동일한 자료형의 파라미터 크기가 동적일 경우, params 키워드를 통해 배열 객체 생성을 생략 가능

        int Sum(params int[] values) // 예를 들어, int의 배열을 파라미터로 받아서 모두 더하는 메소드의 경우
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;
        }
        //params 키워드의 제약 사항 : 메소드는 하나의 params 파라미터만 포함 가능.
        //void ErrorMethod(params int[] ints, params string[] strings) //이렇게 불가능

        //params 키워드와 기본값 지정 파라미터 함께 사용 가능하지만,
        //해당 메소드를 사용하는 개발자 입장에서 불편하므로 자주 사용되지는 않음
        void SomeMethod(int count, int capacity = 10, params int[] ints) // 원래 기본값이 있는 매개변수 뒤의 변수들은 모두 기본값이 있어야 하지만,
                                                                         //params 키워드가 붙은거는 기본값 있는것처럼 취급
        {
            Console.WriteLine($"count : {count}, capacity : {capacity}");
            try
            {
                Console.WriteLine($"ints.Length : {ints?.Length}, ints[0] : {ints?[0]}");

            }
            catch
            {
                Console.WriteLine("ints 배열이 비어있음");
            }
        }



        public void PrintSum()
        {
            int[] values = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(Sum(values));
            //params 키워드가 포함된 메소드는 배열 객체 대신 쉼표로 구분된 여러 값으로 배열을 대체 가능
            int sum1 = Sum(1, 2, 3, 4, 5); //함수 파라미터에 params 키워드를 붙였으므로 그냥 , 로 구분하여 호출하면 알아서 배열로 만들어줌
            Console.WriteLine(sum1);
            SomeMethod(4, 23, 32, 23, 23);
        }
        //out키워드, ref 키워드 : 매개변수를 참조형으로 사용하는 두가지 키워드
        //in 키워드 : 메소드 내에서 해당 파라미터에 값을 재할당 할 수 없음.

        public void PrintParam(in int a)
        {
            //메소드 내에서는 const, readonly 키워드와 같은 역할
            //a = 10; // 이렇게 a에다가 값을 새로 할당할 수 없음
            Console.WriteLine(a);
        }





    }
    //정적클래스와 확장메소드
    //정적클래스 : 객체 생성이 불가능하고, static 멤버만 지닐 수 있는 클래스.
    //용도가 "클래스"에 부합한다기보다는, 멤버메소드와 멤버 필드를 지닌 네임스페이스라고 보는게 더 이해가 쉽다.
    //확장메소드 : 일반 정적 메소드와 전부 같지만, 첫번쨰 파라미터를 접근 요소처럼 표현할 수 있다.
    static class Extensions
    {
        public static int a;
        //Person클래스의 인스턴스 메소드인 ToName()을 정적 메소드인 확장 메소드로 변환하면
        public static string ToName(Person person)
        {
            return $"이름 : {person.name}";
        }

        public static string ToJob(this Person person)
        {
            return $"직업 : {person.job}";
        }
        //확장 메소드의 조건 : 정적클래스의 정적 메소드가 맨 첫 파라미터에 this 키워드를 가지고 있으면,
        //해당 메소드를 호출 할 때, [클래스].[메소드][(파라미터)] 의 방식 대신
        //[파라미터].메소드(); 의 방식으로 호출 가능

    }
    class Person
    {
        public string name;
        public string job;
        public override string ToString()
        {
            return $"이름 : {name}, 직업 : {job}";
        }

        public string ToName()
        {
            return $"이름 : {name}";
        }

        public string ToJob()
        {
            return $"직업 : {job}";
        }
    }

    class YieldTest
    {
        //yield 키워드 : IEnumerable, IEnumerator 와 연관이 깊은 키워드.
        //큰 데이터 전체를 반환 하지 않고 하나씩 순차적으로 반환해야하는경우
        //IEnumerable 인터페이스 상속을 통해 데이터 열거가 가능하다.
        //하지만 특정 조건이 없는 데이터를 순차적으로 리턴해야 할 경우,
        //함수의 반환형을 IEnumerable, IEnumerator로 지정하고 함수 내에서 순차적으로 반환하는것이 가능.
        //이때 쓰는 키워드가 yield. 
        IEnumerable<int> GetMyNumbers()
        {
           yield return 10;
           yield return 28;
           yield return 32;
           yield return 99;
           yield return -131;
        }

        IEnumerable GetSomethings()
        {
            yield return "가";
            yield return 12;
            yield return 'A';
            yield return new Person() { name = "홍길동", job = "강도"}; 
        }

        IEnumerator<int> GetNumberEnumerator()
        {
            yield return 12;
            yield return 122;
            yield return 1232;
            yield return 12422;
            yield return 125222;
        }

        public void PrintNumbers()
        {
            IEnumerable<int> myNumbers;
            myNumbers = GetMyNumbers();
            foreach(int number in myNumbers)
            {
                Console.WriteLine(number);
            }
            
            Console.WriteLine();

            foreach(object item in GetSomethings())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            /*
            foreach (object item in GetNumberEnumerator()) // 이렇게 쓰는게 불가함
            {
                Console.WriteLine(item);
            }
            */

            IEnumerator enumerator = GetNumberEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine();
            //enumerator.Reset(); //yield return을 통해 자동생성된 IEnumerator 객체는 Reset()메소드를 지원하지 않음.


            foreach (int number in RepeatPlus(15,-4, 10))
            {
                Console.WriteLine(number);
            }


        }

        IEnumerable RepeatPlus(int start, int interval, int count = 5)
        {
            //start부터 시작하여 interval만큼 숫자를 더해주고, count만큼 반복하는 Enumerable
            for (int i = 0; i < count; i++)
            {
                yield return start;
                start += interval;
                
                //만약 interval이 음수고, for 반복 도중 start가 0보다 작아지면 멈추고 싶다.
                //조건이 만족하면 yield break를 통해 열거반환 중단
                if(start < 0)
                {
                    yield break;
                }
            }
        }

    }

    class MyEnumerable : IEnumerable<int>
    {
        //IEnumerable을 구현했다는것은 어떤 데이터를 열거하여 접근할 수 있는 형태로
        //가공하는것이 가능하다는 뜻. 그리고 그 데이터를 IEnumerator 형태로 반환할 수 있음.

        private int number;
        public MyEnumerable(int number)
        {
            this.number = number;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator(number);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class MyEnumerator : IEnumerator<int>
    {
        //IEnumerable를 구현한 클래스를 통해, 열거 가능한 현태로 만들어진 객체

        private int[] array = new int[10];
        private int currentIndex = -1;

        public MyEnumerator(int number)
        {
            for(int i = 0; i < 10; i++)
            {
                array[i] = i * number;
            }
        }
        public int Current => array[currentIndex];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {

            currentIndex++;

            return currentIndex < 10;
        }
        public void Dispose() { }

        public void Reset()
        {
            currentIndex = -1;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Parameter parameter = new Parameter();
            //parameter.Print();
            parameter.PrintSum();

            Extensions.a = 10;

            Person person = new Person() { name = "홍길동", job = "의적" };

            Console.WriteLine(Extensions.ToName(person));

            Console.WriteLine(person.ToJob());              // 확장메소드는 이렇게 호출해도 되고
                                                            // 아래처럼 기본 방식으로 호출해도된다
            Console.WriteLine(Extensions.ToJob(person));
            //Console.WriteLine(person.ToName());
            //Console.WriteLine(person.ToJob());
            //Console.WriteLine(person.ToString());
            ///////////////////////////////////////////////////////////////////////////////////



            //foreach문을 통해 순회할 수 있는 객체는 IEnumerable 인터페이스를 구현했다면 무엇이든 가능.
            foreach (int item in new MyEnumerable(1))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();


            YieldTest yieldTest = new YieldTest();
            yieldTest.PrintNumbers();

            Console.WriteLine();

            MyPartialClass myPartialClass = new MyPartialClass();
            myPartialClass.a = 10;
            myPartialClass.b = 20;
        }
    }


    //partial : 분할 클래스. 한 클래스의 내용을 여러 영역에 분할하여 정의가 가능.
    //결국 같은 이름의 클래스에 대한 정의는 하나의 클래스처럼 동작.
    //큰 객체의 기능을 분할작성 하여 가독성을 높이는 기법.
    partial class MyPartialClass 
    {
        public int a;
        //public partial void Print();  아마 유니티에서는 사용 가능할텐데, 지금쓰는 옛날식 닷넷프레임워크에서는 안되는듯?
    }
    partial class MyPartialClass
    {
        public int b;
    }

    //정규표현식(Regex)
    //어트리뷰트(Attribute) -> Java의 annotation이랑 비슷한 기능. 특정 요소에 대한 메타데이터 지정.
    [Serializable]
    class AttributeClass{}

    //nullable literal type
    class Nullable
    {
        int? a;
        void A()
        {
            a = 10;
            a = null;
            if (a.HasValue)
            {
                //null 체크가 가능
                Console.WriteLine(a);
            }
        }
    }


}
