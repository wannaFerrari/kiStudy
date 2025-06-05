using System;

namespace _0605_3
{
    interface IGame 
    {
        event Action<string> onPush;
        /*
        public virtual void SendPushMessage()
        {
            //onPush?.Invoke("게임좀 하거라");
        }*/
    }

    class KartRider : IGame
    {
        public event Action<string> onPush;

        public KartRider()
        {

        
        
        }
        public void SendPushMessage()
        {
            onPush?.Invoke("게임좀 하거라");
        }

    }

    class User
    {
        IGame game;
        public User(IGame game)
        {
            this.game = game;
            this.game.onPush += OnReceivePush;
        }
        public void OnReceivePush(string msg)
        {
            Console.WriteLine(msg);
        }
    }


    internal class _0605_3
    {
        static void Main(string[] args)
        {
            //Game game = new Game();
            KartRider kart = new KartRider();
            User user1 = new User(kart);
            User user2 = new User(kart);

            kart.SendPushMessage();
            //onPush
        }
    }
}
