using System;

namespace _0529_3
{

    class Stupid
    {
        Random rand = new Random(DateTime.Now.Millisecond);
        private string data;
        private int type;

        public string Data
        {
            get
            {
                int which = rand.Next(0, 3);
                switch (which)
                {
                    case 0://정수
                        data = rand.Next(0, 100).ToString();
                        type = 0;
                        break;
                    case 1://실수
                        data = (rand.Next(0, 100) + rand.NextDouble()).ToString();
                        type = 1;
                        break;
                    case 2://문자
                        type = 2;
                        if(rand.Next(0,5) == 0)
                        {
                            data = "메롱";
                            break;
                        }
                        else if (rand.Next(0, 5) == 1)
                        {
                            data = "나는 바보에요";
                            break;
                        }
                        else if (rand.Next(0, 5) == 2)
                        {
                            data = "배고파요";
                            break;
                        }
                        else if (rand.Next(0, 5) == 3)
                        {
                            data = "안녕할까요?";
                            break;
                        }
                        else if (rand.Next(0, 5) == 4)
                        {
                            data = "우와 과제끝이다~";
                            break;
                        }
                        else
                        {
                            data = "멍멍";
                            break;
                            
                        }
                    default:
                        data = "안녕하진 않네요";
                        break;
                }
                return data;
            }
            set
            {
                if(value.GetType() == typeof(int))
                {
                    value = value.ToString();
                    type = 0;
                }
                else if (value.GetType() == typeof(double))
                {
                    value = value.ToString();
                    type = 1;
                }
                else
                {
                    type = 3;
                }
                    data = value;
            }
        }
    }
    internal class _0529_3
    {
        static void Main(string[] args)
        {
            Stupid stupid = new Stupid();
            while (true)
            {
                Console.WriteLine("무엇을 입력하시겠습니까?");
                Console.WriteLine("1.정수 2.실수 3.문자");
                Console.Write("> ");
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                
                switch (menuChoice)
                {
                    case 1:
                        Console.Write("정수를 입력하세요 : ");
                        break;
                    case 2:
                        Console.Write("실수를 입력하세요 : ");
                        break;
                    case 3:
                        Console.Write("문자를 입력하세요 : ");
                        break;
                }
                string typedData = Console.ReadLine();
                stupid.Data = typedData;
                Console.WriteLine($"입력하신 값 : {stupid.Data}");
                Console.WriteLine();
                
            }
        }
    }
}
