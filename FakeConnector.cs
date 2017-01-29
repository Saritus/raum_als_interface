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

            dummyDrops.Add(new Drop("Ausstellung Architektur", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));
            dummyDrops.Add(new Drop("Party Semesterstart", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("S131")));
            dummyDrops.Add(new Drop("Grillen Fak. Informatik", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z136b")));
            dummyDrops.Add(new Drop("Tag der offenen Tür", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));
            dummyDrops.Add(new Drop("Seminar EWZ", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));
            dummyDrops.Add(new Drop("Feierliche Immatrikulation", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));
            dummyDrops.Add(new Drop("Ausstellung Architektur", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));
            dummyDrops.Add(new Drop("Party Semesterstart", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));
            dummyDrops.Add(new Drop("Grillen Fak. Informatik", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));
            dummyDrops.Add(new Drop("Kommission Hochschulmarketing", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));
            dummyDrops.Add(new Drop("Kommission Lehre und Studium", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));
            dummyDrops.Add(new Drop("Bewerbungsfotoshooting", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z901")));

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