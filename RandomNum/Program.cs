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

            for (int i = 0; i < 1000000000; i++)
            {
                int randomNum = rng.NextInt(11);

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
