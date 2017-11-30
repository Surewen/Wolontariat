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

        /// <summary>
        /// inicjalizacja połączzenia
        /// </summary>
        public SQLDatabase()
        {
            Init();
        }

        private void Init()
        {
            connection = new SqlConnection("Data Source=pww-server.database.windows.net;Initial Catalog=pww-database;User ID=wolontariusz;Password=Admini1.");
        }

        /// <summary>
        /// otwarcie połączenia z bazą danych
        /// </summary>
        public void Connect()
        {
            connection.Open();
        }
        /// <summary>
        /// zakończenie połączenia z bazą danych
        /// </summary>
        public void Disconnect()
        {
            connection.Close();
        }
        /// <summary>
        /// procedura polegająca na dodawniu wydarzeń do bazy danych
        /// </summary>
        /// <param name="autor"> kto założył wydarzenie</param>
        /// <param name="add_data"> data dodania</param>
        /// <param name="due_data"> data wydarzenia</param>
        /// <param name="title">nazwa wydarzenia</param>
        /// <param name="content">tresc wydarzenia</param>
        public void InstertEvents(String autor, String add_data, String due_data, String title, String content)
        {
            string query =
                "INSERT INTO events VALUES " +
                "(\'"
                + autor + "\',  CONVERT(DATETIME,'"
                + add_data + "', 102), CONVERT(DATETIME,'"
                + due_data + "', 102), \'"
                + title + "\', \'"
                + content + "\');";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// procedura dodawająca użytkowników do bazy danych
        /// </summary>
        /// <param name="nickname"> nazwa użytkonika</param>
        /// <param name="password">hasło</param>
        /// <param name="pesel">pesel</param>
        /// <param name="email">adres email</param>
        /// <param name="telephone">telefon kontaktowy</param>
        /// <param name="name">Imię</param>
        /// <param name="surname">Nazwisko</param>
        /// <param name="birthdate">Data urodzenia</param>
        /// <param name="sex">Płeć</param>
        /// <param name="type">typ użytkownika(potrzebujący wolontariusz)</param>
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
        /// <summary>
        /// listowanie tabli użytkowników
        /// </summary>
        /// <returns>zwraca litę użytkowników</returns>
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

        /// <summary>
        /// zliczanie użytkowników
        /// </summary>
        /// <returns>zwraca ilość użytkowników</returns>
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