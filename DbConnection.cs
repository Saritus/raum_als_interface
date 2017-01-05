using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TouchWalkthrough
{
    class DbConnection
    {
        public DbConnection()
        {
            try
            {
                new I18N.West.CP1250();
                MySqlConnection sqlconn;
                string connsqlstring = "Server=your.ip.address;Port=3306;database=YOUR_DATA_BASE;User Id=root;Password=password;charset=utf8";
                sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                string queryString = "select count(0) from ACCOUNT";
                MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
                string result = sqlcmd.ExecuteScalar().ToString();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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