using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Question1
{
    public class Program
    {
        // Question 1: 
        // The purpose of this question is to write a method to extract information 
        // about a person based on their ID number.
        /*
            Write an algorithm to extract:
                1. The persons date of birth
                2. Gender
                3. Citizenship
                4. If the ID Number is valid
             A South African ID Number is broken down as follows:
                - The first 6 digits are the persons date of birth in the format YYMMDD
                - The next 4 digits indicate gender:
                    >> 0000 - 4999 = FEMALE
                    >> 5000 - 9999 = MALE
                - The 11th digit indicates citizenship of the person - 
                    >> 0 indicates a South African citizen
                    >> 1  indicates a foreign citizen
                - The last to digits are a checksum based on Luhn algorithm, this is used to validate the ID number
        */

        // NOTE: Please include comments in your code

        private static readonly Regex IDNumberPattern = new Regex(@"^[0-9]{13}$");

        static void Main(string[] args)
        {
            var idNumberList = new List<string>
            {
                "7508305802089",
                "7512305802089"
            };

            foreach(var id in idNumberList)
            {
                var person = ValidateAndExtractInformation(id);
                Console.WriteLine($"Details for person with ID Number: {id}");
                Console.WriteLine($"Person Date Of Birth: {person.DateOfBirth.ToString()}");
                Console.WriteLine($"Person Gender: {person.Gender}");
                Console.WriteLine($"Is person a South African Citizen: {person.isSouthAfricanCitizen.ToString()}");
                Console.WriteLine($"Is ID Number Valid: {person.isValidIDNumber}");
                Console.WriteLine($"**************************************************");
            }

            Console.ReadLine();
        }

        public static Person ValidateAndExtractInformation(string idNumber)
        {
            Person person = new Person();

            // Check if ID number is valid and populate the person object 
            if (IsValidIDNumber(idNumber))
            {
                person.DateOfBirth = ExtractDateOfBirth(idNumber);
                person.Gender = ExtractGender(idNumber);
                person.isSouthAfricanCitizen = IsSouthAfricanCitizen(idNumber);
                person.isValidIDNumber = IsValidIDNumber(idNumber);
            }

            return person;
        }

        public static DateTime ExtractDateOfBirth(string idNumber)
        {
            // Extracts the date of birth from the ID number
            string dateOfBirthString = idNumber.Substring(0, 6);         
            DateTime dateOfBirth = DateTime.ParseExact(dateOfBirthString, "yyMMdd", CultureInfo.InvariantCulture);

            return dateOfBirth;
        }

        public static string ExtractGender(string idNumber)
        {
            // Extracts the gender from the ID number
            string gender = "";

            int genderDigit = int.Parse(idNumber.Substring(6, 1));
            if (genderDigit >= 0 && genderDigit <= 4) gender = "Female";
            else if (genderDigit >= 5 && genderDigit <= 9) gender = "Male";

            return gender;
        }

        public static bool IsSouthAfricanCitizen(string idNumber)
        {
            // Check if it's a south african citizen
            bool isSouthAfricanCitizen = false;
            int citizenshipDigit = int.Parse(idNumber.Substring(10, 1));

            switch (citizenshipDigit)
            {
                case 0:
                    isSouthAfricanCitizen = true;
                    break;
                case 1:
                    isSouthAfricanCitizen = false;
                    break;
            }

            return isSouthAfricanCitizen;
        }

        public static bool IsValidIDNumber(string idNumber)
        {
            // Vaidate if ID number is 13 digits
            if (!IDNumberPattern.IsMatch(idNumber)) return false;

            // Validate if date of birth is valid
            string dateOfBirthString = idNumber.Substring(0, 6);
            DateTime date;
            bool isDateOfBirthValid = DateTime.TryParseExact(dateOfBirthString, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (!isDateOfBirthValid) return false;

            // Validate citizenship check 
            int citizenshipDigit = int.Parse(idNumber.Substring(10, 1));
            if(citizenshipDigit > 1) return false;

            return true;
        }
    }
}
