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

            dummyDrops.Add(new Drop(0, "HTW Dresden auf der KarriereStart Dresden", Category.Messen, "PLACEHOLDER", new DateTime(2017, 01, 21, 10, 00, 00)));
            dummyDrops.Add(new Drop(1, "HTW Dresden auf der KarriereStart Dresden", Category.Messen, "PLACEHOLDER", new DateTime(2017, 01, 22, 10, 00, 00)));
            dummyDrops.Add(new Drop(2, "Steuertipps für Studierende", Category.Workshop, "PLACEHOLDER", new DateTime(2017, 01, 24, 15, 00, 00)));
            dummyDrops.Add(new Drop(3, "Bewerbungsfotoshooting", Category.Veranstaltung, "PLACEHOLDER", new DateTime(2017, 01, 26, 14, 00, 00)));
            dummyDrops.Add(new Drop(4, "Kommission Lehre und Studium", Category.Kommission, "PLACEHOLDER", new DateTime(2017, 01, 31, 15, 30, 00)));
            dummyDrops.Add(new Drop(5, "Textile Filzpraxis in Tire, Türkei", Category.Ausstellung, "PLACEHOLDER", new DateTime(2017, 02, 01, 17, 00, 00)));
            dummyDrops.Add(new Drop(6, "Kommission Hochschulmarketing", Category.Kommission, "PLACEHOLDER", new DateTime(2017, 02, 13, 08, 00, 00)));
            dummyDrops.Add(new Drop(7, "Kommission Lehre und Studium", Category.Kommission, "PLACEHOLDER", new DateTime(2017, 02, 14, 15, 30, 00)));
            dummyDrops.Add(new Drop(8, "D.A.CH-Tagung Flüssigboden 2017", Category.Tagung, "PLACEHOLDER", new DateTime(2017, 03, 09, 09, 00, 00)));
            dummyDrops.Add(new Drop(9, "Nutzung des Bibliothekskataloges", Category.Seminar, "PLACEHOLDER", new DateTime(2017, 03, 14, 15, 00, 00)));

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