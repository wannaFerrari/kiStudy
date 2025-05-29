using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;


//추상클래스
//엔진, 바퀴, 차체, 미션 => 추상 클래스 => 추상 메소드를 정의 
// 추상 메소드란? => 자식들에게 반드시 재정의를 강제하는 메소드

abstract class Engine 
{
    public string engineName;
    //엔진이라면 응당 회전 운동을 할 수 있어야 함
    public abstract void Combustion();
}

class VQ37VHR : Engine
{
    public VQ37VHR()
    {
        engineName = "VQ37VHR";
    }
    public override void Combustion()
    {
        Console.WriteLine("V6 N/A의 트럼펫 사운드~");
    }
}

class VR38DETT : Engine
{
    public VR38DETT()
    {
        engineName = "VR38DETT";
    }
    public override void Combustion()
    {
       // throw new NotImplementedException();   //아직 개발자가 명시적으로 구현하지 않고 자동완성을 통해 만들어짐을 알림
        Console.WriteLine("V6 트윈터보의 GTR!");
    }
}


abstract class Wheel 
{
    
    public string wheelName;
    public abstract void Spin();
}

class BBS : Wheel
{
    public BBS()
    {
        wheelName = "BBS";
    }
    public override void Spin()
    {
        Console.WriteLine("크롬이 반짝반짝");
    }
}

class Enkei : Wheel
{
    public Enkei()
    {
        wheelName = "Enkei";
    }
    public override void Spin()
    {
        Console.WriteLine("역시 경량휠이 경쾌하다..");
    }
}

abstract class Body 
{
    
    public string bodyName;
    public abstract void Absorbe();
}

class AluminiumBody : Body
{
    public AluminiumBody()
    {
        bodyName = "AluminiumBody";
    }
    public override void Absorbe()
    {
        Console.WriteLine("알루미늄만 해도 최고지~");
    }
}

class CarbonBody : Body
{
    public CarbonBody()
    {
        bodyName = "CarbonBody";
    }
    public override void Absorbe()
    {
        Console.WriteLine("풀카본바디면 이게 얼마야..");
    }
}
abstract class Transmission 
{
    public string transmissionName;
    public abstract void GearChange();
}

class PDK : Transmission
{
    public PDK()
    {
        transmissionName = "PDK미션";
    }
    public override void GearChange()
    {
        Console.WriteLine("이보다 빠른 듀얼클러치는 없다..");
    }
}

class Sequential : Transmission
{
    public Sequential()
    {
        transmissionName = "Sequential미션";
    }
    public override void GearChange()
    {
        Console.WriteLine("내 생각을 읽고 미리 변속때리는 이 느낌..");
    }
}

class Car
{
    //위에서 작성한 파츠들을 내부 요소로 가지고 있는 클래스
    public Engine engine;
    public Wheel wheel;
    public Body body;
    public Transmission transmission;

    public void ShowInfo()
    {
        Console.WriteLine("========자동차 정보========");
        Console.WriteLine($"엔진 : {(engine!=null ? engine.engineName : "없음")}");
        Console.WriteLine($"바퀴 : {(wheel!=null ? wheel.wheelName : "없음")}");
        Console.WriteLine($"차체 : {(body!=null ? body.bodyName : "없음")}");
        Console.WriteLine($"미션 : {(transmission!=null ? transmission.transmissionName : "없음")}");
        Console.WriteLine("==========================");
    }
    public void SetEngine(int choice)
    {
        //파라미터로 전달된 선택값에 따라 다른 엔진을 추가
        switch (choice)
        {
            case 1:
                engine = new VQ37VHR();
                break;
            case 2:
                engine = new VR38DETT();
                break;

        }
    }

    public void SetWheel(int choice)
    {
        switch (choice)
        {
            case 1:
                wheel = new BBS();
                break;
            case 2:
                wheel = new Enkei();
                break;

        }
    }

    public void SetBody(int choice)
    {
        switch (choice)
        {
            case 1:
                body = new AluminiumBody();
                break;
            case 2:
                body = new CarbonBody();
                break;

        }
    }

    public void SetTransmission(int choice)
    {
        switch (choice)
        {
            case 1:
                transmission = new PDK();
                break;
            case 2:
                transmission = new Sequential();
                break;

        }
    }

    public enum PartsType
    {
        Engine = 1,
        Wheel = 2,
        Body = 3,
        Transmission = 4,
    }

    //int 두개를 파라미터로 받아서 어떤 파츠에 대한 선택인지 까지 한번에 세팅하는 함수
    public void SetParts(PartsType partsType)
    {
        switch (partsType)
        {
            case PartsType.Engine:
                Console.WriteLine("========엔진 추가========");
                Console.WriteLine("[1] VQ37VHR");
                Console.WriteLine("[2] VR38DETT");
                break;
            case PartsType.Wheel:
                Console.WriteLine("========바퀴 추가========");
                Console.WriteLine("[1] BBS");
                Console.WriteLine("[2] Enkei"); break;
            case PartsType.Body:
                Console.WriteLine("========차체 추가========");
                Console.WriteLine("[1] 알루미늄 바디");
                Console.WriteLine("[2] 카본 바디"); break;
            case PartsType.Transmission:
                Console.WriteLine("========미션 추가========");
                Console.WriteLine("[1] PDK 미션");
                Console.WriteLine("[2] 시퀀셜 미션");
                break;
            default:
                break;
        }
        Console.Write("> ");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (partsType)
        {
            case PartsType.Engine:
                SetEngine(choice);
                break;
            case PartsType.Wheel:
                SetWheel(choice);
                break;
            case PartsType.Body:
                SetBody(choice);
                break;
            case PartsType.Transmission:
                SetTransmission(choice);
                break;
        }
    }
    public void Drive()
    {
        if (engine == null || wheel == null || body == null || transmission == null)
        {
            Console.WriteLine("시동 실패!");
            if (engine == null)
            {
                Console.WriteLine("엔진이 없습니다!");

            }
            if (wheel == null)
            {
                Console.WriteLine("바퀴가 없습니다!");

            }
            if (body == null)
            {
                Console.WriteLine("차체가 없습니다!");

            }
            if (transmission == null)
            {
                Console.WriteLine("미션이 없습니다!");

            }
            return;
        }
        Console.WriteLine("시동 성공! 자동차가 출발합니다.");
        engine.Combustion();
        wheel.Spin();
        body.Absorbe();
        transmission.GearChange();
    }

    public Car()
    {

    }
}

internal class _0528_2_answer
{
    static void Main(string[] args)
    {

        Car car = new Car();
        bool isEnd = false;

        do
        {


            Console.WriteLine("========자동차 조립하기========");
            Console.WriteLine("[1] 엔진 추가");
            Console.WriteLine("[2] 바퀴 추가");
            Console.WriteLine("[3] 차체 추가");
            Console.WriteLine("[4] 미션 추가");
            Console.WriteLine("[5] 자동차 정보 출력");
            Console.WriteLine("[6] 시동 걸기");
            Console.Write("> ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:

                case 2:

                case 3:

                case 4:
                    car.SetParts((Car.PartsType)choice);
                    break;
                case 5:
                    //정보 출력
                    car.ShowInfo();
                    break;
                case 6:
                    //시동 걸기
                    car.Drive();
                    isEnd = true;
                    break;
            }
        }while (isEnd);
    }
}

