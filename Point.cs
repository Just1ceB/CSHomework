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


        /// <summary>
        /// Creates a <c>Point</c> instance using input <b>X</b> and <b>Y</b> coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Creates a <c>Point</c> instance at (0, 0) coordinates
        /// </summary>
        public Point() : this(0, 0) { }

        /// <summary>
        /// Creates a copy of a <c>Point</c> instance that gets as <b>parameter</b>
        /// </summary>
        /// <param name="p"><c>Point</c> instance to copy</param>
        public Point(Point p) : this(p.GetX(), p.GetY()) { }

        /// <summary>
        /// Gets <b>X</b> coordinate from current <c>Point</c> instance
        /// </summary>
        /// <returns><b>X</b> coordinate from current <c>Point</c> instance</returns>
        public double GetX()
        {
            return this.x;
        }

        /// <summary>
        /// Sets input <b>parameter</b> as <b>X</b> coordinate for current <c>Point</c> instance
        /// </summary>
        /// <param name="x"><b>X</b> coordinate to set</param>
        public void SetX(double x)
        {
            this.x = x;
        }

        /// <summary>
        /// Gets <b>Y</b> coordinate from current <c>Point</c> instance
        /// </summary>
        /// <returns><b>Y</b> coordinate from current <c>Point</c> instance</returns>
        public double GetY()
        {
            return this.y;
        }

        /// <summary>
        /// Sets input <b>parameter</b> as <b>Y</b> coordinate for current <c>Point</c>
        /// </summary>
        /// <param name="y"></param>
        public void SetY(double y)
        {
            this.y = y;
        }

        /// <summary>
        /// Calculates between current <c>Point</c> instance to <b>parameter</b> <c>Point</c> instance
        /// </summary>
        /// <param name="p">Other point</param>
        /// <returns>Distance between current <c>Point</c> and <b>parameter</b> <c>Point</c> instance</returns>
        public double Distance(Point p)
        {
            return Math.Sqrt((Math.Pow(this.x - p.GetX(), 2)) + (Math.Pow(this.y - p.GetY(), 2)));
        }

        /// <summary>
        /// Creates a point between current <c>Point</c> instance and <b>parameter</b> <c>Point</c> instance
        /// </summary>
        /// <param name="p"></param>
        /// <returns>New <c>Point</c> instance that is between current and parameter <c>Point</c> instances</returns>
        public Point MiddlePoint(Point p)
        {
            Point middlePoint = new Point((this.x - p.GetX()) / 2, (this.y - p.GetY()) / 2);
            return middlePoint;
        }

        /// <summary>
        /// Creates a copy of current <c>Point</c> instance
        /// </summary>
        /// <returns>New <c>Point</c> instance that is a copy of a current one</returns>
        public Point Copy()
        {
            Point copy = new Point(this.x, this.y);
            return copy;
        }

        /// <summary>
        /// Makes printing <c>Point</c> instance to print string with the point coordinates <br/>
        /// <example>
        /// Example: ( 0, 0 )
        /// </example>
        /// </summary>
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
