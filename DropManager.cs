using System;
using System.Collections.Generic;
using System.Linq;

namespace TouchWalkthrough
{
    public class DropManager
    {
        // Singelton-part

        private static DropManager instance;

        private DropManager() { }

        public static DropManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DropManager();
                }
                return instance;
            }
        }

        // local-part

        public List<Drop> drops { get; private set; }
        public DateTime lastUpdate { get; private set; }

        public List<Drop> getFilteredDrops(Category[] filters)
        {
            return drops.Where(drop => filters.Contains(drop.category)).ToList();
        }

        public List<Drop> getFollowedDrops()
        {
            return drops.Where(drop => drop.followed).ToList();
        }

        public List<Drop> getNotIgnoredDrops()
        {
            return (from drop in drops where !drop.ignored select drop).ToList();
        }

        // server-part

        public FakeConnector connector = FakeConnector.Instance;

        public void updateDropList()
        {
            List<Drop> receivedDrops = updateDropsSince(lastUpdate);
            if (receivedDrops.Count > 0)
                drops.AddRange(receivedDrops);
            lastUpdate = DateTime.Now;
        }

        public List<Drop> updateDropsSince(DateTime lastUpdate)
        {
            return connector.getNewDrops(lastUpdate);
        }

        // front-end-part

        public void showDrop(Drop ev)
        {
            Console.WriteLine(ev.id + ", " + ev.name);
        }

        public void showDropDetail(Drop ev)
        {
            Console.WriteLine("Details: " + ev.id + ", " + ev.name + ", " + ev.description);
        }
    }
}