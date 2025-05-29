using System;
using System.Security.Cryptography;
using System.Text;


namespace Property
{
    //프로퍼티 (속성)
    //get / set 메소드를 한줄로 간소화

    class Player
    {
        private string id;
        //id에 값을 세팅하는 프로퍼티
        private string pw;

        //pw의 Getter Setter를 프로퍼티로 만들면

        //[접근지정자] [자료형] 프로퍼티명 { get{ //getter내용 }; set{ //setter 내용 } }
        public string Id
        {
            get 
            {
                return id; 
            }
            set 
            {
                id = value; 
            }
        }
        public string Pw 
        { 
            get 
            {
                //프로퍼티의 get 항목에는 반드시 return이 있어야 함
                //MD5 해쉬 알고리즘으로 문자열을 해쉬값으로 변환
                MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pw));
                StringBuilder sb = new StringBuilder();
                foreach (byte byteValue in hash)
                {
                    sb.Append($"{byteValue:X2}");

                }
                return sb.ToString();

                //return pw;
            }
            set 
            {
                //내부에서 value라는 키워드를 파라미터 처럼 사용
                if (pw == null)
                {   //아직 비밀번호가 설정이 안됐을 경우.
                    pw = value; // value를 알아서 인식해서 사용
                }
                else
                {
                    Console.WriteLine("비밀번호를 변경할 수 없습니다.");
                }
            } 
        }

        //기본적인 get; set; 기능만 사용하기 위해서는
        //필드를 생략할 수 있음
        public int Level { get; set; } // 내부적으로 _level같은 필드를 생성하긴 하나,
        // 코드 또는 프로세스에서 직접 필드에 접근은 불가

        //값을 외부에서는 Get만 가능하도록 제약을 하기 위해 Set만 private으로 접근지정 가능
        public int Hp { get; private set; }

        //프로퍼티를 읽기 전용으로 만들기 위해서는 get만 선언
        public int Damage { get; } = 10;

        //=> 람다 연산자를 배우고나면
        private int exp;
        public int Exp { get => exp; set => exp = value; }

        private float height;
        public float Height => height; // get만 가능하다는 의미
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            //프로퍼티는 필드에 접근하는 것과 같이 사용할 수 있음.
            //(변수처럼 값을 대입하거나 가져오면 됨)

            player.Pw = "123";
            player.Pw = "asdf";

            Console.WriteLine($"비밀번호 해쉬값 : {player.Pw}");
        }
    }
}
