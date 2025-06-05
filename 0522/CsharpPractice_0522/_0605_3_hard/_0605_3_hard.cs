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
        public User()
        {
           // this.game = game;
           // this.game.onPush += OnReceivePush;
        }
        public void OnReceivePush(string msg)
        {
            Console.WriteLine(msg);
        }

        public void InstallGame(IGame game)
        {
            this.game = game;
            this.game.onPush += OnReceivePush;
        }

        public void UnInstallGame(IGame game)
        {
            this.game.onPush -= OnReceivePush;
            this.game = null;
        }
    }


    internal class _0605_3_hard
    {
        static void Main(string[] args)
        {
            //Game game = new Game();
            KartRider kart = new KartRider();
            User user1 = new User();
            User user2 = new User();

            user1.InstallGame(kart);
            user2.InstallGame(kart);

            kart.SendPushMessage();
            Console.WriteLine("===========================");

            user2.UnInstallGame(kart);
            kart.SendPushMessage();


            //onPush
        }
    }
}
