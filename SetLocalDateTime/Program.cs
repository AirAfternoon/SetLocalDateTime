using System;
using System.Reflection;

namespace SetLocalDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            SetTimeZone(new TimeSpan(-14, 0, 0));
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now);
            SetTimeZone(new TimeSpan(14, 0, 0));
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now);
        }

        static void SetTimeZone(TimeSpan ts)
        {
            var now = DateTime.Now;
            var settingTS = ts;
            TimeZoneInfo settingTZI = TimeZoneInfo.CreateCustomTimeZone("1", settingTS, "测试时区", "测试时区");

            object cachedData = typeof(TimeZoneInfo).GetField("s_cachedData", BindingFlags.NonPublic | BindingFlags.Static).GetValue(settingTZI);

            var typeCachedData = cachedData.GetType();
            typeCachedData.GetField("_localTimeZone", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(cachedData, settingTZI);
            object oneYearLocalFromUtc = typeCachedData.GetField("_oneYearLocalFromUtc", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(cachedData);

            var fieldTS = oneYearLocalFromUtc.GetType().GetField("Offset", BindingFlags.Public | BindingFlags.Instance);
            fieldTS.SetValue(oneYearLocalFromUtc, settingTS);
        }

    }
}
