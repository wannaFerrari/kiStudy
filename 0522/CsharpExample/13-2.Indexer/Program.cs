using System;

namespace Indexer
{
    //Indexer
    // 배열과 비슷하게 인스턴스의 어떤 값을 배열처럼 인덱스로 접근 가능하도록 하는 기능.
    //이름을 따로 지정할 수는 없고, 인스턴스 자체를 이름처럼 사용함.
    //정의할때는 this[]

    class MyInt10Array
    {
        private int[] arr = new int[10];

        //인덱서를 정의할때는 
        //[접근지정자] [자료형] this[매개변수] {get; set;}
        //GetAt(0);
        public int this[int index]
        {
            get 
            {
                if(index > 9 || index < 0 )
                {
                    Console.WriteLine("내 배열에는 index가 9까지밖에 없습니다. ^^");
                    return 0;
                }
                Console.WriteLine($"내가 만든 배열을 사용해 주셨네요. 감사합니다. 인덱스는 {index} 이고" +
                    $" 받아보실 값은 {arr[index]} 입니다. ");
                return arr[index];
            }
            set
            {
                if (index > 9 || index < 0)
                {
                    Console.WriteLine("내 배열에는 index가 9까지밖에 없습니다. ^^");
                }
                Console.WriteLine($"내가 만든 배열을 사용해 주셨네요. 감사합니다. 인덱스는 {index} 이고" +
                    $" 입력하신 값은 {value} 입니다. ");
                arr[index] = value;
            }
        }

        //인덱서 오버로드
        public string this[string indexString]
        {
            get
            {
                int index = int.Parse( indexString );
                return this[index].ToString();
            }
            set
            {
                int index = int.Parse(indexString);
                this[index] = int.Parse(value);
            }

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[4];

            array[1] = 5;
            array[0] = 7;

            MyInt10Array myArray = new MyInt10Array();

            myArray[1] = 1;
            myArray[2] = 3;

            Console.WriteLine($"MyInt10Array에서 2 인덱스에 있는 값을 꺼내면 : {myArray[2]}");

            myArray["8"] = "197";
            Console.WriteLine($"MyInt10Array의 \"8\" 인덱스에 있는 값 : {myArray["8"]}");


        }
    }
}
