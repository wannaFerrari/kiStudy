using System;

internal class Program
{
    static void Main(string[] args)
    {
        //성적표 만들기
        //필수 과목부터
        string required1 = "음악", required2 = "종이접기", required3 = "마법진역학";
        Console.Write("이름을 입력하세요 : ");
        string name = Console.ReadLine();

        Console.Write($"수강한 과목을 입력하세요 (필수과목 - {required1},{required2}," +
            $"{required3}): ");
        string subject = Console.ReadLine();

        Console.Write("시험 성적을 입력하세요 (0~100): ");
        string score = Console.ReadLine();
        int scoreInt = int.Parse(score);
        char grade = 'F';


        //if (scoreInt <= 100 && scoreInt >= 90)
        //{
        //    //A학점
        //    grade = 'A';
        //}
        //else if (scoreInt < 90 &&  scoreInt >= 80)
        //{

        //}
        scoreInt /= 10;

        switch (scoreInt)
        {
            case 10:
            case 9:
                grade = 'A';
                break;
            case 8:
                grade = 'B';
                break;
            case 7:
                grade = 'C';
                break;
            case 6:
                grade = 'D';
                break;
            default:
                grade = 'F';
                break;

        }

        //필수과목 체크를 위해 subject 값이 required1,2,3중 같은게 하나라도 있어야함
        bool isRequired = subject == required1 || subject == required2 || 
            subject == required3;

        //졸업하려면 학점이 F이면 안됨
        bool isPass = grade != 'F';

        /*Console.WriteLine($"필수과목인가요 : {isRequired}, 합격 학점 이상인가요? " +
            $"{isPass}");*/

        //졸업 가능한지?
        bool isGraduate = isRequired && isPass;

        Console.WriteLine($"이름 : {name}");
        Console.WriteLine($"과목 : {subject}");
        Console.WriteLine($"학점 : {grade}");
        Console.WriteLine($"졸업 : {isGraduate}");



    }
}

