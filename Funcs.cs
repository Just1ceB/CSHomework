using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prjcts
{
    internal class Funcs
    {
        /// <summary>
        /// This function asks the user whether he wants to keep to choose options in program
        /// </summary>
        /// <returns>Whether user wants to keep using the program and choose options</returns>
        public static bool RepeatChoosing()
        {
            bool correct = false;
            ConsoleKeyInfo a;

            Console.WriteLine("\n==========================================================================\n");

            do
            {
                Console.Write("Want to see another option? Y/N: ");
                a = Console.ReadKey();
                Console.WriteLine();
                switch (a.KeyChar)
                {
                    case 'y':
                    case 'Y':
                        Console.WriteLine("\n==========================================================================\n");
                        return true;
                        break;
                    case 'n':
                    case 'N':
                        Console.WriteLine("\n==========================================================================\n");
                        return false;
                        break;
                    default:
                        Console.WriteLine("Answer with Y or N");
                        break;
                }
            } while (!correct);

            return false; // Function doesn't work if removed but rudement in general
        }

        /// <summary>
        /// This function will get minimal and maximal number to generate a number in their bounds
        /// </summary>
        /// <param name="min">Bottom bound to random num</param>
        /// <param name="max">Upper bound to random num</param>
        /// <returns>Random num between <c>min</c> and <c>max</c></returns>
        public static int GenNumber(int min, int max)
        {
            Random rnd = new Random();
            int tmp = max;
            max = Math.Max(min, max);
            min = Math.Min(min, tmp);
            max++;

            return rnd.Next(min, max);
        }

        /// <summary>
        /// This function will count amount of digits in <c>double</c> variable
        /// </summary>
        /// <param name="number">Any <c>double</c> type variable</param>
        /// <returns>Returns amount of digits in <b>parameter</b> <c>double</c> variable</returns>
        public static int FloatDigitAmount(double number)
        {
            string strNum = number.ToString();
            bool isRational = false;

            for (int i = 0; i < strNum.Length; i++)
            {
                if (strNum[i] == '.')
                {
                    isRational = true;
                }
            }

            return isRational ? strNum.Length - 1 : strNum.Length;
        }

        /// <summary>
        /// This function generates array with random numbers
        /// </summary>
        /// <param name="length">Array`s length</param>
        /// <param name="min">Bottom bound to random array value</param>
        /// <param name="max">Upper bound to random array value</param>
        /// <returns>Array filled with random numbers between <c>min</c> and <c>max</c></returns>
        public static int[] GenArr(int length, int min, int max)
        {
            Random rnd = new Random();
            int tmp = max;
            max = Math.Max(min, max);
            min = Math.Min(min, tmp);
            max++;
            int[] arr = new int[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(min, max);
            }
            return arr;
        }

        /// <summary>
        /// This function records array from the user
        /// </summary>
        /// <param name="length">Length of the recorded array</param>
        /// <returns>Array filled with values from user input</returns>
        public static int[] RecordArray(int length)
        {
            int[] arr = new int[length];
            int startPos;
            string userInput;
            Console.Write('[');
            for (int i = 0; i < arr.Length; i++)
            {
                startPos = Console.CursorLeft;
                userInput = Console.ReadLine();
                arr[i] = int.Parse(userInput);
                Console.SetCursorPosition(startPos + userInput.Length, Console.CursorTop - 1);
                Console.Write(i < arr.Length - 1 ? ", " : "]" );
            }
            return arr;
        }

        /// <summary>
        /// This function prints array in <c>[a, b, c]</c> format
        /// </summary>
        /// <param name="arr">Array to print</param>
        /// <example><code>[a, b, c]</code> or <code>[0, 1, 2]</code></example>
        public static void PrintArray(int[] arr)
        {
            Console.Write('[');
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(i < arr.Length - 1 ? ", " : "]");
            }
        }

        /// <summary>
        /// This function checks which array between the two is the longest one
        /// </summary>
        /// <param name="arr1">First array to check</param>
        /// <param name="arr2">Second array to check</param>
        /// <returns>Longest array between the two</returns>
        public static int[] LongestArray(int[] arr1, int[] arr2)
        {
            return (arr1.Length > arr2.Length) ? arr1 : arr2;
        }

        /// <summary>
        /// This function checks which array between the two is the shortest one
        /// </summary>
        /// <param name="arr1">First array to check</param>
        /// <param name="arr2">Second array to check</param>
        /// <returns>Shortest array between the two</returns>
        public static int[] ShortestArray(int[] arr1, int[] arr2)
        {
            return (arr1.Length < arr2.Length) ? arr1 : arr2;
        }

    }
}
