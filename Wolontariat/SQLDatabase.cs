using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wolontariat
{
    public class SQLDatabase
    {
        /// <summary>
        /// Klasa odpowiadająca za obsługę połączenia z bazą danych. Zawiera metody 
        /// obsługujące dodawanie, edycję i usuwanie danych z bazy danych. 
        /// Zawiera również metody służące do tworzenia list obiektów, na których 
        /// łatwiej się pracuje.
        /// </summary>
        private SqlConnection connection;
        private SqlCommand cmd;
        /// <summary>
        /// Metoda wywołuje metodę Init.
        /// </summary>
        public SQLDatabase()
        {
            Init();
        }
        /// <summary>
        /// Metoda zawiera połączenie z bazą danych.
        /// </summary>
        private void Init()
        {
            connection = new SqlConnection("Data Source=pww-server.database.windows.net;Initial Catalog=pww-database;User ID=wolontariusz;Password=Admini1.");
        }
        /// <summary>
        /// Metoda inicjująca połączenie z bazą danych.
        /// </summary>
        public void Connect()
        {
            connection.Open();
        }
       /// <summary>
       /// Metoda kończąca połączenie z bazą danych.
       /// </summary>
        public void Disconnect()
        {
            connection.Close();
        }
    /// <summary>
    /// Metoda tworząca listę obiektów typu Użytkownik.
    /// </summary>
    /// <returns></returns>
        public List<Users> ListUsers()
        {
            List<Users> list = new List<Users>();

            cmd = new SqlCommand("SELECT * FROM USERS;", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list.Add(new Users(dataReader));
            }
            dataReader.Close();
            return list;
        }

        /// <summary>
        /// Metoda tworząca listę obiektów typu Zaproszenie.
        /// </summary>
        /// <returns></returns>
        public List<Invitation> ListInvitations()
        {
            List<Invitation> list = new List<Invitation>();

            cmd = new SqlCommand("SELECT * FROM INVITATIONS;", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list.Add(new Invitation(dataReader));
            }
            dataReader.Close();
            return list;
        }
        /// <summary>
        /// Metoda tworząca listę obiektów typu Ogłoszenie.
        /// </summary>
        /// <returns></returns>
        public List<Announcement> ListAnnouncements()
        {
            List<Announcement> list = new List<Announcement>();

            cmd = new SqlCommand("SELECT * FROM ANNOUNCEMENTS;", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list.Add(new Announcement(dataReader));
            }
            dataReader.Close();
            return list;
        }
        /// <summary>
        /// Metoda tworząca listę obiektów typy Wydarzenie.
        /// </summary>
        /// <returns></returns>
        public List<Event> ListEvents()
        {
            List<Event> list = new List<Event>();

            cmd = new SqlCommand("SELECT * FROM EVENTS;", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list.Add(new Event(dataReader));
            }
            dataReader.Close();
            return list;
        }
        /// <summary>
        /// Metoda dodaje do bazy danych nowy rekord w tabeli Events.
        /// </summary>
        /// <param name="id_a"></param>
        /// <param name="id_u"></param>
        /// <param name="due_date"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void InstertEvents(int id_a, int id_u, String due_date, String title, String content)
        {
            string query = "";
            if (id_a == -1)
            {
                query =
                "INSERT INTO EVENTS (id_user, post_date, due_date, title, content) VALUES " +
                "("
                + id_u + ",  CONVERT(DATETIME,'"
                + DateTime.Today + "', 102), CONVERT(DATETIME,'"
                + due_date + "', 102), '"
                + title + "', '"
                + content + "');";
            }
            else
            {
                 query =
                "INSERT INTO EVENTS VALUES " +
                "("
                + id_a + ", "
                + id_u + ",  CONVERT(DATETIME,'"
                + DateTime.Today + "', 102), CONVERT(DATETIME,'"
                + due_date + "', 102), '"
                + title + "', '"
                + content + "');";
            }
            
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda edytuje w bazie danynch wybrany rekord w tabeli Announcements.
        /// </summary>
        /// <param name="id_a"></param>
        /// <param name="end_data"></param>
        /// <param name="type_help"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void EditAnnouncement(int id_a, String end_data, bool type_help, String title, String content)
        {
            String type = "";
            if (type_help) type = "Jednorazowa";
            else type = "Wielorazowa";
            string query =
                "UPDATE ANNOUNCEMENTS SET "
                + "end_date=CONVERT(DATETIME,'"
                + end_data + "', 102), type_help='"
                + type + "', title='"
                + title + "', content='"
                + content + "' WHERE id="+id_a;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda edytuje w bazie danych wybrany rekord w tabeli Events.
        /// </summary>
        /// <param name="id_e"></param>
        /// <param name="due_date"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void EditEvent(int id_e, String due_date, String title, String content)
        {
            string query =
                "UPDATE EVENTS SET "
                + "due_date=CONVERT(DATETIME,'"
                + due_date + "', 102), title='"
                + title + "', content='"
                + content + "' WHERE id="+ id_e;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda dodająca nowy rekord w bazie danych w tabeli Announcement.
        /// </summary>
        /// <param name="id_u"></param>
        /// <param name="end_data"></param>
        /// <param name="type_help"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void InsertAnnouncement(int id_u, String end_data, bool type_help, String title, String content)
        {
            String type = "";
            if (type_help) type = "Jednorazowa";
            else type = "Wielorazowa";
            string query =
                "INSERT INTO ANNOUNCEMENTS VALUES " +
                "("
                + id_u + ", CONVERT(DATETIME,'"
                + DateTime.Today + "', 102),  CONVERT(DATETIME,'"
                + end_data + "', 102), '"
                + type + "', 'trwa', '"
                + title + "', '"
                + content + "')";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Metoda, której zadaniem jest dodawanie do tabeli Invitations kolejnych zaproszeń. 
        /// Parametry, które są pobierane od użytkownika to tytul i zawartosc. Parametry pobierane z aplikacji to id użytkownika, który wysyła zaproszenie,
        /// id wydarzenia, które użytkownik wybierze, id użytkownika, do którego ma być wysłane zaproszenie, użytkownik zalogowany go wybiera. Ostatnim
        /// parametrem jest data, aplikacja sama go pobiera i przesyła.
        /// </summary>
        /// <param name="id_event"></param>
        /// <param name="id_sender"></param>
        /// <param name="id_receiver"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void SendInvitation(int id_event, int id_sender, int id_receiver, String title, String content)
        {

            string query =
                "INSERT INTO INVITATIONS VALUES (" +
                +id_event + ", "
                + id_sender + ", "
                + id_receiver + ", '"
                + title + "', '"
                + content + "', CONVERT(DATETIME, '"
                + DateTime.Today + "', 102))";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda dodająca nowych użytkowników do tabeli Users. Wprowadzane dane są pobierane z wypełnionego formularza przez użytkownika.
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <param name="pesel"></param>
        /// <param name="email"></param>
        /// <param name="telephone"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="birthdate"></param>
        /// <param name="sex"></param>
        /// <param name="type"></param>
        public void InsertUser(String nickname, String password, String pesel, String email, String telephone, String name, String surname, String birthdate, String sex, String type)
        {
            string query =
                "INSERT INTO USERS VALUES " +
                "('"
                + nickname + "', '"
                + password + "', '"
                + pesel + "', '"
                + email + "', '"
                + telephone + "', '"
                + name + "', '"
                + surname + "', CONVERT(DATETIME,'"
                + birthdate + "', 102), '"
                + sex + "', '"
                + type + "');";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda dodająca nowy rekord do tabeli Users_Assigned_Announcement. Podana tabela
        /// przechowuje informacje na temat użytkowników i ich zgłoszeń do wykonania wybranych ogłoszeń.
        /// </summary>
        /// <param name="id_a"></param>
        /// <param name="id_u"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void AssignToAnnouncement(int id_a, int id_u, String from, String to)
        {
            string query =
                "INSERT INTO USERS_ASSIGNED_ANNOUNCEMENT VALUES " +
                "("
                + id_a + ", "
                + id_u + ", '"
                + from + "', '"
                + to + "')";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda dodaje nowy rekord do tabeli Joined_Event. Podana tabela przechowuje
        /// informacje o użytkownikach i wydarzeniach, w których biorą udział.
        /// </summary>
        /// <param name="id_e"></param>
        /// <param name="id_u"></param>
        public void JoinToEvent(int id_e, int id_u)
        {
            string query =
                "INSERT INTO USERS_JOINED_EVENT VALUES " +
                "("
                + id_e + ", "
                + id_u + ")";
                
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Metoda usuwająca wybrany rekord z tabeli Users_Assigned_Announcemet. Oznacza to rezygnację z 
        /// wykonania wybranego ogłoszenia.
        /// </summary>
        /// <param name="id_a"></param>
        /// <param name="id_u"></param>
        public void DeclineFromAnnouncement(int id_a, int id_u)
        {
            string query =
                "DELETE FROM USERS_ASSIGNED_ANNOUNCEMENT WHERE id_announcement=" + id_a + " AND id_user=" + id_u;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda usuwa wybrany rekord z tabeli Joined_Event. Oznacza to opuszczeni wydarzenia przez
        /// wolontariusza.
        /// </summary>
        /// <param name="id_e"></param>
        /// <param name="id_u"></param>
        public void DeclineFromEvent(int id_e, int id_u)
        {
            string query =
                "DELETE FROM USERS_JOINED_EVENT WHERE id_event=" + id_e + " AND id_user=" + id_u;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda usuwająca wybrany rekord z tabeli Announcements. Oznacza to 
        /// usunięcie ogłoszenia.
        /// </summary>
        /// <param name="id_a"></param>
        public void DeleteAnnouncement(int id_a)
        {
            string query =
                "DELETE FROM ANNOUNCEMENTS WHERE id=" + id_a;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda usuwająca rekord z tabeli Events. Oznacza to usunięcie wydarzenia.
        /// </summary>
        /// <param name="id_e"></param>
        public void DeleteEvent(int id_e)
        {
            string query =
                "DELETE FROM events WHERE id=" + id_e;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda usuwająca rekordy z tabeli Events. Oznacza to usunięcie wydarzenia utworzonego 
        /// na podstawie ogłoszenia. Metoda usuwa wszystkie wydarzenia, które opierały się 
        /// na wskazanym ogłoszeniu.
        /// </summary>
        /// <param name="id_a"></param>
        public void DeleteEvent_id_a(int id_a)
        {
            string query =
                "DELETE FROM EVENTS WHERE id_announcement=" + id_a;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda usuwająca zaproszenia na wybrane wydarzenie.
        /// </summary>
        /// <param name="id_e"></param>
        public void DeleteInvitation(int id_e)
        {
            string query =
                "DELETE FROM INVITATIONS WHERE id_event=" + id_e;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda usuwająca rekordy przechowująca informacje o użytkownikach, którzy zgłosili
        /// się do wykonania ogłoszenia. Usuwa wszystkie rekordy z wybranym numerem ogłoszenia.
        /// </summary>
        /// <param name="id_a"></param>
        public void Delete_Users_Assigned_Announcement(int id_a)
        {
            string query =
                "DELETE FROM USERS_ASSIGNED_ANNOUNCEMENT WHERE id_announcement=" + id_a;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda usuwająca wszystkie rekordy przechowujące informacje o użytkownikach biorących udział w wydarzeniu.
        /// Usuwa wszystkie rekordy z wybranym numere wydarzenia.
        /// </summary>
        /// <param name="id_e"></param>
        public void Delete_Users_Joined_Event(int id_e)
        {
            string query =
                "DELETE FROM users_joined_event WHERE id_event=" + id_e;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Metoda zwracająca ogłoszenia, do których zalogowany użytkownik się zgłosił.
        /// </summary>
        /// <param name="id_u"></param>
        /// <returns></returns>
        public DataTable getMyActivities(int id_u)
        {
            cmd = new SqlCommand("SELECT * FROM users_assigned_announcement where id_user="+id_u, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = connection;
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Metoda zwraca wydarzenia, w których zalogowany użytkownik
        /// zadeklarował swoją obecność.
        /// </summary>
        /// <param name="id_u"></param>
        /// <returns></returns>
        public DataTable getMyActivitiesEvents(int id_u)
        {
            cmd = new SqlCommand("SELECT * FROM users_joined_event where id_user=" + id_u, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = connection;
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        /// <summary>
        /// Metoda zwracająca rekord z tabeli Users na podstawie email i password. Służy do obsługi logowania.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public SqlDataReader getLogin(String email, String pass)
        { 
            cmd = new SqlCommand("SELECT email, password FROM users where email='" + email + "' and password='" + pass + "'", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Metoda zwracająca nickname na podstawie email z tabeli Users.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public String getNickname_email(String email)
        {
            string nick = "";
            List<Users> lista = this.ListUsers();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista.ElementAt(i).email == email)
                { nick = lista.ElementAt(i).nickname; }
            }
                return nick;
        }
        /// <summary>
        /// Metoda zwracająca nickname na podstawie id użytkownika z tabeli Users.
        /// </summary>
        /// <param name="id_u"></param>
        /// <returns></returns>
        public String getNickname_id(int id_u)
        {
            string nick = "";
            List<Users> lista = this.ListUsers();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista.ElementAt(i).id==id_u)
                { nick = lista.ElementAt(i).nickname; }
            }
            return nick;
        }
        /// <summary>
        /// Metoda zwracająca listę wydarzeń, które zostały utworzone na podstawie wybranego ogłoszenia.
        /// </summary>
        /// <param name="id_a"></param>
        /// <returns></returns>
        public List<int?> getIdEvents(int id_a)
        {
            List<int?> list = new List<int?>();
            List<Event> lista_wydarzeń = this.ListEvents();
            for (int i = 0; i < lista_wydarzeń.Count; i++)
            {
                if (lista_wydarzeń.ElementAt(i).id_announcement.Equals(id_a) && lista_wydarzeń.ElementAt(i).id_announcement != null) list.Add(lista_wydarzeń.ElementAt(i).id);
            }
            
            return list;
        }
        
        /// <summary>
        /// Metoda zwracająca id ogłoszenia z bazy danych na podstawie numeru ogłoszenia z listy obiektów typu Ogłoszenie.
        /// </summary>
        /// <param name="id_a"></param>
        /// <returns></returns>
        public int getIdAnnouncement(int id_a)
        {
            List<Announcement> lista_ogłoszeń = this.ListAnnouncements();
            int id = 0;
            for (int i = 0; i < lista_ogłoszeń.Count; i++)
            {
                if (lista_ogłoszeń.ElementAt(i).id.Equals(id_a)) id = i;
            }
            return id;
        }
        /// <summary>
        /// Metoda zwracająca id zalogowanego użytkownika na podstawie jego email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int getId(String email)
        {
            int id=0;
            List<Users> lista = this.ListUsers();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista.ElementAt(i).email == email)
                { id = lista.ElementAt(i).id; }
            }
            return id;
        }
        /// <summary>
        /// Metoda zwracająca typ użytkownika na podstawie id użytkownika.
        /// </summary>
        /// <param name="id_user"></param>
        /// <returns></returns>
        public string getType_User(int id_user)
        {
            String type = "";
            List<Users> lista = this.ListUsers();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista.ElementAt(i).id == id_user)
                { type = lista.ElementAt(i).type; }
            }
            return type;
        }

    }
}