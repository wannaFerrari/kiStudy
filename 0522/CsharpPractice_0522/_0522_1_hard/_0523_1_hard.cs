using System;

internal class _0523_1_hard
{
    static void Main(string[] args)
    {
       
        int com1, com2; 
        int player1, player2;

        int selectedByPlayer = -1;
        int selectedByCom = -1;

        bool win = false;
        string[] choice = new string[] { "가위", "바위", "보" };

        do {
            Console.WriteLine("[하나빼기] 첫번째로 낼거를 고르세요");
            Console.Write("1.가위 2.바위 3.보 ! : ");
            player1 = Convert.ToInt32(Console.ReadLine());
            if (player1 < 1 || player1 > 3)
            {
                Console.WriteLine("잘못 선택하셨습니다.");
                continue;
            }
            Console.WriteLine("[하나빼기] 두번째로 낼거를 고르세요");
            Console.Write("1.가위 2.바위 3.보 ! : ");
            player2 = Convert.ToInt32(Console.ReadLine());
            if (player2 < 1 || player2 > 3)
            {
                Console.WriteLine("잘못 선택하셨습니다.");
                continue;
            }

            Random random = new Random(DateTime.Now.Millisecond); //computer start
            com1 = random.Next(1, 4);
            com2 = random.Next(1, 4);
            if(com1 == com2)
            {
                bool same = true;
                while (same)
                {
                    com2 = random.Next(1, 4);
                    if(com2 != com1)
                    {
                        same = false;
                    }
                }
            }
            Console.WriteLine($"컴퓨터가 고른 것 : [{com1}.{choice[com1-1]}], [{com2}.{choice[com2-1]}]");

            Console.Write($"내가 고른 두가지 중에 하나만 고르세요 ({player1}.{choice[player1-1]}, " +
                $"{player2}.{choice[player2-1]}) : ");
            selectedByPlayer = Convert.ToInt32(Console.ReadLine());
            if (selectedByPlayer != player1 && selectedByPlayer != player2)
            {
                Console.WriteLine("잘못 선택하셨습니다.");
            }
            else
            {
                if (com1 > com2)
                {
                    selectedByCom = random.Next(com2, com1 + 1);

                }
                else
                {
                    selectedByCom = random.Next(com1, com2 + 1);

                }
            }

            if((selectedByPlayer - selectedByCom) == -2 || (selectedByPlayer - selectedByCom) == 1)
            {
                Console.WriteLine($"내가 낸것 : {choice[selectedByPlayer-1]}, " +
                    $"컴퓨터가 낸것 : {choice[selectedByCom-1]}");
                Console.WriteLine("이겼다!");
                win = true;
            }
            else if (selectedByCom == selectedByPlayer)
            {
                Console.WriteLine($"내가 낸것 : {choice[selectedByPlayer-1]}, " +
                    $"컴퓨터가 낸것 : {choice[selectedByCom-1]}");
                Console.WriteLine("비겼다");
            }
            else
            {
                Console.WriteLine($"내가 낸것 : {choice[selectedByPlayer-1]}, " +
                    $"컴퓨터가 낸것 : {choice[selectedByCom-1]}");
                Console.WriteLine("졌다.");
            }
        } while (win == false);






        
    }
}

