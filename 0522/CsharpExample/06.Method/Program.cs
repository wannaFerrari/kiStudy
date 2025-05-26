using System;


// C#의 메소드 = 다른 언어의 fuction(함수)
//메소드(함수)란?
//미리 정해진 동작을 수행하는 코드의 묶음
//어떤 처리르 미리 함수로 만들어 두면 다시 반복적으로 호출하여 수행이 가능하다

namespace _06.Method
{ 
    internal class Program
    {
        //함수의 정의 방법
        // [접근지정자] [static여부] [반환자료형] [함수명] ([매개변수]) { 함수의 내용 }
        // 접근지정자 : 클래스의 외부에서 참조 가능한 영역을 정의
        // public / protected / private ... //접근지정자를 생략할 경우 default접근지정자 적용
        //함수의 경우 default가 private 이다
        //static 여부 : 해당 요소(함수,변수 등)이 동적 할당할 요소인지, 코드 시작시에
        //  데이터 영역에 포함될 요소인지 결정
        //반환자료형 : 특정 자료형을 반환하거나, void를 통해 반환이 없는 함수를 정의 가능
        // 매개변수 : 함수를 호출시에 전달할 값. 함수 내에서 매개변수명으로 지정한 이름을 사용

        

        //두 int 값을 매개변수로 받아서 평균값을 반환해주는 함수를 정의
        public static int Average(int value1, int value2)
        {
            //(void를 제외한 모든 함수는 반환값이 있어야 한다.
            // 반환값은 return [반환값]; 으로 정의

            int result = (value1 + value2) / 2;
            Console.WriteLine("int 값의 평균을 구하는 Average호출");
            return result;
        }

        //함수의 오버로딩 : 같은 이름의 함수를 매개변수와 자료형에 차이를 줘서
        // 다른 형태로도 사용할 수 있도록 한것.

        // 두 float값을 매개변수로 받아서 평균값을 float으로 반환해주는 함수
        public static float Average(float value1, float value2)
        {
            Console.WriteLine("float 값의 평균을 구하는 Average호출");
            return (value1 + value2) / 2;
        }

        static void Main(string[] args)//모든 프로그램의 시작점이 되는 Main(메소드)
        {
            int a = 10, b = 20;

            int c = (a + b) / 2; // 정수 상태에서 두개의 값의 평균을 구할 때

            int d = 30, e = 50;

            // ...... 반복적으로 수행할 연산을 함수로 바꾸면
            int f = Average(d, e); // 40

            float float1 = 3.5f, float2 = 7.7f;
            float float3 = Average(float1, float2);

            Console.WriteLine(float3);



            // Console.WriteLine(f);

            //int형 값을 2개를 입력받고 싶다.
            //Console.WriteLine("1번째 수를 입력하세요 : ");
            //string input1 = Console.ReadLine();
            //int number1 = int.Parse(input1);

            //Console.WriteLine("2번째 수를 입력하세요 : ");
            //string input2 = Console.ReadLine();
            //int number2 = int.Parse(input2);

            //이런식으로 6개정도 반복적으로 수를 입력받고 싶은데
            //소스코드 6번 복사 붙여넣기 너무 비효율적이다.

            //for문을 통해 GetInput을 6번 호출해보자

            /*
            int[] numbers = new int[6];

            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = GetInput(i);
            }

            Console.Write("당신이 입력한 숫자 : ");

            foreach (int number in numbers)
            {
                Console.Write($"{number}, ");
            }
            */


            //Average 계산을 정수가 아닌 실수로 하고 싶을때

            a = 10;
            b = 20;
            Console.WriteLine($"a : {a}, b : {b}");

            //int temp = a;
            //a = b;
            //b = temp;
            // Non_ref_swap(a, b);
            Swap(ref a, ref b);

            Console.WriteLine($"a와 b의 자리를 바꿨습니다. a : {a}, b : {b}");

            a = 5;
            b = 2;

            //out 파라미터가 포함된 함수 호출시, 해당 파라미터에 변수를 out키워드와
            // 함께 전달하거나, 
            int remainder;
            int result = Div(a, b, out remainder);
            Console.WriteLine($"{a}와 {b}를 나눗셈. 몫 : {result}, 나머지 : {remainder}");

            //추가적으로, out 파라미터가 포함된 함수를 호출시 out키워드가 붙은 파라미터는
            // 해당 함수 라인에서 바로 선언이 가능

            d = 8;
            e = 3;
            result = Div(a, b, out int rem);
            Console.WriteLine($"{a}와 {b}를 나눗셈. 몫 : {result}, 나머지 : {rem}");


        }

        static void Non_ref_swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        ///문서화주석 태그 유형
        ///summary : 일반 설명
        ///param : 함수의 매개변수에 대한 설명, name 항목에 문자열을 대입하여 어떤 매개변수에
        ///대한 설명인지 지정
        ///returns : 함수의 반환값에 대한 설명

        /// <summary>
        /// 문서화 주석 : 소스코드에는 영향을 미치지 않지만, IDE에서 해당 요소에 대한 설명을
        ///출력해줄때 인지하여 보여줌
        ///문서화 주석은 일반 주석 내용은 IDE에서 무시하나, 꺽쇠 안의 "태그"를 이용하여
        ///해당 요소가 어디에 대한 설명인지 명시할 수 있음.
        /// </summary>
        /// 
        ///<summary>
        ///사용자의 입력을 int로 변환해주는 함수.
        ///</summary>
        ///<param name="index">몇번째 입력인지?<br/>예시: 0번째 정수를 입력하세요 : </param>
        ///<returns>콘솔에서 입력한 입력값을 정수로 반환</returns>




        //입력 받는 절차를 함수로 만들자.
        static int GetInput(int index)
        {
            //index번째 값을 입력하세요 라고 우선 출력
            //int로 변환 가능한 입력이 들어올 때 까지 반복
            while (true)
            {
                Console.Write($"{index}번째 정수를 입력하세요 : ");
                string input = Console.ReadLine();
                if(int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("숫자를 입력하세요. ");
                }

            }

        }
        //함수의 파라미터 ref 키워드
        //매개변수를 값 타입이 아닌 "참조(Reference)"타입으로 간주하여 연산

        /// <summary>
        /// 함수를 호출할 때 a와 b의 변수 안의 값을 직접 바꿀때
        /// </summary>
        static void Swap(ref int a, ref int b)
        {
            //값 형태로 사용할 파라미터 선언 앞에 ref 키워드를 붙여서 선언함
            int temp; //임시 변수
            temp = a;
            a = b;
            b = temp; 


        }

        //함수의 파라미터 out 키워드
        // 함수의 기본적인 반환값 이외에 다른 반환이 필요할 경우. 말하자면 제2의 반환값
        static int Div( int a, int b, out int rem)
        {
            int result = a / b; // 나눗셈의 몫
            rem = a % b; // 나눗셈의 나머지도 함수 밖으로 빼내고 싶다.
            //out 키워드가 있는 파라미터의 제약사항 : 
            // 함수 내에서 반드시 out 키워드가 붙은 매개변수에도 값을 할당해줘야 함.
            //rem = remind
            return result;
        }
    }
}
