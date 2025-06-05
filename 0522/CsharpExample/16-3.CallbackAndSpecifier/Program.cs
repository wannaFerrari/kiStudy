using System;
using System.Runtime.InteropServices;

namespace CallbackAndSpecifier
{
    //콜백과 지정자.
    //델리게이트를 통해 함수를 즉시 호출하는게 아닌, 어떤 함수를 저장해놓았다가 상황에 따라 호출 여부를 결정할 수 있음.
    //미리 받아놓는 함수를 Callback이라고 부르고,
    //어떤 함수 호출 시, 추가로 다른 함수를 매개변수로 받는 경우를 Specifier라고 부름.
    //미완성 상태의 함수를 추가 함수와 함께 호출함으로써 기능을 완성하는것.



    class File
    {
        public void Save()
        {
            Console.WriteLine("저장했습니다.");
        }

        public void Load()
        {
            Console.WriteLine("불러왔습니다.");
        }
    }

    class Button
    {
        public Action callback;
        public void OnClick()
        {
            callback?.Invoke();
        }
    }


    

    internal class Program
    {
        
        static bool IsPositive(int value)
        {
            return value > 0;
        }

        static bool isNegative(int value)
        {
            return value < 0;
        }

        static int CountIf(int[] array, Predicate<int> predicate)
        {
            int count = 0;
            for(int i =0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    count++;
                }
            }
            return count;
        }

        static bool IsOver5(int value)
        {
            return value >= 5;
        }
        static void Main()
        {
            int[] array = { -2, 1, 80, -120, -30, 30, 3, -4, -2, -3, 3, 3 ,-8};

            int positiveCount = CountIf(array, IsPositive);
            int negativeCount = CountIf(array, isNegative);

            Console.WriteLine($"양수의 개수: {positiveCount}, 음수의 개수: {negativeCount}");

            //CountIf를 호출할 때 다른 함수를 predicate로 전달하여 배열 안의 5 이상의 수의 개수를 구하도록 하세요
            int over5Count = CountIf(array,IsOver5);
            Console.WriteLine($"5이상인 수의 개수 : {over5Count}");

        }
        static void Main1(string[] args)
        {
            File file = new File();

            Button saveButton = new Button();
            saveButton.callback = file.Save;

            Button loadButton = new Button();
            loadButton.callback = file.Load;

            while (true)
            {

                Console.WriteLine("무엇을 하시겠습니까? 1.저장 2.불러오기");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        saveButton.OnClick();
                        break;
                    case 2:
                        loadButton.OnClick();
                        break;
                }
            }
        }
    }
}
