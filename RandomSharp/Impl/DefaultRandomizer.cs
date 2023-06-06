using System;

namespace RandomSharp.Impl
{
    /// <summary>
    /// using the System.Random class as generation algorithm
    /// </summary>
    public class DefaultRandomizer : Randomizer, IRandomizer
    {
        protected static Random _Random = new Random();

        /// <summary>
        /// Get random boolean
        /// </summary>
        /// <returns>bool</returns>
        protected override bool InternalBoolean()
        {
            return _Random.Next(2) == 0;
        }

        /// <summary>
        /// Get non-negative random integer that is less than to the specified maximum.
        /// </summary>
        /// <param name="maxExclusive">maxExclusive int, exclusive</param>
        /// <returns>int</returns>
        protected override int InternalInt(int maxExclusive)
        {
            return _Random.Next(maxExclusive);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minInclusive">minInclusive int, inclusive</param>
        /// <param name="maxExclusive">maxExclusive int, exclusive</param>
        /// <returns>int</returns>
        protected override int InternalInt(int minInclusive, int maxExclusive)
        {
            return _Random.Next(minInclusive, maxExclusive);
        }

        /// <summary>
        /// Get random Double between two doubles
        /// </summary>
        /// <param name="min">min double</param>
        /// <param name="max">max double</param>
        /// <returns>double</returns>
        protected override double InternalDouble(double min, double max)
        {
            return _Random.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Get random Double between 0 and 1
        /// </summary>
        /// <returns>double</returns>
        protected override double InternalDouble()
        {
            return _Random.NextDouble();
        }
    }
}