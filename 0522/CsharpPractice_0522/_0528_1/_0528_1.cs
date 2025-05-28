using System;
using System.Runtime.Remoting.Activation;


namespace _0528_1
{
    abstract class Character
    {
        protected string name;
        protected int hp;
        protected int power;
        protected bool isAlive = true;

        public Character(string name )
        {
            this.name = name;
        }

        public abstract void Attack(Character other);
        
        public abstract void Damaged(int damage);

       
        public string ReturnName()
        {
            return name;
        }

        public abstract void Die();

        public abstract void ShowInfo();

        public bool ReturnIsAlive()
        {
            return isAlive;
        }

    }

    enum Style
    {
        전사,
        마법사,
        도적
    }
    class Player : Character
    {
        protected Style style;
        protected int mp;
        protected int exp;
        protected int level = 1;
        

        public Player(string name, int style) : base(name)
        {
            power = 10;
            this.style = (Style)style;
            hp = 100;
            mp = 50;
            exp = 0;
        }
        public override void Attack(Character other)
        {
            Console.WriteLine($"{name}은 {other.ReturnName()}를 공격하여" +
                $" {power}의 데미지를 입혔습니다.");
            other.Damaged(power);
            
        }

        public override void Damaged(int damage)
        {
            hp -= damage;
            if(hp <= 0)
            {
                Die();
            }
        }

        public void Defence(Character other)
        {
            Console.WriteLine($"{name}은 {other.ReturnName()}의 공격을 " +
                $"성공적으로 방어해냈습니다!");
        }

        public void UseSkill(Character other)
        {
            switch (style)
            {
                case Style.전사:
                    Console.WriteLine($"스킬 [벽력일섬] 발동!");
                    Console.WriteLine($"{name}은 {other.ReturnName()}를 공격하여" +
                        $" {40}의 데미지를 입혔습니다.");
                    other.Damaged(40);
                    break;
                case Style.마법사:
                    Console.WriteLine($"스킬 [매직 클로] 발동!");
                    Console.WriteLine($"{name}은 {other.ReturnName()}를 공격하여" +
                        $" {40}의 데미지를 입혔습니다.");
                    other.Damaged(40);
                    break;
                case Style.도적:
                    Console.WriteLine($"스킬 [암살] 발동!");
                    Console.WriteLine($"{name}은 {other.ReturnName()}를 공격하여" +
                        $" {40}의 데미지를 입혔습니다.");
                    other.Damaged(40);
                    break;
            }
        }

        public override void Die()
        {
            Console.WriteLine($"{name}이(가) 죽었습니다.");
            isAlive = false;
           // Console.WriteLine("게임을 종료합니다.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"---<플레이어>---");
            Console.WriteLine($"이름 : {name}");
            Console.WriteLine($"직업 : {style}");
            Console.WriteLine($"레벨 : {level}");
            Console.WriteLine($"체력 : {hp}");
            Console.WriteLine($"마력 : {mp}");
            Console.WriteLine($"---------------");

        }

        public void GainExp(Monster other)
        {
            int expValue = other.DropExp();
            Console.WriteLine($"경험치를 [{expValue}]만큼 획득하였습니다.");
            exp += expValue;
            if(exp >= 100)
            {
                LevelUp();
            }
            Console.WriteLine($"현재 레벨 : {level}, 현재 경험치 : {expValue}");
            Console.WriteLine();
        }

        public void LevelUp()
        {
            level++;
            exp = 0;
            Console.WriteLine($"레벨이 올랐습니다!");
            Console.WriteLine($"현재 레벨 : {level}, 현재 경험치 : {exp}");

        }
        
    }
    enum Drop
    {
        Coin,
        Gold
    }

    enum MonsterType
    {
        Slime,
        Orc,
        Golem

    }
    class Monster : Character
    {
        protected Drop drop;
        protected int gotExp;
        protected MonsterType type;
        public Monster(string name, int r) : base(name)
        {
            
            //Random rand = new Random();
            //drop = (rand.Next(0,2) == 0) ? Drop.Coin : Drop.Gold;
            drop = (r != 0) ? Drop.Coin : Drop.Gold;
            //type = (MonsterType)rand.Next(0, 3);
            type = (MonsterType)r;
            if((int)type == 0)//슬라임
            {
                hp = 10;
                gotExp = 10;
                this.power = 5;
                this.name = "슬라임";
            }
            else if ((int)type == 1)//오크
            {
                hp = 30;
                gotExp = 30;
                this.power = 10;
                this.name = "오크";
            }
            else if ((int)type == 2)//골렘
            {
                hp = 50;
                gotExp = 50;
                this.power = 15;
                this.name = "골렘";
            }
        }
        public override void Attack(Character other)
        {
            Console.WriteLine($"{name}은 {other.ReturnName()}를 공격하여" +
                $" {power}의 데미지를 입혔습니다.");
            other.Damaged(power);
        }

        public override void Damaged(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Die();
            }
        }

        public void AttackHasBeenDefenced(Character other)
        {
            Console.WriteLine($"{name}의 공격은 {other.ReturnName()}이 " +
               $"막아냈습니다!");
        }

        public override void Die()
        {
            Console.WriteLine($"{name}이(가) 죽었습니다.");
            DropItem();
            isAlive = false;
        }

        public void DropItem()
        {
            Console.WriteLine($"[{drop}] 아이템을 획득하였습니다.");
        }

        public int DropExp()
        {
            //Console.WriteLine($"경험치를 [{gotExp}]만큼 획득하였습니다.");
            return gotExp;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"---<적>---");
            Console.WriteLine($"이름 : {name}");
            Console.WriteLine($"체력 : {hp}");
            Console.WriteLine($"----------");
        }
        
    }
    internal class _0528_1
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            

            Console.Write("이름을 입력하세요 : ");
            string playerName = Console.ReadLine();

            Console.WriteLine("직업은 무엇으로 하시겠습니까?");
            Console.Write("1.전사 2.마법사 3.도적 : ");
            int styleChoice = Convert.ToInt32( Console.ReadLine() );

            Player player = new Player(playerName,styleChoice-1);
            player.ShowInfo();
            Monster[] monsters = new Monster[10];
            for(int i = 0;i< monsters.Length; i++)
            {
                int rand = random.Next(0, 3);
                monsters[i] = new Monster("initialName",rand);
            }

            Console.WriteLine("===모험을 시작합니다===");
            for(int i = 0; i< monsters.Length; i++)
            {
                Console.WriteLine("적을 만났습니다.");
                monsters[i].ShowInfo();
                if (player.ReturnIsAlive())
                {
                    while (monsters[i].ReturnIsAlive())
                    {
                        Console.WriteLine("무엇을 하시겠습니까?");
                        Console.Write("1.공격 2.스킬 3.방어");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if(choice == 1)
                        {
                            player.Attack(monsters[i]);
                            if (monsters[i].ReturnIsAlive() == true)
                            {
                                monsters[i].Attack(player);
                                player.ShowInfo();
                                monsters[i].ShowInfo();
                            }
                            else
                            {
                                player.GainExp(monsters[i]);
                            }
                        }
                        else if (choice == 2)
                        {
                            player.UseSkill(monsters[i]);
                            if (monsters[i].ReturnIsAlive() == true)
                            {
                                monsters[i].Attack(player);
                                player.ShowInfo();
                                monsters[i].ShowInfo();
                            }
                            else
                            {
                                player.GainExp(monsters[i]);
                            }
                        }
                        else if (choice == 3)
                        {
                            player.Defence(monsters[i]);
                            monsters[i].AttackHasBeenDefenced(player);
                            //player.ShowInfo();
                            //monsters[i].ShowInfo();
                        }

                    }
                }
                else
                {
                    break;
                }

            }

            
        }
    }
}
