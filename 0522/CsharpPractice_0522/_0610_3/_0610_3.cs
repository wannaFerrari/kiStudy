using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0610_3
{
    internal class _0610_3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("문자열을 입력하세요");
            string input = Console.ReadLine();
            
            Dictionary<char,int> dic = new Dictionary<char,int>();
            Array inputArr = input.ToArray();
          
            foreach(char c in inputArr)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic.Add(c, 1);
                }
            }
           
            var sortedDict = dic.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
           
            foreach (char c in sortedDict.Keys)
            {
                if(c != ' ')
                {
                    Console.WriteLine($"{c} : {sortedDict[c]}");

                }
            }
           
        }
    }
}
