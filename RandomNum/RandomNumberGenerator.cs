using System;
using System.Collections.Generic;

namespace RandomNum
{
    public class RandomNumberGenerator
    {
        List<int> Storage { get; set; }
        int M { get; set; }

        public RandomNumberGenerator(int seed = 292929)
        {
            M = (int)Math.Pow(10, 9);

            var sGenerations = new int[55];
            sGenerations[0] = seed;
            sGenerations[1] = 1;

            // Generate s0 to s54
            for (int s = 2; s <= 54; s++)
                sGenerations[s] = (sGenerations[s - 2] - sGenerations[s - 1]) % M;

            Storage = new List<int>();

            // Generate r0 to r54
            for (int r = 0; r <= 54; r++)
            {
                int s = 34 * (r + 1) % 55;
                Storage.Add(sGenerations[s]);
            }

            for (int r = 0; r < 165; r++)
                GenerateNextR();
        }

        int GenerateNextR()
        {
            int size = Storage.Count;
            int r = (Storage[size - 55] - Storage[size - 24]) % M;

            Storage.Add(r);
            Storage.RemoveAt(0);

            return r;
        }

        /// <summary>
        /// Get the next pseudo-random number in the sequence.
        /// </summary>
        /// <param name="max">The positive limit of random numbers that can be generated, not inclusive.</param>
        /// <returns></returns>
        public int NextInt(int max)
        {
            int nextR = GenerateNextR();

            return Math.Abs(nextR % max);
        }
    }
}
