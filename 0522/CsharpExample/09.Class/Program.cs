using System;


namespace Class
{
    //클래스 : 어떤 대상을 "객체화"해서 프로그래밍 언어의 문법을 통해
    //현실세계의 어떤 "객체"를 프로그램에서 유사하게 동작하도록 만들기 위한 
    // 일종의 "설계도" 역할

    //[접근지정자] class 클래스명 { 속성(필드), 메소드 등 }

    //만약 내가 학생이면
    //나를 구성하는 요소는 .
    //1. 이름 => 문자열
    //2. 학점(성적)
    //2-0. 과목 => 문자열
    //2-1. 어느 학과의 과목인지. => Major
    //2-2. 시험성적(중간고사, 과제점수 ...) => 정수형
    //2-3. 학점등급 -> A+ ~ D, F => enum Grade
    //3. 학과(전공) => 코드 => 숫자(정수) => 열거형


    enum Grade // 학점
    {
        Aplus,  // 100~ 95
        A,      //94~90
        Bplus,  //89~85
        B,      //84~80
        Cplus,  //79~75
        C,      //74~70
        Dplus,  //69~65
        D,      //64~60
        F       //59~
    }
    enum Major  // 학과
    {
        Computer,
        English,
        Economy,
        Electronics,
    }

    class Student
    {
        //필드
        public string name; // 이름
        public Score score;
        public Major major; // 학과

        private int knowledge = 0;


        //생성자
        public Student()
        {
            name = "아무개";
            score = new Score();
            major = Major.Computer;
            knowledge = 10;
        }

        //사용자 정의 생성자
        public Student(string name, Major major)
        {
            this.name = name;
            this.major = major;
            score = new Score();
            score.mainMajor = major;
            knowledge = 10;
        }
        //메소드
        public void Study()
        {
            knowledge += 10;
            //공부를 통해 수업을 들을때 좀 더 잘 듣게됨
        }

        public void TakeCourse(string subjectName)
        {
            //수강신청을 함
            score.subjectName = subjectName;
        }
        public void TakeTest()
        {
            //강의를 통해 쌓인 지식을 점수로 환산.
            score.scorePoint = knowledge;
            score.SetGrade();
        }
    }

    class Score
    {
        public string subjectName;
        public Major mainMajor;
        public int scorePoint;
        public Grade grade;

        public void SetGrade()
        {
            // 100~ 95
            //94~90
            //89~85
            //84~80
            //79~75
            //74~70
            //69~65
            //64~60
            //59~

            if(scorePoint >+ 95)
            {
                grade = Grade.Aplus;
            }
            else if(scorePoint >= 90)
            {
                grade = Grade.A;
            }
            else if (scorePoint >= 85)
            {
                grade = Grade.Bplus;
            }
            else if (scorePoint >= 80)
            {
                grade = Grade.B;
            }
            else if (scorePoint >= 85)
            {
                grade = Grade.Cplus;
            }
            else if (scorePoint >= 80)
            {
                grade = Grade.C;
            }
            else if (scorePoint >= 75)
            {
                grade = Grade.Dplus;
            }
            else if (scorePoint >= 70)
            {
                grade = Grade.D;
            }
            else
            {
                grade= Grade.F;
            }
        }

        //성적에 대한 정보를 문자열로 정리해서 반환해주는 함수를 만들고 싶다.
        public string GetInfo()
        {
            string info = $"과목명 : {subjectName}\n주관학과 : {mainMajor}\n" +
                $"시험점수 : {scorePoint}\n학점 : {grade}";
            return info;
        }
    }


    internal class Program
    {
        static void Main(string[] args)//main함수로 프로그램의 진입점임을 정의함.
        {
            //새로운 학생 한명을 만듦.
            //이름이나 수강할 과목등등 자유
            // 수강회수나 시험보기전에 공부 횟수 자유
            //마지막에 점수를 console에 출력

            Student studentA = new Student(); 

            Student studentB = new Student("이성준", Major.Computer);

            studentA.major = Major.English; //studentA의 major필드에 접근하여 값을 변경

            Console.WriteLine($"studentA의 이름은 {studentA.name}, " +
                $"전공은 {studentA.major}입니다");

            Console.WriteLine($"studentB의 이름은 {studentB.name}, " +
                $"전공은 {studentB.major}입니다");

            studentA.TakeCourse("영문학개론");
            studentB.TakeCourse("C언어 기초");

            studentA.Study();


            for(int i = 0; i < 7; i++)
            {
                studentB.Study();
            }
            Console.WriteLine($"{studentA.name}의 수강과목은 " +
                $"{studentA.score.subjectName}");

            Console.WriteLine($"{studentB.name}의 수강과목은 " +
                $"{studentB.score.subjectName}");



            studentA.TakeTest();
            studentB.TakeTest();
            //studentA.score.SetGrade();
            //studentB.score.SetGrade();
            // Console.WriteLine(studentB.score.grade);
            Console.WriteLine($"==={studentA.name}의 이번학기 성적===");
            Console.WriteLine(studentA.score.GetInfo());
            Console.WriteLine("===============================");
            Console.WriteLine($"==={studentB.name}의 이번학기 성적===");
            Console.WriteLine(studentB.score.GetInfo());
            Console.WriteLine("===============================");
        }
    }
}
