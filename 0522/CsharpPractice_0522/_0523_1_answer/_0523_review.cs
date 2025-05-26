using System;

internal class _0523_review
{
    static void Main(string[] args)
    {
        //콘솔에 출력
        Console.WriteLine("Hello world");
        //콘솔 입력 받을때
        string input = Console.ReadLine();

        //변수 선언 : [자료형] 변수명;
        int a = 1;

        //연산자 : 수식을 계산하여 대입연산자를 통해 변수에 저장

        int b = 3;
        int c = 0;
        c = a + b; // 1 + 3 = 4

        //비교 연산의 경우 값이 bool 형태로 반환된다.

        bool d = 1 < 3;  // true;
        bool e = 1 > 3;  // false;

        //조건문의 조건식을 통해 프로그램을 제어할때 사용한다.

        if (1 < 3/*조건식*/)
        {
            //if 문의 조건식 결과가 true 냐 false 냐에 따라 구문 수행 여부 달라짐

        } // else if 또는 else 가 붙을 수 있음

        // else if 는 앞에 반드시 if 또는 else if문이 와야하며, 앞의 if문의 조건식이
        //  거짓일 경우에만 다음 else if 문의 조건을 검사함.

        else if (5 < 7)
        {
            //앞의 if문의 조건이 거짓일 겨우에만 검사하고, 
            //검사 결과가 true 이면 수행.
        }

        else
        {
            //앞에 반드시 if 또는 else if 문이 와야하며 ,앞에 연결된 
            // if - else 문이 모두 거짓일 경우메나 수행됨.
        }

        //switch-case 문 : 조건 내용이 case와 일치하는 구문을 수행
        int switchCondition = 5;
        switch (switchCondition)
        {
            case 0:
                //switchCondition이 0일 경우 수행
                break;
            case 5:
                //switchCondition이 5일 경우 수행
                break;
            default:
                //default 는 switch 문의 case에 해당하는 값이 하나도 없을 경우
                break;

        }


        //배열은 같은 자료형의 연속된 변수 공간
        int[] array;
        array = new int[5]; //5 개의 int 변수 공간을 가진 메모리 할당
        array[0] = 0;
        array[1] = 1;
        array[2] = 2;
        array[3] = 3;
        array[4] = 4;

        //반복문 
        //for([초기화식]; [조건식]; [최종연산]) {구문}
        for (int i = 0; i < 5; i++)
        {

        }

        //팁1: for문 내의 조건식이 비어있을 경우, 무한반복, while(true) 처럼 동작
        /*for (; ; )
        {
            //무한 반복
        }*/

        //foreach문 : 순서가 있는 데이터 집합(배열)을 순차적으로 순회
        //foreach문을 통해 요소에 접근할 경우, 참조만 가능하고 값 변경은 불가
        foreach(int element in array)
        {
            //element = 5와 같은 값 변경이 불가
        }

        //while문, do-while문
        bool key = true;
        while (key)
        {
            key = false;
        }


        do
        {
            //반드시 한번은 수행됨

        } while (key);

        //continue / break문
        //continue : 루프를 바로 반복
        //break : 루프를 즉시 종료



    }
}

