using System;
using System.Collections.Generic;

namespace OperatorOverloading
{
    //연산자 오버로딩 : 연산자의 연산에 대한 정의를 덮어쓰는 것.
    //기본자료형의 연산자는 오버로딩이 불가능.
    //구조체 또는 클래스의 상호 연산에 대한 정의를 "추가"하는 기능으로 봐야함.

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
        public static Point2D operator + (Point2D left, Point2D right)
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

        public static bool operator != (Point2D left, Point2D right)
        {
            return (left.x != right.x) || (left.y != right.y);
        }


    }
        //1. x,y,z값을 가지고 있는 Point3D 구조체를 만들고
        // 사칙연산 및 비교 연산자를 오버로딩 하기

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
    internal class Program
    {
        static void Main(string[] args)
        {
            Point2D point1 = new Point2D(3, 4);
            Point2D point2 = new Point2D(1, 3);

            //두 좌표의 x, y 값을 각각 합쳐서 더 멀리 있는 좌표를 얻어오고 싶을때

            Point2D point3 = point1 + point2;
            Console.WriteLine($"point3의 x : {point3.x}, point3의 y : {point3.y}");
            point3 = point1 - point2;
            Console.WriteLine($"point3의 x : {point3.x}, point3의 y : {point3.y}");
            point3 = point1 * point2;
            Console.WriteLine($"point3의 x : {point3.x}, point3의 y : {point3.y}");
            point3 = point1 / point2;
            Console.WriteLine($"point3의 x : {point3.x}, point3의 y : {point3.y}");
            //point3.x = point1.x + point2.x;
            //point3.y = point1.y + point2.y;

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

            Console.WriteLine(p1==p2);
            Console.WriteLine(p1!=p2);
            //point3 = point1 + point2;

        }
    }
}
