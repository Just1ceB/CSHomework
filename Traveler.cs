using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prjcts
{
    internal class Traveler
    {
        private Passport passport;
        private bool hasPaid;

        /// <summary>
        /// Creates new <c>Traveler</c> instance with <c>Passport</c> instance and if trip is paid boolean variable as <b>parameters</b>
        /// </summary>
        /// <param name="passport"><c>Passport</c> of the <c>Traveler</c></param>
        /// <param name="hasPaid">Whether the <c>Traveler</c> has paid for the trip or not</param>
        public Traveler(Passport passport, bool hasPaid)
        {
            this.passport = passport;
            this.hasPaid = hasPaid;
        }

        /// <summary>
        /// Checks if <c>Traveler</c>'s <c>Passport</c> is valid and that <c>Traveler</c> paid for the trip
        /// </summary>
        /// <param name="travelDate"><c>Date</c> to check if the <c>Traveler</c>'s passport is valid relatively to the <c>Date</c><param>
        /// <returns>Whether <c>Traveler</c> can travel or not</returns>
        public bool CheckTravel(Date travelDate)
        {
            return this.hasPaid && this.passport.IsValid(travelDate);
        }

        /// <summary>
        /// Sets the state of the <c>Traveler</c> to paid (Pays for the trip for the <c>Traveler</c>
        /// </summary>
        public void Pay()
        {
            this.hasPaid = true;
        }

        /// <summary>
        /// Counts how many <c>Traveler</c>s from <b>parameter</b> <c>Traveler</c>s array<br/>
        /// have valid trips and can travel
        /// </summary>
        /// <param name="travelers">Array of <c>Traveler</c></param>
        /// <returns>Amount of valid <c>Traveler</c>s</returns>
        public static int ValidTravelersAmount(Traveler[] travelers)
        {
            Date today = new Date();
            int validCount = 0;

            for (int i = 0; i < travelers.Length; i++)
            {
                if (travelers[i].CheckTravel(today))
                {
                    validCount++;
                }
            }

            return validCount;
        }

        /// <summary>
        /// When <c>Traveler</c> instance is printed, prints a string with folowing info:<br/>
        /// Name of the <c>Traveler</c><br/>
        /// <c>Passport</c> number of the <c>Traveler</c><br/>
        /// <c>Passport</c> expiry date of the <c>Traveler</c><br/>
        /// Whether the <c>Traveler</c> paid for the trip
        /// </summary>
        /// <returns>a string with info from <b>summary</b></returns>
        public override string ToString()
        {
            return $"Name: {this.passport.GetName()}\nPass. num: {this.passport.GetNumber()}\nExp. date: {this.passport.GetExpiryDate()}\nHas paid: {hasPaid}";
        }

        public static void UnitTest()
        {
            Date validDate = new Date(25,11,2026);
            Date expiredDate = new Date(25,11, 2025);
            Date today = new Date(); 
            Passport passport = new Passport("Name", 1234, validDate);
            Traveler traveler = new Traveler(passport, false);

            Console.WriteLine(traveler);
            Console.WriteLine($"The trip is valid: {traveler.CheckTravel(today)}");
            traveler.Pay();

            Console.WriteLine(traveler);
            Console.WriteLine($"The trip is valid: {traveler.CheckTravel(today)}");

            passport.SetExpiryDate(expiredDate);

            Console.WriteLine(traveler);
            Console.WriteLine($"The trip is valid: {traveler.CheckTravel(today)}");

            Passport validPassport = new Passport("Name", 1234, today);
            Traveler valid = new Traveler(validPassport, true);
            Traveler invalid = new Traveler(validPassport, false);

            Traveler[] travelers = { valid, valid, valid, valid, valid, invalid, invalid, invalid, invalid, invalid };

            Console.WriteLine($"Amount of valid travelers:{Traveler.ValidTravelersAmount(travelers)}");
        }
    }
}
