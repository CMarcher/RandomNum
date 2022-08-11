using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RandomNum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rng = new RandomNumberGenerator();
            var hashTable = new Dictionary<int, int>();
            int count = 0;
            bool validInput = false;

            Console.WriteLine("This is a random number generator (not truly random). It will generate a number between 0 and 10 a certain number of times.");
            Console.Write("Please enter the number of random numbers you'd like to generate: ");

            while (validInput is false)
            {
                string inputRaw = Console.ReadLine();
                validInput = int.TryParse(inputRaw, out count);

                if (validInput is false)
                    Console.WriteLine("That's not a valid integer! Please enter a proper number: ");
            }

            for (int i = 0; i < count; i++)
            {
                int randomNum = rng.NextInt(11);

                // If number already exists in hash table, increase its occurrence count
                if (hashTable.ContainsKey(randomNum))
                    hashTable[randomNum]++;
                else
                    hashTable.Add(randomNum, 1);
            }

            for (int i = 0; i < 11; i++)
                Console.WriteLine($"{i} : {hashTable[i]}");
        }
    }
}
