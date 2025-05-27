using System;

//global namespace 영역

namespace UserDefinedTypes
{
    //사용자 정의 타입 : 시스템에서 정한게 아닌(기본타입을 제외한) 개발자가 직접 정의한 
    // 자료 타입.
    //1. 열거형, 2.구조체, 3.클래스.

    //열거형 : 기본적으로 int와 1:1 대응되는 의미를 가지는 정수값.
    //[접근지정자] enum 열거형명 { 요소, 요소, 요소, ....}
    //public / internal : 최상위 포커스에서는 외부 접근이 불가능한 protected와 private
    //  의 접근지정자는 지정 불가
    //대신 외부 프로세스에서도 접근 가능한 public과
    //같은 프로세스 내에서만 접근 가능한 internal만 가능 (=같은 어셈블리)
    //코드의 가독성을 높이고, 정수로 값을 구분하는 의도를 표현하기 위해 활용
    //추가적으로 int형과 1:1 대응이 되어, switch-case문과 활용할때 활용성이 좋다


    public enum DayOfWeek
    {
        // 요일
        Sunday, //기본적으로 0부터 시작하여, 요소 순서대로 1씩 증가
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday, // 맨 마지막요소에 , 가 붙어도 상관은 없음


    }


    enum HttpStatusCode
    {
        OK = 200, // 요소마다 대응될 int 값을 직접 지정해줄 수 있음
        BadRequset = 400,
        NotFound = 404,
        InternalServerError = 500,
        BadGateway = 502,
    }


    enum WeaponType
    {
        None = 0, //정수랑 1:1대응. int형은 부호가 있으므로 음수도 지정 가능
        Sword,
        Mace,
        Knucle,
        Claw = -100, //중간에 다른 수를 지정을 하면 그 뒤의 순서로 오는 요소는 자동으로
        Fist,           // 1 씩 증가
        Peak,
    }

    //비프 플래그용 열거형
    [Flags] //Flags 라는 어트리뷰트가 부착된 열거형은 비트플래그로 사용가능
            // 단, 모든 요소가 2의 거듭제곱으로 값이 지정되어야 정상 작동
    enum MonsterStatus
    {
        None = 0,
        Poison = 1,     // 1 << 0
        Ice = 2,        // 1 << 1
        Burn = 4,       // 1 << 2
        Confuse = 8,    // 1 << 3
        All = 15        // (1 << 4) - 1
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            
            DayOfWeek day = DayOfWeek.Tuesday; //DayOfWeek 이라는 자료형의 변수 선언
            DayOfWeek tomorrow = day + 1;
            Console.WriteLine($"Today : {day}, to int : {(int)day}");
            Console.WriteLine($"Tomorrow : {tomorrow}, to int : {(int)tomorrow}");

            switch (day)
            {
                case DayOfWeek.Sunday:
                    Console.WriteLine("월요일 전날");
                    break;
                case DayOfWeek.Monday:
                    Console.WriteLine("월요일");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("월요일 다음날");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("월요일 다다음날");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("금요일 전날");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("금요일");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("주말");
                    break;

            }

            Console.WriteLine((HttpStatusCode)400);
            Console.WriteLine((HttpStatusCode)401);

            MonsterStatus status = MonsterStatus.None;

            status |= MonsterStatus.Poison;
            status |= MonsterStatus.Confuse;
            bool isPoisoned = (status & MonsterStatus.Poison) == MonsterStatus.Poison;

            bool isBurned = status.HasFlag(MonsterStatus.Burn);

            Console.WriteLine(status);
            Console.WriteLine($"독에 걸렸나? : {isPoisoned}");
            Console.WriteLine($"화상 입었나? : {isBurned}");
            
        }
    }
}
