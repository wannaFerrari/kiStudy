using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLI_GAME_PROJECT_2
{



    internal class Program
    {
        public static bool isPlaying = true;
        public static int playerPosition2 = 0;
        public static bool bombTrigger = false;
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Thread inputThread = new Thread(CheckInput);
            inputThread.Start();
            
            //Thread timerThread = new Thread(PrintTimer);
            //timerThread.Start();
            
            Console.SetWindowSize(120, 30);
            Console.CursorVisible = false;

            int playerPosition = 0;
            const int moveAmount = 9;
            const int betweenLines = 4;
            const int betweenRedLines = 4;
            int betweenLeft = 0;
            int nextLine = 0;
            int afterLineForRedLine = 4;
            bool isHitted = false;
            
            //int[] screenLine = new int[20];
            List<int> screenLine = new List<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 20; i++)
            {
                //screenLine.Add(rand.Next(0, 5));
                screenLine.Add(0);
            }
            MovePlayer(playerPosition, playerPosition2, moveAmount);
            stopwatch.Start();
            while (true)
            {
                if(playerPosition2 != playerPosition)
                {
                    MovePlayer(playerPosition, playerPosition2, moveAmount);
                    playerPosition = playerPosition2;
                }


                //screenLine[10] = 1;
                for (int i = 19; i >= 0; i--)  // 화면 맨 밑쪽이 배열 0번, 맨 위가 배열 19번
                {
                    Console.SetCursorPosition(10, 22 - i);
                    if (screenLine[i] == 0)
                    {
                        Console.Write("                                                        ");
                    }
                    else if (screenLine[i] == 1)
                    {
                        Console.Write("  *********                                             ");

                    }
                    else if (screenLine[i] == 2)
                    {
                        Console.Write("           *********                                    ");

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
                        Console.Write("                                              *********");

                    }
                    else if (screenLine[i] == 7)
                    {
                        Console.Write("  *********         *********                           ");

                    }
                    else if (screenLine[i] == 8)
                    {
                        Console.Write("           *********         *********                  ");

                    }
                    else if (screenLine[i] == 9)
                    {
                        Console.Write("                    *********         *********         ");

                    }
                    else if (screenLine[i] == 10)
                    {
                        Console.Write("                             *********         *********");

                    }

                    else if (screenLine[i] == 11)
                    {
                        Console.Write("  *********         *********         *********         ");

                    }
                    else if (screenLine[i] == 12)
                    {
                        Console.Write("           *********         *********         *********");

                    }
                    else if (screenLine[i] == 13)
                    {
                        Console.Write("  ******************                  ******************");

                    }
                    else if (screenLine[i] == 14)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("  *********                                             ");
                        Console.ResetColor();

                    }
                    else if (screenLine[i] == 15)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("           *********                                    ");
                        Console.ResetColor();

                    }
                    else if (screenLine[i] == 16)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("                    *********                           ");
                        Console.ResetColor();

                    }
                    else if (screenLine[i] == 17)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("                             *********                  ");
                        Console.ResetColor();

                    }
                    else if (screenLine[i] == 18)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("                                      *********         ");
                        Console.ResetColor();
                    }
                    else if (screenLine[i] == 19)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("                                               *********");
                        Console.ResetColor();
                    }
                    else if (screenLine[i] == 20)
                    {
                        Console.Write("  ******************************************************");

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

                DrawOutLineOfGameBoard();
                Console.SetCursorPosition(80, 5);
                //TimeSpan duration = stopwatch.Elapsed;
                Console.Write(stopwatch.Elapsed.ToString("hh\\:mm\\:ss\\.f"));
                if(bombTrigger == true)
                {
                    //inputThread.Suspend();
                    MiniGame(rand,inputThread);
                    BombEffect();
                    
                    bombTrigger = false;
                }
                MovePlayer(playerPosition2, playerPosition2, moveAmount);
                isHitted = CheckHit(screenLine[0], playerPosition2);
                if(isHitted == true)
                {
                    Console.SetCursorPosition(80, 7);
                    Console.Write("끝");
                }
                if (betweenLeft == 0)
                {
                    if(afterLineForRedLine == 0)
                    {
                        nextLine = rand.Next(1, 21);

                        afterLineForRedLine = betweenRedLines;
                    }
                    else
                    {
                        nextLine = rand.Next(1, 14);
                        afterLineForRedLine--;
                    }
                    betweenLeft = betweenLines;
                }
                else
                {
                    nextLine = 0;
                }
                screenLine.Add(nextLine);
                betweenLeft--;
                    //screenLine.Add(rand.Next(0, 5));
                //Task.Delay(1000);
                Thread.Sleep(70);
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
                ConsoleKeyInfo key = Console.ReadKey(true);
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
                    case ConsoleKey.Spacebar:
                        bombTrigger = true;
                        break;
                }
            }
        }

        public static bool CheckHit(int line, int pos)
        {
            if (line == 0)
            {
                return false;
            }
            else if (line == 1)
            {
                if (pos == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 2)
            {
                if (pos == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 3)
            {
                if (pos == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 4)
            {
                if (pos == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 5)
            {
                if (pos == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 6)
            {
                if (pos == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 7)
            {
                if (pos == 0 || pos == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 8)
            {
                if (pos == 1 || pos == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 9)
            {
                if (pos == 2 || pos == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 10)
            {
                if (pos == 3 || pos == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 11)
            {
                if (pos == 0 || pos == 2 || pos == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 12)
            {
                if (pos == 1 || pos == 3 || pos == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 13)
            {
                if (pos == 0 || pos == 1 || pos == 4 || pos == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (line == 14)
            {
                if (pos == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (line == 15)
            {
                if (pos == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (line == 16)
            {
                if (pos == 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (line == 17)
            {
                if (pos == 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (line == 18)
            {
                if (pos == 4)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (line == 19)
            {
                if (pos == 5)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (line == 20)
            {
                /*
                if (pos == 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }*/
                return false;
            }
            else
            {
                return false;
            }
        }
        public static bool MiniGame(Random rand, Thread thread)
        {
           // thread.Join();
            List<int> keyAnswer = new List<int>();
            keyAnswer.Add(rand.Next(0, 4));
            keyAnswer.Add(rand.Next(0, 4));
            keyAnswer.Add(rand.Next(0, 4));
            keyAnswer.Add(rand.Next(0, 4));
            
            for(int i = 0; i < keyAnswer.Count; i++)
            {
                if (keyAnswer[i] == 0)
                {
                    Console.SetCursorPosition(30 + 3*i, 15);
                    Console.Write("A");
                }
                else if (keyAnswer[i] == 1)
                {
                    Console.SetCursorPosition(30 + 3 * i, 15);
                    Console.Write("S");
                }
                else if (keyAnswer[i] == 2)
                {
                    Console.SetCursorPosition(30 + 3 * i, 15);
                    Console.Write("D");
                }
                else if (keyAnswer[i] == 3)
                {
                    Console.SetCursorPosition(30 + 3 * i, 15);
                    Console.Write("F");
                }
            }

            for(int i = 0; i < 4; i++)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            }


            return true;
        } 

        public static void BombEffect()
        {
            for(int i = 0; i < 23; i++)
            {
                for(int j = 0; j < 64;  j++)
                {
                    Console.SetCursorPosition(6 + j, 2 + i);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }

            for (int i = 0; i < 23; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    Console.SetCursorPosition(6 + j, 2 + i);
                    
                    Console.Write(" ");
                    Console.ResetColor();
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

        public static void DrawOutLineOfGameBoard()
        {
            Console.SetCursorPosition(4, 1);
            Console.Write("┌");
            for(int i = 0; i < 65; i++)
            {
                Console.Write("─");
            }
            Console.Write("┐");
            /*
            Console.SetCursorPosition(4, 2);
            Console.Write("│");
            Console.SetCursorPosition(70, 2);
            Console.Write("│");*/
            for(int i = 0; i < 23; i++)
            {
                Console.SetCursorPosition(4, 2+i);
                Console.Write("│");
                Console.SetCursorPosition(70, 2+i);
                Console.Write("│");
            }

            Console.SetCursorPosition(4, 25);
            Console.Write("└");
            for (int i = 0; i < 65; i++)
            {
                Console.Write("─");
            }
            Console.Write("┘");

        }
    }
}
