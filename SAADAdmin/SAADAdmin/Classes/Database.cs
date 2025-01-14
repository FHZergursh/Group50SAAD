using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAADAdmin.Classes
{
    internal class Database
    {
        static string server;
        static string username;
        static string password;
        static string databaseName;
        public static string connString = "server=localhost;uid=root;pwd=root123;database=saad"; //replace with variables  above when you get time
        public MySqlConnection mysqlconn = new MySqlConnection(connString);

        public bool connect_db()
        {
            try
            {
                mysqlconn.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool closeDB()
        {
            try
            {
                mysqlconn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
