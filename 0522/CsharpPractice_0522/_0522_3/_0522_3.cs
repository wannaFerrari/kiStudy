


using System;

internal class _0522_3
{
    static void Main(string[] args)
    {
        string inputName;
        string inputSubject;
        string inputScore;
        int parsedInputScore;

        char grade = 'z';
        bool canGraduate = false;

        Console.Write("이름을 입력하세요 : ");
        inputName = Console.ReadLine();
        Console.Write("수강한 과목을 입력하세요 (필수과목-데이터베이스, 객체지향언어 : ");
        inputSubject = Console.ReadLine();
        Console.Write("점수(0~100점)을 입력해주세요 : ");
        inputScore = Console.ReadLine();

        if (int.TryParse(inputScore, out parsedInputScore))
        {

        }

        if(inputSubject == "데이터베이스" || inputSubject == "객체지향언어")
        {
            if(parsedInputScore > 100)
            {
                Console.WriteLine("잘못된 점수를 입력하였습니다.");
                return;
            }
            else if(parsedInputScore >= 90)
            {
                grade = 'A';
                canGraduate = true;
            }
            else if (parsedInputScore >= 80)
            {
                grade = 'B';
                canGraduate = true;
            }
            else if (parsedInputScore >= 70)
            {
                grade = 'C';
                canGraduate = true;
            }
            else if (parsedInputScore >= 60)
            {
                grade = 'D';
                canGraduate = true;
            }
            else if (parsedInputScore < 60)
            {
                grade = 'F';
                canGraduate = false;
            }
            else
            {
                Console.WriteLine("점수가 올바르지 않습니다");
                return;
            }
        }
        else
        {
            if (parsedInputScore > 100)
            {
                Console.WriteLine("잘못된 점수를 입력하였습니다.");
                return;
            }
            else if (parsedInputScore >= 90)
            {
                grade = 'A';
                
            }
            else if (parsedInputScore >= 80)
            {
                grade = 'B';
               
            }
            else if (parsedInputScore >= 70)
            {
                grade = 'C';
               
            }
            else if (parsedInputScore >= 60)
            {
                grade = 'D';
                
            }
            else if (parsedInputScore < 60)
            {
                grade = 'F';
                
            }
            else
            {
                Console.WriteLine("점수가 올바르지 않습니다");
                return;
            }
            canGraduate = false;

        }

        Console.WriteLine();
        Console.WriteLine($"이름 : {inputName}");
        Console.WriteLine($"과목 : {inputSubject}");
        Console.WriteLine($"학점 : {grade}");
        Console.WriteLine($"졸업 : {canGraduate}");


    }
}

