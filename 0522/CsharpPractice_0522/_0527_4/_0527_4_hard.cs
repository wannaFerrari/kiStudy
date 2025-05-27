using System;



internal class _0527_4_hard
{
    class Calculator
    {
        int a;
        int b;

        public Calculator(int a, int b)
        {
            this.a = a;
            this.b = b;
            //Calculate((Operation)c);
        }

        public int Calculate(Operation op)
        {
            int result=0;
            switch (op)
            {
                case Operation.Add:
                    result =  this.a + this.b;
                    break;
                case Operation.Sub:
                    result = this.a - this.b;
                    break;
                case Operation.Mul:
                    result = this.a * this.b;
                    break;
                case Operation.Div:
                    result = this.a / this.b;
                    break;
                case Operation.Rem:
                    result = this.a % this.b;
                    break;
                default:
                    break;

            }
            return result;
        }
        /*
        public int Add()
        {
            return a + b;
        }

        public int Sub()
        {
            return a - b;
        }
        public int Mul()
        {
            return a * b;
        }
        public int Div()
        {
            return a / b;
        }

        public int Rem()
        {
            return a % b;
        }*/

    }




    static void Main(string[] args)
    {
        Console.Write("첫번째 수를 입력하세요 : ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("두번째 수를 입력하세요 : ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("1.덧셈 2.뺄셈 3.곱셈 4.나눗셈 5.나머지");
        Console.Write("어떤 연산을 하시겠습니까? : ");
        int c = Convert.ToInt32(Console.ReadLine());

        Calculator cal = new Calculator(a, b);

        Console.WriteLine($"결과 : {cal.Calculate((Operation)c - 1)}");


    }

    enum Operation
    {
        Add,
        Sub,
        Mul,
        Div,
        Rem

    }
}

