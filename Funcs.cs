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
        /*
        This function asks if user want to keep using the program that using the function
        input: none
        output: whether to keep choosing between the options
        */
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

        /*
        This function will get minimal and maximal number to generate a number in their bounds
        input: minimal number, maximal number
        output: random number between them
        */
        public static int GenNumber(int min, int max)
        {
            Random rnd = new Random();
            int tmp = max;
            max = Math.Max(min, max);
            min = Math.Min(min, tmp);
            max++;

            return rnd.Next(min, max);
        }

        /*
        This function generates array with random numbers
        input: array`s length, minimal possible number and maximal possible number
        output: randomized array
        */
        public static int[] GenArr(int length, int min, int max)
        {

            int tmp = max;
            max = Math.Max(min, max);
            min = Math.Min(min, tmp);
            max++;

            Random rnd = new Random();

            int[] arr = new int[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(min, max);
            }
            return arr;
        }

        /*
        This function records array from the user
        input: array length
        output: array with values from the user
        */
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

        /*
        This function prints array in [a, b, c] format
        input: array
        output: none
        */
        public static void PrintArray(int[] arr)
        {
            Console.Write('[');
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(i < arr.Length - 1 ? ", " : "]");
            }
        }

        /*
        This function checks which array between two are the longest one
        input: two arrays
        output: the longest array
        */
        public static int[] LongestArray(int[] arr1, int[] arr2)
        {
            return (arr1.Length > arr2.Length) ? arr1 : arr2;
        }

        /*
        This function checks which array between two are the shortest one
        input: two arrays
        output: the shortest array
        */
        public static int[] ShortestArray(int[] arr1, int[] arr2)
        {
            return (arr1.Length < arr2.Length) ? arr1 : arr2;
        }

    }
}
