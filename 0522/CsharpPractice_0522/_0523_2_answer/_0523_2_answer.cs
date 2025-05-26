using System;


internal class _0523_2_answer
{
    static void Main(string[] args)
    {
        //로또 번호 추첨기
        Random random = new Random();
        int[] numbers = new int[6]; // 6개 크기의 배열 선언 및 초기화

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 46);//번호 하나 뽑기
            //기존에 뽑은 번호중에 중복되는 번호가 있는지 검사

            for(int j = 0; j < i; j++)
            {
                if(numbers[i] == numbers[j])
                {
                    //기존에 뽑힌 번호와 같은 번호가 numbers 배열에 이미 있는경우
                    //numbers[i]를 한번 더 뽑음 => 이번 i를 무시하고 다시 한번
                    //돌리기 위해 i값을 1만큼 감소
                    i--;
                    break; // 더이상 검사할 이유가 없으므로 break;
                }
            }
        }

        // (심화문제 해결) 정렬 알고리즘. (삽입, 선택, 버블)
        Array.Sort(numbers); 

        //numbers 출력
        foreach (int number in numbers)
        {
            Console.Write($"{number}, ");
        }
    }
}

