

using System;

internal class _0522_2
{
    static void Main(string[] args)
    {
        string firstInput;
        int parsedFirstInput;
        string secondInput;
        int parsedSecondInput;

        int result1;
        int result2;
        int result3;
        int result4;


        Console.WriteLine("첫번째 수를 입력하세요.");
        firstInput = Console.ReadLine();
        Console.WriteLine("두번째 수를 입력하세요.");
        secondInput = Console.ReadLine();

        if (int.TryParse(firstInput, out parsedFirstInput))
        {

        }
        if (int.TryParse(secondInput, out parsedSecondInput))
        {

        }

        Console.WriteLine($"두 수의 덧셈은 {parsedFirstInput + parsedSecondInput}입니다.");
        Console.WriteLine($"두 수의 뺄셈은 {parsedFirstInput - parsedSecondInput}입니다.");
        Console.WriteLine($"두 수의 곱셈은 {parsedFirstInput * parsedSecondInput}입니다.");
        Console.WriteLine($"두 수의 나눗셈은 {parsedFirstInput / parsedSecondInput}입니다.");




    }
}

