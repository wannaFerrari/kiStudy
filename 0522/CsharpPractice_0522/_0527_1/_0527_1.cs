using System;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

internal class _0527_1
{
    class Character
    {
        private Weapon characterWeapon;
        private Style characterStyle;
        private int hp = 100;
        private int mp = 100 ;
        private int exp = 0;
        private int lv = 1;

        public void Damaged(int damage) //뎀지입음
        {
            hp -= damage;
            Console.WriteLine($"데미지를 {damage}만큼 입었습니다!");
            Console.WriteLine($"현재 체력 : {hp}");
        }

        public void ExpGained(int exp) //경치 얻음
        {
            this.exp += exp;
            Console.WriteLine($"경험치를 {this.exp}만큼 얻었습니다 (현재 경험치 : " +
                $"{this.exp})");
            if(this.exp >= 100)
            {
                LevelUp();
            }
        }

        public void LevelUp() //렙업
        {
            lv++;
            Console.WriteLine($"레벨이 올랐습니다!");
            Console.WriteLine($"현재 레벨 : {lv}");
            exp = 0;
        }

        public void Attack() //공격하기
        {
            if (mp >= 10)
            {
                Console.WriteLine($"{characterWeapon.ReturnWeaponToString()}" +
                     $"을 사용하여 몬스터를 처치했습니다!");
                ExpGained(10);
                mp -= 10;
            }
            else
            {
                Console.WriteLine($"마나가 부족합니다!");
            }

        }

        public void Defence()
        {
            Console.WriteLine($"방어태세를 취합니다.");
        }

        public void UseItemToRecoverHp()
        {
            hp = 100;
            Console.WriteLine($"아이템을 사용하여 체력이 100으로 회복되었습니다.");
        }

        public void UseItemToRecoverMp()
        {
            mp = 100;
            Console.WriteLine($"아이템을 사용하여 마나가 100으로 회복되었습니다.");
        }

        public Character (int styleNum, int weaponNum)
        {
            characterWeapon = new Weapon(weaponNum);
            characterStyle = (Style)styleNum;
            hp = 100;
            mp = 100 ;
            exp = 0;
        }

        public string ReturnWeapon()
        {
            return characterWeapon.ReturnWeaponToString();
        }

        public string ReturnStyle()
        {
            return characterStyle.ToString();
        }
        public int ReturnLevel()
        {
            return lv;
        }
        public int ReturnHp()
        {
            return hp;
        }

        public int ReturnMp()
        {
            return mp;
        }

    }

    struct Weapon
    {
        Weapons currentWeapon;

        public int ReturnWeapon()
        {
            return (int)currentWeapon;
        }

        public void SetWeapon(int x)
        {
            currentWeapon = (Weapons)x;
        }

        public string ReturnWeaponToString()
        {
            return currentWeapon.ToString();
        }
        
        public Weapon(int x)
        {
            currentWeapon= (Weapons)x;
        }

    }

    enum Weapons
    {
        검,
        활,
        지팡이,
        표창,
        총,
        
    }

    enum Style
    {
        전사,
        궁수,
        마법사,
        도적,
        해적,
        
    }


    static void Main(string[] args)
    {
        //RPG게임의 캐릭터를 만드세요.
        // 캐릭터 : 클래스
        //무기 : 구조체
        //캐릭터의 직업 : 열거형
        // 체력, 마력, 경험치, 그 외 본인이 넣고싶은속성넣기
        //데미지입음, 경험치얻음, 공격함 등의 행동을 할 수 있도록 만들어 보세요
        //메인함수에서 임의의 전투상황을 만들어 공격.방어.체력회복.레벨업 등을 해보세요

        //심화 : 전투상황에서 어떤 행동을 할지 사용자에게 직접 입력을 받도록 해보세요
        //예시 : 어떤 행동을 하시겠습니까? 1.공격 2.아이템사용 3.방어

        //

        Console.WriteLine("캐릭터를 생성합니다.");
        Console.WriteLine("직업을 선택하세요. => 1.전사 2.궁수 3.마법사 4.도적 5.해적");
        int styleChoice = Convert.ToInt32(Console.ReadLine())-1;
        Console.WriteLine("무기를 선택하세요. => 1.검 2.활 3.지팡이 4.표창 5.총");
        int weaponChoice = Convert.ToInt32(Console.ReadLine())-1;

        Character player = new Character(styleChoice, weaponChoice);
        Console.WriteLine($"{player.ReturnWeapon()}을 사용하는" +
            $" {player.ReturnStyle()}를 생성하였습니다 ");
        Random rand = new Random();
        int monsterStatus;
        int randomDamage;
        while (true)
        {
            Console.WriteLine("===(경고) 몬스터가 등장했습니다 !===");
            monsterStatus =  rand.Next(0,3);
            randomDamage = rand.Next(0,30);
            
            Console.WriteLine($"어떻게 행동하시겠습니까?(현재 레벨 : " +
                $"{player.ReturnLevel()}, 현재 체력 : {player.ReturnHp()}" +
                $", 현재 마나 : {player.ReturnMp()}");
            Console.WriteLine("1.공격한다 2.체력을 회복한다 3.방어한다 4.마나를 회복한다");
            int behaviorChoice = Convert.ToInt32(Console.ReadLine());
            if (monsterStatus == 0)
            {
                if(behaviorChoice != 3)
                {
                    Console.WriteLine("=(경고) 몬스터가 공격을 개시합니다!!=");
                    player.Damaged(randomDamage);

                }
                else if (behaviorChoice == 3)
                {
                    Console.WriteLine("=(경고) 몬스터가 공격을 개시합니다!!=");
                    player.Defence();
                    player.ExpGained(30);
                    Console.WriteLine();
                    continue;
                }
            }
            else
            {
                Console.WriteLine("=몬스터가 공격하지 않았습니다.=");
            }
            if(behaviorChoice == 1)
            {
                player.Attack();
            }
            else if (behaviorChoice == 2)
            {
                player.UseItemToRecoverHp();
            }
            else if(behaviorChoice == 3)
            {
                player.Defence();
            }
            else if (behaviorChoice == 4)
            {
                player.UseItemToRecoverMp();
            }
            Console.WriteLine();

        }
    }
}

