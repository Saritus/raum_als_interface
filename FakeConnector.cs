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

            dummyDrops.Add(new Drop("Ausstellung Architektur", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z902")));
            dummyDrops.Add(new Drop("Party Semesterstart", Category.WARNING, new DateTime(2017, 1, 31), new HTWLocation("Z325")));
            dummyDrops.Add(new Drop("Grillen Fak. Informatik", Category.VOTE, new DateTime(2017, 1, 31), new HTWLocation("Parkplatz")));
            dummyDrops.Add(new Drop("Tag der offenen Tür", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("PAB")));
            dummyDrops.Add(new Drop("Seminar EWZ", Category.VOTE, new DateTime(2017, 1, 31), new HTWLocation("S410")));
            dummyDrops.Add(new Drop("Feierliche Immatrikulation", Category.WARNING, new DateTime(2017, 1, 31), new HTWLocation("TRE 204")));
            dummyDrops.Add(new Drop("Ausstellung Architektur", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z902")));
            dummyDrops.Add(new Drop("Party Semesterstart", Category.VOTE, new DateTime(2017, 1, 31), new HTWLocation("Z311")));
            dummyDrops.Add(new Drop("Grillen Fak. Informatik", Category.WARNING, new DateTime(2017, 1, 31), new HTWLocation("Parkplatz")));
            dummyDrops.Add(new Drop("Kommission Hochschulmarketing", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation("Z136b")));
            dummyDrops.Add(new Drop("Kommission Lehre und Studium", Category.VOTE, new DateTime(2017, 1, 31), new HTWLocation("Z136c")));
            dummyDrops.Add(new Drop("Bewerbungsfotoshooting", Category.WARNING, new DateTime(2017, 1, 31), new HTWLocation("PAB")));

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