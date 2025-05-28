using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    

    class Player
    {
        //static 변수 : Player라는 클래스로 생성된 객체 전체가 공유할 수 있는 변수

        public static int playerCount; // 전역변수 Player.playerCount

        public string name; // 멤버 변수
        public int level;
        public int hp; // 체력

        //기본생성자 정의
        public Player()
        {
            Console.WriteLine($"플레이어가 생성되었습니다.");
            playerCount++;
            hp = 100;
        }
        public void Attack()
        {
            Console.WriteLine($"{name}이 공격합니다");
        }

        public void ShowHP()
        {
            Console.WriteLine($"{name}의 현재 체력은 {hp} 입니다.");
        }

        public void Die()
        {
            Console.WriteLine($"{name}이 죽었습니다.");
            hp = 0;
            playerCount--;
        }

        //플레이어를 부활시키는 기능을 만들고 싶은데.
        //이 기능을 사용할 객체는 Player밖에 없음.
        //그리고 특정 플레이어가 사용하는 기능이 아니라 시스템이 어떤 플레이어든
        //부활 시킬 수 있어야함.
        //static(정적) 함수로 부활 기능을 만든다.

        public static void Revive(Player target)
        {
            target.hp = 30;
            Console.WriteLine($"{target.name}이 부활했습니다.");
            playerCount++;
        }
    }
    internal class Program
    {
        class Student
        {
            static int studentCount = 0;
            public int studentID;
            public string name;

            public Student(string name)
            {
                //학생이 새로 생성될때마다 1씩 증가한 ID를 studentID로 부여
                this.name = name;
                this.studentID = studentCount;
                studentCount++;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"학생이름 : {name}, 학생코드 : {studentID}");
            }

        }
        static void Main()
        {
            //static 실습.
            Student stud1 = new Student("홍길동");
            Student stud2 = new Student("아무개");
            Student stud3 = new Student("김한결");

            stud1.ShowInfo();
            stud2.ShowInfo();
            stud3.ShowInfo();

        }
        //static 요소 클래스의 멤버변수 또는 멤버함수가 힙영역에 동적 생성되지 않고
        //프로세스를 시작할 시에 바로 데이터 영역에 저장할 요소를 앞에 static 키워드를
        //  붙여서 구분한다.

        void ShowInstacneId()
        {
            Console.WriteLine($"이 객체의 ID는 : {this.GetHashCode()}");
        }

        static void ShowClassType()
        {
            Console.WriteLine($"이 클래스의 Type은 : {typeof(Program)}");
        }
        static void Main1(string[] args)
        {
            // ShowInstanceID(); 호출 불가
            ShowClassType();

           

            Player player1 = new Player();
            player1.name = "아무개";
            player1.level = 1;
            Player player2 = new Player()
            {
                name = "홍길동",
                level = 1
            };

            Console.WriteLine($"playerCount : {Player.playerCount}");
            player1.Attack();
            player2.Attack();

            player1.Die();
            Console.WriteLine($"playerCount : {Player.playerCount}");


            player1.ShowHP();
            player2.ShowHP();

            //player1.Revive(); 이렇게 호출이 불가능하다.player1꺼가 아닌 클래스자체꺼기때문
            //정적함수이기 떄문에 특정 인스턴스가 지닌 메서드가 아님.

            int pc = Player.playerCount;//playerCount는 정적 변수이고 멤버변수가 아니기에
            //          특정 인스턴스를 통해 접근이 불가능하다.
            Player.Revive(player1);
            Console.WriteLine($"playerCount : {Player.playerCount}");
        }
    }
}
