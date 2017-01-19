using System;
using System.Collections.Generic;
using System.Linq;

namespace TouchWalkthrough
{
    class DropManager
    {
        public List<Drop> drops { get; set; }
        public DateTime lastTimestamp { get; private set; }

        //server daten

        public DropManager()
        {
            //this.drops;
            drops.ForEach(drop => showDrop(drop));
        }

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

        //server related
        public void updateDropList()
        {
            List<Drop> receivedDrops = new List<Drop>();
            receivedDrops = updateDropsSince(lastTimestamp);
            if (receivedDrops.Count > 0)
                drops.AddRange(receivedDrops);
            lastTimestamp = DateTime.Now;
        }

        public List<Drop> updateDropsSince(DateTime lastTimestamp)
        {
            List<Drop> receivedDrops = new List<Drop>();
            //TODO: frage bei server nach neuen events seit lastTimestamp
            return receivedDrops;
        }

        //Front end related
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