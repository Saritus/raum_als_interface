using System;
using System.Collections.Generic;
using System.Linq;

namespace TouchWalkthrough
{
    public class FakeConnector : DbConnector
    {
        static List<Drop> dummyDrops
        {
            get
            {
                if (!dummyDropsCreated)
                {
                    // Create dummy drops
                    foreach (Category filter in Enum.GetValues(typeof(Category)))
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            string f = Enum.GetName(typeof(Category), filter);
                            dummyDrops.Add(new Drop(i, "Test" + f + i, filter, "Test" + f + i + "Description, ", DateTime.Today, DateTime.Now, new ExtendedLocation()));
                        }
                    }

                }
                return dummyDrops;
            }
        }
        static bool dummyDropsCreated = false;

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