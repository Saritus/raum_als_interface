using System;
using System.Data;
using System.Collections.Generic;

//using MySql.Data;
//using MySql.Data.MySqlClient;
namespace TouchWalkthrough
{
    public class MySqlConnector : Connector
    {

        //private static MySqlConnection sqlconn;

        public bool connect()
        {
            /*
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
            */
            return false;
        }

        public void close()
        {
            /*
            // TODO: close the sql connection
            if (sqlconn.State == ConnectionState.Open)
            {
                sqlconn.Close();
            }
            */
        }

        public List<Drop> getNewDrops(DateTime lastUpdate)
        {
            /*
            //SELECT *
            //FROM temp
            //WHERE mydate > '2009-06-29 16:00:44';


            // TODO: return fetched drops from database

            connect();

            MySqlCommand cmd = sqlconn.CreateCommand();
            cmd.CommandText = "select item.NAME from ITEM as item where lastChange > lastUpdate";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataSet tickets = new DataSet();
            adapter.Fill(tickets, "Drops");

            List<Drop> products = new List<Drop>();
            foreach (DataRow row in tickets.Tables["Drops"].Rows)
            {
                products.Add(new Drop(row));
            }

            close();

            return products;
            */
            return null;
        }

        public bool saveNewDrop(Drop newDrop)
        {
            /*
            // TODO: push new drop to database
            connect();

            MySqlCommand cmd = sqlconn.CreateCommand();
            cmd.CommandText = "INSERT INTO Drops(Name, Pos, Start) VALUES (@Name, @Pos, @Start)";
            cmd.Parameters.AddWithValue("@Name", newDrop.name);
            cmd.Parameters.AddWithValue("@Pos", newDrop.pos);
            cmd.Parameters.AddWithValue("@Start", newDrop.start);
            cmd.ExecuteNonQuery();

            close();

            return false;
        }
        */
            return false;
        }
    }
}