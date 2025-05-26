using System;



internal class _0526_3
{
    static void Main(string[] args)
    {
        int[] intInput = new int[2];
        for(int i = 0; i < 2; i++)
        {
            intInput[i] = GetInput(i);
        }
        if (intInput[0] % intInput[1] == 0 )
        {
            Console.WriteLine($"{intInput[0]}는 {intInput[1]}의 배수입니다.");
        }
        else
        {

            Console.WriteLine($"{intInput[0]}는 {intInput[1]}의 배수가 아닙니다.");
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

