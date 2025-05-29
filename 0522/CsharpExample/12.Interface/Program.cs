using System;


namespace Interface
{
    //인터페이스(Interface) : 매개체, 다른 객체간의 호환성을 제공하는 기능
    //C++에 있던 다중상속 기능을 부분적으로 구현 가능하도록 만들어준다.
    //내 게임에서는 플레이어가 스페이스바를 누르면 열 수 있는 물건은 뭐든지 열게 하고 싶음
    //[접근지정자] interface 인터페이스명 (보통 이름 앞에I를 붙임)
    interface IOpenable
    {
        //인터페이스 안에 들어올 수 있는 요소는 
        // 공통으로 구현할 메소드(함수)의 이름과 매개변수 정의(단 내용은 정의하지 않음)
        //프로퍼티, 이벤트 등

        //public int openCount; //인터페이스는 필드를 포함하지 않음

        //인터페이스에서 허용하는 메소드는 외부에서 반드시 호출할 수 있어야 하므로 무조건 public
        void Open(); // public을 직접 붙여서도 안된다.
    }
    
    //박스
    //인터페이스를 "구현" 하는 문법 : class 클래스명 : (부모클래스), 인터페이스명, 인터페이스명2,...
    //인터페이스를 구현하는데에는 개수 제한이 없음. ( 단, 상속한 부모 클래스가 있을 경우엔 
    // 반드시 부모 클래스 이름이 가장 앞에 와야함
    class Box : IOpenable
    {
        public virtual void Open()
        {
            Console.WriteLine("상자가 열림");
        }
    }

    //미믹
    class Mimic : Box
    {
        public override void Open()
        {
            Console.WriteLine("미믹과 전투를 시작"); ;
        }
    }

    //문
    class Door :IOpenable
    {
        public void Open()
        {
            Console.WriteLine("문이 열려서 길이 생김");
        }
    }

    class Stair : IOpenable
    {
        public void Open()
        {
            //인터페이스를 구현하기 위해 정의한 메소드는
            //재정의(override)키워드를 붙이지 않는다.
            
            Console.WriteLine("계단이 열려 비밀 문이 보입니다.");
        }
    }
    
    class Player
    {
        //스페이스바를 누른다 라는 메소드
        public void SpaceBar(IOpenable openable)
        {
            openable.Open();
        }
        
    }

    //MyFather를 상속한 Me와 FriendFather를 상속한 Friend클래스를 각각 만든다.
    //Me와 Friend는 둘다 IProgrammer 인터페이스를 구현한다.
    //IProgrammer를 구현한 클래스는 반드시 Codint()이라는 메소드를 정의한다.
    //Main에 Me와 Friend를 같은 자료형의 배열에 담아서 차례로 Codint()을 호출

    class MyFather
    {

    }

    class FriendFather
    {

    }

    class Me : MyFather, IProgrammer
    {
        public void Coding()
        {
            Console.WriteLine("나는 코딩중입니다.");
        }
    }

    class Friend : FriendFather, IProgrammer
    {
        public void Coding()
        {
            Console.WriteLine("친구는 코딩중입니다.");
            
        }
    }

    interface IProgrammer
    {
        void Coding();
       
    }
    internal class Program
    {
        static void Main()
        {
            Me me = new Me();
            Friend friend = new Friend();

            IProgrammer[] ips = new IProgrammer[] {me, friend}; 
            foreach(IProgrammer ip in ips)
            {
                ip.Coding();
            }
        }
        static void Main1(string[] args)
        {
            Box box = new Box();
            Mimic mimic = new Mimic();
            Door door = new Door();
            Stair stair = new Stair();

            //플레이어가 스페이스바를 눌렀을때 Open 을 호출하도록
            //열릴 수 있는 오브젝트면 전부 Open을 호출해서 열고 싶다.

            IOpenable[] openables = new IOpenable[] { box, mimic, door, stair };

            foreach(IOpenable open  in openables)
            {
                open.Open();
            }
            Player player = new Player();
            player.SpaceBar(openables[3]);

        }
    }
}
