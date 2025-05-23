using System;
using System.Collections.Concurrent;
using System.Data;


internal class _0523_3
{
    static void Main(string[] args)
    {
        Console.WriteLine("블랙잭 게임을 시작합니다.");
        int comCard1, comCard2, comCard3;
        int playerCard1, playerCard2, playerCard3;

        Random rand = new Random(DateTime.Now.Millisecond);
        playerCard1 = rand.Next(1, 14);
        
        playerCard2 = rand.Next(1, 14);
        if (playerCard1 == playerCard2)
        {
            bool same1 = true;
            while (same1)
            {

                playerCard2 = rand.Next(1, 14);
                if (playerCard2 == playerCard1)
                {
                    same1 = true;
                }
                else
                {
                    same1 = false;
                }
            }
        }

        comCard1 = rand.Next(1, 14);
        comCard2 = rand.Next(1, 14);
        if (comCard1 == comCard2)
        {
            bool same2 = true;
            while (same2)
            {

                comCard2 = rand.Next(1, 14);
                if (comCard2 == comCard1)
                {
                    same2 = true;
                }
                else
                {
                    same2 = false;
                }
            }
        }

        Console.WriteLine($"나의 카드 : {playerCard1}, {playerCard2}");
        Console.WriteLine("1.더받기 2.스테이 : ");
        int inputNum = Convert.ToInt32(Console.ReadLine());
        if (inputNum == 1) // 더받기
        {
            playerCard3 = rand.Next(1, 14);
            bool same3 = true;

            
            while (same3)
            {

                playerCard3 = rand.Next(1, 14);
                if (playerCard2 == playerCard3 || playerCard1 == playerCard3)
                {
                    same3 = true;
                }
                else
                {
                    same3 = false;
                }
            }

            int mySum = playerCard1 + playerCard2 + playerCard3;
            int comSum = comCard1 + comCard2;

            if ((mySum) > 21)
            {
                Console.WriteLine($"나 : {mySum}, 컴퓨터 : {comSum}");
                Console.WriteLine("플레이어의 3개의 카드의 합이 21이 넘어 플레이어 패배");
            }
            else if ((mySum) > (comSum))
            {
                Console.WriteLine($"나 : {mySum}, 컴퓨터 : {comSum}");
                Console.WriteLine("플레이어의 카드의 합이 컴퓨터보다 크므로, 플레이어 승리");
            }
            else if (comSum > 21)
            {
                Console.WriteLine($"나 : {mySum}, 컴퓨터 : {comSum}");
                Console.WriteLine("컴퓨터의 2개의 카드의 합이 21이 넘어 플레이어 승리");
            }
        }
        else if(inputNum == 2) //스테이
        {
            int mySum = playerCard1 + playerCard2;
            int comSum = comCard1 + comCard2;
            if(mySum == comSum)
            {
                Console.WriteLine($"나 : {mySum}, 컴퓨터 : {comSum}");
                Console.WriteLine("둘의 숫자가 같으므로 비김");
            }
            else if (mySum > comSum)
            {
                Console.WriteLine($"나 : {mySum}, 컴퓨터 : {comSum}");
                Console.WriteLine("플레이어의 숫자의 합이 더 크므로 플레이어 승리");
            }
            else if (comSum<21 && mySum < comSum)
            {
                Console.WriteLine($"나 : {mySum}, 컴퓨터 : {comSum}");
                Console.WriteLine("컴퓨터의 카드의 합이 더 크므로 플레이어 패배");
            }
            else if (comSum > 21)
            {
                Console.WriteLine($"나 : {mySum}, 컴퓨터 : {comSum}");
                Console.WriteLine("컴퓨터의 2개의 카드의 합이 21이 넘어 플레이어 승리");
            }
        }
            //Console.WriteLine($"{comCard1}, {comCard2}");
    }





    
}

