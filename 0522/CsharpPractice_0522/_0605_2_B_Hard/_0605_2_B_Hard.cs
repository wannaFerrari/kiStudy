using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace _0605_2_B
{
    class Object
    {
        public virtual string ToString()
        {
            return default(string);
        }
    }
    class Monster : Object
    {
        public string name;
        public int level;
        public float hp;

        public Monster(string name, int level, float hp)
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
        }
        public override string ToString()
        {
            return $"이름:{name}, 레벨:{level}, 체력:{hp}";
        }
    }
    internal class _0605_2_B_Hard
    {
        static void Main(string[] args)
        {
            Monster m1 = new Monster("단소살인마", 88, 10);
            Monster m2 = new Monster("자르반 84세", 84, 13);
            Monster m3 = new Monster("공항도둑", 51, 60);
            Monster m4 = new Monster("그냥 애1", 2, 20);
            Monster m6 = new Monster("그냥 애2", 1, 10);
            Monster m5 = new Monster("햄버거 최대 몇개", 28, 120);

            List<Monster> villains = new List<Monster>();
            villains.Add(m1);
            villains.Add(m2);
            villains.Add(m3);
            villains.Add(m4);
            villains.Add(m5);
            villains.Add(m6);

            Console.Write("레벨이 3 이하인 몬스터");
            Console.WriteLine();
            List<Monster> underLevel3 = villains.FindAll(x => x.level <= 3);
            foreach (Monster m in underLevel3)
            {
                Console.WriteLine(m.ToString());
            }

            Console.WriteLine();

            Console.Write("체력이 100 이상인 몬스터");
            Console.WriteLine();
            List<Monster> overHp100 = villains.FindAll(x => x.hp >= 100);
            foreach (Monster m in overHp100)
            {
                //Console.WriteLine($"이름 : {m.name}, 체력 : {m.hp}");
               Console.WriteLine( m.ToString());
            }
            Console.WriteLine();



        }
    }
}
