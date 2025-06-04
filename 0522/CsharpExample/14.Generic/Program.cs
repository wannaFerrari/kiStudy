using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;


namespace Generic
{
    //제네릭 클래스
    //클래스 내부 필드, 속성(프로퍼티 등)의 자료형을 가변적으로 지정할 수 있음
    class BoundSafeArray<T>
    {
        //-1, 또는 크기 이상의 예외가 발생할 수 있는 인덱스 접근을 방지하도록..
        private T[] array;
        public BoundSafeArray(int size)
        {
            array = new T[size];
        }

        //인덱서
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Length)
                {
                    Console.WriteLine("인덱스가 적절하지 않습니다.");
                    return default(T); // (제네릭)T의 기본값을 반환
                }
                return array[index];
            }
            set
            {
                if (index < 0 || index >= array.Length)
                {
                    Console.WriteLine("인덱스가 적절하지 않습니다.");
                }
                else
                {
                    array[index] = value;
                }
            }

        }
    }

    //일반화의 자료형은 개발자가 제한 가능
    //일반화(제네릭) 자료형을 정의할 당시, 해당 자료형으로 사용할 수 있는 형식을 몇가지 제한할 수 있음.
    // where 키워드와 " : " 을 사용

    class StructT<T> where T : struct { } // T는 구조체만 사용할 수 있도록 함
    class ClassT<T> where T : class { } // T는 클래스만 사용할 수 있도록 함

    class EnumT<T> where T : Enum { } // T는 열거형만 사용할 수 있음.
    class NewT<T> where T : new() { } // T는 매개변수 없는 기본 생성자가 있는 자료형만 사용 가능
    class ChildT<T> where T : Parent { } // T는 Parent의 파생클래스만 사용할 수 있음.
    class InterfaceT<T> where T : IJob { } // T는 IJob을 구현한 클래스만 사용할 수 있음.



    class Parent { }
    class Child : Parent { }
    interface IJob { }

    class Worker : IJob { }


    internal class Program
    {
        //제네릭 (Generic, 일반화)
        //클래스 또는 함수가 자료형을 코드에 의해 선언하지 않고, 호출시에 결정하는 방법.
        //런타임에서 코드가 생성되는 것은 아니고, 컴파일시에 자료형이 호환 가능한 형태로 빌드된다.

        //제네릭 : 자료형을 변수처럼 개발자가 이름을 짓는다.
        //제네릭 함수 정의 하는 형식
        //[접근지정자] [static,virtual,abstract여부] [반환자료형] 메소드명 <가변자료형(변수처럼 이름지음)> (파라미터) { 함수 내용 }
        static void Swap<SomeType>(ref SomeType left, ref SomeType right)
        {
            SomeType temp = left;
            left = right;
            right = temp;
        }

        //제네릭 제약사항의 용도
        //제네릭으로 지정가능한 가변자료형에 제약사항을 설정할 경우, 해당 제약사행 내에서 사용할 수 있는 기능은
        //  제네릭 함수에서 사용 가능하다. 

        //예시: T라는 데이터 2개를 비교해서 더 큰 값을 반환하는 함수를 만드려고 할 때
        static T Bigger<T>(T left, T right) where T : IComparable<T>
        {
            //제약사항을 명시하지 않으면, T의 값이 뭐가 지정될지 알 수 없으니 비교가 불가능하다
            //IComparable 인터페이스를 구현한 자료형으로 제약사항을 명시할 경우,
            //IComparable 인터페이스에서 정의를 강제하는 CompareTo메소드를 호출할 수 있음.
            T bigger;

            if (left.CompareTo(right) > 0) // left가 클때
            {
                bigger = left;
            }
            else // 둘이 같거나 right가 큼
            {
                bigger = right;
            }

            /*
            if(left > right)
            {

            }*/

            return bigger;
        }

        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;

            Swap<int>(ref a, ref b);   //함수의 자료형을 호출 당시에 결정
            Console.WriteLine($"a : {a}, b : {b}");

            float fa = 2.3f;
            float fb = 4.2f;

            Swap<float>(ref fa, ref fb);
            Console.WriteLine($"fa : {fa}, fb : {fb}");

            BoundSafeArray<string> arr = new BoundSafeArray<string>(5);
            arr[-1] = "안녕하세요";
            arr[5] = "반갑습니다";
            arr[4] = "어서오세요";
            Console.WriteLine(arr[4]);

            //내부 자료형을 int로 사용하는 BoundSafeArray와 float으로 사용하는 BoundSafeArray 직접 선언/생성/참조
            BoundSafeArray<int> intArr = new BoundSafeArray<int>(5);
            BoundSafeArray<float> floatArr = new BoundSafeArray<float>(5);



            //StructT<ArrayList> st = new StructT<ArrayList>();
            StructT<int> st = new StructT<int>();   //struct를 제약조건으로 상요한 일반화 형식에는 값 형태의 자료형만 사용 가능
            ClassT<int[]> ct = new ClassT<int[]>();  //class를 제약조건으로 사용한 일반화 형식에는 참조 형태의 자료형만 사용 가능
            // 그냥 int는 안되지만 int[]배열은 참조형태이기 때문에 사용 가능한것.

            NewT<int> nt = new NewT<int>();
            //NewT<BoundSafeArray<string>> nt2 = NewT<BoundSafeArray<string>>(); // BoundSafeArray는 기본생성자 호출을 막아놨으므로 제약사항에 의해 생성불가
            ChildT<Child> cht = new ChildT<Child>();
            ChildT<Parent> pat = new ChildT<Parent>(); //Parent는 자기 자신이므로 사용 가능
            //Child<Array> cht = new Child<Array>(); // Parent를 상속한 클래스만 가능

            InterfaceT<Worker> it = new InterfaceT<Worker>(); //IJob을 구현한 클래스만 사용 가능

            int bigger = Bigger<int>(20, 30);
            Console.WriteLine(bigger);
        }
    }
}

