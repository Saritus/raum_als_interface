using System;

namespace TouchWalkthrough
{
    class DbConnection
    {
        public DbConnection()
        {

        }

        public bool connect()
        {
            // TODO: connect to mariaDB / MySQL database
            return true;
        }

        Drop[] getNewEvents(DateTime lastTime)
        {
            // TODO: return fetched drops from database
            return null;
        }

        bool saveNewEvent(Drop newDrop)
        {
            // TODO: push new drop to database
            return true;
        }
    }
}