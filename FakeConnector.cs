using System;
using System.Collections.Generic;
using System.Linq;

namespace TouchWalkthrough
{
    public class FakeConnector : Connector
    {

        // Singleton-part

        private static FakeConnector instance;

        private FakeConnector()
        {
            dummyDrops = createDummyDrops();
        }

        public static FakeConnector Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FakeConnector();
                }
                return instance;
            }
        }

        // Fake-part

        static public List<Drop> dummyDrops { get; private set; }

        private static List<Drop> createDummyDrops()
        {
            List<Drop> dummyDrops = new List<Drop>();

            dummyDrops.Add(new Drop(0, "Ausstellung Architektur", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(new Drop(1, "Party Semesterstart", Category.EVENT, new DateTime(2017, 2, 3), new HTWLocation(Building.Z, "701")));
            dummyDrops.Add(new Drop(2, "Grillen Fak. Informatik", Category.EVENT, new DateTime(2017, 2, 14), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(new Drop(3, "Tag der offenen Tür", Category.EVENT, new DateTime(2017, 2, 21), new HTWLocation(Building.S, "311")));
            dummyDrops.Add(new Drop(4, "Seminar EWZ", Category.EVENT, new DateTime(2017, 3, 29), new HTWLocation(Building.Z, "410")));
            dummyDrops.Add(new Drop(5, "Feierliche Immatrikulation", Category.EVENT, new DateTime(2017, 4, 12), new HTWLocation(Building.S, "331")));
            dummyDrops.Add(new Drop(6, "Ausstellung Architektur", Category.EVENT, new DateTime(2017, 5, 2), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(new Drop(7, "Party Semesterstart", Category.EVENT, new DateTime(2017, 6, 7), new HTWLocation(Building.Z, "136b")));
            dummyDrops.Add(new Drop(8, "Grillen Fak. Informatik", Category.EVENT, new DateTime(2017, 7, 19), new HTWLocation(Building.S, "325")));
            dummyDrops.Add(new Drop(9, "Kommission Hochschulmarketing", Category.EVENT, new DateTime(2017, 8, 12), new HTWLocation(Building.Z, "136c")));
            dummyDrops.Add(new Drop(10, "Kommission Lehre und Studium", Category.EVENT, new DateTime(2017, 9, 1), new HTWLocation(Building.Z, "327")));
            dummyDrops.Add(new Drop(11, "Bewerbungsfotoshooting", Category.EVENT, new DateTime(2017, 10, 29), new HTWLocation(Building.S, "131")));

            return dummyDrops;
        }

        // Connector-part

        public bool connect()
        {
            return true;
        }

        public void close()
        {
            return;
        }

        public List<Drop> getNewDrops(DateTime lastUpdate)
        {
            return dummyDrops.Where(drop => drop.lastChange >= lastUpdate).ToList();
        }

        public bool saveNewDrop(Drop newDrop)
        {
            dummyDrops.Add(newDrop);
            return true;
        }
    }
}