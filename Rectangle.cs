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

        public Rectangle(Point bottomLeft, Point topRight)
        {
            this.bottomLeft = bottomLeft;
            this.topRight = topRight;
        }

        public Rectangle(Point bottomLeft, double width, double height)
        {
            this.bottomLeft = bottomLeft;
            this.topRight = new Point(this.bottomLeft.GetX() + width, this.bottomLeft.GetY() + height);
        }

        public double GetWidth()
        {
            return this.topRight.GetX() - this.bottomLeft.GetX();
        }

        public double GetHeight()
        {
            return this.topRight.GetY() - this.bottomLeft.GetY();
        }

        public double GetArea()
        {
            return GetHeight() * GetWidth();
        }

        public double GetPerimeter()
        {
            return (GetHeight() * 2) + (GetWidth() * 2);
        }

        public void Move(double deltaX, double deltaY)
        {
            this.bottomLeft.SetX(this.bottomLeft.GetX() + deltaX);
            this.bottomLeft.SetY(this.bottomLeft.GetY() + deltaY);
            this.topRight.SetX(this.topRight.GetX() + deltaX);
            this.topRight.SetY(this.topRight.GetY() + deltaY);
        }

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
