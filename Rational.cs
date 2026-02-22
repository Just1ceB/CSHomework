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

        public Rational(int x, int y)
        {
            this.x = x;
            this.y = y != 0 ? y : 1;
        }

        public Rational() : this(1, 1) { }

        public Rational(Rational num) : this(num.GetNumerator(), num.GetDenom()) { }

        public Rational Copy()
        {
            Rational copy = new Rational(this.x, this.y);
            return copy;
        }

        public int GetNumerator()
        {
            return this.x;
        }

        public void SetNumerator(int x)
        {
            this.x = x;
        }

        public void SetDenom(int y)
        {
            if (y != 0)
            {
                this.y = y;
            }
        }

        public int GetDenom()
        {
            return this.y;
        }

        bool IsEqual(Rational num)
        {
            return this.x * num.GetDenom() == this.y * num.GetNumerator();
        }

        public Rational Multiply(Rational num)
        {
            Rational result = new Rational(this.x * num.GetNumerator(), this.y * GetDenom());
            return result;
        }

        public Rational Divide(Rational num)
        {
            Rational result = new Rational(this.x * num.GetDenom(), this.y * num.GetNumerator());
            return result;
        }

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
