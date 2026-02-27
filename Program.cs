using Prjcts;
using System.ComponentModel;

namespace Prjcts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool repeatChoosing = false;

            do
            {
		repeatChoosing = false;

                Console.Write("1 - Point\n2 - Dates\n3 - Rectangle\n4 - Rational\n5 - Passport\n0 - Close\nChoose: ");

                switch (Console.ReadKey().KeyChar)
                {
                    case '0':
                        Console.WriteLine();
                        Console.Write("Closed");
                        break;
                    case '1':
                        Console.WriteLine();
                        Point.UnitTest();
                        break;
                    case '2':
                        Console.WriteLine();
                        Date.UnitTest();
                        break;
                    case '3':
                        Console.WriteLine();
                        Rectangle.UnitTest();
                        break;
                    case '4':
                        Console.WriteLine();
                        Rational.UnitTest();
                        break;
                    case '5':
                        Console.WriteLine();
                        Passport.UnitTest();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Error");
                        repeatChoosing = Funcs.RepeatChoosing();
                        break;
                }
            } while (repeatChoosing);
        }
    }
}
