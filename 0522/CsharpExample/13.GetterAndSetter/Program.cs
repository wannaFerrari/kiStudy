using System;
using System.Security.Cryptography;
using System.Text;


namespace GetterAndSetter
{
    //객체를 캡슐화 할때
    //(Setter) : 
    //어떤 필드는 값을 세팅할 때 일부 유효성 검사를 하거나
    //아니면 일부 필드는 값을 세팅만 하고, 얻을수는 없게 하거나
    //(Getter) :
    //반대로 연산에 중요한 값은 외부에서 세팅을 할 수 없도록 막아서 값을 얻을수만 있게 하거나
    // 또는, 값을 외부에서 얻어올 때 일종의 가공이 필요한 경우

    class Player
    {
        private string id;
        //id값을 세팅하거나 가져오는 Getter / Setter 메소드를 작성

        //심화
        //SetId "나쁜"이라는 문자열이 포함되어 있으면 Console에 경고 출력, "나쁜"을 빼고 세팅
        //GetId시  id가 6글자를 넘으면 6글자 까지만 반환
        public void SetId(string value)
        {
            id = value;

            if (value.IndexOf("나쁜") != -1)
            {
                Console.WriteLine("\'나쁜\' 이라는 단어는 사용이 불가능합니다. 자동으로 제거됩니다.");
                char[] temp = new char[];
                int tempCount = 0;
                for(int i = 0; i < value.Length; i++)
                {
                    if( i >= value.IndexOf("나쁜") && i < value.IndexOf("나쁜") + "나쁜".Length)
                    {
                        continue;
                    }
                    else
                    {
                        temp[tempCount] = value[i];
                    }
                }
            }
        }

        public string GetId()
        {
            return id;
        }
        private string pw = null; //초기값을 대입해줄 수 있음. 이 경우 생성자보다 먼저 값이 세팅됨

        //패스워드 값을 세팅하는 Setter메소드
        public void SetPw(string value)
        {
            //이미 패스워드가 설정된 경우 최초 설정값만 유지
            
            if(pw == null)
            {   //아직 비밀번호가 설정이 안됐을 경우.
                pw = value;
            }
            else
            {
                Console.WriteLine("비밀번호를 변경할 수 없습니다.");
            }
        }

        //패스워드 값을 가져오는 Getter메소드
        public string GetPw()
        {


            //MD5 해쉬 알고리즘으로 문자열을 해쉬값으로 변환
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pw));
            StringBuilder sb = new StringBuilder();
            foreach(byte byteValue in hash)
            {
                sb.Append($"{byteValue:X2}");

            }
            return sb.ToString();

            //return pw;

        }
        
        //[자료형] [필드명] 이런 필드가 있을때
        //이를 캡슐화 하고 Getter / Setter메소드를 제공할때
        //void Set[필드명]([자료형] 파라미터) {}
        //[자료형] Get[필드명]() {}

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            player.SetPw("123");
            player.SetPw("asdf");

            Console.WriteLine($"비밀번호 해쉬값 : {player.GetPw()}");
                
        }
    }
}
