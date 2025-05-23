using System;


namespace Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //반복문 : 조건문(if, switch)등과 함께 제어문
            // 블록{} 내의 구문을 반복적으로 수행함

            //for문 : 초기화, 조건식, 최종연산 으로 구성된 반복문
            //(~~하는동안)

            //for([초기화] ; [조건식]; [최종연산]) { 구문 }

            /*
            for(int i = 0; i < 5; ++i) // i-> index
            {
                Console.WriteLine($"for문이 {i+1}번째 실행됐습니다.");
            }

            Console.WriteLine("for문이 끝났습니다.");
            */


            int[] array = new int[10];

                //array의 각 요소에 10,20,30...등
                // (index+1) * 10만큼의 값을 모두 할당하고 싶다면

            for(int i = 0; i < 10; ++i)
            {
                array[i] = (i + 1) * 10;
                Console.WriteLine($"{i}번째 값 : {array[i]}");
            }

            int arrayIndex = 9;

            Console.WriteLine($"array[{arrayIndex}]의 값 : " +
                $"{array[arrayIndex]}"); //100

            //주의할 점 : 최종연산에서 인덱스의 증감연산을 누락하거나, for문 내에서
            // 인덱스(i)의 값을 제어하면 잘못하면 무한루프에 빠질 수 있다.


            //foreach문 : 어떤 순서가 있는 데이터의 집합을 순차적으로 순회하는 반복문
            //대표적으로 배열.
            //foreach(\ ([요소의 자료형] [구문 내에서 사용할 요소의 변수명]in[데이터집합(
            //                                  배열의 변수명)])
            //for문에 비해 간결하고 쉽지만, index를 직접 참조하기 어려우므로, 연산에
            //index를 알아야 할 필요가 있을때는 for문을 사용하는게 좋음.
            foreach(int element in array)
            {
                Console.WriteLine(element);
            }


            //실습 예제 : 먼저 단어 개수를 입력 받고, 해당 개수 만큼 단어를 입력받은 후
            //모든 단어들을 한줄에 이어서 출력하도록 해보세요.
            //출력 예시 :
            //몇개의 단어를 입력하시겠어요? 4
            //단어를 입력하세요 : 호랑이
            //감자
            //돌멩이
            //장난감
            //당신이 입력한 단어 : 호랑이감자돌멩이장난감

            //string inputNum;
            int number;
            
            /*

            Console.Write("몇 개의 단어를 입력하시겠어요? : ");
            number = Convert.ToInt32(Console.ReadLine());
            string[] words = new string[number];
            Console.Write("단어를 입력하세요 : ");
            for(int i = 0; i < number; i++)
            {
                words[i] = Console.ReadLine();
            }
            foreach(string element in words)
            {
                Console.Write(element);
            }

            */
            //while문 : 특정 조건이 만족 한다면 계속 반복하는 반복문
            //while([조건식]) {구문}

            /*
            while (true) //무한반복문
            {

            }*/
            /*
            while (false)//실행되지 않는 구문
            {

            }
            */

            int coin = 500;
            while (coin > 0)
            {
                coin -= 100;
                Console.WriteLine("동전 100개를 꺼냈습니다.");
                Console.WriteLine($"남은 동전 : {coin}");

            }

            Console.WriteLine("지갑이 텅 비었습니다. \\^0^/");

            //do-while문 : while문과 거의 같지만, 무조건 1회는 수행을 한다.
            //do { 구문 } while ([조건식]);

            int inputNumber;
            do
            {
                Console.Write("1~5를 입력하지 않으면 무한 반복 합니다 : ");
                string inputText = Console.ReadLine();
                int.TryParse(inputText, out inputNumber);
            } while (inputNumber < 1 || inputNumber > 5);

            //반복 제어문 : 반복문 내에서 반복 자체를 제어할 수 있는 키워드.
            //continue, break;

            //break : 해당 반복문을 즉시 끝내고 빠져나옴.
            
            while (true)
            {
                //무한 반복
                Console.WriteLine("무한 반복이 시작됐습니다.");
                break;
                Console.WriteLine("끝이 없습니다.");
            }
            Console.WriteLine("사실 무한이 아니었습니다.");

            int sum = 0;
            Random random = new Random(); // 난수를 생성하기 위한 랜덤 객체
            while (true)
            {
                sum += random.Next(10, 50);

                Console.WriteLine($"현재 총점은 {sum}점 입니다.");
                if (sum > 900)
                {
                    Console.WriteLine($"축하합니다. 기준점을 넘었습니다.");
                    break;
                }

            }

            //continue문 : 반복문 내에서 continue문을 만나면 밑의 구문은
            //  수행하지 않고 바로 반복조건 검사를 하게됨
            // 0~10까지의 숫자중 3의 배수만 빼고 모두 더하는 for문이라면


            sum = 0;
            for (int i = 0; i< 11; ++i)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine($"{i}는 3의 배수이므로 건너 뜁니다.");
                    continue;
                }
                Console.WriteLine($"{sum}에 {i}를 더합니다");
                sum += i;

            }
            Console.WriteLine($"0부터 10까지의 수 중 3의 배수를 뺀 나머지를" +
                $"모두 더한 값은 {sum} 입니다.");

            //C# (.Netframework)의 난수 생성 클래스 Random
            Random random1 = new Random();//Random 객체 생성
            random1.Next(0, 5);// 0,1,2,3,4

           
        }
    }
}
