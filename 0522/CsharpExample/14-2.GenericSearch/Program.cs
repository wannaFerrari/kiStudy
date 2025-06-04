using System;
using System.Collections.Generic;
abstract class Parts
{
    protected string name;
    public abstract void Drive();
}
abstract class Engine : Parts { }
abstract class Wheel : Parts { }
abstract class Body : Parts { }
abstract class Transmission : Parts { }

class GasolineEngine : Engine
{
    public GasolineEngine()
    {
        name = "가솔린 엔진";
    }
    public override void Drive()
    {
        Console.Write($"{name}이 부릉부릉");
    }
}
class SteamEngine : Engine
{
    public SteamEngine()
    {
        name = "증기 엔진";
    }
    public override void Drive()
    {
        Console.Write($"{name}이 털털털털");
    }
}
class WoodenWheel : Wheel
{
    public WoodenWheel()
    {
        name = "나무 바퀴";
    }
    public override void Drive()
    {
        Console.Write($"{name}가가 데굴데굴");
    }
}
class CarbonWheel : Wheel
{
    public CarbonWheel()
    {
        name = "카본 휠";
    }
    public override void Drive()
    {
        Console.Write($"{name}이 빙글빙글");
    }
}
class PlasticBody : Body
{
    public PlasticBody()
    {
        name = "플라스틱 차체";
    }
    public override void Drive()
    {
        Console.Write($"{name}가 삐걱삐걱");
    }
}
class TitaniumBody : Body
{
    public TitaniumBody()
    {
        name = "티타늄 차체";
    }
    public override void Drive()
    {
        Console.Write($"{name}가 덜컹덜컹");
    }
}
class SandMission : Transmission
{
    public SandMission()
    {
        name = "모래 미션";
    }
    public override void Drive()
    {
        Console.Write($"{name}이 촤르르르");
    }
}
class PlasmaMission : Transmission
{
    public PlasmaMission()
    {
        name = "플라즈마 미션";
    }
    public override void Drive()
    {
        Console.Write($"{name}이 파지지직");
    }
}

class Car
{
    private Engine engine;
    private Wheel wheel;
    private Body body;
    private Transmission mission;
    private List<Parts> partsList;

    public Car()
    {
        partsList = new List<Parts>();
    }
    public Engine Engine
    {
        set
        {
            if (engine != null) partsList.Remove(engine);
            engine = value;
            if (value != null) partsList.Add(value);
        }
    }
    public Wheel Wheel
    {
        set
        {
            if (wheel != null) partsList.Remove(wheel);
            wheel = value;
            if (value != null) partsList.Add(value);
        }
    }
    public Body Body
    {
        set
        {
            if (body != null) partsList.Remove(body);
            body = value;
            if (value != null) partsList.Add(value);
        }
    }
    public Transmission Mission
    {
        set
        {
            if (mission != null) partsList.Remove(mission);
            mission = value;
            if (value != null) partsList.Add(value);
        }
    }


    //가변 자료형을 통해 리턴받는 제네릭 메소드로 만들어보려면
    public PartsType GetParts<PartsType>() where PartsType : Parts
    {
        for (int i = 0; i < partsList.Count; i++)
        {
            Console.WriteLine($"{i}번째 파츠는 {partsList[i].GetType()} 입니다. 찾는 파츠는 {typeof(PartsType)}");
            if (partsList[i] is PartsType)
            {
                //is : 패턴 매칭 연산자로, [객체] is [타입] : 객체가 비교하려난 타입과 매칭될 경우 true 반환. 아닐경우 false반환
                //is를 안썼을경우 : partList[i].GetType().IsAssugnableFrom(typeof(PartsType)) 이런식으로 해야함
                Console.WriteLine($"{i}번째에 파츠를 찾았습니다!");
                return (PartsType)partsList[i];
            }
        }
        Console.WriteLine("찾는 파츠가 없네요...");
        return default(PartsType); // null; 라고 해도 됨

    }
}

class GenericSearch
{
    static void Main()
    {
        Car car = new Car();
        car.Engine = new GasolineEngine();
        car.Wheel = new WoodenWheel();
        car.Body = new PlasticBody();
        car.Mission = new SandMission();

        //car로부터 내부 멤버요소로 가지고 있는 Parts중에 특정 데이터 타입의 객체를 가져오고 싶다.
        Parts target = car.GetParts<Body>();
        if(target != null)
        {
            target.Drive();
        }

        //패턴 매칭 키워드 is, as
        //참조형식의 어떤 데이터가 특정 타입과 호환이 가능한지(캐스팅 가능한지) 여부를 판단하는 키워드.
        //is : [객체(변수)] is [타입] = true, false. 호환 가능한 자료형일 경우 true, 아니면 false.
        //as : [객체(변수)] as [타입] = 캐스팅, null. 호환 가능한 자료형일 경우 캐스팅 된 데이터. 아닐면 null

        Parts engine = car.GetParts<Engine>();

        if (engine is Wheel )
        {
            Console.WriteLine("엔진은 바퀴입니다.");
        }
        else if (engine is Body)
        {
            Console.WriteLine("엔진은 차체입니다.");
        }
        else if (engine is Engine)
        {
            Console.WriteLine("엔진은 엔진입니다.");
        }

        GasolineEngine gasolineEngine = new GasolineEngine();
        Engine engine1 = gasolineEngine;  //Up casting 또는 boxing은 암시적으로 형변환 가능
        Parts parts = engine1;
        engine1 = parts as Engine;          // down casting 또는 unboxing은 명시적으로 형변환 해야만 함
        gasolineEngine = engine1 as GasolineEngine; // as 키워드(패턴매칭)을 통해 형변환을 할 경우,
                                                    // 연산 단계도 간소화되고 코드 가독성이 좋아지며, 캐스팅이 불가능할경우
                                                    // null 값을 확정적으로 얻을 수 있다.

    }
}