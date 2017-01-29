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

            dummyDrops.Add(DropManager.Instance.createDrop("Ausstellung Architektur", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Party Semesterstart", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Grillen Fak. Informatik", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Tag der offenen Tür", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Seminar EWZ", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Feierliche Immatrikulation", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Ausstellung Architektur", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Party Semesterstart", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Grillen Fak. Informatik", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Kommission Hochschulmarketing", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Kommission Lehre und Studium", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));
            dummyDrops.Add(DropManager.Instance.createDrop("Bewerbungsfotoshooting", Category.EVENT, new DateTime(2017, 1, 31), new HTWLocation(Building.Z, "902")));

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