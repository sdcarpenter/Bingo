using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo
{
    public static class Extensions
    {
        /// <summary>
        /// Randomize an IEnumerable
        /// </summary>
        /// <typeparam name="T">Type stored in the Enumerable</typeparam>
        /// <param name="data">Enumerable</param>
        /// <remarks>Note this isn't terribly efficient,
        /// a shuffle in place would be faster.</remarks>
        /// <returns>A randomized array</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> data)
        {
            var random = new Random();
            return data.OrderBy(c => random.Next());
        }
    }
}
