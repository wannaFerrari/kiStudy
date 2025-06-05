using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLI_GAME_PROJECT_2
{



    internal class Program
    {
        public static bool isPlaying = true;
        public static int playerPosition2 = 0;
        static void Main(string[] args)
        {
            Thread inputThread = new Thread(CheckInput);
            inputThread.Start();


            Console.SetWindowSize(120, 30);
            Console.CursorVisible = false;

            int playerPosition = 0;
            const int moveAmount = 9;
            const int betweenLines = 4;
            int betweenLeft = 0;
            int nextLine = 0;
            //int[] screenLine = new int[20];
            List<int> screenLine = new List<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 20; i++)
            {
                //screenLine.Add(rand.Next(0, 5));
                screenLine.Add(0);
            }
            MovePlayer(playerPosition, playerPosition2, moveAmount);
            while (true)
            {
                if(playerPosition2 != playerPosition)
                {
                    MovePlayer(playerPosition, playerPosition2, moveAmount);
                    playerPosition = playerPosition2;
                }


                //screenLine[10] = 1;
                for (int i = 19; i >= 0; i--)
                {
                    Console.SetCursorPosition(10, 20 - i);
                    if (screenLine[i] == 0)
                    {
                        Console.Write("                                                        ");
                    }
                    else if (screenLine[i] == 1)
                    {
                        Console.Write("*********                                               ");

                    }
                    else if (screenLine[i] == 2)
                    {
                        Console.Write("          *********                                     ");

                    }
                    else if (screenLine[i] == 3)
                    {
                        Console.Write("                    *********                           ");

                    }
                    else if (screenLine[i] == 4)
                    {
                        Console.Write("                             *********                  ");

                    }
                    else if (screenLine[i] == 5)
                    {
                        Console.Write("                                      *********         ");

                    }
                    else if (screenLine[i] == 6)
                    {
                        Console.Write("                                               *********");

                    }
                }
                //Console.SetCursorPosition(11, 21);
                //Console.Write("----");
                //Console.SetCursorPosition(11, 22);
                //Console.Write("/--*--\\");
                
                /*
                Console.SetCursorPosition(10 + playerPosition2 * moveAmount, 23);
                Console.Write("/---*---\\");
                Console.SetCursorPosition(10 + playerPosition2 * moveAmount, 24);
                Console.Write("---------");
                Console.SetCursorPosition(10 + playerPosition2 * moveAmount, 25);
                Console.Write(" /\\   /\\ ");*/
                screenLine.RemoveAt(0);
                if (betweenLeft == 0)
                {
                    nextLine = rand.Next(0, 7);
                    betweenLeft = betweenLines;
                }
                else
                {
                    nextLine = 0;
                }
                screenLine.Add(nextLine);
                    //screenLine.Add(rand.Next(0, 5));
                    betweenLeft--;
                //Task.Delay(1000);
                Thread.Sleep(100);
                /*ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (playerPosition != 0)
                        {
                            playerPosition--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerPosition != 3)
                        {
                            playerPosition++;
                        }
                        break;
                }*/
            }

        }

        public static void CheckInput()
        {
            while(isPlaying== true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (playerPosition2 != 0)
                        {
                            playerPosition2--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerPosition2 != 5)
                        {
                            playerPosition2++;
                        }
                        break;
                }
            }
        }

        public static void MovePlayer(int p1, int p2, int moveAmount) // p1이전위치, p2는 현재위치
        {
            Console.SetCursorPosition(12 + p1 * moveAmount, 21);
            Console.Write("         ");
            Console.SetCursorPosition(12 + p1 * moveAmount, 22);
            Console.Write("         ");
            Console.SetCursorPosition(12 + p1 * moveAmount, 23);
            Console.Write("         ");


            Console.SetCursorPosition(12 + p2 * moveAmount, 21);
            Console.Write("/---*---\\");
            Console.SetCursorPosition(12 + p2 * moveAmount, 22);
            Console.Write("---------");
            Console.SetCursorPosition(12 + p2 * moveAmount, 23);
            Console.Write(" /\\   /\\ ");
        }
    }
}
