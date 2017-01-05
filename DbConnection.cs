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
            string connsqlstring = "Server=your.ip.address;Port=3306;database=YOUR_DATA_BASE;User Id=root;Password=password;charset=utf8"; // TODO: change values in string
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
        sqlconn.Close();
        return false;
    }

    public static List<Drop> getNewEvents(DateTime lastUpdate)
    {
        /*
        SELECT *
        FROM temp
        WHERE mydate > '2009-06-29 16:00:44';
        */

        // TODO: return fetched drops from database

        List<Drop> products = new List<Drop>();

        DataSet tickets = new DataSet();
        string queryString = "select item.NAME from ITEM as item where lastChange > lastUpdate";
        MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
        adapter.Fill(tickets, "Item");
        foreach (DataRow row in tickets.Tables["Item"].Rows)
        {
            products.Add(new Drop(row));
        }

        return products;
    }

    public static bool saveNewEvent(Drop newDrop)
    {
        // TODO: push new drop to database
        return false;
    }
}