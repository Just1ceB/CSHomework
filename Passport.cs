using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prjcts
{
    internal class Passport
    {
        private string name;
        private int number;
        private Date expiryDate;

        /// <summary>
        /// Creates a <c>Passport</c> instance with <b>parameters:</b>
        /// </summary>
        /// <param name="name">Name on the passport</param>
        /// <param name="number">Number of the passport</param>
        /// <param name="expiryDate">Expiration date of the passport</param>
        public Passport(string name, int number, Date expiryDate)
        {
            this.name = name;
            this.number = number > 0 ? number : 0;
            this.expiryDate = expiryDate;
        }

        /// <summary>
        /// Creates a copy of <c>Passport</c> instance from input <c>Passport</c> instance
        /// </summary>
        /// <param name="passport"><c>Passport</c> instance to copy</param>
        public Passport(Passport passport) : this(passport.GetName(), passport.GetNumber(), passport.GetExpiryDate()) {}

        /// <summary>
        /// Gets name string from current <c>Passport</c> instance
        /// </summary>
        /// <returns>Name string from <c>Passport</c> instance</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// Gets number value from current <c>Passport</c> instance
        /// </summary>
        /// <returns>Number value from <c>Passport</c> instance</returns>
        public int GetNumber()
        {
            return this.number;
        }
        /// <summary>
        /// Gets expiry <c>Date</c> instance from current <c>Passport</c> instance
        /// </summary>
        /// <returns>Expiry <c>Date</c> instance from <c>Passport</c> instance</returns>
        public Date GetExpiryDate()
        {
            return this.expiryDate;
        }

        /// <summary>
        /// Set expiry date to the current <c>Passport</c> instance
        /// </summary>
        /// <param name="expiryDate"><c>Date</c> instance that represents <c>Passport</c> instance expiry date</param>
        public void SetExpiryDate(Date expiryDate)
        {
            this.expiryDate = expiryDate;
        }

        /// <summary>
        /// Creates copy of current <c>Passport</c> instance
        /// </summary>
        /// <param name="passport"><c>Passport</c> instance to copy</param>
        /// <returns>A copy of current <c>Passport</c> instance</returns>
        public Passport Copy(Passport passport)
        {
            Passport copy = new Passport(this.name, this.number, this.expiryDate);
            return copy;
        }

        /// <summary>
        /// Checks if current expiry <c>Date</c> is not past <c>Date</c> instance that inputted as <b>parameter</b>
        /// </summary>
        /// <param name="dateChecked"></param>
        /// <returns>Whether is <c>Passport</c> expired</returns>
        public bool IsValid(Date dateChecked)
        {
            return this.expiryDate.CompareTo(dateChecked) > 0 ? true : false;
        }

        /// <summary>
        /// Makes printing <c>Passport</c> instance to print a string with <c>Passport</c> instance info: <br/>
        /// <example>
        /// Example:<br/>
        /// Name: Name<br/>
        /// Pass. num: 111<br/>
        /// Exp date: 26/02/2026
        /// </example>
        /// </summary>
        public override string ToString()
        {
            return $"Name: {this.name}\nPass. num: {this.number}\nExp date: {this.expiryDate}";
        }
        public static void UnitTest()
        {
            Date expDate = new Date(23, 8, 2029);
            Passport passport = new Passport("Aleksandr", 345191233, expDate);

            Date now = new Date();

            Console.WriteLine(passport);
            Console.Write("The passport is ");
            Console.WriteLine(passport.IsValid(now) ? "valid" : "expired");
            
            expDate.SetDate(29, 1, 2022);
            
            passport.SetExpiryDate(expDate);
            
            Console.WriteLine(passport);
            Console.Write("The passport is ");
            Console.WriteLine(passport.IsValid(now) ? "valid" : "expired");
        }
    }
}
