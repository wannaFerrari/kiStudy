using System;

internal class _0523_1
{
    static void Main(string[] args)
    {
        //while 문을 이용하여 컴퓨터와 가위바위보를 하는 게임을 만들어 보세요.
        //이길때까지 무한 반복
        //출력예시 :
        // 1.가위 2.바위 3.보 ! : 3
        // 나 : 보, 컴퓨터 : 가위
        //지셨네요
        // 1.가위 2.바위 3.보 ! : 2
        // 나 : 바위, 컴퓨터 : 가위
        //이겼다!
        bool win = false;
        bool draw = false;
        int com = 0;
        string myHand = "None";
        string comHand = "None";
        do
        {
            Console.Write("1.가위 2.바위 3.보 ! : ");
            int inputNum = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            com = random.Next(1,4);

            switch (inputNum)
            {
                case 1:
                    myHand = "가위";
                    break;
                case 2:
                    myHand = "바위";
                    break;
                case 3:
                    myHand = "보";
                    break;
                default:
                    myHand = "안냄";
                    break;

            }
            switch (com)
            {
                case 1:
                    comHand = "가위";
                    break;
                case 2:
                    comHand = "바위";
                    break;
                case 3:
                    comHand = "보";
                    break;
                default:
                    comHand = "안냄";
                    break;

            }

            if (myHand == "가위")
            {
                if(comHand == "가위")
                {
                    win = false;
                    draw = true;
                }
                else if (comHand == "바위")
                {
                    win = false;
                    draw = false;
                }
                else if (comHand == "보")
                {
                    win = true;
                    draw = false;
                }
            }
            else if (myHand == "바위")
            {
                if (comHand == "가위")
                {
                    win = true;
                    draw = false;
                }
                else if (comHand == "바위")
                {
                    win = false;
                    draw = true;
                }
                else if (comHand == "보")
                {
                    win = false;
                    draw = false;
                }
            }
            else if (myHand == "보")
            {
                if (comHand == "가위")
                {
                    win = false;
                    draw = false;
                }
                else if (comHand == "바위")
                {
                    win = true;
                    draw = false;
                }
                else if (comHand == "보")
                {
                    win = false;
                    draw = true;
                }
            }


            Console.WriteLine($"나 : {myHand}, 컴퓨터 : {comHand}");
            if (win == true)
            {
                Console.WriteLine("이겼다!");
            }
            else if (win == false && draw == true)
            {
                Console.WriteLine("비겼네요.");
            }
            else
            {
                Console.WriteLine("지셨네요.");
            }



        } while (!win);




    }
}

