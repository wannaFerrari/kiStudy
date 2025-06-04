using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0604_3
{
    abstract class Buff
    {
        
        public abstract void Use();
    }

    class SpeedUP : Buff
    {
        public string name = "이속 버프";
        public int speed = 10;
        public override void Use()
        {
            Console.WriteLine("이동속도가 빨라집니다");
        }

        public static bool operator ==(SpeedUP a, SpeedUP b)
        {
            return a.speed == b.speed;
        }
        public static bool operator !=(SpeedUP a, SpeedUP b)
        {
            return !(a.speed == b.speed);
        }
    }

    class DamageUP : Buff
    {
        public string name = "데미지 버프";
        public int dam = 10;
        public override void Use()
        {
            Console.WriteLine("데미지가 증가합니다");

        }

        public static bool operator ==(DamageUP a, DamageUP b) 
        { 
            return a.dam == b.dam;
        }
        public static bool operator !=(DamageUP a, DamageUP b)
        {
            return a.dam != b.dam;
        }
    }

    class DefenceUP : Buff
    {
        public string name = "방어 버프";
        public int def = 10;
        public override void Use()
        {
            Console.WriteLine("방어력이 증가합니다");

        }

        public static bool operator ==(DefenceUP a, DefenceUP b)
        {
            return a.def == b.def;
        }
        public static bool operator !=(DefenceUP a, DefenceUP b)
        {
            return a.def != b.def;
        }
    }
    interface IBuffable
    {
        void Buff<T>(T buff) where T : Buff;
    }
    class Player : IBuffable
    {
        List<Buff> playerBuffs = new List<Buff>();
        public void Buff<T> (T buff) where T : Buff
        {
            buff.Use();
            playerBuffs.Add(buff);
        }

        public bool GetBuff<T>() where T : Buff
        {
            for (int i = 0; i < playerBuffs.Count; i++)
            {
                if (playerBuffs[i] is T)
                {
                    return true;
                }
            }
            return false;
        }

        public Buff[] GetAllBuffs<T>()
        {
            List<Buff> temp = new List<Buff>();
            for (int i = 0; i < playerBuffs.Count; i++)
            {
                if (playerBuffs[i] is T)
                {
                    temp.Add(playerBuffs[i]);
                }
            }
            if (temp.Count > 1)
            {
                return temp.ToArray();
            }
            else
            {
                return default(Buff[]);
            }
        }
    }

    class Enemy : IBuffable
    {
        List<Buff> enemyBuffs = new List<Buff>();
        public void Buff<T>(T buff) where T : Buff
        {
            buff.Use();
            enemyBuffs.Add(buff);
        }

        public bool GetBuff<T>() where T : Buff
        {
            for(int i = 0;  i < enemyBuffs.Count; i++)
            {
                if(enemyBuffs[i] is T)
                {
                    return true;
                }
            }
            return false;
        }

        public Buff[] GetAllBuffs<T>()
        {
            List<Buff> temp = new List<Buff>();
            for(int i = 0; i < enemyBuffs.Count; i++)
            {
                if (enemyBuffs[i] is T)
                {
                    temp.Add(enemyBuffs[i]);
                }
            }
            if(temp.Count > 1)
            {
                return temp.ToArray();
            }
            else
            {
                return default(Buff[]);
            }
            
        }
    }
    internal class _0604_3
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Enemy enemy = new Enemy();

            SpeedUP sUp = new SpeedUP();
            DamageUP damUp = new DamageUP();
            DefenceUP defUp = new DefenceUP();
            DefenceUP defUp2 = new DefenceUP();
            player.Buff(sUp);
            player.Buff(damUp);
            player.Buff(defUp);

            enemy.Buff(defUp2);
            if(defUp == defUp2)
            {
                Console.WriteLine("두 버프의 효과는 같습니다");
            }

            Console.WriteLine(player.GetBuff<SpeedUP>()); // 버프 있는지 확인 true, false

            Buff[] buffs = player.GetAllBuffs<SpeedUP>();
            if( buffs != null )
            {
                if (buffs.Length > 1)
                {
                    for (int i = 0; i < buffs.Length; i++)
                    {
                        Console.WriteLine(buffs[i]);
                    }
                }
                else
                {
                    Console.WriteLine("플레이어에게 같은 종류의 버프가 여러개 활성화되지 않았습니다");
                }

            }
            else
            {
                Console.WriteLine("플레이어에게 같은 종류의 버프가 여러개 활성화되지 않았습니다");
            }
            
            enemy.Buff(defUp2 );
            Buff[] buffs2 = enemy.GetAllBuffs<DefenceUP>();
            if (buffs2 != null)
            {
                if (buffs2.Length > 1)
                {
                    for (int i = 0; i < buffs2.Length; i++)
                    {
                        Console.WriteLine(buffs2[i]);
                    }
                }
                else
                {
                    Console.WriteLine("적에게 같은 종류의 버프가 여러개 활성화되지 않았습니다");
                }

            }
            else
            {
                Console.WriteLine("적에게 같은 종류의 버프가 여러개 활성화되지 않았습니다");
            }

        }
    }
}
