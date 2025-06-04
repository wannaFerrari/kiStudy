using System;
using System.Collections.Generic;


namespace _0604_4
{
    class Character
    {

    }
    class Player : Character
    {
        public int hp = 100;
        public int exp = 0;
        public virtual void Attack()
        {

        }

        public virtual void Deffence()
        {

        }
    }

    class Warrior : Player
    {
        public override void Attack()
        {

        }

        public override void Deffence()
        {

        }
    }

    class Wizard : Player
    {
        public override void Attack()
        {

        }

        public override void Deffence()
        {

        }
    }

    class Archer : Player
    {
        public override void Attack()
        {

        }

        public override void Deffence()
        {

        }
    }

    class Rogue : Player
    {
        public override void Attack()
        {

        }

        public override void Deffence()
        {

        }
    }




    class Monster : Character
    {
        public int hp = 30;
        public int exp = 30;
        public virtual void Attack()
        {

        }

        public virtual void Deffence()
        {

        }
    }

    class Orc : Monster
    {
        public override void Attack()
        {

        }

        public override void Deffence()
        {

        }
    }

    class Troll : Monster
    {
        public override void Attack()
        {

        }

        public override void Deffence()
        {

        }
    }

    class Ogre : Monster
    {
        public override void Attack()
        {

        }

        public override void Deffence()
        {

        }
    }

    class Dragon : Monster
    {
        public override void Attack()
        {

        }

        public override void Deffence()
        {

        }
    }




    public class BattleStage<T1, T2>
    {
        public string playerName;
        public string comName;
        public string stageName;

        public BattleStage(T1 left, T2 right)
        {
            if (left is Player && right is Player)
            {
                this.stageName = "arena";
            }
            else if (left is Monster && right is Monster)
            {
                this.stageName = "monsterGym";
            }
            else
            {
                this.stageName = "field";
            }
        }

        public void Fight()
        {

        }
    }


    internal class _0604_4
    {
        static void Main(string[] args)
        {
            /*
            Player player1 = new Player();
            Player player2 = new Player();
            Rogue rogue = new Rogue();
            Monster monster1 = new Monster();
            Monster monster2 = new Monster();
            BattleStage<Player, Monster> field = new BattleStage<Player, Monster>(rogue, monster1);
            BattleStage<Player, Player> arena = new BattleStage<Player, Player>(player1, player2);
            BattleStage<Monster, Monster> monsterGym = new BattleStage<Monster, Monster>(monster1, monster2);*/
            /*
            Console.WriteLine("플레이어 캐릭터의 직업을 고르세요.");
            Console.WriteLine("1.전사 2.마법사 3.궁수 4.도적");
            Console.Write(" >");*/
            //int playerClassChoice = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            int playerClassChoice = rand.Next(1, 9);

            Character player = new Character();
            Character enemy = new Character();
            switch (playerClassChoice)
            {
                case 1:
                    Warrior warrior = new Warrior();
                    player = warrior;
                    Console.Write("당신은 전사입니다.");
                    break;
                case 2:
                    Wizard wizard = new Wizard();
                    player = wizard;
                    Console.Write("당신은 마법사입니다.");

                    break;
                case 3:
                    Archer archer = new Archer();
                    player = archer;
                    Console.Write("당신은 궁수입니다.");

                    break;
                case 4:
                    Rogue rogue = new Rogue();
                    player = rogue;
                    Console.Write("당신은 도적입니다.");

                    break;
                case 5:
                    Orc orc = new Orc();
                    player = orc;
                    Console.Write("당신은 오크입니다.");
                    break;
                case 6:
                    Troll troll = new Troll();
                    player = troll;
                    Console.Write("당신은 트롤입니다.");
                    break;
                case 7:
                    Ogre ogre = new Ogre();
                    player = ogre;
                    Console.Write("당신은 오거입니다.");
                    break;
                case 8:
                    Dragon dragon = new Dragon();
                    player = dragon;
                    Console.Write("당신은 드래곤입니다.");
                    break;
            }
            int monrand = rand.Next(0, 4);
            switch (monrand)
            {
                case 1:
                    Warrior warrior = new Warrior();
                    enemy = warrior;
                    Console.Write("적은 전사입니다.");
                    break;
                case 2:
                    Wizard wizard = new Wizard();
                    enemy = wizard;
                    Console.Write("적은 마법사입니다.");

                    break;
                case 3:
                    Archer archer = new Archer();
                    enemy = archer;
                    Console.Write("적은 궁수입니다.");

                    break;
                case 4:
                    Rogue rogue = new Rogue();
                    enemy = rogue;
                    Console.Write("적은 도적입니다.");

                    break;
                case 5:
                    Orc orc = new Orc();
                    enemy = orc;
                    Console.Write("적은 오크입니다.");
                    break;
                case 6:
                    Troll troll = new Troll();
                    enemy = troll;
                    Console.Write("적은 트롤입니다.");
                    break;
                case 7:
                    Ogre ogre = new Ogre();
                    enemy = ogre;
                    Console.Write("적은 오거입니다.");
                    break;
                case 8:
                    Dragon dragon = new Dragon();
                    enemy = dragon;
                    Console.Write("적은 드래곤입니다.");
                    break;

            }
            if(playerClassChoice  >= 5 && monrand >= 5)
            {
                BattleStage<Monster, Monster> monsterGym = new BattleStage<Monster, Monster>(player , enemy as Monster);
                monsterGym.Fight();
            }
            else if (playerClassChoice <5 && monrand < 5)
            {
                BattleStage<Player, Player> arena = new BattleStage<Player, Player>(player as Player, enemy as Player);

            }
            else if (playerClassChoice >=5 && monrand <5)
            {
                BattleStage<Monster, Player> field = new BattleStage<Monster, Player>(player as Monster, enemy as Player);

            }
            else
            {
                BattleStage<Player, Monster> field = new BattleStage<Player, Monster>(player as Player, enemy as Monster);

            }
            
        }
    }
}
