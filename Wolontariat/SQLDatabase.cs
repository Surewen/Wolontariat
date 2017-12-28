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
        /// The class responsible for handling the connection to the database. 
        /// It contains methods for adding, editing and deleting data from the database. 
        /// It also includes methods for creating lists of objects on which it is easier to work.
        /// </summary>
        private SqlConnection connection;
        private SqlCommand cmd;
        /// <summary>
        /// The method calls the Init method.
        /// </summary>
        public SQLDatabase()
        {
            Init();
        }
        /// <summary>
        /// The method includes a connection to the database.
        /// </summary>
        private void Init()
        {
            connection = new SqlConnection("Data Source=pww-server.database.windows.net;Initial Catalog=pww-database;User ID=wolontariusz;Password=Admini1.");
        }
        /// <summary>
        /// The method that initiates the connection to the database.
        /// </summary>
        public void Connect()
        {
            connection.Open();
        }
        /// <summary>
        /// The method terminating the connection to the database.
        /// </summary>
        public void Disconnect()
        {
            connection.Close();
        }
        /// <summary>
        /// The method that creates a list of User type objects.
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
        /// The method that creates a list of objects like Invitation.
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
        /// The method that creates a list of objects like Advert.
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
        /// The method that creates the list of objects types Event.
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
        /// The method adds a new record to the database in the Events table.
        /// </summary>
        /// <param name="id_a"></param>
        /// <param name="id_u"></param>
        /// <param name="due_date"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void InstertEvents(int id_a, int id_u, String due_date, String title, String content)
        {
            String query = "";
            if (id_a == -1)
            {
                query = prepareSql("null", id_u, due_date, title, content);
            }
            else
            {
                query = prepareSql(id_a.ToString(), id_u, due_date, title, content);
            }
            
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }


        public String prepareSql(String id_a, int id_u, String due_date, String title, String content)
        {
            string query = "";
            query =
              "INSERT INTO EVENTS VALUES " +
              "("
              + id_a + ", "
              + id_u + ",  CONVERT(DATETIME,'"
              + DateTime.Today.ToString("yyyy-MM-dd") + "', 102), CONVERT(DATETIME,'"
              + due_date + "', 102), '"
              + title + "', '"
              + content + "');";
            return query;
        }
        /// <summary>
        /// The method edits the selected record in the Notification database in the Announcements table.
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
        /// The method edits the selected record in the Events table in the database.
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
        /// A method that adds a new record in the database in the Announcement table.
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
                + DateTime.Today.ToString("yyyy-MM-dd") + "', 102),  CONVERT(DATETIME,'"
                + end_data + "', 102), '"
                + type + "', 'trwa', '"
                + title + "', '"
                + content + "')";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// A method whose task is to add further invitations to the Invitations table.
        /// Parameters that are downloaded from the user are the title and content.
        /// The parameters downloaded from the application are the user's id that sends the invitation, the id of the event that the user chooses, 
        /// the id of the user to whom the invitation is to be sent, the logged-in user selects it. 
        /// The last parameter is the date, the application itself downloads and transmits.
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
                + DateTime.Today.ToString("yyyy-MM-dd") + "', 102))";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// A method that adds new users to the Users table. The data entered is downloaded from the completed form by the user.
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

        public void EditAccount(int id, String nickname, String pesel, String email, String telephone, String name, String surname, String birthdate, String sex, String type)
        {
            string query =
                "UPDATE USERS SET "
                + "nickname='" + nickname + "', pesel='"
                + pesel + "', email='"
                + email + "', telephone='"
                + telephone + "', name='"
                + name + "', surname='"
                + surname + "', birth_date=CONVERT(DATETIME,'"
                + birthdate + "', 102), sex='"
                + sex + "', type='"
                + type + "' WHERE id="+id+";";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }


        public void EditPassword(int id, String new_password)
        {
            string query =
                "UPDATE USERS SET "
                + "password='" + new_password + "' WHERE id=" + id + ";";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// A method that adds a new record to the Users Assigned Announcement table. 
        /// The given table stores information about users and their applications to perform selected announcement.
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
        /// The method adds a new record to the Joined_Event table. 
        /// The given table stores information about users and events in which they participate.
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
        /// The method that deletes the selected record from the Users_Assigned_Announcemet table. 
        /// This means giving up the selected advertisement.
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
        /// The method deletes the selected record from the Joined_Event table. It means abandoned events by a volunteer.
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
        /// The method that deletes the selected record from the Announcements table. It means removing the advertisement.
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
        /// The method that deletes the record from the Events table. This means deleting the event.
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
        /// The method that deletes records from the Events table. This means deleting the event created on the basis of the announcement. 
        /// The method removes all events that were based on the indicated advertisement.
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
        /// The method that removes invitations to the selected event.
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
        /// A method that deletes records that store information about users who have applied to perform the announcement. 
        /// Removes all records with the selected number of the announcement.
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
        /// A method that deletes all records that store information about users who are participating in the event. 
        /// Removes all records from the selected event number.
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
        /// The method that returns ads to which the logged-in user has applied.
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
        /// The method returns events in which the logged-in user declared his presence.
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
        /// A method that returns a record from the Users table based on email and password. Used to support logging.
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
        /// The method returns nickname based on an email from the Users table.
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
        /// The method returns nickname based on the user's id from the Users table.
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
        /// A method that returns a list of events that have been created based on the selected advertisement.
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
        /// The method that returns id of the announcement from the database based on the number of the advertisement from the list of objects.
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
        /// The method that returns the id of the logged in user based on his email.
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
        /// A method that returns a user type based on a user's id.
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