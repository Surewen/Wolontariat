using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Wolontariat
{
    public class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;


        public Database()
        {
            Init();
            Connect();
            InsertUser("a", "a", "a", "a", "a", "a", "a", "01-02-1995", "a", "a");
            Disconnect();
        }




        private void Init()
        {
            server = "172.23.176.86";
            database = "wolontariat";
            username = "lukasz.maszkiewicz";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private void Connect()
        {
            connection.Open();
        }

        private void Disconnect()
        {
            connection.Close();
        }

        private void InsertUser(String nickname, String password, String pesel, String email, String telephone, String name, String surname, String birthdate, String sex, String type)
        {
            string query =
                "INSERT INTO users VALUES " + 
                "(NULL, \"" + nickname + "\", \"" + password + "\", \"" + pesel + "\", \"" + email + "\", \"" + telephone + "\", \"" + name + "\", \"" + surname + "\", STR_TO_DATE('" + birthdate + "', '%d-%m-%Y'), \"" + sex + "\", \"" + type + "\");";

            MySqlCommand cmd = new MySqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }



    }
}