using System;


namespace _0528_2
{
    public abstract class Engine { public string name, comment; }

    public class I4_2000cc : Engine
    {
        public string name = "I4_2000cc";
        public string comment = "9000 RPM을 쥐어짜던 혼다의 영광스런 순간을!";
    }
    public class V6_3700cc : Engine 
    {
        public string name = "V6_3700cc";
        public string comment = "닛산의 트럼펫! 오로롱~";
    }

    public class V8_6200cc : Engine
    {
        public string name = "V8_6200cc";
        public string comment = "중독적인 슈퍼차져 소리! 위잉~";
    }

    public class V10_5200cc : Engine
    {
        public string name = "V10_5200cc";
        public string comment = "R8과 우라칸의 심장이 느껴진다! 부릉~";
    }

    public class V12_6500cc : Engine
    {
        public string name = "V12_6500cc";
        public string comment = "F1같은 귀곡성 사운드를 느껴볼 준비가 되셨나요?";
    }



    public abstract class Wheel { public string name,comment; }

    public class Enkei : Wheel
    {
        public string name = "Enkei휠";
        public string comment = "경량휠의 대가!";
    }

    public class BBS : Wheel
    {
        public string name = "BBS휠";
        public string comment = "고급스러운 고성능 휠!";
    }

    public class Work : Wheel
    {
        public string name = "Work휠";
        public string comment = "인증받은 레이싱 휠 브랜드!";
    }

    public class MOMO : Wheel
    {
        public string name = "MOMO휠";
        public string comment = "레이싱의 역사를 가진 이탈리아의 걸작!";
    }

    public abstract class Body { public string name,comment; }

    public class FR_RWD : Body
    {
        public string name = "FR_RWD";
        public string comment = "스포츠카의 기본이자 정석!";
    }

    public class FR_AWD : Body
    {
        public string name = "FR_AWD";
        public string comment = "사륜이라 미끄러지지 않아~";
    }

    public class MR_RWD : Body
    {
        public string name = "MR_RWD";
        public string comment = "진정한 스포츠카를 즐기시는군요~";
    }

    public class MR_AWD : Body
    {
        public string name = "MR_AWD";
        public string comment = "빠르고 안정적인!";
    }

    public abstract class Transmission { public string name,comment; }

    public class Auto_7 : Transmission
    {
        public string name = "7단 오토 미션";
        public string comment = "무난하고 편안한 미션~";
    }

    public class Manual_6 : Transmission
    {
        public string name = "6단 수동 미션";
        public string comment = "수동을 고른 당신은 진정한 멋쟁이!";
    }

    public class DCT_8 : Transmission
    {
        public string name = "8단 듀얼클러치 미션";
        public string comment = "이보다 빠른 변속이 필요할까요?";
    }

    public class Sequential_7 : Transmission
    {
        public string name = "7단 시퀀셜 미션";
        public string comment = "누르기도 전에 변속되는듯한 이 느낌!";
    }




    public class Car
    {
        public Engine engine = null;
        public Wheel wheel = null;
        public Body body = null;
        public Transmission transmission = null;

        public bool CheckCarCondition()
        {
            if (engine != null && wheel != null && body != null && transmission != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void SetEngine(Engine engine)
        {
            this.engine = engine;
        }

        public void SetWheel(Wheel wheel)
        {
            this.wheel = wheel;
        }

        public void SetBody(Body body)
        {
            this.body = body;
        }

        public void SetTransmission(Transmission transmission)
        {
            this.transmission = transmission;
        }

        public void ShowInfo()
        {

            Console.WriteLine($"=====자동차 정보=====");
            Console.WriteLine($"엔진 : {engine.name}");
            Console.WriteLine($"바퀴 : {wheel.name}");
            Console.WriteLine($"차체 : {body.name}");
            Console.WriteLine($"미션 : {transmission.name}");

        }
    }

    internal class _0528_2
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(); 
            while (true) {
            Console.WriteLine("=====자동차 조립하기=====");
            Console.WriteLine("[1] 엔진 추가");
            Console.WriteLine("[2] 바퀴 추가");
            Console.WriteLine("[3] 차체 추가");
            Console.WriteLine("[4] 미션 추가");
            Console.WriteLine("[5] 자동차 정보 출력");
            Console.WriteLine("[6] 시동 걸기");

            bool condition;
            int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice)
                {
                    case 1:
                        Console.WriteLine("======엔진 추가 ======");
                        Console.WriteLine("[1] I4  2000cc");
                        Console.WriteLine("[2] V6  3700cc");
                        Console.WriteLine("[3] V8  6200cc");
                        Console.WriteLine("[4] V10 5200cc");
                        Console.WriteLine("[5] V12 6500cc");
                        int engineChoice = Convert.ToInt32(Console.ReadLine());
                        if (engineChoice == 1)
                        {
                            myCar.SetEngine(new I4_2000cc());
                        }
                        else if (engineChoice == 2)
                        {
                            myCar.SetEngine(new V6_3700cc());
                        }
                        else if (engineChoice == 3)
                        {
                            myCar.SetEngine(new V8_6200cc());
                        }
                        else if (engineChoice == 4)
                        {
                            myCar.SetEngine(new V10_5200cc());
                        }
                        else if (engineChoice == 5)
                        {
                            myCar.SetEngine(new V12_6500cc());
                        }
                        break;
                    case 2:
                        Console.WriteLine("======바퀴 추가 ======");
                        Console.WriteLine("[1] ENKEI");
                        Console.WriteLine("[2] BBS");
                        Console.WriteLine("[3] WORK");
                        Console.WriteLine("[4] MOMO");
                        int wheelChoice = Convert.ToInt32(Console.ReadLine());
                        if (wheelChoice == 1)
                        {
                            myCar.SetWheel(new Enkei());
                        }
                        else if (wheelChoice == 2)
                        {
                            myCar.SetWheel(new BBS());
                        }
                        else if (wheelChoice == 3)
                        {
                            myCar.SetWheel(new Work());
                        }
                        else if (wheelChoice == 4)
                        {
                            myCar.SetWheel(new MOMO());
                        }
                        break;
                    case 3:
                        Console.WriteLine("======차체 추가 ======");
                        Console.WriteLine("[1] FR_RWD");
                        Console.WriteLine("[2] FR_AWD");
                        Console.WriteLine("[3] MR_RWD");
                        Console.WriteLine("[4] MR_AWD");
                        int bodyChoice = Convert.ToInt32(Console.ReadLine());
                        if (bodyChoice == 1)
                        {
                            myCar.SetBody(new FR_RWD());
                        }
                        else if (bodyChoice == 2)
                        {
                            myCar.SetBody(new FR_AWD());
                        }
                        else if (bodyChoice == 3)
                        {
                            myCar.SetBody(new MR_RWD());
                        }
                        else if (bodyChoice == 4)
                        {
                            myCar.SetBody(new MR_AWD());
                        }
                        break;
                    case 4:
                        Console.WriteLine("======미션 추가 ======");
                        Console.WriteLine("[1] 7단 오토 미션");
                        Console.WriteLine("[2] 6단 수동 미션");
                        Console.WriteLine("[3] 8단 듀얼클러치 미션");
                        Console.WriteLine("[4] 7단 시퀀셜 미션");
                        int mChoice = Convert.ToInt32(Console.ReadLine());
                        if (mChoice == 1)
                        {
                            myCar.SetTransmission(new Auto_7());
                        }
                        else if (mChoice == 2)
                        {
                            myCar.SetTransmission(new Manual_6());
                        }
                        else if (mChoice == 3)
                        {
                            myCar.SetTransmission(new DCT_8());
                        }
                        else if (mChoice == 4)
                        {
                            myCar.SetTransmission(new Sequential_7());
                        }
                        break;
                    case 5:
                        myCar.ShowInfo();
                        break;
                    case 6:
                        condition = myCar.CheckCarCondition();
                        if (condition == true)
                        {
                            Console.WriteLine("시동 성공! 드라이브를 시작합니다~");
                            Console.WriteLine($"{myCar.engine.name}... " +
                                $"{myCar.engine.comment}");
                            Console.WriteLine($"{myCar.wheel.name}... " +
                                $"{myCar.wheel.comment}");
                            Console.WriteLine($"{myCar.body.name}... " +
                                $"{myCar.body.comment}");
                            Console.WriteLine($"{myCar.transmission.name}... " +
                                $"{myCar.transmission.comment}");
                        }
                        else
                        {
                            Console.WriteLine("시동 실패!");
                            if (myCar.engine == null)
                            {
                                Console.Write("엔진이 없습니다!");
                            }
                            if (myCar.wheel == null)
                            {
                                Console.Write("바퀴가 없습니다!");
                            }
                            if (myCar.body == null)
                            {
                                Console.Write("차체가 없습니다!");
                            }
                            if (myCar.transmission == null)
                            {
                                Console.Write("미션이 없습니다!");
                            }

                        }
                        break;




                }
            }
        }
    }
}
