using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjcts
{
    internal class Date
    {
        private int day;
        private int month;
        private int year;

        /// <summary>
        /// Creates new <c>Date</c> instance using input <b>parameters</b>
        /// </summary>
        /// <param name="day">Day value for the date</param>
        /// <param name="month">Month value for the date</param>
        /// <param name="year">Year value for the date</param>
        public Date(int day, int month, int year)
        {
            bool isLongMonth = month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 ||
                month == 12;
            bool isFebruar = month == 2;
            bool isLeapYear = year % 4 == 0;
            if (!isFebruar)
            {
                if (isLongMonth)
                {
                    this.day = (day <= 31 && day > 0) ? day : 0;
                }
                else
                {
                    this.day = (day < 31 && day > 0) ? day : 0;
                }
            }
            else
            {
                if (isLeapYear)
                {
                    this.day = (day <= 29 && day > 0) ? day : 0;
                }
                else
                {
                    this.day = (day < 29 && day > 0) ? day : 0;
                }
            }

            this.month = month > 0 && month <= 12 ? month : 0;
            this.year = year;

            if (this.day == 0 || this.month == 0)
            {
                this.day = 0;
                this.month = 0;
            }
        }

        /// <summary>
        /// Creates a copy of the <c>Date</c> isntance
        /// </summary>
        /// <param name="time"><c>Date</c> instance to copy</param> 
        public Date(Date time) : this(time.GetDay(), time.GetMonth(), time.GetYear())
        {
        }

        /// <summary>
        /// Creates <c>Date</c> instance using computers current date
        /// </summary>
        public Date() : this(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year)
        {
        }

        /// <summary>
        /// Gets gurrent <c>Date</c> instance day value
        /// </summary>
        /// <returns><c>this.day</c> value</returns>
        public int GetDay()
        {
            return this.day;
        }

        /// <summary>
        /// Sets <b>parameter</b> as current <c>Date</c> instance day value
        /// </summary>
        /// <param name="day">Day value to set</param>
        public void SetDay(int day)
        {
            bool isLongMonth = this.month == 1 || this.month == 3 || this.month == 5 || this.month == 7 ||
                this.month == 8 || this.month == 10 || this.month == 12;
            bool isFebruar = this.month == 2;
            bool isLeapYear = IsLeapYear();
            if (!isFebruar)
            {
                if (isLongMonth)
                {
                    if (day <= 31 && day > 0)
                    {
                        this.day = day;
                    }
                }
                else
                {
                    if (day < 31 && day > 0)
                    {
                        this.day = day;
                    }
                }
            }
            else
            {
                if (isLeapYear)
                {
                    if (day <= 29 && day > 0)
                    {
                        this.day = day;
                    }
                }
                else
                {
                    if (day < 29 && day > 0)
                    {
                        this.day = day;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the current <c>Date</c> instance month value
        /// </summary>
        /// <returns><c>this.month</c> value</returns>
        public int GetMonth()
        {
            return this.month;
        }

        /// <summary>
        /// Sets <b>parameter</b> as current <c>Date</c> instance month value
        /// </summary>
        /// <param name="month">Month value to set</param>
        public void SetMonth(int month)
        {
            if (month > 0 && month <= 12)
            {
                if (month == 2 && this.year % 4 == 0 && day <= 29)
                {
                    this.month = month;
                }
                else if (month == 2 && this.year % 4 != 0 && day < 29)
                {
                    this.month = month;
                }
                else
                {
                    this.month = month;
                }
            }
        }
        /// <summary>
        /// Gets the current <c>Date</c> instance year value
        /// </summary>
        /// <returns><c>this.year</c> value</returns>
        public int GetYear()
        {
            return this.year;
        }

        /// <summary>
        /// Sets <b>parameter</b> as year value for the current <c>Date</c> instance
        /// </summary>
        /// <param name="year">Year value to set</param>
        public void SetYear(int year)
        {
            if (!(this.month == 2 && this.day == 29 && year % 4 != 0))
            {
                this.year = year;
            }
        }

        /// <summary>
        /// Sets date for the current <c>Date</c> instance by 3 parameters
        /// </summary>
        /// <param name="day">Date day</param>
        /// <param name="month">Date month</param>
        /// <param name="year">Date year</param>
        public void SetDate(int day, int month, int year)
        {
            SetDay(day);
            SetMonth(month);
            SetYear(year);
        }

        /// <summary>
        /// Updates current <c>Date</c> instance to current date
        /// </summary>
        public void UpdateDate()
        {
            SetDay(DateTime.Now.Day);
            SetMonth(DateTime.Now.Month);
            SetYear(DateTime.Now.Year);
        }

        /// <summary>
        /// Sorts an array of dates by bubble sort method
        /// </summary>
        public static void DateSort(Date[] dates)
        {
            Date tmp = new Date();
            for (int i = 0; i < dates.Length; i++)
            {
                for (int j = 0; j < dates.Length - 1; j++)
                {
                    if (dates[j].CompareTo(dates[j+1]) > 0)
                    {
                        tmp = dates[j + 1];
                        dates[j + 1] = dates[j];
                        dates[j] = tmp;
                    }
                }
            }
        }

        /// <summary>
        /// Compares between current <c>Date</c> instance to another <c>Date</c> instance that comes as <b>parameter</b>
        /// <example>
        /// <code>
        /// Console.Write(new Date(5,2,2026).CompareTo(new Date(1,12,2025))); // Will print positive number
        /// Console.Write(new Date(1,12,2025).CompareTo(new Date(5,2,2026))); // Will print negative number
        /// Console.Write(new Date(1,1,2026).CompareTo(new Date(1,1,2026))); // Will print 0
        /// </code>
        /// </example> 
        /// </summary>
        /// <param name="other">Other date</param>
        /// <returns>0 if Dates are the same <br/>
        /// Negative number if Date the function is operated on is earlier than <c>other</c> date <br/>
        /// Positive number if Date the function is operated on is after the <c>other</c> date </returns>
        public int CompareTo(Date other)
        {
            if (this.year != other.GetYear())
            {
                return this.year - other.GetYear();
            }
            else if (this.month != other.GetMonth())
            {
                return this.month - other.GetMonth();
            }
            else
            {
                return this.day - other.GetDay();
            }
        }

        /// <summary>
        /// Checks if the current <c>Date</c> instance year is a leap year
        /// </summary>
        /// <returns> Whether is current <c>Date</c> instance year is a leap year </returns>
        public bool IsLeapYear()
        {
            return this.year % 4 == 0 && this.year % 100 != 0 || this.year % 400 == 0;
        }

        /// <summary>
        /// Makes printing <c>Date</c> instance to print the string with the date <br/>
        /// <example>
        /// Will print todays date in dd/mm/yyyy format<br/> Example: 26/02/2026
        /// </example>
        /// </summary>
        public override string ToString()
        {
            return $"{this.day:00}/{this.month:00}/{this.year:0000}";
        }

        public static void UnitTest()
        {
            Date currentDate = new Date();

            Console.WriteLine(currentDate);

            Date randomDate = new Date(1, 4, 2026);

            Console.WriteLine(randomDate);

            randomDate.SetDay(28);
            randomDate.SetMonth(7);
            randomDate.SetYear(2012);

            Date otherDate = new Date(5, 7, 2013);

            Console.WriteLine(randomDate);

            Date copyDate = new Date(randomDate);
            Console.WriteLine(copyDate);

            copyDate.SetDate(12, 12, 2222);
            Console.WriteLine(copyDate);


            Console.WriteLine(new Date().CompareTo(new Date(2,3,2026)) > 0 ? "Before current date" : "After current Date");


            Console.WriteLine(new Date(28, 2, 2026).CompareTo(new Date(5,7,2013)) > 0 ? "Before current date" : "After current Date");

            Date[] dates = {currentDate, randomDate, copyDate, otherDate};


            for (int i = 0; i < dates.Length; i++)
            {
                Console.Write($"{dates[i]} ,");
            }
            Console.Write("]");

            for (int i = 0; i < dates.Length; i++)
            {
                Console.Write($"{dates[i]} ,");
            }
            Console.Write("]");

            Console.WriteLine(otherDate);
            DateSort(dates);

            Date datetest1 = new Date(2, 1, 2024);
            Date datetest2 = new Date(2, 1, 1900);
            Date datetest3 = new Date(2, 1, 2000);
            Console.WriteLine("Leap year test:");
            Console.WriteLine($"{datetest1}:{datetest1.IsLeapYear()}");
            Console.WriteLine($"{datetest2}:{datetest2.IsLeapYear()}");
            Console.WriteLine($"{datetest3}:{datetest3.IsLeapYear()}");
            Console.WriteLine("---------");

            Console.Write("[");

            for (int i = 0; i < dates.Length; i++)
            {
                Console.Write($"{dates[i]} ,");
            }
            Console.Write("]");
        }
    }
}
