using System;
using System.Data;
using System.Collections.Generic;

using MySql.Data;
using MySql.Data.MySqlClient;

abstract class DbConnection
{
    private static MySqlConnection sqlconn;

    public static bool connect()
    {
        // TODO: connect to mariaDB / MySQL database
        try
        {
            string connsqlstring = "Server=your.ip.address;Port=3306;database=YOUR_DATA_BASE;User Id=root;Password=password;charset=utf8";
            sqlconn = new MySqlConnection(connsqlstring);
            sqlconn.Open();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public static bool close()
    {
        // TODO: close the sql connection
        return false;
    }

    public static Drop[] getNewEvents(DateTime lastTime)
    {
        // TODO: return fetched drops from database
        return null;
    }

    public static bool saveNewEvent(Drop newDrop)
    {
        // TODO: push new drop to database
        return false;
    }
}