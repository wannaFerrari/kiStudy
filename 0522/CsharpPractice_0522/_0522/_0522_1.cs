
using System;

internal class _0522_1
{
     static void Main(string[] args)
     {
        string firstInput;
        int parsedFirstInput;
        string secondInput;
        int parsedSecondInput;

        string thirdInput;
        int parsedThirdInput;

        int result;

        Console.Write("첫번째 수를 입력하세요 : ");
        firstInput = Console.ReadLine();
        if (int.TryParse(firstInput, out parsedFirstInput))
        {
            
        }
        Console.Write("두번째 수를 입력하세요 : ");
        secondInput = Console.ReadLine();
        if (int.TryParse(secondInput, out parsedSecondInput))
        {

        }
        Console.WriteLine("1.덧셈 2.뺄셈 3.곱셈 4.나눗셈 5.나머지");
        Console.Write("어떤 연산을 하시겠습니까? : ");
        thirdInput = Console.ReadLine();
        if (int.TryParse(thirdInput, out parsedThirdInput))
        {

        }
        
        switch (parsedThirdInput)
        {
            case 1:
                result = parsedFirstInput + parsedSecondInput;
                Console.WriteLine(result);
                break;
            case 2:
                result = parsedFirstInput - parsedSecondInput;
                Console.WriteLine(result);
                break;
            case 3:
                result = parsedFirstInput * parsedSecondInput;
                Console.WriteLine(result);
                break;
            case 4:
                result = parsedFirstInput / parsedSecondInput;
                Console.WriteLine(result);
                break;
            case 5:
                result = parsedFirstInput % parsedSecondInput;
                Console.WriteLine(result);
                break;
            default:
                Console.WriteLine("뭔가 잘못됨");
                break;

        }



    }
}

