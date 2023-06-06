
namespace RandomSharp.Impl
{
    /// <summary>
    /// using the XorShift algorithm
    /// </summary>
    public class XorShiftRandomizer : Randomizer, IRandomizer
    {

        protected uint x = 0, y = 0, z = 0, w = 0;

        const uint MT19937 = 1812433253;

        public XorShiftRandomizer()
        {
            InitSeed();
        }

        public void InitSeed()
        {
            x = unchecked((uint)System.DateTime.Now.Ticks);
            y = MT19937 * x + 1;
            z = MT19937 * y + 1;
            w = MT19937 * z + 1;
        }

        protected uint XorShifttInt()
        {
            uint t = x ^ (x << 11);
            x = y; y = z; z = w;
            return (w = w ^ (w >> 19) ^ t ^ (t >> 8));
        }

        /// <summary>
        /// Get random boolean
        /// </summary>
        /// <returns>bool</returns>
        protected override bool InternalBoolean()
        {
            return XorShifttInt() % 2 == 0;
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
            checked
            {
                double scaleFactor = ScaleFactor();
                return (int)(minInclusive + (maxExclusive - minInclusive) * scaleFactor);
            }
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
            const double scale = 1.0 / uint.MaxValue;
            return XorShifttInt() * scale;
        }
    }
}