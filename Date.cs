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

        public Date(int day, int month, int year)
        {
            bool isLongMonth = month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 ||
                               month == 12;
            bool isFebruar = month == 2;
            bool isLongYear = year % 4 == 0;
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
                if (isLongYear)
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

        public Date(Date time) : this(time.GetDay(), time.GetMonth(), time.GetYear())
        {
        }

        public Date() : this(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year)
        {
        }

        public int GetDay()
        {
            return this.day;
        }

        public void SetDay(int day)
        {
            bool isLongMonth = this.month == 1 || this.month == 3 || this.month == 5 || this.month == 7 ||
                               this.month == 8 || this.month == 10 || this.month == 12;
            bool isFebruar = this.month == 2;
            bool isLongYear = this.year % 4 == 0;
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
                if (isLongYear)
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

        public int GetMonth()
        {
            return this.month;
        }

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

        public int GetYear()
        {
            return this.year;
        }

        public void SetYear(int year)
        {
            if (!(this.month == 2 && this.day == 29 && year % 4 != 0))
            {
                this.year = year;
            }
        }

        public void SetDate(int day, int month, int year)
        {
            SetDay(day);
            SetMonth(month);
            SetYear(year);
        }

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

        public override string ToString()
        {
            return $"{this.day}/{this.month}/{this.year}";
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

            Console.WriteLine(randomDate);

            Date copyDate = new Date(randomDate);
            Console.WriteLine(copyDate);

            copyDate.SetDate(12, 12, 2222);
            Console.WriteLine(copyDate);
        }
    }
}