using System;
using System.Runtime.InteropServices;


namespace Inheritance
{

    //상속(Inheritance)
    //부모클래스의 모든 기능을 가진 채로 추가 기능을 확장하는 자식 클래스를 설계하는 방법
    //부모클래스 모든 기능을 수행할 수 있으므로 부모클래스와 같은 타입으로 취급 가능.

    //예시 : 
    //Monster라는 클래스를 만들었는데, 
    //BossMonster는 Monster가 할 수 있는 기능을 전부 수행하는 동시에 추가적으로 
    //  스킬을 사용할 수 있다.
    //그러면서 동시에 Monster 이다.

    class Monster
    {
        public string name;
        public int hp;

        public void Move()
        {
            Console.WriteLine($"{name}이 움직입니다.");
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine($"{name}이 {damage}만큼 데미지를 받았습니다.");
            hp -= damage;
            Console.WriteLine($"{name}의 남은 체력 :  {hp}");

        }


    }
    



    //다른 클래스를 부모로서 자식클래스가 상속하는 방법
    //class 자식클래스 : 부모클래스 { 클래스 내용 }
    class BossMonster : Monster
    {
        public string skill;
        public void UseSkill()
        {

            Console.WriteLine($"{name}이 {skill}을 사용합니다.");
        }
    }


    //접근지정자 클래스는 public / internal
    //클래스 멤버 요소의 접근 지정자 : public / protected / private
    //protected, private : 객체의 캡슐화를 위해 필요한 접근 지정
    //캡슐화(Encapsulation) 
    //객체 내부의 정보를 숨기고 외부에서 접근을 허용할 요소만 공개 하는식으로
    //  데이터의 보안을 강화 하기 위한 기능

    //학생 개체를 만드려고 하는데 성격, 학생코드, 등은 외부에 노출되면 안됨.
    //외부에서 수정을 하려하거나 아무렇게나 알 수 없어야 함.

    class Student
    {
        private static int nextID = 0;
        private int studentID;
        public string name; // 이름은 외부에 알려져있음.
        public int score; // 성적은 외부에 알려져있으며, 부여함에 따라 값이 바뀜

        //private string personality;
        protected string personality; // 성격이 존재하긴 하는데 외부에서 바꿀 수 없음.

        public Student()
        {
            studentID = nextID++;
        }

        // TODO: 1.자식이 재정의 할 수 있는 가상함수로 바꾸고
        public virtual void ChangePersonality()
        {
            if(score > 50)
            {
                int randomNumber = new Random().Next(0, 2);
                switch (randomNumber)
                {
                    case 0:
                        personality = "쾌활함";
                        break;
                    case 1:
                        personality = "솔직함";
                        break;

                }
            }
            else
            {
                int randomNumber = new Random().Next(0, 2);
                switch (randomNumber)
                {
                    case 0:
                        personality = "우울함";
                        break;
                    case 1:
                        personality = "소심함";
                        break;

                }
            }
                //this.personality = personality;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {name}, 성격 : {personality}, 성적 : " +
                $"{score}, 학생코드 : {studentID}");
        }
    }

    //대학원생
    //Postgraduate Student
    class Slave : Student
    {
        public Slave()
        {
            //studentID = 0;
        }
        //TODO : 2.부모의 ChangePersonality를 재정의
        public override void ChangePersonality()
        {
            if (score > 50)
            {
                int randomNumber = new Random().Next(0, 2);
                switch (randomNumber)
                {
                    case 0:
                        personality = "비이성적";
                        break;
                    case 1:
                        personality = "자아도취";
                        break;

                }
            }
            else
            {
                int randomNumber = new Random().Next(0, 2);
                switch (randomNumber)
                {
                    case 0:
                        personality = "반사회적";
                        break;
                    case 1:
                        personality = "무기력함";
                        break;

                }
            }
        }
    }

    //다형성(Polymorphism)
    //Dog이나, Cat이나 Animal이면 모두 Hunt를 해야하는데,
    //Dog의 Hunt와 Cat의 Hunt가 서로 다른 프로세스를 거쳐야 함.

    class Animal
    {
        public string name;
        private int health;
        protected int hunger;

        public void Turn()
        {
            hunger--;
            if(hunger <= 0)
            {
                health--;
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{name}의 정보\n배고픔 : {hunger}, " +
                $"건강 : {health}");
        }


        public Animal(string name, int health, int hunger)
        {
            this.name = name;
            this.health = health;
            this.hunger = hunger;

        }

        //가상 메소드 : 내 클래스를 상속한 자식 클래스들이 다르게 정의 할 수 있도록 허용하는 메소드
        //[접근지정자] virtual [반환 자료형] 메소드명(){}
        public virtual void Hunt()
        {
            //동물이 사냥을 하는데 기본저그올 배고픔을 채움
            hunger += 2;                                                                                                 
        }

        
    }
    class Dog : Animal
    {
        //자식의 생성자가 부모의 생성자 호출하는법
        //내 생성자 : base (부모 생성자에 전달할 파라미터)
        public Dog(string name, int health, int hunger) : base(name, health, hunger)
        {
            Console.WriteLine($"개가 생성되었습니다. 이름 : {name}");
        }
        //자식 클래스가 부모클래스의 가상메소드(또는 추상메소드)를 재정의 하기 위해서는
        // override 키워드를 사용
        //[접근지정자] override [반환형] 메소드명() {}
        public override void Hunt()
        {
            Console.WriteLine($"{name}이 사냥감을 물어 뜯습니다. \"멍멍\"");
            hunger += 10;
        }
    }

    class Cat : Animal
    {
        public Cat(string name, int health, int hunger) : base(name, health, hunger)
        {
            Console.WriteLine($"고양이가 생성되었습니다. 이름 : {name}");
        }
        public override void Hunt()
        {
            Console.WriteLine($"{name}이 사냥감을 후려칩니다. \"냐옹\"");
            hunger += 5;
        }
    }

    //추상화(Abstraction) :
    //어떤 사물의 개념에 대해서 생각했을때
    //동작을 구체화 시킬수 없는것을 프로그램으로 구현하려 할때
    //사용할 수 있는 개념

    //예시: 아이템 - 사용 기능은 있으나, 아이템마다 사용했을때의 동작이 현저히 다름
    //따라서, 아이템이라는 개념은 존재하나, 실제 객체들은 아이템을 상속하여 
    // 각자의 사용했을때의 동작을 재정의 하도록 "강제"해야 한다.


    //추상 클래스
    //[접근지정자] abstract class 클래스명 {}
    abstract class Item // 개념만 존재하도록 하겠다. new Item이란건 불가능하다.
    {
        //반드시 Item을 포함한 더 큰 객체가 있어야 한다.

        //추상메소드 : 각자 재정의 해야 하지만, 일단 Item을 상속했다면
        // 어떤 객체든 Use()라는 메소드를 가지고 있을 것을 약속합니다.
        //[접근지정자] abstract [반환명] 매소드명(); 
        public abstract void Use(); //아이템마다 내용이 너무 다를테니, 지금 쓸 내용이 없음

        
    }

    class Portion : Item
    {
        //사용했을때 체력을 회복
        public override void Use()
        {
            Console.WriteLine("포션을 사용하여 체력을 회복합니다.");
        }
    }

    class Weapon : Item
    {
        //사용했을때 무기를 장착
        public override void Use()
        {
            Console.WriteLine("무기를 장착합니다.");
        }
    }

    internal class Program
    {
        static void Main4()
        {
            Item item = new Portion();
            Item item2 = new Weapon();

            item.Use();
            item2.Use();

        }
        static void Main3()
        {
            //동물 클래스를 만들고
            //private health -> hunger가 0이면 매 턴마다 감소
            //protected hunger -> 매 턴마다 감소
            //Hunt() 라는 메소드를 통해 hunger를 채움.
            //콘솔에서 1. 사냥 2. 배회 두가지만 가지고
            //둘중 뭘 하든 턴이 지나가도록.
            // 매 턴마다 showInfo()를 통해 health와 hunger를 출력
            //동물을 상속한 개와 고양이를 만들어서
            // HuntDog() HuntCat()을 통해 다르게 사냥하도록

            Console.WriteLine("어느 동물을 선택하시겠습니까?");
            Console.Write("1.개 2.고양이");
            int choice = Convert.ToInt32(Console.ReadLine());

            //Dog dog;
            //Cat cat;
            Animal animal;

            //new Dog("강아지", 10, 10);
            //new Cat("고양이", 5, 5);


            int behaviorChoice;
            if( choice == 1)
            {
                animal = new Dog("바둑이", 10, 10);
            }
            else 
            {
                animal = new Cat("나비", 5, 5);
            }
            animal.Hunt();
            animal.ShowInfo();
        }

        static void Main()
        {
            Student stud1 = new Student()
            {
                name = "홍길동",
                score = 0,
                
            };
            //stud1.personality = "쾌활함";

            Random random = new Random();
            stud1.score = random.Next(0, 100);
            stud1.ChangePersonality();
            stud1.ShowInfo();
            Slave slave1 = new Slave()
            {
                name = "김한결"
            };
            slave1.score = random.Next(0, 100);

            //TODO: 3.ChangeSlavePersonality대신 ChangePersonality를 호출
            slave1.ChangePersonality();
            slave1.ShowInfo();
        }

        static void Main1(string[] args)
        {

            Monster slime = new Monster()
            {
                name = "슬라임",
                hp = 100
            };
            slime.Move();
            slime.TakeDamage(10);
            BossMonster kingSlime = new BossMonster()
            {
                name = "왕슬라임",
                hp = 300,
                skill = "깔아뭉개기"
            };
            kingSlime.Move();
            kingSlime.TakeDamage(20);
            kingSlime.UseSkill();


        }
    }
}
