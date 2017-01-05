using System;
using System.Data;
using System.Collections.Generic;

using MySql.Data;
using MySql.Data.MySqlClient;

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

    public List<String> LoadAllItemFromMySQL()
    {
        List<String> products = new List<String>();
        try
        {
            string connsqlstring = "Server=your.ip.address;Port=3306;database=YOUR_DATA_BASE;User Id=root;Password=password;charset=utf8";
            MySqlConnection sqlconn = new MySqlConnection(connsqlstring);
            sqlconn.Open();

            DataSet tickets = new DataSet();
            string queryString = "select item.NAME from ITEM as item";
            MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
            adapter.Fill(tickets, "Item");
            foreach (DataRow row in tickets.Tables["Item"].Rows)
            {
                products.Add(row[0].ToString());
            }

            sqlconn.Close();
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
        return products;
    }

    public bool connect()
    {
        // TODO: connect to mariaDB / MySQL database
        return false;
    }

    Drop[] getNewEvents(DateTime lastTime)
    {
        // TODO: return fetched drops from database
        return null;
    }

    bool saveNewEvent(Drop newDrop)
    {
        // TODO: push new drop to database
        return false;
    }
}