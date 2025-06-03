using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Game_Project1
{
    class Sudoku
    {
        public int[,] matrix;
        public int[,] answer;
        public bool[,] canChange;
        public Sudoku()
        {
            matrix = new int[9, 9];
            answer = new int[9, 9];
            canChange = new bool[9, 9];

        }

        public void MakeAnswer()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j =0;  j < 9; j++)
                {
                    answer[i,j] = matrix[i, j];
                }
            }
        }

        public void DrawXMark()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(60, 21);
            Console.Write($"            ■■                   ■■    ");
            Console.SetCursorPosition(60, 22);
            Console.Write($"              ■■               ■■      ");
            Console.SetCursorPosition(60, 23);
            Console.Write($"                ■■           ■■        ");
            Console.SetCursorPosition(60, 24);
            Console.Write($"                  ■■       ■■        ");
            Console.SetCursorPosition(60, 25);
            Console.Write($"                    ■■   ■■            ");
            Console.SetCursorPosition(60, 26);
            Console.Write($"                      ■■■■      ");
            Console.SetCursorPosition(60, 27);
            Console.Write($"                    ■■   ■■       ");
            Console.SetCursorPosition(60, 28);
            Console.Write($"                  ■■       ■■     ");
            Console.SetCursorPosition(60, 29);
            Console.Write($"                ■■           ■■     ");
            Console.SetCursorPosition(60, 30);
            Console.Write($"              ■■               ■■     ");
            Console.SetCursorPosition(60, 31);
            Console.Write($"            ■■                   ■■    ");
            Console.ResetColor();
        }

        public void DrawOMark()
        {
            EraseMark();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(60, 23);
            Console.Write($"                        ■■■■            ");
            Console.SetCursorPosition(60, 24);
            Console.Write($"                   ■■■■■■■■■              ");
            Console.SetCursorPosition(60, 25);
            Console.Write($"               ■■■                ■■■                ");
            Console.SetCursorPosition(60, 26);
            Console.Write($"            ■■■                      ■■■             ");
            Console.SetCursorPosition(60, 27);
            Console.Write($"          ■■■                          ■■■                    ");
            Console.SetCursorPosition(60, 28);
            Console.Write($"        ■■■                              ■■■                     ");
            Console.SetCursorPosition(60, 29);
            Console.Write($"          ■■■                          ■■■                    ");
            Console.SetCursorPosition(60, 30);
            Console.Write($"            ■■■                    ■■■                  ");
            Console.SetCursorPosition(60, 31);
            Console.Write($"               ■■■              ■■■                ");
            Console.SetCursorPosition(60, 32);
            Console.Write($"                   ■■■■■■■■■              ");
            Console.SetCursorPosition(60, 33);
            Console.Write($"                        ■■■■            ");
            Console.ResetColor();
        }

        public void EraseMark()
        {
            Console.SetCursorPosition(60, 21);
            Console.Write($"                                           ");
            Console.SetCursorPosition(60, 22);
            Console.Write($"                                          ");
            Console.SetCursorPosition(60, 23);
            Console.Write($"                                        ");
            Console.SetCursorPosition(60, 24);
            Console.Write($"                                         ");
            Console.SetCursorPosition(60, 25);
            Console.Write($"                                        ");
            Console.SetCursorPosition(60, 26);
            Console.Write($"                                      ");
            Console.SetCursorPosition(60, 27);
            Console.Write($"                                      ");
            Console.SetCursorPosition(60, 28);
            Console.Write($"                                      ");
            Console.SetCursorPosition(60, 29);
            Console.Write($"                                      ");
            Console.SetCursorPosition(60, 30);
            Console.Write($"                                       ");
            Console.SetCursorPosition(60, 31);
            Console.Write($"                                      ");
            Console.Write($"                                      ");
        }

        public void ShowTime(string time)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(59, 2);
            Console.Write("┌────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(59, 3);
            Console.Write("│                                                    │");
            Console.SetCursorPosition(59, 4);
            Console.Write("│                                                    │");
            Console.SetCursorPosition(59, 5);
            Console.Write("│                                                    │");
            Console.SetCursorPosition(59, 6);
            Console.Write("└────────────────────────────────────────────────────┘");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(75, 4);
            Console.Write($"경과 시간 : {time}");


            ShowInformation();

        }

        public void ShowInformation()
        {
            Console.SetCursorPosition(59, 1);
            Console.Write("                                                                 ");
            Console.SetCursorPosition(59, 11);
            Console.Write("┌────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(59, 12);
            Console.Write("│                                                    │");
            Console.SetCursorPosition(59, 13);
            Console.Write("│                                                    │");
            Console.SetCursorPosition(59, 14);
            Console.Write("└────────────────────────────────────────────────────┘");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(67, 13);
            Console.Write($"Enter 키를 눌러 메인 화면으로 돌아가기");
        }

        public void ShowInformationInAnswer()
        {
            Console.SetCursorPosition(59, 21);
            Console.Write("┌────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(59, 22);
            Console.Write("│                                                    │");
            Console.SetCursorPosition(59, 23);
            Console.Write("│                                                    │");
            Console.SetCursorPosition(59, 24);
            Console.Write("└────────────────────────────────────────────────────┘");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(73, 22);
            Console.Write($"< 정답을 출력하였습니다 >");
            Console.SetCursorPosition(72, 23);
            Console.Write($"다음 기회엔 꼭 성공해보세요!");
        }

        public void WriteAllAnswers()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matrix[i, j] = answer[i, j];
                }
            }
        }
        public void DrawBoard()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    /*
                    if(i==x && j == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }*/
                    if (canChange[i, j] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.SetCursorPosition(i * 6 + 4, j * 4 + 1);
                    Console.Write("┌───┐");
                    Console.SetCursorPosition(i * 6 + 4, j * 4 + 2);
                    Console.Write("│   │");
                    Console.SetCursorPosition(i * 6 + 4, j * 4 + 3);
                    Console.Write("└───┘");
                    Console.ResetColor();
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i * 6 + 7, j * 4 + 2);
                    if (matrix[i, j] == -1)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        if (canChange[i, j] == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.Write(matrix[i, j]);
                        Console.ResetColor();

                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0) + 1; i += 3)
            {
                for (int j = 0; j < matrix.GetLength(1) + 1; j += 3)
                {

                    if (true)
                    {
                        Console.SetCursorPosition(i * 6 + 3, j * 2);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 1);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 2);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 3);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 4);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 5);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 6);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 7);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 8);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 9);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 10);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 11);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 12);
                        Console.Write("│");

                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 13);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 14);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 15);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 16);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 17);
                        Console.Write("│");
                        Console.SetCursorPosition(i * 6 + 3, j * 2 + 18);
                        Console.Write("│");
                    }
                    Console.SetCursorPosition(i * 4 + 3, j * 4);
                    //Console.Write("───────────────────────────────");
                    Console.Write("───────────────────");
                    //Console.Write("================================");
                }
            }
            Console.SetCursorPosition(3, 0);
            Console.Write("┌");
            Console.SetCursorPosition(21, 0);
            Console.Write("┬");
            Console.SetCursorPosition(39, 0);
            Console.Write("┬");
            Console.SetCursorPosition(57, 0);
            Console.Write("┐");

            Console.SetCursorPosition(3, 12);
            Console.Write("├");
            Console.SetCursorPosition(21, 12);
            Console.Write("╂");
            Console.SetCursorPosition(39, 12);
            Console.Write("╂");
            Console.SetCursorPosition(57, 12);
            Console.Write("┤");

            Console.SetCursorPosition(3, 24);
            Console.Write("├");
            Console.SetCursorPosition(21, 24);
            Console.Write("╂");
            Console.SetCursorPosition(39, 24);
            Console.Write("╂");
            Console.SetCursorPosition(57, 24);
            Console.Write("┤");

            Console.SetCursorPosition(3, 36);
            Console.Write("└");
            Console.SetCursorPosition(21, 36);
            Console.Write("┴");
            Console.SetCursorPosition(39, 36);
            Console.Write("┴");
            Console.SetCursorPosition(57, 36);
            Console.Write("┘");

            Console.SetCursorPosition(59, 11);
            Console.Write("┌────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(59, 12);
            Console.Write("│                                                    │");
            Console.SetCursorPosition(59, 13);
            Console.Write("│                                                    │");
            Console.SetCursorPosition(59, 14);
            Console.Write("└────────────────────────────────────────────────────┘");

            Console.SetCursorPosition(61, 12);
            Console.Write($"남은 빈칸의 수 : {EmptyCount()}");

            Console.SetCursorPosition(61, 13);
            Console.Write($"이동: 화살표   숫자입력: 숫자키   지우기: BackSpace");

            Console.SetCursorPosition(65, 1);
            Console.Write($"제출하기: Enter   정답보기: Q    메인메뉴로 나가기: M");





        }

        public void PaintCursorBox(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x * 6 + 4, y * 4 + 1);
            Console.Write("┌───┐");
            Console.SetCursorPosition(x * 6 + 4, y * 4 + 2);
            Console.Write("│   │");
            Console.SetCursorPosition(x * 6 + 4, y * 4 + 3);
            Console.Write("└───┘");
            Console.ResetColor();
            Console.SetCursorPosition(x * 6 + 7, y * 4 + 2);
            if (matrix[x, y] == -1)
            {
                Console.Write("  ");
            }
            else
            {
                if (canChange[x, y] == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(matrix[x, y]);
                Console.ResetColor();
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public bool GenerateNumberToMatrix()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int row = 0; row < 9; row++) // 행
            {
                for (int col = 0; col < 9; col++) //열
                {
                    if (matrix[row, col] == 0)
                    {
                        List<int> numbers = GenarateRandomNumbers();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (CheckNumberIsValid(row, col, numbers[i]))
                            {
                                matrix[row, col] = numbers[i];

                                if (GenerateNumberToMatrix())
                                {
                                    return true;
                                }
                                matrix[row, col] = 0;


                            }
                        }
                        return false;

                    }
                }
            }
            return true;
        }

        public bool CheckNumberIsValid(int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (matrix[i, col] == num)
                {
                    return false;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (matrix[row, i] == num)
                {
                    return false;
                }
            }

            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[startRow + i, startCol + j] == num)
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public List<int> GenarateRandomNumbers()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            List<int> numbers = new List<int>();
            int temp = -1;
            for (int i = 1; i < 10; i++)
            {
                numbers.Add(i);
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                int randIndex = rand.Next(i, numbers.Count);
                temp = numbers[i];
                numbers[i] = numbers[randIndex];
                numbers[randIndex] = temp;
            }
            return numbers;
        }

        public void EraseMatrix(int count)
        {
            Random rand = new Random();
            int randX;
            int randY;
            List<int> randXList = new List<int>();
            List<int> randYList = new List<int>();
            for (int i = 0; i < count; i++)
            {
                randX = rand.Next(0, 9);
                randY = rand.Next(0, 9);
                if (i != 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (randX == randXList[j] && randY == randYList[j])
                        {
                            randX = rand.Next(0, 9);
                            randY = rand.Next(0, 9);
                            j = 0;
                        }

                    }
                }
                randXList.Add(randX);
                randYList.Add(randY);
            }
            for (int i = 0; i < count; i++)
            {
                matrix[randXList[i], randYList[i]] = -1;
            }
        }

        public int EmptyCount()
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == -1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public bool CheckIsCorrect()
        {
            for (int row = 0; row < 9; row++)
            {
                bool[] seen = new bool[10]; 
                for (int col = 0; col < 9; col++)
                {
                    int num = matrix[row, col];
                    if (num < 1 || num > 9 || seen[num])
                        return false;
                    seen[num] = true;
                }
            }

            for (int col = 0; col < 9; col++)
            {
                bool[] seen = new bool[10];
                for (int row = 0; row < 9; row++)
                {
                    int num = matrix[row, col];
                    if (num < 1 || num > 9 || seen[num])
                        return false;
                    seen[num] = true;
                }
            }

            for (int boxRow = 0; boxRow < 3; boxRow++)
            {
                for (int boxCol = 0; boxCol < 3; boxCol++)
                {
                    bool[] seen = new bool[10];
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int num = matrix[boxRow * 3 + i, boxCol * 3 + j];
                            if (num < 1 || num > 9 || seen[num])
                                return false;
                            seen[num] = true;
                        }
                    }
                }
            }

            return true;
            /*
            int count = 0;
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(matrix[i, j] == answer[i, j])
                    {
                        count++;
                    }
                }
            }
            if (count == 81)
            {
                //Console.SetCursorPosition(60, 5);
                //Console.Write($"{count}");
                //foreach(int m in answer) Console.Write(m);
                return true;
            }
            else
            {
                return false;
            }*/


            /*
            for (int i = 0; i < 9; i++)
            {
                List<int> list = new List<int>();
                List<int> list2 = new List<int>();
                for (int j = 0; j < 9; j++)
                {
                    
                    list.Add(matrix[i, j]);
                    list2.Add(matrix[j, i]);
                    
                   
                }
                list.Sort();
                Console.SetCursorPosition(60, 3);
                foreach(int num in list)
                {
                    Console.Write(num);
                }
                //Console.Write($"{matrix[i,j]}");
                list2.Sort();
                Console.SetCursorPosition(60, 4);
                foreach (int num in list)
                {
                    Console.Write(num);
                }
               // Console.Write($"{list2[0]}");
                if (list.SequenceEqual(list2))
                {
                    Console.SetCursorPosition(60, i);
                    Console.Write($"ffff");
                    //return false;
                }
            }
            Console.SetCursorPosition(60, 5);
            Console.Write($"true");
            return true;*/
        }

    }

    internal class Program
    {
        enum Scene
        {
            Main,StartGame,End
        }
        static void ChangeScene()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 40; i++)
            {
                for(int j = 0; j < 120; j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    Console.ResetColor();
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 0);

        }
        static void Main()
        {
            Console.SetWindowSize(120, 43);
            Console.CursorVisible = false;
            ChangeScene();
            int selectNum = 0;
            

            string sudokuString = @"
                     ■■                         ■■■■■■■■■                    ■■■■■■■■■
                  ■■  ■■                      ■■                                                ■■
                ■■     ■■                     ■■                                                ■■
              ■■         ■■                   ■■                                  ■■■■■■■■■
             ■■           ■■                  ■■                                                ■■
            ■■             ■■                 ■■■■■■■■■                                  ■■
           ■■               ■■                                                                       
                                                         ■■                         ■■■■■■■■■■■
                                                         ■■                                   ■■        
          ■■■■■■■■■■■■               ■■■■■■■■■■                           ■■       ";
            Console.SetCursorPosition(30, 7);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(sudokuString);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 0);
            Console.Write("┌");
            for (int i = 0; i < 117; i++)
            {
                Console.Write("─");

            }
            Console.WriteLine("┐");

            for (int i = 0; i < 35; i++)
            {
                Console.Write("│");
                Console.SetCursorPosition(118, i + 1);
                Console.WriteLine("│");
            }

            Console.Write("└");
            for (int i = 0; i < 117; i++)
            {
                Console.Write("─");

            }
            Console.WriteLine("┘");

            ///////////// 쉬움
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(17, 25);
            Console.Write("┌");
            for(int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.Write("┐");

            Console.SetCursorPosition(17, 26);
            Console.Write("│");
            Console.SetCursorPosition(38, 26);
            Console.Write("│");
            Console.SetCursorPosition(17, 27);
            Console.Write("│");
            Console.SetCursorPosition(38, 27);
            Console.Write("│");
            Console.SetCursorPosition(17, 28);
            Console.Write("│");
            Console.SetCursorPosition(38, 28);
            Console.Write("│");

            Console.SetCursorPosition(17, 29);
            Console.Write("└");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.Write("┘");
            Console.SetCursorPosition(26, 27);
            Console.Write("쉬 움");
            ////////////////////// 쉬움

            ///////////// 보통
            ///
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(47, 25);
            Console.Write("┌");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.Write("┐");

            Console.SetCursorPosition(47, 26);
            Console.Write("│");
            Console.SetCursorPosition(68, 26);
            Console.Write("│");
            Console.SetCursorPosition(47, 27);
            Console.Write("│");
            Console.SetCursorPosition(68, 27);
            Console.Write("│");
            Console.SetCursorPosition(47, 28);
            Console.Write("│");
            Console.SetCursorPosition(68, 28);
            Console.Write("│");

            Console.SetCursorPosition(47, 29);
            Console.Write("└");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.Write("┘");
            Console.SetCursorPosition(56, 27);
            Console.Write("보 통");
            ////////////////////// 보통

            ///////////// 어려움
            Console.ForegroundColor= ConsoleColor.Red;
            Console.SetCursorPosition(77, 25);
            Console.Write("┌");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.Write("┐");

            Console.SetCursorPosition(77, 26);
            Console.Write("│");
            Console.SetCursorPosition(98, 26);
            Console.Write("│");
            Console.SetCursorPosition(77, 27);
            Console.Write("│");
            Console.SetCursorPosition(98, 27);
            Console.Write("│");
            Console.SetCursorPosition(77, 28);
            Console.Write("│");
            Console.SetCursorPosition(98, 28);
            Console.Write("│");

            Console.SetCursorPosition(77, 29);
            Console.Write("└");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.Write("┘");
            Console.SetCursorPosition(86, 27);
            Console.Write("어려움");
            ////////////////////// 어려움
            ///
            Console.ResetColor();
            MoveSelectCursorInMain(selectNum);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (selectNum != 0)
                        {
                            selectNum--;
                            MoveSelectCursorInMain(selectNum);
                        }
                        
                        break;
                    case ConsoleKey.RightArrow:
                        if (selectNum != 2)
                        {
                            selectNum++;
                            MoveSelectCursorInMain(selectNum);
                        }
                        
                        break;
                    case ConsoleKey.Enter:
                        ChangeScene();
                        StartGame(selectNum);
                        break;


                }
                

            }

        }

        static void MoveSelectCursorInMain(int select)
        {
            if(select == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                ///////////////쉬움
                Console.SetCursorPosition(17, 24);
                Console.Write("▼▼▼▼▼▼▼▼▼▼▼");
                Console.SetCursorPosition(17, 30);
                Console.Write("▲▲▲▲▲▲▲▲▲▲▲");

                //////////////보통
                Console.SetCursorPosition(47, 24);
                Console.Write("                      ");
                Console.SetCursorPosition(47, 30);
                Console.Write("                      ");

                /////////////////어려움
                Console.SetCursorPosition(77, 24);
                Console.Write("                      ");
                Console.SetCursorPosition(77, 30);
                Console.Write("                      ");
            }
            else if (select == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                ///////////////쉬움
                Console.SetCursorPosition(17, 24);
                Console.Write("                      ");
                Console.SetCursorPosition(17, 30);
                Console.Write("                      ");

                //////////////보통
                Console.SetCursorPosition(47, 24);
                Console.Write("▼▼▼▼▼▼▼▼▼▼▼");
                Console.SetCursorPosition(47, 30);
                Console.Write("▲▲▲▲▲▲▲▲▲▲▲");

                /////////////////어려움
                Console.SetCursorPosition(77, 24);
                Console.Write("                      ");
                Console.SetCursorPosition(77, 30);
                Console.Write("                      ");
            }
            else if (select == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                ///////////////쉬움
                Console.SetCursorPosition(17, 24);
                Console.Write("                      ");
                Console.SetCursorPosition(17, 30);
                Console.Write("                      ");

                //////////////보통
                Console.SetCursorPosition(47, 24);
                Console.Write("                      ");
                Console.SetCursorPosition(47, 30);
                Console.Write("                      ");

                /////////////////어려움
                Console.SetCursorPosition(77, 24);
                Console.Write("▼▼▼▼▼▼▼▼▼▼▼");
                Console.SetCursorPosition(77, 30);
                Console.Write("▲▲▲▲▲▲▲▲▲▲▲");
            }
            /*
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            ///////////////쉬움
            Console.SetCursorPosition(17, 24);
            Console.Write("▼▼▼▼▼▼▼▼▼▼▼");
            Console.SetCursorPosition(17, 30);
            Console.Write("▲▲▲▲▲▲▲▲▲▲▲");

            //////////////보통
            Console.SetCursorPosition(46, 24);
            Console.Write("▼▼▼▼▼▼▼▼▼▼▼");
            Console.SetCursorPosition(46, 30);
            Console.Write("▲▲▲▲▲▲▲▲▲▲▲");

            /////////////////어려움
            Console.SetCursorPosition(75, 24);
            Console.Write("▼▼▼▼▼▼▼▼▼▼▼");
            Console.SetCursorPosition(75, 30);
            Console.Write("▲▲▲▲▲▲▲▲▲▲▲");*/
        }

        

        static void StartGame(int select)
        {
            int cursorX = 0;
            int cursorY = 0;
            int difficulty = 0;

            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            if(select == 0)
            {
                difficulty = 1;
            }
            else if(select == 1)
            {
                difficulty = 35;
            }
            else if(select == 2)
            {
                difficulty = 50;
            }
            Console.SetWindowSize(120, 43);
            //int[,] matrix = new int[9, 9];
            //int[,] answer = new int[9, 9];
            //bool[,] canChange = new bool[9, 9];

            Sudoku sdk = new Sudoku();
            Console.CursorVisible = false;
            bool cleared = false;

            for (int i = 0; i < sdk.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < sdk.matrix.GetLength(1); j++)
                {
                    sdk.matrix[i, j] = 0;
                }
            }

            sdk.GenerateNumberToMatrix();

            // sdk.answer = sdk.matrix;
            sdk.MakeAnswer();
            sdk.EraseMatrix(difficulty);

            for (int i = 0; i < sdk.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < sdk.matrix.GetLength(1); j++)
                {
                    if (sdk.matrix[i, j] == -1)
                    {
                        sdk.canChange[i, j] = true;
                    }
                    else
                    {
                        sdk.canChange[i, j] = false;
                    }
                }
            }
            //DrawBoard(matrix, canChange);
            sdk.DrawBoard();
            sdk.PaintCursorBox(0, 0);

            while (cleared == false)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursorY != 0)
                        {
                            cursorY--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorY != 8)
                        {
                            cursorY++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursorX != 0)
                        {
                            cursorX--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorX != 8)
                        {
                            cursorX++;
                        }
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = 1;
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = 2;
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = 3;
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = 4;
                        }
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = 5;
                        }
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = 6;
                        }
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = 7;
                        }
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = 8;
                        }
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = 9;
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (sdk.canChange[cursorX, cursorY])
                        {
                            sdk.matrix[cursorX, cursorY] = -1;
                        }
                        break;
                    case ConsoleKey.Q:
                        sdk.WriteAllAnswers();
                        sdk.DrawBoard();
                        cleared = true;
                        sdk.ShowInformation();
                        sdk.ShowInformationInAnswer();
                        break;
                    case ConsoleKey.M:
                       
                        cleared = true;
                        ChangeScene();
                        Main();
                        break;
                    case ConsoleKey.Enter:
                        bool checkAnswer = sdk.CheckIsCorrect();
                        //bool a = sdk.CheckIsCorrect();
                        //Console.SetCursorPosition(60, 10);
                        //Console.Write($"{a}");
                        
                        if(checkAnswer== true)
                        {
                            Console.SetCursorPosition(80, 35);
                            Console.Write($"정답입니다.");
                            Console.SetCursorPosition(80, 36);
                            endTime = DateTime.Now;
                            TimeSpan diff = startTime - endTime;
                            String totalTime = string.Empty;
                            totalTime = string.Format("{0:hh\\:mm\\:ss}", diff);
                            //Console.Write(totalTime);
                            sdk.DrawOMark();
                            sdk.ShowTime(totalTime);
                            cleared = true;
                            
                            //return;
                        }
                        else
                        {
                            Console.SetCursorPosition(80, 35);
                            Console.Write($"틀렸습니다.");
                            sdk.DrawXMark();
                        }
                        break;
                }

                if (cleared != true)
                {
                    sdk.DrawBoard();
                    sdk.PaintCursorBox(cursorX, cursorY);
                }
                else
                {
                    bool enterPressed = false;
                    while (enterPressed == false)
                    {
                        ConsoleKeyInfo info2 = Console.ReadKey(true);
                        switch (info2.Key)
                        {
                            case ConsoleKey.Enter:
                                ChangeScene();
                                Main();
                                enterPressed = true;
                                break;
                        }
                    }
                }


            }

            
        }
    }
}
