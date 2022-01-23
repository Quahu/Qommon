using System;
using System.ComponentModel;

namespace Qommon
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class RandomExtensions
    {
        /// <summary>
        ///     Returns a random <see cref="bool"/> based on <see cref="Random.NextDouble()"/>
        ///     returning less than <c>0.5</c>.
        /// </summary>
        /// <returns>
        ///     A <see cref="bool"/>.
        /// </returns>
        public static bool NextBoolean(this Random random)
            => random.NextDouble() < 0.5;

        /// <summary>
        ///     Returns a random <see cref="bool"/> based on <see cref="Random.NextDouble()"/>
        ///     returning less than <paramref name="probability"/>.
        /// </summary>
        /// <param name="random"> The random instance. </param>
        /// <param name="probability"> The [0..1) probability. </param>
        /// <returns>
        ///     A <see cref="bool"/>.
        /// </returns>
        public static bool NextBoolean(this Random random, double probability)
        {
            Guard.IsBetweenOrEqualTo(probability, 0, 1);

            return random.NextDouble() < probability;
        }
    }
}
