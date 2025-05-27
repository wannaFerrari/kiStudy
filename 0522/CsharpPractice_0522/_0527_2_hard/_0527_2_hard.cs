using System;
using System.Linq;

internal class _0527_2_hard
{
    enum Major
    {
        불마법,
        물마법,
        물리마법
    }

    enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }
    class Student
    {
        private string name;
        private Major major;
        private int score;
        private Grade grade;

        public Student(string name, int major, int score)
        {
            this.name = name;
            this.major = (Major)major;
            this.score = score;
            grade = GetGrade(score);
        }

        public void PrintInfo()
        {
            // Console.WriteLine("======학생 정보 출력======");
            // Console.WriteLine($"{}번학생");
            Console.WriteLine($"이름 : {name}");
            Console.WriteLine($"전공 : {major}");
            Console.WriteLine($"점수 : {score}");
            Console.WriteLine($"학점 : {grade}");
            Console.WriteLine($"=========================");

        }

        public void ChangeStudentInfo()
        {
            Console.WriteLine($"이름(수정 없을 경우 공란) : ");
            string newName = Console.ReadLine();
            Console.WriteLine($"전공(1.불마법 2.물마법 3.물리마법) : ");
            int newMajor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"점수 : ");
            int newScore = Convert.ToInt32(Console.ReadLine());



            if (newName != "")
            {
                this.name = newName;
            }
            this.major = (Major)newMajor;
            this.score = newScore;
            this.grade = GetGrade(newScore);

        }

        public Grade GetGrade(int sc)
        {
            if (sc >= 90 && sc <= 100)
            {
                grade = Grade.A;
            }
            else if (sc >= 80)
            {
                grade = Grade.B;
            }
            else if (sc >= 70)
            {
                grade = Grade.C;
            }
            else if (sc >= 60)
            {
                grade = Grade.D;
            }
            else if (sc >= 50)
            {
                grade = Grade.F;
            }
            return grade;
        }

        public string ReturnName()
        {
            return name;
        }

        public int ReturnScore()
        {
            return score;
        }

    }
    static void Main(string[] args)
    {
        int menuChoice = 0;
        string name;
        int major;
        int score;
        int studentCount = 0;
        Student[] students = new Student[10];
        Student[] studentsTemp = new Student[10];

        //List<Student> studentList = new List<Student>();
        while (true)
        {
            Console.WriteLine("======학생 관리 프로그램======");
            Console.WriteLine("1. 새 학생 등록");
            Console.WriteLine("2. 학생 정보 수정");
            Console.WriteLine("3. 학생 정보 출력");
            Console.WriteLine("4. 학생 정보 삭제");
            Console.Write("무엇을 하시겠습니까? : ");
            menuChoice = Convert.ToInt32(Console.ReadLine());
            if (menuChoice == 1)
            {
                Console.WriteLine("======새 학생 등록======");
                Console.WriteLine("학생 정보를 입력하세요.");
                Console.Write("이름 : ");
                name = Console.ReadLine();
                Console.Write($"전공(1.불마법 2.물마법 3.물리마법) : ");
                major = Convert.ToInt32(Console.ReadLine());
                Console.Write("점수 : ");
                score = Convert.ToInt32(Console.ReadLine());
                Student nStudent = new Student(name, major, score);
                students[studentCount] = nStudent;
                studentCount++;
                //studentList.Add(newStudent);


            }
            else if (menuChoice == 2)
            {
                for (int i = 0; i < studentCount; i++)
                {
                    Console.WriteLine($"{i + 1} {students[i].ReturnName()}");
                }
                Console.Write($"누구를 수정하시겠습니까? : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                students[choice - 1].ChangeStudentInfo();
            }
            else if (menuChoice == 3)
            {
                Console.Write($"정렬 방식을 선택해주세요 : 1.이름 2.성적 => ");
                int choice = Convert.ToInt32(Console.ReadLine());

                /*
                Student[] sortArray = students;
                sortArray = students.OrderBy(Student => Student.ReturnName()).ToArray();*/
                //students = sortArray;
                if(choice == 1)
                {
                    for (int i = 0; i < studentCount; i++)
                    {
                        for (int j = i + 1; j < studentCount; j++)
                        {
                            if (string.Compare(students[i].ReturnName(), students[j].ReturnName()) == 1)
                            {
                                Student temp;
                                temp = students[j];
                                students[j] = students[i];
                                students[i] = temp;
                            }
                        }
                    }
                }
                else if(choice == 2)
                {
                    for (int i = 0; i < studentCount; i++)
                    {
                        for (int j = i + 1; j < studentCount; j++)
                        {
                            if (students[i].ReturnScore()< students[j].ReturnScore())
                            {
                                Student temp;
                                temp = students[j];
                                students[j] = students[i];
                                students[i] = temp;
                            }
                        }
                    }
                }

                    for (int i = 0; i < studentCount; i++)
                    {
                        students[i].PrintInfo();
                    }
            }
            else if (menuChoice == 4)
            {
                for (int i = 0; i < studentCount; i++)
                {
                    Console.WriteLine($"{i + 1} {students[i].ReturnName()}");
                }
                Console.Write($"누구를 삭제하시겠습니까? : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                //choice == index 
                int tempCount=0;
                for(int i = 0; i < studentCount; i++)
                {
                    if(i != choice-1)
                    {
                        studentsTemp[tempCount] = students[i];
                        tempCount++;
                    }
                }
                students = studentsTemp;
                studentCount = tempCount;
                Console.WriteLine($"삭제가 완료되었습니다.");

            }
        }
    }
}

