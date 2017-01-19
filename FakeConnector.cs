using System;
using System.Collections.Generic;
using System.Linq;

namespace TouchWalkthrough
{
    abstract class FakeConnector
    {
        static List<Drop> dummyDrops;

        private static bool connect()
        {
            return true;
        }

        private static void close()
        {

        }

        public static List<Drop> getNewDrops(DateTime lastUpdate)
        {
            return dummyDrops.Where(drop => drop.lastChange >= lastUpdate).ToList();
        }

        public static bool saveNewDrop(Drop newDrop)
        {
            dummyDrops.Add(newDrop);
            return true;
        }
    }
}