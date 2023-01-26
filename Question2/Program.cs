using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class Program
    {
        // Question 2:
        // Find every position in an input string where a letter is succeeded by itself
        // Please note that space is not a letter, each time a duplicated letter is found, write this letter plus it's position into the duplicate list
        
        /*
         * Example if data is "letter" position of t is 3 and value is tt
        */
            
        // NOTE: Please include comments in your code
        
        static void Main(string[] args)
        {
            //const string data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commmodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            const string data = "Lorem ipsumm dolor sit amett";
            var duplicates = GetDuplicatedCharacters(data);

            foreach (var duplicateItem in duplicates)
            {
               Console.WriteLine($"Position of { duplicateItem.DuplicatedLetter } is { duplicateItem.DuplicatedPosition } and value is {duplicateItem.DuplicatedLetter}{duplicateItem.DuplicatedLetter} ");
            }
            Console.ReadLine();
        }

        public static List<StringPosition> GetDuplicatedCharacters(string data)
        {
            // Loops through the data string, check for duplicated characters and adds it to a StringPosition list object 
            List<StringPosition> stringPositionList = new List<StringPosition>();

            for (int i = 0; i < data.Length - 1; i++)
            {
                if (Char.IsLetter(data[i]) && data[i] == data[i + 1])
                    stringPositionList.Add(new StringPosition { DuplicatedLetter = data[i], DuplicatedPosition = i });
            }

            return stringPositionList;
        }
    }
}
