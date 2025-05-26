using System;


internal class _0526_4
{
    static void Main(string[] args)
    {
        Console.Write("몇 단을 출력하시겠습니까? : ");
        int input = Convert.ToInt32(Console.ReadLine());
        PrintGugudan(input);
    }

    static void PrintGugudan(int num)
    {
        for (int i = 1; i < 10; i++)
        {
            Console.WriteLine($"{num} X {i} = {num * i}");
        }
    }
}

