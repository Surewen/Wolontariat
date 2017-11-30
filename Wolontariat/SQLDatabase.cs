using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wolontariat
{
    public class SQLDatabase
    {
        private SqlConnection connection;

        public SQLDatabase()
        {
            Init();
        }

        private void Init()
        {
            connection = new SqlConnection("Data Source=pww-server.database.windows.net;Initial Catalog=pww-database;User ID=wolontariusz;Password=Admini1.");
        }

        public void Connect()
        {
            connection.Open();
        }
        public void Disconnect()
        {
            connection.Close();
        }

        public void InstertEvents(String autor, String add_data, String due_data, String title, String content)
        {
            string query =
                "INSERT INTO events VALUES " +
                "(NULL, \""
                + autor + "\",  CONVERT(DATETIME,'"
                + add_data + "', 102), CONVERT(DATETIME,'"
                + due_data + "', 102), \""
                + title + "\", \""
                + content + "\");";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public void InsertUser(String nickname, String password, String pesel, String email, String telephone, String name, String surname, String birthdate, String sex, String type)
        {
            string query =
                "INSERT INTO users VALUES " +
                "(\'"
                + nickname + "\', \'"
                + password + "\', \'"
                + pesel + "\', \'"
                + email + "\', \'"
                + telephone + "\', \'"
                + name + "\', \'"
                + surname + "\', CONVERT(DATETIME,'"
                + birthdate + "', 102), \'"
                + sex + "\', \'"
                + type + "\');";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }
        public List<String>[] ListUsers()
        {
            string query = "SELECT * FROM users;";

            List<String>[] list = new List<String>[11];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new List<string>();
            }

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list[0].Add(dataReader["id"] + "");
                list[1].Add(dataReader["nickname"] + "");
                list[2].Add(dataReader["password"] + "");
                list[3].Add(dataReader["pesel"] + "");
                list[4].Add(dataReader["email"] + "");
                list[5].Add(dataReader["telephone"] + "");
                list[6].Add(dataReader["id"] + "");
                list[7].Add(dataReader["name"] + "");
                list[8].Add(dataReader["surname"] + "");
                list[9].Add(dataReader["birth_date"] + "");
                list[10].Add(dataReader["sex"] + "");
                list[11].Add(dataReader["type"] + "");
            }

            dataReader.Close();

            return list;
        }
        public int CountUsers()
        {
            string query = "SELECT Count(*) FROM users;";
            int count = -1;

            SqlCommand cmd = new SqlCommand(query, connection);

            count = int.Parse(cmd.ExecuteScalar() + "");

            return count;
        }




    }
}