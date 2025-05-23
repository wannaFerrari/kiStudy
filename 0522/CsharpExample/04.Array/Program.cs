using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //배열이란 : 동일한 자료형을 지닌 연속된 주소의 변수
            //4byte씩, 정수로 계산되는 메모리를 할당하고 그 시작 주소를 마킹.
            //  -> 변수 명을 지어야한다
            //배열 선언 방식 : 자료형[] 배열이름
            // [] => 인덱서 : 박스 안의 정수가 순서를 의미하며 0부터 시작
            //

            //만약 int형의 배열, 5칸짜리 배열이 필요하다?
            //배열의 마지막 인덱스는 항상 전체 크기 -1
            int[] a = new int[5]; // 5칸짜리 int형 배열을 생성, 번호는 0~4
            int[] b;
            b = new int[7];
            a[0] = 10;
            a[1] = 20;
            a[2] = 30;
            a[3] = 40;
            a[4] = 50;

            Console.WriteLine($"배열 a의 0번째 요소 : {a[0]}");
            Console.WriteLine($"배열 a의 1번째 요소 : {a[1]}");
            Console.WriteLine($"배열 a의 2번째 요소 : {a[2]}");
            Console.WriteLine($"배열 a의 3번째 요소 : {a[3]}");
            Console.WriteLine($"배열 a의 4번째 요소 : {a[4]}");

            //배열 선언 방법
            int[] array1; // 배열 array1 변수를 단순 선언
            array1 = new int[6]; // 6개의 데이터를 가지는 배열을 생성
            //                          시작 주소를 array1에 대입
            int[] array2 = new int[6] { 1 , 2 , 3 , 4 , 5 , 6}; //6개의 데이터를
            //                      가지는 배열을 생성하고, 요소의 값을 초기화

            for(int i = 0; i<array2.Length-1; i++)
            {
                Console.WriteLine(array2[i]);
            }

            int[] array3 = new int[] { 3, 5, 7 }; //초기화 요소 개수만큼
            //      데이터를 가지는 배열을 생성하고, 요소의 값을 초기화
            int[] array4 = {6,7,8,9,0 };//new int[]부분은 항상 배열을 초기화할때
            //  쓰이는 구문이기도 하고, 선언시 이미 알 수 있으므로 생략 가능

            //실습 예제 : string 형의 4칸짜리 배열을 만들고, 좋아하는 과일 4개를 
            //  차례대로 입력받으세요

            //출력예시
            //좋아하는 과일을 입력하세요 : 사과
            //바나나
            //귤
            //망고
            // 당신이 좋아하는 과일 : 사과, 바나나, 귤, 망고
            string input1, input2, input3, input4;
            string[] fruit = new string[4];
            Console.Write("좋아하는 과일을 입력하세요 : ");
            /*
            input1 = Console.ReadLine();
            fruit[0] = input1;

            input2 = Console.ReadLine();
            fruit[1] = input2;

            input3 = Console.ReadLine();
            fruit[2] = input3;

            input4 = Console.ReadLine();
            fruit[3] = input4;*/

            for(int i = 0; i< 4; i++)
            {
                fruit[i] = Console.ReadLine();
            }


            Console.WriteLine($"당신이 좋아하는 과일 : {fruit[0]}, {fruit[1]}, " +
                $"{fruit[2]}, {fruit[3]}");


            //다차원배열 (2차원, 3차원, 4차원...)
            //다차원 배열의 선언 : []안에 쉼표(,)로 각 차원의 인덱스를 지정
            //특징 : 각 차원마다 크기가 동일하다 (정사각형,직사각형,...직육면체)

            //int형의 2차원 배열을 선언
            int[,] matrix;// 2차원 배열을 선언
            matrix = new int[4,3];// x축으로 4칸, y축으로 3칸만큼의 크기를 가진 2차원
            //                  배열로 메모리 생성

            //[0,0]=10    [0,1]       [0,2]
            //[1,0]       [1,1]       [1,2]
            //[2,0]       [2,1]=25    [2,2]
            //[3,0]       [3,1]       [3,2]=88

            matrix[0, 0] = 10;
            matrix[2, 1] = 25;
            matrix[3, 2] = 88;


            //3차원 배열의 선언과 동시에 초기화
            int[,,] cube = new int[2, 2, 2]
                { 
                    { 
                        { 5, 6 },{ 2,5 } 
                    },
                    {
                        { 1,34 },{ 22,66 } 
                    } 
                };

            //가변형 배열 (배열의 배열)
            //배열인데, 배열을 담은 배열..배열 수만큼 [][]개수를 추가
            // 각 배열마다 크기를 다르게 할당할 수 있음

            int[][] jaggedInts = new int[3][]; //int[]을 담을 3개의 배열 생성
            jaggedInts[0] = new int[5]; // 5칸 int 배열 할당
            jaggedInts[1] = new int[2]; // 2칸 int 배열 할당
            jaggedInts[2] = new int[3]; // 3칸 int 배열 할당
            //[0][0] [0][1] [0][2] [0][3] [0][4]
            //[1][0] [1][1]
            //[2][0] [2][1] [2][2]=39
            jaggedInts[2][2] = 39;
 




        }
    }
}
