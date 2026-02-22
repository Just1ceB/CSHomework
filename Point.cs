using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prjcts
{
    internal class Point
    {
        private double x;
        private double y;



        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point() : this(0, 0) { }

        public double GetX()
        {
            return this.x;
        }

        public Point(Point p) : this(p.GetX(), p.GetY()) { }

        public void SetX(double x)
        {
            this.x = x;
        }

        public double GetY()
        {
            return this.y;
        }

        public void SetY(double y)
        {
            this.y = y;
        }

        public double Distance(Point p)
        {
            return Math.Sqrt((Math.Pow(this.x - p.GetX(), 2)) + (Math.Pow(this.y - p.GetY(), 2)));
        }

        public Point MiddlePoint(Point p)
        {
            Point middlePoint = new Point((this.x - p.GetX()) / 2, (this.y - p.GetY()) / 2);
            return middlePoint;
        }

        public Point Copy()
        {
            Point copy = new Point(this.x, this.y);
            return copy;
        }

        public override string ToString()
        {
            return $"( {this.x}, {this.y} )".ToString();
        }

        public static void UnitTest()
        {
            Point point = new Point(14.24, 15.69);

            Console.WriteLine($"Point coordinates is: {point}");

            Point point2 = new Point();

            Console.WriteLine($"New point coordinates is: {point2}");

            Console.WriteLine($"Distance is: {point2.Distance(point)}");

            Point point3 = point.MiddlePoint(point2);
            Console.WriteLine($"Middle point is: {point3}");

            Point point4 = new Point(point);
        }
    }
}
