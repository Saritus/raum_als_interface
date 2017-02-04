using System;
using System.Collections.Generic;
using System.Linq;

namespace TouchWalkthrough
{
    public class DropManager
    {
        // Singelton-part

        private static DropManager instance;

        private DropManager()
        {
            drops = new List<Drop>();
        }

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
        public DateTime lastUpdate { get; private set; } = DateTime.MinValue;

        public int getDropNumber(Guid id)
        {
            for (int i = 0; i < drops.Count; i++)
            {
                if (drops[i].id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void sortDrops()
        {
            drops.Sort((x, y) => DateTime.Compare(x.startTime, y.startTime));
        }

        public void addDrop(Drop drop)
        {
            drops.Add(drop);
        }

        public List<Drop> getDrops()
        {
            return drops;
        }

        public List<Drop> getFilteredDrops(Category[] filters)
        {
            return drops.Where(drop => filters.Contains(drop.category)).ToList();
        }

        public List<Drop> getBuildingDrops(Building building)
        {
            return drops.Where(drop => drop.location.building == building).ToList();
        }

        public List<Drop> getDropAfterDate(DateTime datetime)
        {
            return drops.Where(drop => drop.startTime >= datetime).ToList();
        }

        public List<Drop> getFollowedDrops()
        {
            return drops.Where(drop => drop.followed).ToList();
        }

        public List<Drop> getNotIgnoredDrops()
        {
            return (from drop in drops where !drop.ignored select drop).ToList();
        }

        public void saveDrops(string filename)
        {
            XML.Save(drops, filename);
        }

        public void loadDrops(string filename)
        {
            drops = XML.Load<List<Drop>>(filename);
        }

        // server-part

        public FakeConnector connector = FakeConnector.Instance;

        public void updateDrops()
        {
            List<Drop> newDrops = connector.getNewDrops(lastUpdate);
            foreach (Drop newDrop in newDrops)
            {
                if (drops.Select(drop => drop.id).Contains(newDrop.id))
                {
                    drops.Where(drop => drop.id == newDrop.id).ToList().ForEach(drop => drop.update(newDrop));
                }
                else
                {
                    drops.Add(newDrop);
                }
            }
            lastUpdate = DateTime.Now;
        }
    }
}