using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prjcts
{
    internal class Rectangle
    {
        private Point bottomLeft;
        private Point topRight;

        /// <summary>
        /// Creates a <c>Rectangle</c> instance by taking bottom left corner and top right left corner <c>Point</c> instances as <b>parameters</b>
        /// </summary>
        /// <param name="bottomLeft">Bottom left corner <c>Point</c> instance coordinates</param>
        /// <param name="topRight">Top right corner <c>Point</c> instance coordinates</param>
        public Rectangle(Point bottomLeft, Point topRight)
        {
            this.bottomLeft = bottomLeft;
            this.topRight = topRight;
        }

        /// <summary>
        /// Creates new <c>Rectangle</c> instance by taking bottom left corner <c>Point</c> instance  and rectangle width and height as <b>parameters</b>
        /// </summary>
        /// <param name="bottomLeft">Botton left corner <c>Point</c> instance coordinates</param>
        /// <param name="width">Rectangle width</param>
        /// <param name="height">Rectangle height</param>
        public Rectangle(Point bottomLeft, double width, double height)
        {
            this.bottomLeft = bottomLeft;
            this.topRight = new Point(this.bottomLeft.GetX() + width, this.bottomLeft.GetY() + height);
        }

        /// <summary>
        /// Calculates width of the current <c>Rectangle</c> instance
        /// </summary>
        /// <returns>Width of a <c>Rectangle</c> instance</returns>
        public double GetWidth()
        {
            return this.topRight.GetX() - this.bottomLeft.GetX();
        }

        /// <summary>
        /// Calculates height of the current <c>Rectangle</c> instance
        /// </summary>
        /// <returns>Height of a <c>Rectangle</c> instance</returns>
        public double GetHeight()
        {
            return this.topRight.GetY() - this.bottomLeft.GetY();
        }

        /// <summary>
        /// Calculates are of the current <c>Rectangle</c> instance
        /// </summary>
        /// <returns>Current <c>Rectangle</c> instance area</returns>
        public double GetArea()
        {
            return GetHeight() * GetWidth();
        }

        /// <summary>
        /// Calculates perimeter of the current <c>Rectangle</c> instance
        /// </summary>
        /// <returns>Current <c>Rectangle</c> instance perimeter</returns>
        public double GetPerimeter()
        {
            return (GetHeight() * 2) + (GetWidth() * 2);
        }

        /// <summary>
        /// Moves current <c>Rectangle</c> instance by <c>deltaX</c> in <b>X</b> axis and by <c>deltaY</c> in <b>Y</b> axis
        /// </summary>
        /// <param name="deltaX">The distance to move the <c>Rectangle</c> instance in <b>X</b> axis</param>
        /// <param name="deltaY">The distance to move the <c>Rectangle</c> instance in <b>Y</b> axis</param>
        public void Move(double deltaX, double deltaY)
        {
            this.bottomLeft.SetX(this.bottomLeft.GetX() + deltaX);
            this.bottomLeft.SetY(this.bottomLeft.GetY() + deltaY);
            this.topRight.SetX(this.topRight.GetX() + deltaX);
            this.topRight.SetY(this.topRight.GetY() + deltaY);
        }

        /// <summary>
        /// Makes printing <c>Rectangle</c> instance to print a string with <c>Rectangle</c> instance info as: <br/>
        /// <example>
        /// Rectangle:<br/>
        /// bottom-left point = ( 0, 0 )<br/>
        /// topright point = ( 15, 15 )
        /// </example>
        /// </summary>
        public override string ToString()
        {
            return $"Rectangle:\nbottom-left point = {bottomLeft}\ntop-right point = {topRight}".ToString();
        }
        public static void UnitTest()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(15, 10);

            Rectangle rect = new Rectangle(point1, point2);

            Console.WriteLine(rect.GetArea());
            Console.WriteLine(rect.GetPerimeter());

            Console.WriteLine(rect);

            Console.WriteLine("Moving rectangle:");
            rect.Move(10, 10);
            Console.WriteLine(rect);

            rect.Move(10, 0);
        }
    }
}
