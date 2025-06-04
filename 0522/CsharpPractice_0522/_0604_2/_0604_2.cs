using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0604_2
{
    class Item
    {
        
    }

    class Dagger : Item
    {

    }

    class Potion : Item
    {

    }

    class Feather : Item
    {

    }

    class Stone : Item 
    {

    }

    internal class _0604_2
    {
        static void Main(string[] args)
        {
            List<Item> list = new List<Item>();
            while (true)
            {


                Console.WriteLine("상점에 어서오세요.");
                Console.WriteLine("1.아이템사기 2.아이템팔기 3.내아이템 보기");
                Console.Write("> ");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("무엇을 사시겠습니까?");
                    Console.WriteLine("1.포션 2.단검 3.돌멩이 4.깃털");
                    Console.Write("> ");
                    int buyChoice = Convert.ToInt32(Console.ReadLine());
                    if (buyChoice == 1)
                    {
                        list.Add(new Potion());
                    }
                    else if (buyChoice == 2)
                    {
                        list.Add(new Dagger());
                    }
                    else if (buyChoice == 3)
                    {
                        list.Add(new Stone());
                    }
                    else if (buyChoice == 4)
                    {
                        list.Add(new Feather());
                    }

                }
                else if (choice == 2)
                {
                    Console.WriteLine("무엇을 파시겠습니까?");
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] is Potion)
                        {
                            Console.WriteLine($"{i + 1}.포션");
                        }
                        else if (list[i] is Dagger)
                        {
                            Console.WriteLine($"{i + 1}.단검");

                        }
                        else if (list[i] is Stone)
                        {
                            Console.WriteLine($"{i + 1}.돌멩이");

                        }
                        else if (list[i] is Feather)
                        {
                            Console.WriteLine($"{i + 1}.깃털");

                        }
                    }
                    Console.Write("> ");
                    int sellChoice = Convert.ToInt32(Console.ReadLine());
                    list.RemoveAt(sellChoice - 1);
                }
                else if (choice == 3)
                {
                    Console.WriteLine("======아이템 목록======");
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] is Potion)
                        {
                            Console.WriteLine($"{i + 1}.포션");
                        }
                        else if (list[i] is Dagger)
                        {
                            Console.WriteLine($"{i + 1}.단검");

                        }
                        else if (list[i] is Stone)
                        {
                            Console.WriteLine($"{i + 1}.돌멩이");

                        }
                        else if (list[i] is Feather)
                        {
                            Console.WriteLine($"{i + 1}.깃털");

                        }
                    }
                    Console.WriteLine("=====================");
                }

            }

        }
    }
}
