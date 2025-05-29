using System;


namespace _0529_1
{
    class OffsetArray
    {
        private int availableOffset;
        private int[] arr;
        public OffsetArray(int input) 
        {
            this.availableOffset = input/2;
            arr = new int[input];
        }

        public int this[int index]
        {
            get
            {
                if((index >= availableOffset) || (index < (-availableOffset)))
                {
                    Console.WriteLine("배열 크기를 벗어났습니다");
                    return 0;
                }
                else
                {
                    /*
                    string stringIndex = index.ToString();
                    int realIndex = (int)(stringIndex[1]);*/
                    if (index < 0)
                    {
                        int realIndex = (int)Math.Sqrt(Math.Pow(index, 2));
                        //-5 =0
                        return arr[availableOffset - realIndex];
                    }
                    else
                    {
                        int realIndex = (int)Math.Sqrt(Math.Pow(index, 2));
                        return arr[availableOffset + realIndex];
                    }
                }
            }
            set
            {
                if ((index >= availableOffset) || (index < (-availableOffset)))
                {
                    Console.WriteLine("배열 크기를 벗어났습니다");
                    
                }
                else
                {
                    /* string stringIndex = index.ToString();
                     //int realIndex = (int)(stringIndex[1]) ;
                     int realIndex = (stringIndex.ToCharArray()[1]) ;*/
                    //int realIndex = (int)Math.Sqrt(Math.Pow(index,2));
                    //arr[realIndex] = value;
                    if (index < 0)
                    {
                        int realIndex = (int)Math.Sqrt(Math.Pow(index, 2));
                        //-5 =0
                        arr[availableOffset - realIndex] = value;
                    }
                    else
                    {
                        int realIndex = (int)Math.Sqrt(Math.Pow(index, 2));
                        arr[availableOffset + realIndex] = value;
                    }

                }
            }
        }
    }
    internal class _0529_1
    {
        //1. 음수인덱스 배열
        //생성자에서 배열 크기를 파라미터로 받는 OffsetArray 클래스를 작성
        //방법 1. : 생성자에서 지정받은 크기의 절반을 offset으로 활용하여
        //그 절반 크기의 음수 인덱스까지 접근 가능한 배열로 만들기
        //이 경우 내부에서 사용하는 배열은 생성자 파라미터 크기만큼 생성

        //방법 2. : 생성자에서 지정받은 크기를 offset으로 활용하고
        //그 만큼의 음수 인덱스까지 접근 가능한 배열로 만들기
        // 이 경우 내부에서 사용하는 배열은 생성자 파라미터 크기의 두배 만큼 생성
        static void Main(string[] args)
        {
            OffsetArray off = new OffsetArray(20);
            for(int i = -10; i < 10;  i++)
            {
                off[i] = i;
                Console.WriteLine(off[i]);
            }
            // off[-3] = 5;
            //Console.WriteLine(off[-3]);
            // Console.WriteLine((-1).ToString()[0]);
            //Console.WriteLine($"{ (char)51}");

        }
    }
}
