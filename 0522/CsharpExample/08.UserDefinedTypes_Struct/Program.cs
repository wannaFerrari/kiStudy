using System;


//<global namespace>
//.....

namespace UserDefinedTypes_Struct
{
    //구조체 : 데이터를 구조화 시키기 위한 타입. 즉, 데이터를 포장한 데이터
    //[접근지정자] struct 구조체명 { 속성, 행동(Method) 등등 }
    //접근지정자 생략하면 internal
    //2D 표면상에서의 위치를 지정하는 구조체
    struct Point2D
    {
        public int x; //필드 (전역변수)
        public int y; 

        //생성자 정의할 수 있다.
        //[접근지정자] 구조체명(매개변수) {초기화 내용}

        public Point2D(int xValue, int yValue)
        {
            //Point2d라는 구조체를 처음 생성할때 반드시 할당되어야 하는 값을 할당
            //이를 통해 Point2D 하나를 만들어 데이터를 저장함
            x = xValue;
            y = yValue;
        }


        /// <summary>
        /// x 값과 y값을 콘솔에 출력하는 메소드
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"x : {x}, y : {y}");
        }


    }

    //1번.
    //색상을 표현하는 Color 구조체를 만들어보세요.
    // byte 타입의 r, g, b 필드(전역변수)를 가지고 있고,
    // R, G, B 값 16진수(Hexa) 포맷의 문자열로 반환하는 ToHex() 함수를 만드세요
    // $"#{r:X2}{g:X2}{b:X2}"

    struct Color
    {
        public byte r;
        public byte g;
        public byte b;
        
        //public Color(){} 구조체의 기본생성자는 정의가 불가능
        //모든 필드의 기본값 (default)이 자동으로 할당되는 기본생성자가 미리 정의되어있음

        /// <summary>
        /// 컬러 생성자
        /// </summary>
        /// <param name="rVal">빨강</param>
        /// <param name="gVal">초록</param>
        /// <param name="bVal">파랑</param>
        public Color(byte rVal, byte gVal, byte bVal)
        {
            r = rVal;
            g = gVal;
            b = bVal;

            //this.r = r;
            //this.g = g;
            //this.b = b;
        }

        //구조체의 생성자는 파라미터 개수 상관없이 모든 필드에 값을 할당하기만 하면 됨
        public Color(byte grayscale)
        {
            r = g = b = grayscale;
        }
        public string ToHex()
        {
            return $"#{r:X2}{g:X2}{b:X2}";
        }
    }




    //2번.
    //GPS 위치를 계산할 수 있는 GPSPoint구조체를 만들어 보세요
    // double 타입의 latitude, longitude 필드를 가지고 있고
    // 다른 GPSPoint를 매개변수로 받아 거리를 계산하여 반환하는 Distance()
    // 메소드를 만들어 보세요.
 
    struct GPSPoint
    {
        //구조체의 포커스에서는 
        //internal 대신 public / private을 사용할 수 있다.
        // default 접근지정자가 private 이다
        //private : GPSPoint 구조체가 자신의 메소드에서만 접근 가능한 필드
        private double latitude;
        private double longitude;


        private void Print()
        {
            //외부에서 접근이 안되는 메소드
            Console.WriteLine($"{latitude:n2}, {longitude:n2}위치에 좌표가 생성됨");
        }
        public double GetLatitude()
        {
            return latitude;
        }

        public double GetLongitude()
        {
            return longitude;
        }

        public GPSPoint(double la, double lo)
        {
            latitude = la;
            longitude = lo;
            Print();
        }

        public double Distance(GPSPoint point)
        {
            double distance = Math.Sqrt(Math.Pow(this.latitude - point.GetLatitude(), 2) +
                        Math.Pow(this.longitude - point.GetLongitude(), 2));
            return distance;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Point2D point1, point2, point3; // 구조체인 Point2D의 자료형을 가진 변수 3개 선언
            point1 = new Point2D(); // 기본생성자를 통해 초기화.
            point2 = new Point2D(5, 8); // 사용자정의 생성자를 통해 초기화

            //사용자 정의 자료형인 구조체, 클래스의 내부 요소에 접근할때에는 .을 사용함
            point1.x = 1;
            point1.Print();
            point2.Print();

            //구조체는 생성자를 통해 초기화를 하지 않아도 값에 접근 가능(실체가 있다)
            point3.x = 4;
            point3.y = 3;
            point3.Print();

            Color color = new Color(255,2,255);
            Console.WriteLine(color.ToHex());


            GPSPoint p1 = new GPSPoint(6.0, 7.0);
            GPSPoint p2 = new GPSPoint(8.0, 5.0);
            Console.WriteLine(p1.Distance(p2));
        }
    }
}
