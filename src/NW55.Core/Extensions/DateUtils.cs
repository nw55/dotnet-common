using System;
using System.Collections.Generic;
using System.Text;

namespace NW55.Extensions
{
    // https://stackoverflow.com/questions/1004698

    public static class DateUtils
    {
        public static DateTime Truncate(this DateTime date, long ticksResolution)
            => new DateTime(date.Ticks - (date.Ticks % ticksResolution), date.Kind);

        public static DateTime ToSecondsResolution(this DateTime date)
            => date.Truncate(TimeSpan.TicksPerSecond);

        public static DateTime UtcNowSeconds => DateTime.UtcNow.ToSecondsResolution();
    }
}
