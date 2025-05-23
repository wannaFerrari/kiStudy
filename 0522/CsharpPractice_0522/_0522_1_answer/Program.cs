

using System;

internal class Program
{
    static void Main(string[] args)
    {
        int number1, number2;

        Console.Write("첫번째 수를 입력하세요 : ");
        string input1 = Console.ReadLine(); //입력을 문자열 형태로 저장

        Console.Write("두번째 수를 입력하세요 : ");
        string input2 = Console.ReadLine();

        number1 = Convert.ToInt32(input1);//input1의 문자열을 정수로 읽어 대입
        number2 = Convert.ToInt32(input2);

        Console.WriteLine("1.덧셈 2.뺄셈 3.곱셈 4.나눗셈 5.나머지");
        Console.Write("어떤 연산을 하시겠습니까? ");
        string input3 = Console.ReadLine();
        int result = 0;//결과를 저장할 변수
        if (input3 =="1")
        {
            //덧셈 출력
            result = number1 + number2;
        }
        else if (input3 =="2") 
        {
             //뺄셈 출력
             result = number1 - number2;
        }
        else if (input3 =="3")
        {
            //곱셈 출력
            result = number1 * number2;
        }
        else if (input3 =="4")
        {
            //나눗셈
            result = number1 / number2;
        }
        else
        {
            //나머지
            result = number1 % number2;
        }

        Console.WriteLine($"결과 : {result}");

        //switch (input3)
        //{
        //    case "3":
        //        //곱셈 출력
        //        break;
        //}
        //int number3 = Convert.ToInt32(input3);

    }
}

