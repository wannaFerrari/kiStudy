using System;

namespace Throw
{
    //throw 키워드 : 개발자가 의도적으로 예외를 발생
    //throw new 예외클래스생성자();
    internal class Program
    {
        //Program클래스 내의 inner Class
        class DumbException : Exception
        {
            public DumbException() : base("바보 이슈 발생")
            {
                
            }
        }
        static void Method1()
        {
            Console.WriteLine("메1전");
            Method2();
            Console.WriteLine("메1후");
        }

        static void Method2()
        {
            Console.WriteLine("메2전");
            Method3();
            Console.WriteLine("메2후");
        }

        static void Method3()
        {
            Console.WriteLine("메3전");
            //스택 중간에서 예외 발생

            throw new DumbException();
            Console.WriteLine("메3후");

        }


        static void Main(string[] args)
        {
            try
            {
                Method1();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace); //스택트레이스는 릴리즈 단계에선 위험(해킹 등등..)하므로 디버깅할때만 주로 사용
            }
        }
    }
}
