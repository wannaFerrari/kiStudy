using System;

namespace Conditional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //조건문 : 조건에 따라 수행할 연산이 달라지는 문장

            //1. if문 : 조건식의 true, false 여부에 따라 실행 여부가 결정
            // if(조건식(bool형태)) {실행 내용}

            bool condition = true;
            if (condition/*true*/)
            {
                Console.WriteLine("이 문장은 출력됩니다.");

            }

            condition = !condition;
            if (condition/*false*/)
            {
                Console.WriteLine("이 문장은 출력되지 않습니다.");
            }

            int int1 = 3, int2 = 3;

            if(int1 < int2)
            {
                Console.WriteLine($"{int1}은 {int2}보다 작다.");
            }
            else if (int1 == int2)
            {
                //else if : 앞에 무조건 if 구문이 와야하며,
                // 앞의 if 조건이 거짓일 때만 조건을 검사함.
                Console.WriteLine($"{int1}은 {int2}과 같습니다.");

            }
            else // else : 앞에 무조건 if구문이 와야하며, 
            //   앞의 if조건또는 else if 구문이 모두 거짓일 때만 실행됨
            {
                Console.WriteLine($"{int1}은 {int2}보다 작지 않다.");
            }
            Console.Write("가위 바위 보 중 하나만 입력하세요 : ");
            string input = Console.ReadLine();
            if (input == "가위")
            {
                Console.WriteLine("가위를 내셨네요");
            }
            else if (input == "바위")
            {
                Console.WriteLine("바위를 내셨네요");
            }
            else if (input == "보")
            {
                Console.WriteLine("보를 내셨네요");
            }
            else
            {
                Console.WriteLine("잘못 내셨네요");
            }

            int intValue = 4;
            //switch-case문 : switch 조건 안의 값이 case에 해당할 경우,
            //해당 지점을 수행.
            //switch문 안의 조건에 들어갈 수 있는 값은 문자, 문자열, 정수, 열거형으로 제한
            //값을 특정할 수 있어야 하기 때문
            switch(intValue)
            {
                case 0://switch 구문 내의 case 값은 switch조건 내의 값과 자료형이
                    //동일하거나 암시적 형변환이 가능해야 하며, :(콜론)뒤의 
                    //구문을 실행하고, break;문에서 끊음
                    Console.WriteLine("intValue 값은 0");
                    break;
                case 1:
                    Console.WriteLine("intValue 값은 1");
                    break;

                default://switch 구문 내의 default : switch내의 모든 case에
                    //해당하지 않을때 실행
                    Console.WriteLine("intValue 값은 0이나 1이 아님");
                    break;
            }

            Console.Write("당신의 레벨을 입력하세요(1~10) : ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                //입력된 문자열이 숫자로 변환 가능할 경우
                switch (result)
                {
                    case 1://case문을 여러 경우를 한번에 처리하려 할 경우 중첩이 가능.
                    case 2://단, case문과 다음case문에서 아무것도 하지 않아야함.
                    case 3:
                        Console.WriteLine("하급 난이도로 진입");
                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        Console.WriteLine("중급 난이도로 진입");
                        break;
                    case 8:
                    case 9:
                    case 10:
                        Console.WriteLine("상급 난이도로 진입");
                        break;
                    default:
                        Console.WriteLine("잘못된 레벨");
                        break;


                }
            }
            else
            {
                Console.WriteLine("입력값이 숫자가 아닙니다..");
            }


        }
    }
}
