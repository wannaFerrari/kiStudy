using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0530_2
{
    internal class _0530_2
    {
        static int CheckPwCorrect(int[] answer, int[] now)
        {
            int correctCount = 0;
            int sum = 0;
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == now[i])
                {
                    correctCount++;
                }
                else
                {

                    sum += (answer[i] - now[i]);


                }
            }
            if (correctCount == 4)
            {
                return 0;
            }
            else
            {
                return sum;
            }
        }

        static void DrawLock(int[] now, int settingIndex)
        {
            switch (settingIndex)
            {
                case 0:
                    Console.SetCursorPosition(14, 2);
                    Console.Write("▲");
                    Console.SetCursorPosition(18, 2);
                    Console.Write("△");
                    Console.SetCursorPosition(22, 2);
                    Console.Write("△");
                    Console.SetCursorPosition(26, 2);
                    Console.Write("△");

                    Console.SetCursorPosition(14, 4);
                    Console.Write("▼");
                    Console.SetCursorPosition(18, 4);
                    Console.Write("▽");
                    Console.SetCursorPosition(22, 4);
                    Console.Write("▽");
                    Console.SetCursorPosition(26, 4);
                    Console.Write("▽");
                    break;
                case 1:
                    Console.SetCursorPosition(14, 2);
                    Console.Write("△");
                    Console.SetCursorPosition(18, 2);
                    Console.Write("▲");
                    Console.SetCursorPosition(22, 2);
                    Console.Write("△");
                    Console.SetCursorPosition(26, 2);
                    Console.Write("△");

                    Console.SetCursorPosition(14, 4);
                    Console.Write("▽");
                    Console.SetCursorPosition(18, 4);
                    Console.Write("▼");
                    Console.SetCursorPosition(22, 4);
                    Console.Write("▽");
                    Console.SetCursorPosition(26, 4);
                    Console.Write("▽");
                    break;
                case 2:
                    Console.SetCursorPosition(14, 2);
                    Console.Write("△");
                    Console.SetCursorPosition(18, 2);
                    Console.Write("△");
                    Console.SetCursorPosition(22, 2);
                    Console.Write("▲");
                    Console.SetCursorPosition(26, 2);
                    Console.Write("△");

                    Console.SetCursorPosition(14, 4);
                    Console.Write("▽");
                    Console.SetCursorPosition(18, 4);
                    Console.Write("▽");
                    Console.SetCursorPosition(22, 4);
                    Console.Write("▼");
                    Console.SetCursorPosition(26, 4);
                    Console.Write("▽");
                    break;
                case 3:
                    Console.SetCursorPosition(14, 2);
                    Console.Write("△");
                    Console.SetCursorPosition(18, 2);
                    Console.Write("△");
                    Console.SetCursorPosition(22, 2);
                    Console.Write("△");
                    Console.SetCursorPosition(26, 2);
                    Console.Write("▲");

                    Console.SetCursorPosition(14, 4);
                    Console.Write("▽");
                    Console.SetCursorPosition(18, 4);
                    Console.Write("▽");
                    Console.SetCursorPosition(22, 4);
                    Console.Write("▽");
                    Console.SetCursorPosition(26, 4);
                    Console.Write("▼");
                    break;

            }


            Console.SetCursorPosition(14, 3);
            Console.Write($" {now[0]}");

            Console.SetCursorPosition(18, 3);
            Console.Write($" {now[1]}");

            Console.SetCursorPosition(22, 3);
            Console.Write($" {now[2]}");

            Console.SetCursorPosition(26, 3);
            Console.Write($" {now[3]}");
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rand = new Random(DateTime.Now.Millisecond);
            int[] pw = new int[4];

            int[] now = new int[4] { 0, 0, 0, 0 };

            int settingIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                pw[i] = rand.Next(0, 10);

            }

            Console.Write("┌");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");

            for (int j = 0; j < 10; j++)
            {


                Console.Write("│");
                for (int i = 0; i < 40; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("│");
            }
            Console.Write("└");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");

            Console.SetCursorPosition(10, 3);
            Console.Write("◁");

            Console.SetCursorPosition(30, 3);
            Console.Write("▷");

            //자물쇠
            /*
            Console.SetCursorPosition(14, 2);
            Console.Write("▲");
            Console.SetCursorPosition(18, 2);
            Console.Write("△");
            Console.SetCursorPosition(22, 2);
            Console.Write("△");
            Console.SetCursorPosition(26, 2);
            Console.Write("△");

            Console.SetCursorPosition(14, 4);
            Console.Write("▼");
            Console.SetCursorPosition(18, 4);
            Console.Write("▽");
            Console.SetCursorPosition(22, 4);
            Console.Write("▽");
            Console.SetCursorPosition(26, 4);
            Console.Write("▽");


            Console.SetCursorPosition(14, 3);
            Console.Write($" {now[0]}");

            Console.SetCursorPosition(18, 3);
            Console.Write($" {now[1]}");

            Console.SetCursorPosition(22, 3);
            Console.Write($" {now[2]}");

            Console.SetCursorPosition(26, 3);
            Console.Write($" {now[3]}");
            */
            while (true)
            {


                DrawLock(now, settingIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (settingIndex != 0)
                        {
                            settingIndex--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (settingIndex != 3)
                        {
                            settingIndex++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (now[settingIndex] == 9)
                        {
                            now[settingIndex] = 0;
                        }
                        else
                        {
                            now[settingIndex]++;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (now[settingIndex] == 0)
                        {
                            now[settingIndex] = 9;
                        }
                        else
                        {
                            now[settingIndex]--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        int checkSum = CheckPwCorrect(pw, now);
                        if(checkSum == 0)
                        {
                            Console.SetCursorPosition(17, 6);
                            Console.Write("정답입니다");
                            Console.SetCursorPosition(17, 7);
                            Console.Write($"        ");
                        }
                        else
                        {
                            Console.SetCursorPosition(17, 6);
                            Console.Write("틀렸습니다!");
                            if(checkSum>10 || checkSum < -10)
                            {
                                Console.Write($"         ");
                                Console.SetCursorPosition(17, 7);
                                Console.Write($"힌트: {checkSum} ");
                            }
                            else
                            {
                                Console.Write($"         ");
                                Console.SetCursorPosition(17, 7);
                                Console.Write($"힌트: {checkSum} ");
                            }
                                
                        }

                        
                        break;

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }

        }
    }
}
