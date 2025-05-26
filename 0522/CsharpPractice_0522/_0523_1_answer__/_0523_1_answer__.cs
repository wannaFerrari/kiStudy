using System;

internal class _0523_1_answer__
{
    static void Main(string[] args)
    {
        //1. 가위바위보 (Random)
        Random random = new Random();
        Console.WriteLine("가위바위보를 시작합니다");

        //이겼는지 여부를 저장할 bool 변수
        bool isWin = false;
        do
        {
            Console.Write("1.가위 2.바위 3.보 ! : ");
            string input = Console.ReadLine(); //입력 받기
            int userChoice = int.Parse(input); //플레이어의 입력을 숫자로 변환
            int computerChoice = random.Next(1,4); // 1,2,3 중 하나 선택됨

            //경우의 수 3 가지 : 플레이어가 이기거나, 비기거나, 지거나


            /* //풀이 1
            //비기는 경우
            if (userChoice == computerChoice)
            {
                Console.WriteLine("비겼습니다.");
            }
            else if ((userChoice == 1 && computerChoice == 2) ||
                (userChoice == 2 && computerChoice == 3) ||
                (userChoice == 3 && computerChoice == 1)) //플레이어가 지는 경우
            {
                Console.WriteLine("졌습니다.");
            }
            else
            {
                Console.WriteLine("이겼습니다!");
                isWin = true;//이겼으므로 루프를 빠져나가기위해 isWin을 true로 대입
            }
            */


            //풀이 2

            int result = userChoice - computerChoice;
            //0 : 비김     -1, 2 : 플레이어 패배   1, -2 : 플레이어 승

            if(result < 0)
            {
                result += 3; // 이렇게 하면 -1 이 2가되고, -2가 1이됨
            }

            switch (result)
            {
                case 0:
                    //비김
                    Console.WriteLine("비겼습니다.");
                    break;
                case 2:
                    //플레이어 패배
                    Console.WriteLine("졌습니다.");
                    break;
                case 1:
                    //플레이어 승리
                    Console.WriteLine("이겼습니다!");
                    isWin = true;
                    break;
            }


        } while (!isWin);
    }
}

