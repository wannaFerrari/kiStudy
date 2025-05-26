using System;


internal class _0526_1
{
    static void Main(string[] args)
    {
        //5/22일 1번 연습문제 계산기의
        // 덧셈, 뺄셈, 곱셈, 나눗셈을 각각
        // Add, Sub, Multi, Div 라는 이름의 함수를 통해
        // 연산해보세요
        // int로 변환 가능한 수를 입력할때까지 입력을
        //반복적으로 받는 함수도 만들어 사용하시오

        int[] numbers = new int[2];
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

    static int Add( int a, int b )
    {
        return a + b;
    }

    static int Sub (int a, int b )
    {
        return a - b;
    }

    static int Mul(int a, int b)
    {
        return a * b;
    }

    static int Div(int a, int b)
    {
        if( b == 0)
        {
            Console.WriteLine("0으로 나눌 수 없습니다. 결과값이 0으로 출력됩니다.");
            return 0;
        }
        else 
        {
            return a / b;
        }
    }
    static int GetInput(int i)
    {
        
        while (true)
        {
            Console.WriteLine($"{i + 1}번째 정수를 입력하세요 : ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("정수를 입력하세요");
            }
        }
        
    }
}

