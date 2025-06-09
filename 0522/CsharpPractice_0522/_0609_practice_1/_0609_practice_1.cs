using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _0609
{
    static class NewStaticClass
    {
        public static string ToWeek(this DateTime datetime)
        {
            return datetime.ToString("(ddd)");
        }

        public static int WorkCount(this string str)
        {
            string[] strings = str.Split(' ');
            return strings.Length;
        }

        public static int AverageOfArray(this int[] array)
        {
            int sum = 0;
            for(int i =0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum / array.Length;
        }
    }
    
    internal class _0609_practice_1
    {
        static void Main(string[] args)
        {
           // DateTime date = DateTime.Parse("1999-11-11");
            DateTime date = DateTime.Now;

            string stringSomething = "can i go home now?";
            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

           // Console.WriteLine(date);

           // long tick = date.Ticks;
            //Console.WriteLine(tick);

            Console.WriteLine($"오늘의 요일 : {date.ToWeek()}");

            Console.WriteLine($"단어의 개수 : {stringSomething.WorkCount()}");

            Console.WriteLine($"배열의 평균 값 : {intArray.AverageOfArray()}");
        }

        
    }
    
}
//1. 확장 메서드 만들기.
//date.ToWeek() = "월" "화" "수"
//DateTime 형태의 this 파라미터를 사용하여 요일을 표시하는 문자열로 변환하는 확장 메소드를 만들어보자