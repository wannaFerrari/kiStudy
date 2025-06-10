using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0610_4
{
    internal class _0610_4
    {
        static void Main(string[] args)
        {
            Console.Write("비밀번호 입력 : ");
            int pw = int.Parse(Console.ReadLine());
            bool end = false;
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            while(end == false)
            {
                Console.Write($"시도중 : {i1}{i2}{i3}");
                if(i1*100 + i2*10 + i3 == pw)
                {
                    Console.WriteLine("비밀번호를 찾았습니다!");
                    end = true;
                }
                else
                {
                    Console.WriteLine("비밀번호가 아닙니다");
                    if (i3 != 9)
                    {
                        i3++;
                    }
                    else if (i3 == 9)
                    {
                        i3 = 0;
                        if (i2 != 9)
                        {
                            i2++;
                        }
                        else if (i2 == 9)
                        {
                            i2 = 0;
                            i3 = 0;
                            i1++;
                        }
                    }
                }
            }
        }
    }
}
