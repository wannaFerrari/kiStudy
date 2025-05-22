/* 자료형(DataType)
 * 데이터의 형태를 지정함.
 * 컴퓨터는 0과 1로만 이루어진 정보만 취급이 가능한데, 이를 사람이 실제 사용하는
 * 자료(Data)로서 활용하기 위해서는 해당 자료가 어떤 형태의 자료인지 명시가 필요함.
 * */

/* 기본 자료형 : C언어 시절부터 사용되어 온 데이터의 타입
        자료형 이름       자료 형태          메모리 크기          표현 범위 

 *         bool         논리 자료형          1byte              true, false
 *         Int          부호 있는 정수       4byte      -2^31 ~ 2^31-1 => 약 -21억 ~ 21억
 *         float        부동 소수점 실수     4byte   3.4e-38 ~ 3.4e+38 => 약 소수점 7자리
 *         char         문자(Ascii->Unicode)2byte         'A' 'B' '가' '!' '1' 등등
 *         
 *         
 *         byte         부호 없는 정수       1byte               0 ~ 255
 *         Sbyte        부호 있는 정수       1byte            -128 ~ 127
 *         short        부호 있는 정수       2byte    -2^15 ~ 2^15-1 => -32,768 ~ 32,767
 *         ushort       부호 없는 정수       2byte    0 ~ 2^16-1     => 0 ~ 65,545
 *         int          부호 있는 정수       4byte    -2^31 ~ 2^31-1 => 약 -21억 ~ 21억
 *         uint         부호 없는 정수       4byte    0 ~ 2^31 -1    => 약 42억
 *         long         부호 있는 정수       8byte    -2^63 ~ 2^63-1 => 약 -900경 ~ 900경
 *         ulong        부호 없는 정수       8byte    0 ~ 2^64-1     => 약 1800경
 *         
 *         float        부동소수점 실수      4byte    3.4e-38 ~ 3.4e+38 => 소수점 약 7자리
 *         double       부동소수점 실수      8byte    1.6e-308 ~ 1.7e+308 => 소수점 약 15자리
 *         
 *         char         문자(Ascii->Unicode)2byte         'A' 'B' '가' '!' '1' 등등
 *         string       문자열              가변적        "abcde", "Hello World" 등등
 */

//프로그래밍(C계열)언어에서 ;의 의미 : 한 명령 라인의 끝을 의미.
using System;

namespace DataType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 변수 (Variable)
             * 데이터를 저장하기 위해 프로그램에게 이름을 할당 받은 메모리공간
             * 데이터를 저장한 수 있는 메모리 공간이며, 일반적으로 값 변경이 가능
             */
            // 변수를 사용하는 방법 : 선언과 정의(초기화)
            // 변수를 선언할 때는 자료형과 변수명을 명시하면 됨
            int a; // a라는 이름의 변수를 선언하고, 이 변수에 저장될 데이터는 정수임을 명시
            a = 10; //a라는 변수에 정수값 10을 대입.

            //Console.WriteLine(a);

            a = 9;

            //Console.WriteLine(a);

            //변수는 선언과 동시에 값을 대입하여 초기화 할 수 있음.
            //같은 자료형의 변수는 쉼표(,)로 구분하여 여러개 선언 할 수 있음.
            int b = 8, c = 7;

            //Console.Write(a);
            //Console.Write(b);
            //Console.Write(c);

            int d;
            Int32 e;

            short f;
            Int16 g;
/*
            Console.WriteLine($"정수형 변수 int는 \n최대 {int.MaxValue} 부터\n" +
                $"최소 {int.MinValue}까지\n 값을 저장하는 변수. \n변수 a의 타입 : " +
                $"{a.GetType()}, 변수 a의 크기 : {sizeof(int)}byte");
*/
            byte byteValue = 0;
            sbyte sbyteValue = 1;

            short shortValue = 3;
            ushort ushortValue = 5;

            int intValue = 6;
            uint uintValue = 8;

            long longValue = 33;
            ulong ulongValue = 494;
/*
            Console.WriteLine($"정수형 변수 byte는 \n최대 {byte.MaxValue} 부터\n" +
                $"최소 {byte.MinValue}까지\n 값을 저장하는 변수. \n변수 a의 타입 : " +
                $"{byteValue.GetType()}, 변수 a의 크기 : {sizeof(byte)}byte");

            Console.WriteLine($"정수형 변수 sbyte는 \n최대 {sbyte.MaxValue} 부터\n" +
                $"최소 {sbyte.MinValue}까지\n 값을 저장하는 변수. \n변수 a의 타입 : " +
                $"{sbyteValue.GetType()}, 변수 a의 크기 : {sizeof(sbyte)}byte");

            Console.WriteLine($"정수형 변수 short는 \n최대 {short.MaxValue} 부터\n" +
                $"최소 {short.MinValue}까지\n 값을 저장하는 변수. \n변수 a의 타입 : " +
                $"{shortValue.GetType()}, 변수 a의 크기 : {sizeof(short)}byte");

            Console.WriteLine($"정수형 변수 ushort는 \n최대 {ushort.MaxValue} 부터\n" +
                $"최소 {ushort.MinValue}까지\n 값을 저장하는 변수. \n변수 a의 타입 : " +
                $"{ushortValue.GetType()}, 변수 a의 크기 : {sizeof(ushort)}byte");

            Console.WriteLine($"정수형 변수 int는 \n최대 {int.MaxValue} 부터\n" +
                $"최소 {int.MinValue}까지\n 값을 저장하는 변수. \n변수 a의 타입 : " +
                $"{intValue.GetType()}, 변수 a의 크기 : {sizeof(int)}byte");

            Console.WriteLine($"정수형 변수 uint는 \n최대 {uint.MaxValue} 부터\n" +
                $"최소 {uint.MinValue}까지\n 값을 저장하는 변수. \n변수 a의 타입 : " +
                $"{uintValue.GetType()}, 변수 a의 크기 : {sizeof(uint)}byte");

            Console.WriteLine($"정수형 변수 long는 \n최대 {long.MaxValue} 부터\n" +
                $"최소 {long.MinValue}까지\n 값을 저장하는 변수. \n변수 a의 타입 : " +
                $"{longValue.GetType()}, 변수 a의 크기 : {sizeof(long)}byte");

            Console.WriteLine($"정수형 변수 ulong는 \n최대 {ulong.MaxValue} 부터\n" +
                $"최소 {ulong.MinValue}까지\n 값을 저장하는 변수. \n변수 a의 타입 : " +
                $"{ulongValue.GetType()}, 변수 a의 크기 : {sizeof(ulong)}byte");

            Console.WriteLine();
*/
            float fValue = 1.23456f; //실수는 정수와 다르게 소숫점 표현이 가능.
            double dValue = 1.23456;
/*
            Console.WriteLine($"실수형 변수 float의 크기는 {sizeof(float)}byte." +
                $"\nfValue 의 값 : {fValue}");
            Console.WriteLine($"실수형 변수 double의 크기는 {sizeof(double)}byte." +
                $"\nfValue 의 값 : {dValue}");
*/
           // Console.WriteLine();

            char charValue = 'a';//문자형 변수는 사실 정수와 문자를 1:1 매칭 시켜놓은것
                                   // c언어에서는 Ascii코드를 사용하여 1byte만 차지하였으나
                                   //C#에서는 유니코드를 사용하므로 2byte가 필요.

         /*   Console.WriteLine($"문자형 변수 char의 크기는 {sizeof(char)}byte." +
                $"\nfValue 의 값 : {charValue}");
         */
            string stringValue = "문자열";//문자열은 단순히 말하면 문자의 연속된 배열이다.
                                       //문자열은 길이에 따라 메모리에서 차지하는 공간이 달라지므로실제 메모리 공간은
                                       //가변적이기 때문에 크기를 측정할 수 없음.
            //문자열 앞에 $표시 : 보간 문자열. 문자열 사이에 특정 변수의 값을
            //끼워넣기가 가능.
            stringValue = $"문자열은 종류가 여러가지로 표현 가능.{charValue}";

          //  Console.WriteLine(stringValue);

            //문자열 앞에 @표시 : 표현 문자열. 문자열 내의 특수문자(\)등을 그대로 표현. 
            stringValue = @"줄바꿈을 위한 역슬래시 무시됨. \n 대신 문자열 안에 엔터키로 줄바꿈을 하면 줄이 바뀜
큰 따옴표를 쓰고 싶으면 큰 따옴표 두개""로 표시 가능";

            // Console.WriteLine(stringValue);

            //형 변환(Casting)
            //어떤 자료형으로 저장된 데이터를 다른 자료형으로 변환하는것
            //암시적 형변환, 명시적 현변환, 문자열 형변환

            // 암시적 형변환 : 형변환시 큰 무리(데이터 손실)가 없는 경우,
            //      별도의 명시가 없이 자료형 변환이 가능
            int int1 = 2000000011, int2 = 2000000000;
            long long1 = int1, long2 = int2; 
            //int형의 변수값을 long형의 변수에 대입할때,
            //int -> long 으로 암시적 형변환이 이루어짐
            Console.WriteLine(long1 + long2);
            float float1 = 0.001f;
            double double1 = float1;
            //암시적 형변환은 시스템상 문제 없지만, 코드 가독성이 떨어지므로,
            //암시적 형변환이 가능하더라도 명시적으로 형변환을 해주는 것이 좋다.

            //명시적 형변환 : 형변환시 데이터 손실 우려가 있어 손실을 감수하고 변환될
            //              데이터 타입을 앞에 명시해줌.
            int1 = (int)long1; //이 경우에는 데이터 손실이 일어날 수 있으므로,
            //              명시적으로 형변환을 해야함 (데이터손실을 감수)
            //long -> int , 큰 자리수의 4byte는 손실됨.
            float1 = (float)double1;

            int someInt = (int)32.23f;
            Console.WriteLine($"32.23f float 데이터를 int로 형변환 했을 경우의 값 : " +
                $"{someInt}");
            //float -> int 실수형 데이터를 정수형 데이터로 캐스팅할때,
            //소수점 이해 값을 버림

            //int -> float 암시적 형변환이 가능함.
            float someFloat = someInt;

            char someChar = '1';
            someInt = someChar;
            //char -> int 암시적 형변환 가능
            Console.WriteLine($"char '1' 데이터를 int로 형 변환 했을 경우의 값 : " +
                $"{someInt}");

            someChar = (char)98;
            //int -> char 명시적 형변환 해야함
            Console.WriteLine($"int 98을 char로 형 변환 했을 경우의 값 : " +
                $"{someChar}");

            //문자열 형변환
            //문자열은 단순 변환이 불가능하며, 사실상 문자 하나 하나를 읽어서
            //데이터로 변환 시키는 과정이 필요하다
            //이 과정은 매우 빈번히 일어나기 때문에 닷넷에서 기능을 제공한다
            //Convert 클래스 또는 각 자료형의 Parse, TryParse 메소드를 사용

            int sToInt1 = Convert.ToInt32("132");
            int sToInt2 = int.Parse("201");
            int sToInt3 = sToInt1 + sToInt2;

            Console.WriteLine($"sToInt3의 값 : {sToInt3}");

            string number = "123";
            string notNumber = "가나다";
            
            bool isNumber = int.TryParse(number, out int sToInt4);
            Console.WriteLine($"숫자로 변환이 가능한가요? {isNumber}");

            //반대로 다른 데이터를 문자열로 변환 하는건?
            //모든 객체에 존재하는 ToString() 메소드를 통해 변환
            string text1 = someInt.ToString();
            string text2 = 1.3f.ToString("E2");
            Console.WriteLine($"1.3f 를 포맷 코드를 통해 문자열로 변환한 결과 : " +
                $"{text2}");
            Console.WriteLine($"보간 문자열에서도 포맷 코드를 쓸 수 있다. " +
                $"{112341.3f:N3}");

        }
    }
}
