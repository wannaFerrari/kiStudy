using System;
using System.Collections;


namespace CLIGame
{

    //좌표로 쓸 구조체
    struct Point2D
    {
        public int x;
        public int y;
        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    internal class Program
    {
        //상수 정의 : 변수처럼 개발자가 지은 이름으로 컴파일 이후 변하지 않는 값을 사용.
        //예시 : int.MaxVlue, int.MinValue
        const int X_SIZE = 2; // 내 게임은 콘솔에 표현할 때 X축으로 2칸씩 렌더링 함.
        static void DrawMenu()
        {
            // 메뉴 화면 만들기
            Console.CursorVisible = false;

            Console.Write("┌─");
            for (int i = 0; i < 10 ; i++)
            {
                Console.Write("──");
            }
            Console.Write("─┐");
            Console.WriteLine();
            //////////
            for (int j = 0; j < 3; j++)
            {
                Console.Write('│');
                for (int i = 0; i < 10+1 ; i++)
                {
                    Console.Write("  ");
                }
                Console.Write('│');
                Console.WriteLine();
            }
            ////////////////
            Console.Write("└─");
            for (int i = 0; i < 10 ; i++)
            {
                Console.Write("──");
            }
            Console.Write("─┘");
            Console.WriteLine();
            Console.SetCursorPosition(5, 2);
            Console.Write("성준의 모험");
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("▶시작하기    종료하기");
        }
        /// <summary>
        /// 플레이어 위치를 그려주는 메소드
        /// 주의 : 지워주진 않음.
        /// </summary>
        /// <param name="x">가로 축 좌표</param>
        /// <param name="y">세로 축 좌표</param>
        static void DrawPlayer(int x, int y)
        {
            Console.SetCursorPosition((x + 1)*X_SIZE, y + 1);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("★");
            Console.ResetColor();
        }

        //x,y값을 Point2D 구조체로 대체 하여 호출할 수 있는 오버로드 된 DrawPlayer 메소드
        static void DrawPlayer(Point2D point)
        {
            DrawPlayer(point.x, point.y);
        }

        static void DrawMap(Point2D point)
        {

            //외곽선 렌더링
            Console.Write("┌─");
            for (int i = 0; i < point.x + 1; i++)
            {
                Console.Write("──");
            }
            Console.WriteLine("─┐");

            //아이템 개수 출력
            //Console.Write($"남은 아이템 : ");
            //Console.WriteLine(itemList.Count);

            for (int i = 0; i < point.y + 1; i++)
            {
                Console.Write("│"); // 맨 왼쪽 외곽선
                Console.SetCursorPosition((point.x + 2) * X_SIZE + 1, i + 1); // 맨 오른쪽 외곽선
                Console.WriteLine("│");
            }

            Console.Write("└─");
            for (int i = 0; i < point.x + 1; i++)
            {
                Console.Write("──");
            }
            Console.WriteLine("─┘");

            Console.WriteLine("이동 : ↑↓←→ or WASD, 종료 : Q or ESC");
        }
        //게임 시작시 호출할 함수
        static void StartGame()
        {
            Console.Clear(); 
            Point2D mapSize = new Point2D(20, 20);
            int mapWidth = mapSize.x; //맵의 너비
            int mapHeight = mapSize.y; // 맵의 높이
            int playerX = 5; //플레이어의 x좌표
            int playerY = 5; //플레이어의 y좌표
            int itemCount = 3;
            int obstacleCount = 3;
            Point2D playerPoint = new Point2D(playerX, playerY);

            //아이템 배열
           
            

            bool[] rootedItems = new bool[3] { false, false, false };
            //자동으로 크기가 줄었다, 늘었다, 그리고 개수까지 카운트 할 수 있는
            //좋은 데이터 모음컨테이너가 없을까?
            // => System.Collections 에 포함된 컬렉션들 : 데이터묶음을 여러 방식으로 컨트롤 할 수 있는
            //클래스 또는 구조체 모음
            //ArrayList : 자료형 지정 없이 모두 Object의 형태로 박싱하여 데이터를 취급함

            //ArrayList에 데이터를 삽입할 때 Add 메소드를 호출하여 파라미터로 삽입할 데이터를 전달
            //itemList.Count; // => itemList에 삽입된 데이터 개수


            //Todo: 아이템 개수나 위치
            //생성 가능한곳에 랜덤 생성
            //Random random = new Random(); random.Next(0,10);
            //조건 : 같은 위치에 아이템이 없어야 함. 플레이어 생성 위치에는 생성되면 안됨.

            //Todo: 2. 플레이어 좌표를 playerX, playerY 대신 Point2D구조체 활용
            ArrayList itemList = new ArrayList();
            ArrayList obstacleList = new ArrayList();
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < itemCount + obstacleCount; i++)
            {
                int[] xArray = new int[itemCount+obstacleCount];
                xArray[i]= rand.Next(0,mapWidth);

                int[] yArray = new int[itemCount+obstacleCount];
                yArray[i] = rand.Next(0,mapHeight);
                if(i != 0)
                {
                    for(int j = 0; j < i; j++)
                    {
                        while ((xArray[i] == xArray[j] && yArray[i] == yArray[j]) || xArray[i] == playerX && yArray[i] == playerY)
                        {
                            xArray[i] = rand.Next(0, mapWidth);
                            yArray[i] = rand.Next(0, mapHeight);
                        }
                    }
                }
               if(i < itemCount)
                {
                    itemList.Add(new Point2D(rand.Next(0, mapWidth), rand.Next(0, mapHeight)));

                }
                else
                {
                    obstacleList.Add(new Point2D(rand.Next(0, mapWidth), rand.Next(0, mapHeight)));
                }

            }

            /*
            for (int i = 0; i < obstacleCount; i++)
            {
                int[] xArray = new int[3];
                xArray[i] = rand.Next(0, mapWidth);

                int[] yArray = new int[3];
                yArray[i] = rand.Next(0, mapHeight);
                if (i != 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        while ((xArray[i] == xArray[j] && yArray[i] == yArray[j]) || xArray[i] == playerX && yArray[i] == playerY)
                        {
                            xArray[i] = rand.Next(0, mapWidth);
                            yArray[i] = rand.Next(0, mapHeight);
                        }
                    }
                }

                obstacleList.Add(new Point2D(rand.Next(0, mapWidth), rand.Next(0, mapHeight)));

            }
            */

            /*
            itemList.Add(new Point2D(3, 4));
            itemList.Add(new Point2D(18, 7));
            itemList.Add(new Point2D(2, 9));*/
            /*
            //외곽선 렌더링
            Console.Write("┌─");
            for (int i = 0; i < mapWidth +1; i++)
            {
                Console.Write("──");
            }
            Console.Write("─┐");

            //아이템 개수 출력
            Console.Write($"남은 아이템 : ");
            Console.WriteLine(itemList.Count);

            for (int i = 0; i < mapHeight + 1 ; i++)
            {
                Console.Write("│"); // 맨 왼쪽 외곽선
                Console.SetCursorPosition((mapWidth + 2)*X_SIZE+1, i + 1); // 맨 오른쪽 외곽선
                Console.WriteLine("│");
            }

            Console.Write("└─");
            for (int i = 0; i < mapWidth +1; i++)
            {
                Console.Write("──");
            }
            Console.WriteLine("─┘");

            Console.WriteLine("이동 : ↑↓←→ or WASD, 종료 : Q or ESC");
            */


            //Point2D mapSize = new Point2D(20, 20);
            DrawMap(mapSize);
            //아이템 개수 출력
            Console.Write($"남은 아이템 : ");
            Console.WriteLine(itemList.Count);

            //아이템 모두 렌더링
            foreach (Point2D item in itemList)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition((item.x + 1)*X_SIZE, item.y + 1);
                Console.Write("○");
                Console.ResetColor();
            }

            //장애물 모두 렌더링
            foreach (Point2D item in obstacleList)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((item.x + 1) * X_SIZE, item.y + 1);
                Console.Write("※");
                Console.ResetColor();
            }

            //플레이어 렌더링
            //DrawPlayer(playerX, playerY);
            DrawPlayer(playerPoint);
            int[] obstacleX = new int[obstacleList.Count];
            int[] obstacleY = new int[obstacleList.Count];

            for (int i = 0; i < obstacleList.Count; i++)
            {
                obstacleX[i] = ((Point2D)obstacleList[i]).x;
                obstacleY[i] = ((Point2D)obstacleList[i]).y;
            }
            while (true)
            {
                int oldX = playerX; //이동하기전 플레이어 위치의 문자를 지워주기 위해 좌표를 저장
                int oldY = playerY;
                //사용자의 키 입력에 따라 플레이어 위치를 이동
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (playerY > 0)
                        {
                            bool checkAble = false;
                            for(int i = 0; i < obstacleList.Count; i++)
                            {
                                if(playerX == obstacleX[i] && playerY == (obstacleY[i] + 1))
                                {
                                    checkAble = false;
                                    break;
                                }
                                else
                                {
                                    checkAble = true;
                                    
                                }
                            }
                            if(checkAble == true)
                            {
                                playerY--;
                                playerPoint.y = playerY;
                            }
                        }
                            
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (playerX > 0)
                        {
                            bool checkAble = false;
                            for (int i = 0; i < obstacleList.Count; i++)
                            {
                                if (playerY == obstacleY[i] && playerX == (obstacleX[i] + 1))
                                {
                                    checkAble = false;
                                    break;
                                }
                                else
                                {
                                    checkAble = true;
                                    
                                }
                            }
                            if(checkAble == true)
                            {
                                playerX--;
                                playerPoint.x = playerX;
                            }
                        }
                            
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (playerY < mapHeight)
                        {
                            bool checkAble = false;
                            for (int i = 0; i < obstacleList.Count; i++)
                            {
                                if (playerX == obstacleX[i] && playerY == (obstacleY[i] - 1))
                                {
                                    checkAble = false;
                                    break;
                                }
                                else
                                {
                                    checkAble = true;
                                }
                            }
                            if(checkAble == true)
                            {
                                playerY++;
                                playerPoint.y = playerY;
                            }
                        }
                            
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (playerX < mapWidth)
                        {
                            bool checkAble = false;
                            for (int i = 0; i < obstacleList.Count; i++)
                            {
                                if (playerY == obstacleY[i] && playerX == (obstacleX[i] - 1))
                                {
                                    checkAble = false;
                                    break;
                                }
                                else
                                {
                                   
                                    checkAble = true;
                                }
                            }
                            if(checkAble == true)
                            {
                                playerX++;
                                playerPoint.x = playerX;
                            }
                        }

                            
                        break;
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                        //Q 또는 ESC입력시 메소드 종료
                        return;
                }
                //Console.Clear();
                //플레이어의 위치를 다시 그려줌
                if (oldX != playerX || oldY != playerY)
                {
                    //기존 플레이어 위치의 문자를 지워줌
                    Console.SetCursorPosition((oldX + 1) * X_SIZE, oldY + 1);
                    Console.Write("  ");
                    // DrawPlayer(playerX, playerY);
                    DrawPlayer(playerPoint);

                    //Todo: 플레이어가 이동할때마다 이동한 위치에 아이템이 있는지 확인.
                    //아이템이 있으면 해당 아이템을 획득한 표시를 함

                    //반복문
                    for(int i = 0; i < itemList.Count; i++) 
                    {
                        if(playerX == (((Point2D)itemList[i])).x && playerY == ((Point2D)itemList[i]).y)
                        {
                            //아이템 획득
                            //rootedItems[i] = true;
                            //ArrayList에서 먹은 아이템을 제거
                            //itemList.Remove(itemList[i]); : ArrayList.Remove() : 같은 객체인지를 엄격하게 판단하여 같은객체가 있으면 제거
                            // -> 참조형 데이터를 취급할 떄 주의해야 함.
                            //ArrayList.RemoveAt() : 특정 인덱스에 있는 값을 바로 제거
                            itemList.RemoveAt(i);
                        }
                    }

                    //남은 아이템 개수를 메뉴에 출력
                    // Console.SetCursorPosition((mapWidth + 2) * X_SIZE+ 15+1, 0);
                    Console.SetCursorPosition(14, mapHeight + 4);
                    Console.Write(itemList.Count);
                    //남은 아이템 개수가 0개인지 확인해서 게임을 종료.

                    if(itemList.Count == 0)
                    {
                        //게임을 끝냄;
                        EndGame();
                        return;
                    }

                    //bool isFinished = true; 
                    ////모든 아이템 획득 여부거 true 이어야 게임이 끝남
                    ////==> 하나라도 false 가 있으면 게임을 끝내면 안됨.
                    //foreach(bool isRooted in rootedItems)
                    //{
                    //    if(!isRooted)
                    //    {
                    //        isFinished = false;
                    //        break;
                    //    }
                    //}

                    //if (isFinished)
                    //{
                    //    //게임을 끝냄.
                    //    //DrawEnding(); //알아서 구현
                    //    return;
                    //}
                }

            }
        }

        static void EndGame()
        {
            Console.Clear();
            /*
            Console.Write("┌─");
            for(int i = 0; i < 40;  i++)
            {
                Console.Write("──");
            }
            Console.Write("─┐");*/
            string end = @"
┌──────────────────────────────────────────┐
│                                          │
│                                          │
│    축하합니다. 게임을 클리어하셨습니다.     │
│                                          │
│    아무 키를 눌러 메뉴화면으로 돌아가세요    │
└──────────────────────────────────────────┘";
            Console.WriteLine(end);
            Console.ReadKey();
            return;
        }



        static void Main()
        {
            //메뉴 화면 만들기
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                DrawMenu();


                //사용자의 선택과 루프 종료 조건을 저장할 변수
                int choice = 0;  //사용자의 선택, 0: 게임 시작, 1: 게임 종료
                bool isEntered = false; //사용자가 선택키(스페이스바, 엔터키)를 눌렀는지 여부

                while (!isEntered)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            Console.SetCursorPosition(0, 6);    //커서를 왼쪽 끝으로
                            Console.Write('▶');                //화살표 출력 
                            Console.SetCursorPosition(12, 6);   //커서를 "▶시작하기"의 왼쪽으로
                            Console.Write("  ");                //기존에 있던 화살표를 "  "로 지움
                            choice = 0;
                            //화살표를 시작하기 쪽으로 
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            Console.SetCursorPosition(0, 6);    //커서를 왼쪽 끝으로
                            Console.Write("  ");
                            Console.SetCursorPosition(12, 6);   //커서를 "▶시작하기"의 왼쪽으로
                            Console.Write('▶');                //화살표 출력 
                            choice = 1;
                            //화살표를 종료하기 쪽으로
                            break;
                        case ConsoleKey.Spacebar:
                        case ConsoleKey.Enter:
                            //선택 여부에 따라 게임을 시작하거나 종료
                            isEntered = true;
                            break;

                    }
                }

                if (choice == 0)
                {
                    //게임 시작
                    Console.WriteLine("게임을 시작합니다");
                    StartGame();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("게임을 종료합니다");
                    return; //메인 메소드를 종료하여 프로그램을 종료
                }

            }

        }
        static void KeyTest()
        {
            //Console.WriteLine("뭔가 입력해주세요");
            //int input = Console.Read(); 
            //// Console.Read(); => ReadLine과 같이 Enter키 입력을 기다리지만,
            ////입력값의 첫글자만 char 형으로 캐스팅 가능한 정수를 반환받는다
            //Console.WriteLine($"입력 하신 값 : {(char)input}");


            //Console.ReadKey() : 키보드 입력이 이루어지는 즉시 눌린 키의 정보를 return
            // /*ConsoleKeyInfo*/ var keyInfo = Console.ReadKey();
            //var 키워드 : 추론타입 - 변수가 선언되는 라인에서 할당받는 값에 따라 자료형을 다르게 배정하는 키워드
            //컴파일 타임에서 자료형이 결정되므로, 미리 선언하거나 할 수 없고,
            // 반드시 선언과 동시에 데이터를 할당해야 한다

            Console.CursorVisible = false;
            Console.WriteLine("입력 키 : ");
            Console.WriteLine("보조 키 : ");

            while (true)
            {
                //Console.ReadKey(bool param) : 파라미터 값이 true이면 나의 입력을 숨김
                //var keyInfo = Console.ReadKey(true);
                //Console.Clear(); // 터미널(콘솔, CLI화면등)에 출력된 내용을 모두 지움.
                //Console.Write("입력 키 : ");
                //Console.WriteLine($"{keyInfo.Key} {keyInfo.Modifiers}");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                //커서가 보이지 않을 뿐, 존재는 한다.
                //커서를 특정 위치로 옮겨서 Write등 출력 함수를 호출하면 현재 커서 위치에서 다시 씀.
                //"입력 키 : "라고 출력된 줄 옆으로 커서를 이동후 입력키 출력
                Console.SetCursorPosition(10, 0);
                Console.Write($"{keyInfo.Key}             ");

                //"보조 키 : " 라고 출력된 줄 옆으로 커서를 이동 후 보조 키 출력.
                Console.SetCursorPosition(10, 1);
                Console.Write($"{keyInfo.Modifiers}            ");



                //입력된 키가 esc 키이면 루프를 빠져나감

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }


            }
        }
    }
}
