using System;
using System.Linq;
using ddd.Core.Entities;

namespace ddd.Core.Queries
{
    public static class QueryableAvialabilityExtensions
    {
        private const int SecondsPerHour = 3600;
        private const int SecondsPerMinute = 60;

        /// <summary>
        /// Return entities with a given tenant
        /// </summary>
        public static IQuery<T> IsAvialable<T>(this IQuery<T> query, DateTime time) 
            where T : Entity, IAvialability
        {
            // get day of week
            var d = (int)time.DayOfWeek;
            // seconds since midnight
            var s = time.Hour * SecondsPerHour + time.Minute * SecondsPerMinute + time.Second;

            query.Queryable = query.Queryable
                .Where(item => item.Start[d] <= s)
                .Where(item => item.End[d] >= s);

            return query;
        }
    }
}