using System;

namespace Event
{
    interface IObservable
    {
        event Action<string> onEventHappened;
    }

    class Observer : IObservable
    {
        public event Action<string> onEventHappened;

        public void SomthingHappended()
        {
            onEventHappened?.Invoke("뭔가 사건이 발생했습니다.");
        }

    }

    class Subscriber
    {
        string name;
        IObservable observer;
        public Subscriber(IObservable observer, string name)
        {
            this.name = name;
            this.observer = observer;
            observer.onEventHappened += OnReceiveMessage;
            //observer.onEventHappened =+ (msg)=> Console.WriteLine($"{name}가 \"{msg}\"라는 메시지를 받았습니다.");
            // 이렇게하면 구독을 해지 할 수가 없으므로 좋지 않은 방식임
        }

        private void OnReceiveMessage(string msg)
        {
            Console.WriteLine($"{name}가 \"{msg}\"라는 메시지를 받았습니다.");
        }
        public void Dissubscribe()
        {
            observer.onEventHappened -= OnReceiveMessage;
            //observer.onEventHappened("sss");   -> 불가
            //observer.onEventHappened = OnReceiveMessage;   -> 불가

        }
    }
    internal class Program
    {
        //이벤트 : 몇가지 제약사항으로 안전장치를 해 놓은 특수한 용도의 델리게이트.
        //제약사항 1. +=, -=을 제외한 완전 할당(=)이 불가능하다.
        //제약사항 2. 해당 이벤트를 멤버로 가진 클래스내에서만 호출이 가능하다.
        //대신, interface에서 멤버로 이벤트를 가질 수 있다.( 참고로 델리게이트는 안됨)
        //델리게이트와 같은데 앞에 event 키워드를 붙임
        //[접근지정자] [static여부] event [델리게이트명] 변수명
         //public static event Action someEvent;
        
        static void Main(string[] args)
        {
            Observer observer = new Observer();
            Subscriber s1 = new Subscriber(observer, "구독자1");
            Subscriber s2 = new Subscriber(observer, "한결이");
            Subscriber s3 = new Subscriber(observer, "강아지");


            observer.SomthingHappended();

            s1.Dissubscribe();
            
            Console.WriteLine("사건이 소강상태입니다.");
            observer.SomthingHappended();

        }
    }
}
