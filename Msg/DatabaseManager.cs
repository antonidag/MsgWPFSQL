using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg
{
    class DatabaseManager
    {

        public DatabaseManager()
        {

        }

        public void Send(Message m)
        {
            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=pgserver.mah.se;User Id=ae4864;" + "Password=y8334zd4;Database=ae4864buss;");
            conn.Open();
            NpgsqlCommand cmd = null;
            // Define a query
            cmd = new NpgsqlCommand("insert bla bla bla ", conn);
            // Execute a query
            NpgsqlDataReader dr = cmd.ExecuteReader();
            // Close connection
            conn.Close();
        }
        public List<Message> GetMessages(int index)
        {
            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=pgserver.mah.se;User Id=ae4864;" + "Password=y8334zd4;Database=ae4864buss;");
            conn.Open();
            NpgsqlCommand cmd = null;
            // Define a query
            cmd = new NpgsqlCommand("select bla bla ", conn);

            // Execute a query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // Read all rows and output the first column in each row
            while (dr.Read())
            {
                //new Message(dr[0].ToString());
            }
            // Close connection
            conn.Close();
            return new List<Message>();
        }
    }
}
