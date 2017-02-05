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

            dummyDrops.Add(new Drop("Ausstellung Architektur", Category.EVENT, new DateTime(2017, 1, 13), new HTWLocation("Z150")));
            dummyDrops.Add(new Drop("Party Semesterstart", Category.WARNING, new DateTime(2017, 2, 20), new HTWLocation("Z154b")));
            dummyDrops.Add(new Drop("Grillen Fak. Informatik", Category.VOTE, new DateTime(2017, 3, 12), new HTWLocation("Z146b")));
            dummyDrops.Add(new Drop("Tag der offenen Tür", Category.EVENT, new DateTime(2017, 4, 21), new HTWLocation("Z136b")));
            dummyDrops.Add(new Drop("Seminar EWZ", Category.VOTE, new DateTime(2017, 5, 13), new HTWLocation("Z133")));
            dummyDrops.Add(new Drop("Feierliche Immatrikulation", Category.WARNING, new DateTime(2017, 6, 11), new HTWLocation("Z107")));
            dummyDrops.Add(new Drop("Party Semesterstart", Category.VOTE, new DateTime(2017, 8, 10), new HTWLocation("Z102")));
            dummyDrops.Add(new Drop("Grillen Fak. Informatik", Category.WARNING, new DateTime(2017, 9, 23), new HTWLocation("Z126")));
            dummyDrops.Add(new Drop("Kommission Hochschulmarketing", Category.EVENT, new DateTime(2017, 10, 9), new HTWLocation("Z123")));
            dummyDrops.Add(new Drop("Kommission Lehre und Studium", Category.VOTE, new DateTime(2017, 11, 24), new HTWLocation("Z141")));
            dummyDrops.Add(new Drop("Bewerbungsfotoshooting", Category.WARNING, new DateTime(2017, 12, 8), new HTWLocation("Z138")));
            dummyDrops.Add(new Drop("Weihnachtsfeier", Category.EVENT, new DateTime(2017, 12, 21), new HTWLocation("Z113a")));

            // Better examples
            dummyDrops.Add(new Drop("Kommission Hochschulmarketing", Category.EVENT, "Organisator: Prof. Dr. Ralph Sonntag", new DateTime(2017, 2, 13, 8, 0, 0), new DateTime(2017, 2, 13, 9, 30, 0), new HTWLocation("Z241")));
            dummyDrops.Add(new Drop("Kommission IT-Service", Category.EVENT, "Organisator: Prof. Dr. Dirk Reichelt", new DateTime(2017, 2, 28, 14, 0, 0), new DateTime(2017, 2, 28, 15, 30, 0), new HTWLocation("Z343")));

            ImageStorage.Instance.addURL("https://www.htw-dresden.de/uploads/tx_templavoila/16_Banner_Dies.png");
            dummyDrops.Add(new Drop("Dies Academicus", Category.EVENT, "", new DateTime(2017, 6, 1, 9, 0, 0), new DateTime(2017, 6, 1, 10, 30, 0), new HTWLocation("Z107"), "https://www.htw-dresden.de/uploads/tx_templavoila/16_Banner_Dies.png"));

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