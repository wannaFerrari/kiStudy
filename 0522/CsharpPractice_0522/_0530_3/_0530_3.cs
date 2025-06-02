using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace _0530_3
{
    internal class _0530_3
    {
        
        enum Way
        {
            Up, Down, Left, Right, None
        }

        enum Color 
        {
            Red,Blue,Yellow,Green
        }
        static void DrawScene()
        {

            ///////////////////////////////////////////----------바깥 시작
            Console.Write("┌");
            for (int i = 0; i < 50; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");

            for (int j = 0; j < 20; j++)
            {
                Console.Write("│");
                for (int i = 0; i < 50; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("│");
            }


            Console.Write("└");
            for (int i = 0; i < 50; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");

            /////////////////////////////////////////-----------바깥 끝



            /////////////////////////////////////////------------내부 시작
            Console.SetCursorPosition(5, 2);
            Console.Write("┌");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");

            Console.SetCursorPosition(5, 3);
            for (int j = 0; j < 15; j++)
            {
                Console.SetCursorPosition(5, j + 3);
                Console.Write("│");
                for (int i = 0; i < 40; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("│");
            }

            Console.SetCursorPosition(5, 18);
            Console.Write("└");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");
            ////////////////////////////////////////////-------------내부 끝
            ///

            Console.SetCursorPosition(5, 16);
            Console.Write("├");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("─");
            }
            Console.Write("┤");

            Console.SetCursorPosition(7, 17);
            Console.Write("현재색 : ");

            Console.SetCursorPosition(3, 19);
            Console.Write("이전색:Q, 다음색:W, 붓이동:방향키, 끝내기:ESC");

        }
        static void PaintCurrentColor(Color color)
        {
            //Console.SetCursorPosition(7, 23);
            PaintDot(15,17,color);
        }

        static void MoveCursor(int x, int y, Way way)
        {
            switch (way)
            {
                case Way.Up:
                    Console.SetCursorPosition(x , y + 1);
                    Console.ResetColor();
                    Console.Write(" ");
                    Console.SetCursorPosition(x , y);
                   // Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("*");
                    break;
                case Way.Down:
                    Console.SetCursorPosition(x , y - 1);
                    Console.ResetColor();
                    Console.Write(" ");
                    Console.SetCursorPosition(x , y);
                   // Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("*");
                    break;
                case Way.Left:
                    Console.SetCursorPosition((x + 1), y);
                    Console.ResetColor();
                    Console.Write(" ");
                    Console.SetCursorPosition(  x, y);
                   // Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("*");
                    break;
                case Way.Right:
                    Console.SetCursorPosition((x - 1), y);
                    Console.ResetColor();
                    Console.Write(" ");
                    Console.SetCursorPosition(x , y);
                   // Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("*");
                    break;
                case Way.None:
                    Console.SetCursorPosition(x , y);
                   // Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("*");
                    break;
            }
            
        }

        static void PaintDot(int x, int y, Color color)
        {
            Console.SetCursorPosition(x, y);

            switch (color)
            {
                case Color.Red:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                    Console.ResetColor();
                    break;
                case Color.Blue:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(" ");
                    Console.ResetColor();
                    break;
                case Color.Yellow:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(" ");
                    Console.ResetColor();
                    break;
                case Color.Green:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" ");
                    Console.ResetColor();
                    break;

            }
            
        }

        static void PaintAllPoints(int[,] matrix, int minX, int minY)
        {
            for (int i =0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] != -1)
                    {
                        PaintDot(i+minX, j+minY, (Color)matrix[i,j]);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int cursorX = 6;
            int cursorY = 4;
            int minCanvasX = 6;
            int minCanvasY = 4;
            int maxCanvasX = 44;
            int maxCanvasY = 15;
            int currentColor = 0;
            int[,] matrix = new int[39,12];
            bool nowPainted = false;

            Console.CursorVisible = false;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = -1;
                }
            }

            DrawScene();
            
            MoveCursor(cursorX, cursorY, Way.None);
            PaintCurrentColor((Color)currentColor);
            while (true)
            {
                PaintAllPoints(matrix, minCanvasX, minCanvasY);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (cursorX > minCanvasX)
                        {
                            cursorX--;
                            MoveCursor(cursorX, cursorY, Way.Left);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorX < maxCanvasX)
                        {
                            cursorX++;
                            MoveCursor(cursorX, cursorY, Way.Right);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (cursorY > minCanvasY)
                        {
                            cursorY--;
                            MoveCursor(cursorX, cursorY, Way.Up);
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorY < maxCanvasY)
                        {
                            cursorY++;
                            MoveCursor(cursorX, cursorY, Way.Down);
                        }

                        break;
                    case ConsoleKey.Q:
                        if (currentColor == 0)
                        {
                            currentColor = 3;
                        }
                        else
                        {
                            currentColor--;
                        }
                        break;
                    case ConsoleKey.W:
                        if (currentColor == 3)
                        {
                            currentColor = 0;
                        }
                        else
                        {
                            currentColor++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        PaintDot(cursorX, cursorY, (Color)currentColor);
                        matrix[cursorX - minCanvasX,cursorY - minCanvasY] = currentColor;
                        break;
                    case ConsoleKey.Escape:
                        return;

                }
                PaintCurrentColor((Color)currentColor);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
        }

    }
}
