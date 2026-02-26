using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prjcts
{
    internal class Rational
    {
        private int x; // Numerator
        private int y; // Denominator

        /// <summary>
        /// Creates rational number with <b>parameter X</b> as Numerator and <b>parameter Y</b> as Denominator
        /// </summary>
        /// <param name="x">Numerator</param>
        /// <param name="y">Denominator</param>
        public Rational(int x, int y)
        {
            this.x = x;
            this.y = y != 0 ? y : 1;
        }

        /// <summary>
        /// Creates <c>Rational</c> instance with <b>1</b> as numerator and as denominator
        /// </summary>
        public Rational() : this(1, 1) { }

        /// <summary>
        /// Creates a copy of <c>Rational</c> instance that gets as <b>parameter</b>
        /// </summary>
        /// <param name="num"><c>Rational</c> instance to copy</param>
        public Rational(Rational num) : this(num.GetNumerator(), num.GetDenom()) { }

        /// <summary>
        /// Creates copy of current <c>Rational</c> instance
        /// </summary>
        /// <returns>Copy of <c>Rational</c> instance</returns>
        public Rational Copy()
        {
            Rational copy = new Rational(this.x, this.y);
            return copy;
        }

        /// <summary>
        /// Gets value of current <c>Rational</c> instance numerator
        /// </summary>
        /// <returns>Current <c>Rational</c> instance numerator value</returns>
        public int GetNumerator()
        {
            return this.x;
        }

        /// <summary>
        /// Sets <b>parameter X</b> value as current <c>Rational</c> instance numerator value
        /// </summary>
        /// <param name="x">Numerator value to set</param>
        public void SetNumerator(int x)
        {
            this.x = x;
        }

        /// <summary>
        /// Sets <b>parameter Y</b> value as current <c>Rational</c> instance denominator value
        /// </summary>
        /// <param name="y">Denominator value to set</param>
        public void SetDenom(int y)
        {
            if (y != 0)
            {
                this.y = y;
            }
        }

        /// <summary>
        /// Gets value of current <c>Rational</c> instance denominator value
        /// </summary>
        /// <param name="y">Current <c>Rational</c> instance denominator value</param>
        public int GetDenom()
        {
            return this.y;
        }

        /// <summary>
        /// Checks if current <c>Rational</c> instance is equals to other <c>Rational</c> instance that gets as <b>parameter</b>
        /// </summary>
        /// <param name="num">Other <c>Rational</c> instance</param>
        /// <returns>Whether the numbers are equal or not</returns>
        bool IsEqual(Rational num)
        {
            return this.x * num.GetDenom() == this.y * num.GetNumerator();
        }


        /// <summary>
        /// Multiply between current <c>Rational</c> instance and other <c>Rational</c> instance that gets as <b>
        /// </summary>
        /// <param name="num">Other <c>Rational</c> instance to multiply</param>
        /// <returns>Result of multiplication between the two</returns>
        public Rational Multiply(Rational num)
        {
            Rational result = new Rational(this.x * num.GetNumerator(), this.y * GetDenom());
            return result;
        }

        /// <summary>
        /// Divides between current <c>Rational</c> instance and other <c>Rational</c> instance that gets as <b>
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Result of dividing the two</returns>
        public Rational Divide(Rational num)
        {
            Rational result = new Rational(this.x * num.GetDenom(), this.y * num.GetNumerator());
            return result;
        }

        /// <summary>
        /// Adds current <c>Rational</c> instance to another <c>Rational</c> instance
        /// </summary>
        /// <param name="num">The other <c>Rational</c> instance to add to the current</param>
        /// <returns>The sum of the two</returns>
        public Rational Add(Rational num)
        {
            Rational result = new Rational(this.x * num.GetDenom() + num.GetNumerator() * this.y, this.y * num.GetDenom());
            for (int i = result.GetDenom(); i > 0; i--)
            {
                if (result.GetDenom() % i == 0 && result.GetNumerator() % i == 0)
                {
                    result.SetNumerator(result.GetNumerator() / i);
                    result.SetDenom(result.GetDenom() / i);
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// Takes another <c>Rational</c> instance from current one
        /// </summary>
        /// <param name="num">Other <c>Rational</c> instance to take from current</param>
        /// <returns>Difference between the two</returns>
        public Rational Take(Rational num)
        {
            Rational result = new Rational(this.x * num.GetDenom() - num.GetNumerator() * this.y, this.y * num.GetDenom());
            for (int i = result.GetDenom(); i > 0; i--)
            {
                if (result.GetDenom() % i == 0 && result.GetNumerator() % i == 0)
                {
                    result.SetNumerator(result.GetNumerator() / i);
                    result.SetDenom(result.GetDenom() / i);
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// Makes printing <c>Rational</c> instance to print a string in:<br/>
        /// <example>
        /// 'Numenator' / 'Denominator'
        /// </example>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.x} / {this.y}";
        }

        public static void UnitTest()
        {
            Rational anum = new Rational(15, 45);
            Rational bnum = new Rational(3, 9);
            Rational cnum = new Rational(1, 9);

            Console.WriteLine($"The numbers are: {anum}, {bnum}, {cnum}");

            Console.Write($"numbers {anum} and {bnum} are ");
            Console.WriteLine(anum.IsEqual(bnum) ? "equal." : "not equal");

            Console.Write($"And {anum} and {cnum} are ");
            Console.WriteLine(anum.IsEqual(cnum) ? "equal." : "not equal");

            Rational dnum = anum.Copy();

            Console.WriteLine($"Copied number is: {dnum}");


            Console.WriteLine($"The sum of {bnum} and {cnum} is {bnum.Add(cnum)}");
            Console.WriteLine($"The difference between {bnum} and {cnum} is {bnum.Take(cnum)}");
        }
    }
}
