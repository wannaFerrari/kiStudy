using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _0610_1
{

    class Score
    {
        public int science;
        public int english;
        public int mathmatic;
        public int korean;

        public Score(int science, int english, int mathmatic, int korean)
        {
            this.science = science;
            this.english = english;
            this.mathmatic = mathmatic;
            this.korean = korean;
        }
        
    }

    //학생의 이름을 통해 성적을 모두 탐색할 수 있는 프로그램을 만들어보세요
    //출력예시 
    //무엇을 하시겠습니까?
    //1.성적 입력 2.성적 출력
    // > 1
    //누구의 성적을 입력하시겠습니까?
    // > 김한결
    //과학 점수를 입력하세요 : 30
    //영어 점수를 입력하세요 : 20
    //수학 점수를 입력하세요 : 77
    //국어 점수를 입력하세요 : 32
    //무엇을 하시겠습니까?
    //1.성적 입력 2.성적 출력
    // > 2
    //누구의 성적을 출력하시겠습니까?

    internal class _0610_1
    {

        static void Main(string[] args)
        {
            Dictionary<string,Score> userScoreDic = new Dictionary<string,Score>();
            while (true)
            {
                Console.WriteLine("무엇을 하시겠습니까?");
                Console.WriteLine("1.성적 입력 2.성적 출력");
                int choice1 = int.Parse(Console.ReadLine());
                if(choice1 == 1)
                {
                    Console.WriteLine("누구의 성적을 입력하시겠습니까?");
                    string name = Console.ReadLine();

                    Console.Write("과학 점수를 입력하세요 : ");
                    int sc = int.Parse(Console.ReadLine());

                    Console.Write("영어 점수를 입력하세요 : ");
                    int en = int.Parse(Console.ReadLine());

                    Console.Write("수학 점수를 입력하세요 : ");
                    int ma = int.Parse(Console.ReadLine());

                    Console.Write("국어 점수를 입력하세요 : ");
                    int ko = int.Parse(Console.ReadLine());
                    Score score = new Score(sc,en, ma, ko);
                    userScoreDic.Add(name, score);

                }
                else if (choice1 == 2)
                {
                    Console.WriteLine("누구의 성적을 출력하시겠습니까?");
                    string name = Console.ReadLine();
                    if (userScoreDic.ContainsKey(name))
                    {
                        Score theScore = userScoreDic[name];
                        Console.WriteLine($"=============={name}===============");
                        Console.WriteLine($"과학 : {theScore.science}");
                        Console.WriteLine($"영어 : {theScore.english}");
                        Console.WriteLine($"수학 : {theScore.mathmatic}");
                        Console.WriteLine($"국어 : {theScore.korean}");
                        Console.WriteLine($"==================================");
                    }
                    else
                    {
                        Console.WriteLine("그런사람 또 없습니다...");
                    }
                    
                }
            }
        }
    }
}
