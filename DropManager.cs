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

        public List<Drop> getBuildingDrops(Building building)
        {
            return drops.Where(drop => drop.location.building == building).ToList();
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

        public void updateDrops()
        {
            drops.AddRange(connector.getNewDrops(lastUpdate));
            lastUpdate = DateTime.Now;
        }
    }
}