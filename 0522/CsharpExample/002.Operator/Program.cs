using System;

namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool boolValue = false;
            int intValue = 0;
            float floatValue = 0.0f;

            //연산자 : 값을 연산하기 위해 사용하는 수식연산자.
            // 실제 수학에서 사용하는 연산과 유사하게 연산됨

            //1. 대입 연산자.
            // 대입 연산자는 오른쪽의 값을 왼쪽에 대입 하는데, 
            // 왼쪽에는 값이 저장되어야 하므로 반드시 변수가 와야 한다.

            intValue = 2;

            //2. 산술 연산자.
            // 수학의 사칙연산(+1, 정수 나머지 연산자)로 이뤄져 있다. 


            //이항 연산자
            intValue = 1 + 2; // + 더하기
            intValue = 1 - 2; // - 빼기
            intValue = 2 * 3; // * 곱하기
            intValue = 5 / 2; // / 나누기(정수 연산에서는 나눈 값의 나머지를 버린 몫)
            intValue = 5 % 2; // % 나머지(정수형 데이터끼리만 연산이 가능)
            Console.WriteLine($"intValue = {intValue}");

            floatValue = 5f / 2f; // 실수의 나누기 연산은 정수의 나누기 연산과 다름
            Console.WriteLine($"floatValue = {floatValue}");

            //단항 연산자
            intValue = +intValue; // + 단항 연산 : 값을 그대로 반환
            Console.WriteLine(intValue);
            intValue = -intValue; // - 단항 연산 : 값의 음/양을 변환하여 반환
            Console.WriteLine(intValue);
            ++intValue; // ++ 전위 증가 연산 : 값을 1만큼 증가
            Console.WriteLine(intValue);
            --intValue; // -- 전위 감소 연산 : 값을 1만큼 감소
            Console.WriteLine(intValue);
            intValue++; // ++ 후의 증가 연산 : 값을 1만큼 증가 
            Console.WriteLine(intValue);
            intValue--; // -- 후위 감소 연산 : 값을 1만큼 감소
            Console.WriteLine(intValue);

            //후위/전위 증감 연산자의 차이
            //해당 연산이 일어난 라인에서 값이 반환되기 전에 값에 증감이 일어나는지,
            // 아니면 반환된 후에 값에 증감이 일어나는지가 다름.
            Console.WriteLine($"전위 증감 연산");
            intValue = 0;
            Console.WriteLine(intValue);
            Console.WriteLine(++intValue);
            Console.WriteLine(intValue);

            Console.WriteLine($"후위 증감 연산");
            intValue = 0;
            Console.WriteLine(intValue);
            Console.WriteLine(intValue++);
            Console.WriteLine(intValue);

            //복합 대입 연산자.
            intValue = 0;
            Console.WriteLine(intValue);
            intValue += 2; //intValue = intValue + 2;
            Console.WriteLine(intValue);
            intValue -= 4; //intValue = intValue - 4;
            Console.WriteLine(intValue);
            intValue *= 5; //intValue = intValue * 5;
            Console.WriteLine(intValue);
            intValue /= 2; //intValue = intValue / 2;
            Console.WriteLine(intValue);
            intValue %= 82;//intValue = intValue % 82; (정수 연산만 가능) 
            Console.WriteLine(intValue);


            //3. 논리 연산자 : 특정 조건이 참인지 거짓인지 구분하거나,
            // 여러 참/거짓 조건에 맞게 연산 하는 연산자.

            //비교 연산자
            boolValue = 3 > 1; // > : 왼쪽 피연산자가 더 클 경우에 true.
            Console.WriteLine(boolValue);
            boolValue = 3 < 1; // < : 왼쪽 피연산자가 더 작을 경우에 true.
            Console.WriteLine(boolValue);
            boolValue = 3 >= 1; // >= : 왼쪽 피연산자가 크거나 같을 경우에 true.
            Console.WriteLine(boolValue);
            boolValue = 3 <= 1; // <= : 왼쪽 피연산자가 작거나 같을 경우에 true.
            boolValue = 3 == 1; // == : 왼쪽과 오른쪽 피연산자가 같을 경우에 true.
            boolValue = 3 != 1; // != : 왼쪽과 오른쪽 피연산자가 같지 않을 경우 true.

            //논리 연산자
            boolValue = !boolValue;    // ! (not) : 피연산자의 논리 부정을 반환
            boolValue = true && false; // &&(and) : 두 피연산자가 모두 true일때 true.
            boolValue = true || false; // ||(or)  : 두 피연산자중 하나라도 true일때 true.
            boolValue = true ^ false;  // ^(exclusive or) : 두 피연산자 값이 다르면 true;

            //4. 비트 연산자 : 1bit = 0,1
            intValue = 0b0000_0100; // intValue = 4; 맨 앞에 0b는 2진수라는 뜻
            Console.WriteLine($"0b0000_0100을 10진수로 표현하면 {intValue}임\n" +
                $"2진수로 표현하면 {Convert.ToString(intValue,2)}임");

            intValue = ~0b0000_0100; // ~(비트 보수) : 비트 단위로 0은 1로, 1은0으로 보수연산
            Console.WriteLine(Convert.ToString(intValue,2));

            intValue = 0b111_1111_1111_1111_1111_1111_1111_1011 &
                0b111_1111_0000_0000_1111_0000_1111_1011;
            // & : 비트 단위로 and 연산. 둘다 1일경우 1, 아닐경우 0
            Console.WriteLine(Convert.ToString(intValue, 2));

            intValue = 0b111_1111_1111_1111_1111_1011_1111_1011 |
               0b111_1111_0000_0000_1111_0000_1111_1011;
            // | : 비트 단위로 or 연산. 하나라도1이면1, 아니면 0
            Console.WriteLine(Convert.ToString(intValue, 2));

            intValue = 0b111_1111_1111_1111_1111_1011_1111_1011 ^
               0b000_1111_0000_0000_1111_0000_1111_1011;
            // ^ : 비트 단위로 xor 연산. 같으면 1, 아니면 0;
            Console.WriteLine(Convert.ToString(intValue, 2));

            intValue = 0b001 << 2; 
            // << : 비트단위로, 왼쪽 값을 전체 왼쪽으로 오른쪽 값만큼 밀고,
            //              빈곳에 0을 채움.
            Console.WriteLine(Convert.ToString(intValue, 2));
            Console.WriteLine(intValue);

            intValue = 0b100 >> 2;
            // >> : 비트단위로, 왼쪽 값을 전체 오른쪽으로 오른쪽값만큼 밀고,
            //              빈곳에 0을 채움.
            Console.WriteLine(Convert.ToString(intValue, 2));
            Console.WriteLine(intValue);
        }
    }
}
