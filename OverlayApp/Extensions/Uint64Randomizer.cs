using System;

namespace OverlayApp
{
    /// <summary>
    /// Extension class for the Random class
    /// </summary>
    public static class Uint64Randomizer
    {
        /// <summary>
        /// Randomises a UInt64 number.
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        public static UInt64 NextUInt64(this Random rnd)
        {
            var buffer = new byte[sizeof(UInt64)];
            rnd.NextBytes(buffer);
            return BitConverter.ToUInt64(buffer, 0);
        }
    }
}
