using System;

namespace TouchWalkthrough
{
    class Event
    {
        public String name { get; set; }
        public Location pos { get; set; }
        public DateTime start { get; set; }

        public Event()
        {
        }

        public bool saveToFile(String filename)
        {
            return true;
        }
    }
}