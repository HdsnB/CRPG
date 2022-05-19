using System;
using System.Collections.Generic;
using System.Text;

namespace CRPG
{
    public static class RandomNumberGenerator
    {
        private static Random _generator = new Random(Guid.NewGuid().GetHashCode());

        public static int NumberBetween(int minVal, int maxVal)
        {
            return _generator.Next(minVal, maxVal + 1);
        }

    }
}
