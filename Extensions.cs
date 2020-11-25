﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo
{
    public static class Extensions
    {
        /// <summary>
        /// Random number generator
        /// </summary>
        private static readonly Random _Random = new Random();

        /// <summary>
        /// Lock object for random number generator
        /// </summary>
        private static object _Lock = new object();
        
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
            int randomNumber;

            lock (_Lock)
                randomNumber = _Random.Next();
            return data.OrderBy(c => randomNumber);
        }

        /// <summary>Partitions an array into smaller collections of partitionSize.  The last
        /// partition may contain fewer elements.</summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="source">Source array</param>
        /// <param name="partitionSize">Number of elements to put in each partition</param>
        /// <returns></returns>
        public static IEnumerable<IReadOnlyList<T>> Partition<T>(this IEnumerable<T> source, int partitionSize)
        {
            if (partitionSize < 0)
                throw new ArgumentException("partitionSize value of " + partitionSize + " is invalid.  It must be > 0.");

            var currentPartition = new List<T>();
            foreach (var item in source)
            {
                if (currentPartition.Count >= partitionSize)
                {
                    yield return currentPartition;
                    currentPartition = new List<T>(partitionSize) { item };
                }
                else
                {
                    currentPartition.Add(item);
                }
            }

            if (currentPartition.Any())
                yield return currentPartition;
        }
    }
}
