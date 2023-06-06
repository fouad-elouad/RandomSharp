using System;
using System.Security.Cryptography;

namespace RandomSharp.Impl
{
    /// <summary>
    /// using the System.Security.Cryptography.RNGCryptoServiceProvider class as generation algorithm.
    /// </summary>
    public class RNGRandomizer : Randomizer, IRandomizer
    {
        protected static RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();

        /// <summary>
        /// Get random boolean
        /// </summary>
        /// <returns>bool</returns>
        protected override bool InternalBoolean()
        {
            byte[] randomByte = new byte[1];
            rngCryptoServiceProvider.GetBytes(randomByte);
            return (randomByte[0] & 1) == 1;
        }

        /// <summary>
        /// Get non-negative random integer that is less than to the specified maximum.
        /// </summary>
        /// <param name="maxExclusive">maxExclusive int, exclusive</param>
        /// <returns>int</returns>
        protected override int InternalInt(int maxExclusive)
        {
            return InternalInt(0, maxExclusive);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minInclusive">minInclusive int, inclusive</param>
        /// <param name="maxExclusive">maxExclusive int, exclusive</param>
        /// <returns>int</returns>
        protected override int InternalInt(int minInclusive, int maxExclusive)
        {
            double scaleFactor = ScaleFactor();
            return (int)(minInclusive + (maxExclusive - minInclusive) * scaleFactor);
        }

        /// <summary>
        /// Get random Double between two doubles
        /// </summary>
        /// <param name="min">min double</param>
        /// <param name="max">max double</param>
        /// <returns>double</returns>
        protected override double InternalDouble(double min, double max)
        {
            return InternalDouble() * (max - min) + min;
        }

        /// <summary>
        /// Get random Double between 0 and 1
        /// </summary>
        /// <returns>double</returns>
        protected override double InternalDouble()
        {
            return ScaleFactor();
        }

        protected double ScaleFactor()
        {
            byte[] randomBytes = new byte[8];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            ulong randomUInt64 = BitConverter.ToUInt64(randomBytes, 0);
            return randomUInt64 / (ulong.MaxValue + 1.0);
        }
    }
}