using System;


internal class _0523_2_hard
{
    static void Main(string[] args)
    {
        int[] array = new int[6];
        int newNumber;
        int oldNumber = -1;
        int count = 0;
        while (count < 6)
        {
            Random rand = new Random();
            newNumber = rand.Next(1, 46);
            if (newNumber == oldNumber)
            {
                continue;
            }
            else
            {
                oldNumber = newNumber;
                array[count] = newNumber;
                //Console.Write($"{array[count]} ");
                count++;
            }

        }
        Array.Sort(array);
        foreach(int i in array)
        {
            Console.Write($"{i} ");
        }
    }
}

