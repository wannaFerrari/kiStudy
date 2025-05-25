using System;




internal class _0523_4_hard
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
        int targetValue = 10;
        double distance = 0;
        int displayDistance;
        //int randomValue = rand.Next(0, 10);
        matrix[randomX, randomY] = targetValue;


        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (x >= randomX)
                {
                    if (y >= randomY)
                    {
                        distance = Math.Sqrt(Math.Pow((x - randomX), 2) + Math.Pow((y - randomY), 2));
                        matrix[x, y] = (int)Math.Ceiling(10 - distance);
                    }
                    else
                    {
                        distance = Math.Sqrt(Math.Pow((x - randomX), 2) + Math.Pow((randomY - y), 2));
                        matrix[x, y] = (int)Math.Ceiling(10 - distance);

                    }
                }
                else
                {
                    if (y >= randomY)
                    {
                        distance = Math.Sqrt(Math.Pow((randomX - x), 2) + Math.Pow((y - randomY), 2));
                        matrix[x, y] = (int)Math.Ceiling(10 - distance);

                    }
                    else
                    {
                        distance = Math.Sqrt(Math.Pow((randomX - x), 2) + Math.Pow((randomY - y), 2));
                        matrix[x, y] = (int)Math.Ceiling(10 - distance);

                    }
                }
            }
        }

        while (!found)
        {
            Console.Write($"탐색할 x축 좌표(0~9) : ");
            int inputX = Convert.ToInt32(Console.ReadLine());

            Console.Write($"탐색할 y축 좌표(0~9) : ");
            int inputY = Convert.ToInt32(Console.ReadLine());
            
            
            if (matrix[inputX, inputY] == 10)
            {
                Console.WriteLine($"[{inputX},{inputY}] = {targetValue}. 보물을 찾았습니다!");
                found = true;
            }
            else
            {
                Console.WriteLine($"[{inputX},{inputY}] = {matrix[inputX,inputY]}. 여기에는 보물이 없습니다.");
            }

            Console.WriteLine($"((정답은 [{randomX},{randomY}] 에 {targetValue}가 있습니다.))");
        }
    }
}

