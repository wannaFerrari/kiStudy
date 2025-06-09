using System;

namespace ExceptionExample
{
    //예외 (Exception)
    //프로그래밍 언어에서 문법상 무제가 되지는 않지만
    // 프로그램 빌드 후 실행시에 일어나느 ㄴ모든 에러를 
    //C# 에서는 예외 라고 말함(런타임 에러)
    //try-catch-finally 키워드를 통해 런타임 에러 발생가능성이 예상될때를 대비한 방어코드 작성이 가능
    // System.Exception 클래스를 상속한 커스텀 예외를 제작하여
    // 다른 개발자로 하여금 에러 발생 상황에 대해 더 자세한 내용을 제공할 수 있음.
    internal class Program
    {

        static void Main(string[] args)
        {
            //예외 처리 (try-catch)
            //예외가 발생할 수 있는 코드를 try 블록 안에 작성 후,
            //예외가 발생했을 때의 처리를 catch 블록 안에 작성.

            //예외처리가 되지 않은 상황에서 예외가 발생할 경우, 프로세스가 즉시 종료되나,
            //개발자가 직접 예외처리를 할 경우 프로세스가 종료되는 대신, 해당 try 블록만 건너뜀.

            //catch문은 else-if과 비슷하게
            //여러 catch문을 중첩할 수 있으며,
            //try문 안에서 발생한 예외에 해당하는 catch문만 수행한다.
            //매치되는 예외가 catch문 중에 없을 경우 처리되지 않은 예외로 취급.
            //발생한 예외사항과 매치할 예외는 catch문 뒤에 괄호 안에 명시
            //관용적으로 맨 뒤의 catch 문은 모든 예외를 포함하는 Exception또는 괄호 없는 catch문을 배치함.
          
            int[] array = new int[10];
            while (true)
            {
                try
                {
                    /*
                    Console.Write("수를 입력하세요 : "); // 0~9 외의 문자를 입력하면
                    string input = Console.ReadLine();
                    int value = int.Parse(input); // 에러 발생
                    Console.WriteLine($"입력한 수 : {value}");
                    array[value] = 10; //0보다 작거나 9보다 큰 문자를 입력했으면 에러 발생
                    Console.WriteLine($"array[{value}]에 10을 대입.");
                    */
                    //입력을 3번 받아서 처음 받은 입력은 배열 개수로 지정.
                    //두번째 받은 입력을 배열 인덱스로 사용.
                    //세번째 받은 입력을 배열 내 인덱스의 값으로 대입.
                    Console.Write("배열의 크기를 입력하세요 : ");
                    int arrayLength = int.Parse(Console.ReadLine());
                    Console.Write("접근할 인덱스를 입력하세요 : ");
                    int arrayIndex = int.Parse(Console.ReadLine());
                    Console.Write("해당 인덱스에 대입할 값을 입력하세요 : ");
                    int indexValue = int.Parse(Console.ReadLine());
                    int[] array2 = new int[arrayLength];
                    array2[arrayIndex] = indexValue;
                    Console.WriteLine(array2[arrayIndex]);

                }
                catch (FormatException e)
                {
                    Console.WriteLine("숫자를 입력하셔야 합니다.");
                    Console.WriteLine(e.Message);
                }
                //IndexOutOfRangeException 예외처리하기
                //그 외 다른 예외 처리도 해보기
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    //finally 블록 : 예외 발생 여부에 상관없이 무조건 수행되는 블록
                    Console.WriteLine("다음으로 넘어갑니다.");
                }
            }
        }
    }
}
