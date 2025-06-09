using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0609_practice_2
{
    class Player
    {
        public string name;
        public int level;
        public string style;
        public int hp;
        public Player(string name, int level = 1, string style = "무직", int hp = 100)
        {
            this.name = name;
            this.level = level;
            this.style = style;
            this.hp = hp;
        }

        public void TakeDamage(int damage, int criticalChance = -1)
        {
            Random rand  = new Random();
            int checkCritical = rand.Next(0, 100);
            if(checkCritical < criticalChance && criticalChance != -1)
            {
                damage *= 2;
            }
            hp -= damage;
        }
    }
    internal class _0609_practice_2
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("a", 2, hp: 80);
            Player p2 = new Player("b");

            p1.TakeDamage(10, 50);
            p2.TakeDamage(10, 20);
            Console.WriteLine($"p1의 체력 : {p1.hp}, p2의 체력 : {p2.hp}");
        }
    }
}
