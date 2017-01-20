using System;

namespace TouchWalkthrough
{
    class RandomDateTime
    {
        DateTime start;
        DateTime end;
        Random gen = new Random();
        int range;

        public RandomDateTime(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
            range = (end - start).Days;
        }

        public DateTime Next()
        {
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
    }
}