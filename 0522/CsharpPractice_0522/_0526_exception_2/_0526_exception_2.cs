using System;


internal class _0526_exception_2
{
    static void Main(string[] args)
    {
        Console.Write("팩토리얼 할 수를 입력하세요 : ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.Write(Factorial(input));

    }
    
    static int Factorial(int i)
    {
        if(i >= 1)
        {
            return i * Factorial(i - 1);
        }
        else
        {
            return 1;
        }
    }
    /*
    static int Fibonacci(int i)
    {
        
        
    }*/
}

