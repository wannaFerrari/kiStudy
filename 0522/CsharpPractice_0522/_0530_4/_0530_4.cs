using System;
using System.Collections.Generic;


namespace _0530_4
{
    internal class _0530_4
    {
        enum BoT
        {
            b2 = -2,
            b1 = -1,
            bomb = 10,
            t3 = 3,
            t2 = 2,
            t1 = 1,
            treasure = 100
        }
        static void DrawBoard(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.SetCursorPosition((i + 1)*4, (j + 2)*2);
                    Console.Write(matrix[i,j]);
                    if (matrix[i,j] == 1)
                    {
                        Console.SetCursorPosition((i + 1) * 4 , (j + 2) * 2 );
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 40; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 + i, (1 + j) * 2 +1);
                    Console.Write("──");
                }
                
            }
        }

        static void SetBoardBehind(int [,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i+1,j] != 0 || (i != 0 && (matrix[i -1, j] != 0)))
                    {
                        if (matrix)
                        matrix[i, j] = (int)BoT.t1;
                    }
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }

            Random rand = new Random(DateTime.Now.Millisecond);
            int bombPosX = rand.Next(0, 10);
            int bombPosY = rand.Next(0, 10);
            int trePosX = rand.Next(0, 10);
            int trePosY = rand.Next(0, 10);
            while (trePosX == bombPosX && trePosY == bombPosY)
            {
                trePosX = rand.Next(0, 10);
                trePosY = rand.Next(0, 10);
            }

            matrix[bombPosX, bombPosY] = 10;
            matrix[trePosX, trePosY] = 100;
            SetBoardBehind(matrix);
            matrix[5, 5] = 1;
            DrawBoard(matrix);


        }
    }
}
