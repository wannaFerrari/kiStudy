using System;

internal class _0526_2
{
    int nnnnn;
    int min;
    int max;
    static void Main(string[] args)
    {

        //연습문제 2번
        //숫자의 입력 개수를 받고
        //해당 횟수 만큼 숫자입력을 받고
        // 그 숫자들의 평균, 최소값, 최대값을 출력하는 프로그램
        //값의 계산은 무조건 다른 함수를 만들어서 return 받도록 함

        //2-1 정수
        //2-2 실수
        //2-3 숫자의 입력 전에 1. 정수 2. 실수로 입력을 받아 사용자가 선택하도록

        // 심화 : 위 세가지 값을 1개의 함수로 구해보세요. 출력은 해당 함수 밖의Main에서 하기.


        Console.Write("입력할 숫자의 개수를 입력하세요 : ");
        int input1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("1. 정수    2. 실수  : ");
        int input2 = Convert.ToInt32(Console.ReadLine());

        int[] intInputs = new int[input1];
        float[] floatInputs = new float[input1];
        if(input2 == 1)
        {
            for(int i = 0; i < input1; i++)
            {
                intInputs[i] = GetInput(i);
            }
            
            int avr = Calculate(intInputs, out int min, out int max);
            Console.WriteLine($"평균 : {avr}, 최소값 : {min}, 최대값 : {max}");

        }
        else if(input2 == 2)
        {
            for (int i = 0; i < input1; i++)
            {
                floatInputs[i] = GetInputFloat(i);
            }
            float avr = Calculate(floatInputs, out float min, out float max);
            Console.WriteLine($"평균 : {avr}, 최소값 : {min}, 최대값 : {max}");
        }
        else
        {

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

    static float GetInputFloat(int i)
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
                Console.WriteLine("정수를 입력하세요");
            }
        }

    }
    static int Calculate(int[] intArr, out int min, out int max)
    {
        Array.Sort(intArr);
        min = intArr[0];
        max = intArr[intArr.Length-1];
        int sum = 0;
        for(int i = 0; i < intArr.Length; i++)
        {
            sum += intArr[i];
        }
        sum /= intArr.Length;
        return sum;
    }
    static float Calculate(float[] floatArr, out float min, out float max)
    {
        Array.Sort(floatArr);
        min = floatArr[0];
        max = floatArr[floatArr.Length - 1];
        float sum = 0;
        for (int i = 0; i < floatArr.Length; i++)
        {
            sum += floatArr[i];
        }
        sum /= floatArr.Length;
        return sum;
    }
}

