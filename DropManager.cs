using System;
using System.Collections.Generic;

namespace TouchWalkthrough
{
    class DropManager //: iUIHandler
    {
        private List<Drop> allDrops;
        private DateTime lastTimestamp;
        //server daten

        public DropManager()
        {
            this.allDrops = createDummyDrops(5);
            foreach (Drop d in getDrops())
            {
                showDrop(d);
            }
        }

        public List<Drop> getDrops()
        {
            return allDrops;
        }

        public List<Drop> getDrops(Category[] filters)
        {
            //if all filters are active
            if (filters.Length == Enum.GetNames(typeof(Category)).Length)
            {
                return getDrops();
            }
            else
            {
                List<Drop> tempList = new List<Drop>();
                foreach (Drop drop in allDrops)
                {
                    foreach (Category filter in filters)
                    {
                        if (drop.category == filter)
                            tempList.Add(drop);
                        break;
                    }
                }
                return tempList;
            }
        }

        public List<Drop> getFollowedDrops()
        {
            List<Drop> tempList = new List<Drop>();
            foreach (Drop drop in allDrops)
            {
                if (drop.followed)
                    tempList.Add(drop);
            }
            return tempList;
        }

        public void ignoreDrop(Drop ev)
        {
            ev.ignored = true;
        }

        public void followDrop(Drop ev)
        {
            ev.followed = true;
        }

        public List<Drop> createDummyDrops(int i)
        {
            List<Drop> tempList = new List<Drop>();
            foreach (Category filter in Enum.GetValues(typeof(Category)))
            {
                for (int j = 0; j < i; j++)
                {
                    string f = Enum.GetName(typeof(Category), filter);
                    tempList.Add(new Drop(i, "Test" + f + i, filter, "Test" + f + i + "Description, ", DateTime.Today, DateTime.Now, new ExtendedLocation()));
                }
            }
            return tempList;
        }


        //server related
        public void updateDropList()
        {
            List<Drop> receivedDrops = new List<Drop>();
            receivedDrops = updateDropsSince(lastTimestamp);
            if (receivedDrops.Count > 0)
                allDrops.AddRange(receivedDrops);
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

        public void setLastTimestamp(DateTime t)
        {
            this.lastTimestamp = t;
        }
    }
}