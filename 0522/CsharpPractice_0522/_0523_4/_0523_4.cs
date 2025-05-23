using System;


internal class _0523_4
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                matrix[i, j] = 0;
            }
        }

        bool found = false;

        Console.WriteLine("보물 위치를 탐색합니다. (10x10)");
        Random rand = new Random(DateTime.Now.Millisecond);
        int randomX = rand.Next(0, 10);
        int randomY = rand.Next(0, 10);
        int randomValue = rand.Next(0, 10);
        matrix[randomX, randomY] = randomValue;

        while (!found)
        {
            Console.Write($"탐색할 x축 좌표(0~9) : ");
            int inputX = Convert.ToInt32(Console.ReadLine());

            Console.Write($"탐색할 y축 좌표(0~9) : ");
            int inputY = Convert.ToInt32(Console.ReadLine());

            if (matrix[inputX, inputY] != 0)
            {
                Console.WriteLine($"[{inputX},{inputY}] = {randomValue}. 보물을 찾았습니다!");
                found = true;
            }
            else
            {
                Console.WriteLine($"[{inputX},{inputY}] = 0. 여기에는 보물이 없습니다.");
            }

            Console.WriteLine($"((정답은 [{randomX},{randomY}] 에 {randomValue}가 있습니다.))");
        }
        




        //Console.WriteLine($"{randomX}, {randomY}, {randomValue}");

    }
}

