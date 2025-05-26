using System;

internal class _0526_1_2
{
    static void Main(string[] args)
    { //실수
        float[] numbers = new float[2];
        for (int i = 0; i < 2; i++)
        {
            numbers[i] = GetInput(i);
        }

        Console.WriteLine("1.덧셈 2.뺄셈 3.곱셈 4.나눗셈");
        Console.Write("어떤 연산을 하시겠습니까? ");
        int userSelected = Convert.ToInt32(Console.ReadLine());

        switch (userSelected)
        {
            case 1:
                Console.WriteLine($"{Add(numbers[0], numbers[1])}");
                break;
            case 2:
                Console.WriteLine($"{Sub(numbers[0], numbers[1])}");
                break;
            case 3:
                Console.WriteLine($"{Mul(numbers[0], numbers[1])}");
                break;
            case 4:
                Console.WriteLine($"{Div(numbers[0], numbers[1])}");
                break;
            default:
                Console.WriteLine("잘못된 방법");
                break;
        }
    }
    static float Add(float a, float b)
    {
        return a + b;
    }

    static float Sub(float a, float b)
    {
        return a - b;
    }

    static float Mul(float a, float b)
    {
        return a * b;
    }

    static float Div(float a, float b)
    {
        if (b == 0)
        {
            Console.WriteLine("0으로 나눌 수 없습니다. 결과값이 0으로 출력됩니다.");
            return 0;
        }
        else
        {
            return a / b;
        }
    }
    static float GetInput(int i)
    {

        while (true)
        {
            Console.WriteLine($"{i + 1}번째 실수를 입력하세요 : ");
            string input = Console.ReadLine();
            if (float.TryParse(input, out float result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("실수를 입력하세요");
            }
        }

    }
}

