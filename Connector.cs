using System;
using System.Collections.Generic;

namespace TouchWalkthrough
{
    public interface Connector
    {
        bool connect();

        void close();

        List<Drop> getNewDrops(DateTime lastUpdate);

        bool saveNewDrop(Drop newDrop);
    }
}
