using System;
using System.Collections.Generic;


namespace _0604_1
{
    internal class _0604_1
    {
        struct Point2D
        {
            public int x;
            public int y;
            public Point2D(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            //연산자 오버로딩 : 연산자를 재정의 할 경우, Point2D라는 자료형을 지닌 데이터는 모두 연산 가능해야 하므로
            // 메소드와 비슷하게 정의하는 대신, 접근지정자 및 static 여부는 무조건 public static 이다.
            //public static [반환형] operator + ([좌변자료형] 파라미터1, [우변자료형] 파라미터2) { 연산내용 }
            //
            public static Point2D operator +(Point2D left, Point2D right)
            {
                return new Point2D(left.x + right.x, left.y + right.y);
            }

            public static Point2D operator -(Point2D left, Point2D right)
            {
                return new Point2D(left.x - right.x, left.y - right.y);
            }

            public static Point2D operator *(Point2D left, Point2D right)
            {
                return new Point2D(left.x * right.x, left.y * right.y);
            }

            public static Point2D operator /(Point2D left, Point2D right)
            {
                return new Point2D(left.x / right.x, left.y / right.y);
            }


            //==비교 연산자, 형변환
            public static bool operator ==(Point2D left, Point2D right)
            {
                return (left.x == right.x) && (left.y == right.y);
            }

            public static bool operator !=(Point2D left, Point2D right)
            {
                return (left.x != right.x) || (left.y != right.y);
            }

            public static implicit operator Point2D(Point3D p3d)
            {
                Point2D n2d = new Point2D();
                n2d.x = p3d.x;
                n2d .y = p3d.y;
                return n2d;
            }


        }
        struct Point3D
        {
            public int x;
            public int y;
            public int z;
            public Point3D(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public static Point3D operator +(Point3D left, Point3D right)
            {
                return new Point3D(left.x + right.x, left.y + right.y, left.z + right.z);
            }

            public static Point3D operator -(Point3D left, Point3D right)
            {
                return new Point3D(left.x - right.x, left.y - right.y, left.z - right.z);
            }

            public static Point3D operator *(Point3D left, Point3D right)
            {
                return new Point3D(left.x * right.x, left.y * right.y, left.z * right.z);
            }

            public static Point3D operator /(Point3D left, Point3D right)
            {
                return new Point3D(left.x / right.x, left.y / right.y, left.z / right.z);
            }

            public static bool operator ==(Point3D left, Point3D right)
            {
                return (left.x == right.x) && (left.y == right.y) && (left.z == right.z);
            }

            public static bool operator !=(Point3D left, Point3D right)
            {
                return (left.x != right.x) || (left.y != right.y) || (left.z != right.z);
            }
        }
        static void Main(string[] args)
        {
            Point3D p1 = new Point3D(10, 20, 30);
            Point3D p2 = new Point3D(1, 2, 3);
            Point3D p3 = p1 + p2;
            Console.WriteLine($"p3의 x : {p3.x}, p3의 y : {p3.y}, p3의 z : {p3.z}");
            p3 = p1 - p2;
            Console.WriteLine($"p3의 x : {p3.x}, p3의 y : {p3.y}, p3의 z : {p3.z}");
            p3 = p1 * p2;
            Console.WriteLine($"p3의 x : {p3.x}, p3의 y : {p3.y}, p3의 z : {p3.z}");
            p3 = p1 / p2;
            Console.WriteLine($"p3의 x : {p3.x}, p3의 y : {p3.y}, p3의 z : {p3.z}");

            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1 != p2);
            Console.Write($"Point3D를 Point2D로 형변환 후 x :{((Point2D)p3).x}, y : {((Point2D)p3).y}");
        }
    }
}
