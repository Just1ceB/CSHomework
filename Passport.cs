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

        public Passport(string name, int number, Date expiryDate)
        {
            this.name = name;
            this.number = number > 0 ? number : 0;
            this.expiryDate = expiryDate;
        }

        public Passport(Passport passport) : this(passport.GetName(), passport.GetNumber(), passport.GetExpiryDate()) {}

        public string GetName()
        {
            return this.name;
        }
        public int GetNumber()
        {
            return this.number;
        }

        public Date GetExpiryDate()
        {
            return this.expiryDate;
        }

        public void SetExpiryDate(Date expiryDate)
        {
            this.expiryDate = expiryDate;
        }

        public Passport Copy(Passport passport)
        {
            Passport copy = new Passport(this.name, this.number, this.expiryDate);
            return copy;
        }

        public bool IsValid(Date dateChecked)
        {
            return this.expiryDate.CompareTo(dateChecked) == 1 ? true : false;
        }

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
