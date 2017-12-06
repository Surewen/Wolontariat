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
        private SqlConnection connection;
        private SqlCommand cmd;
        
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

        public List<Announcement> ListAnnouncements()
        {
            List<Announcement> list = new List<Announcement>();

            cmd = new SqlCommand("SELECT * FROM Announcements;", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list.Add(new Announcement(dataReader));
            }
            dataReader.Close();
            return list;
        }

        public List<Event> ListEvents()
        {
            List<Event> list = new List<Event>();

            cmd = new SqlCommand("SELECT * FROM events;", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list.Add(new Event(dataReader));
            }
            dataReader.Close();
            return list;
        }

        public void InstertEvents(int id_a, int id_user, String due_date, String title, String content)
        {
            string query = "";
            if (id_a == -1)
            {
                query =
                "INSERT INTO events (id_user, post_date, due_date, title, content) VALUES " +
                "("
                + id_user + ",  CONVERT(DATETIME,'"
                + DateTime.Today + "', 102), CONVERT(DATETIME,'"
                + due_date + "', 102), '"
                + title + "', '"
                + content + "');";
            }
            else
            {
                    query =
                "INSERT INTO events VALUES " +
                "("
                + id_a + ", "
                + id_user + ",  CONVERT(DATETIME,'"
                + DateTime.Today + "', 102), CONVERT(DATETIME,'"
                + due_date + "', 102), '"
                + title + "', '"
                + content + "');";
            }
            
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void EditAnnouncement(int id_a, String end_data, bool type_help, String title, String content)
        {
            String type = "";
            if (type_help) type = "Jednorazowa";
            else type = "Wielorazowa";
            string query =
                "UPDATE announcements SET "
                + "end_date=CONVERT(DATETIME,'"
                + end_data + "', 102), type_help='"
                + type + "', title='"
                + title + "', content='"
                + content + "' WHERE id="+id_a;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void EditEvent(int id_e, String due_date, String title, String content)
        {
            string query =
                "UPDATE events SET "
                + "due_date=CONVERT(DATETIME,'"
                + due_date + "', 102), title='"
                + title + "', content='"
                + content + "' WHERE id="+ id_e;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void InsertAnnouncement(int id_user, String end_data, bool type_help, String title, String content)
        {
            String type = "";
            if (type_help) type = "Jednorazowa";
            else type = "Wielorazowa";
            string query =
                "INSERT INTO announcements VALUES " +
                "("
                + id_user + ", CONVERT(DATETIME,'"
                + DateTime.Today + "', 102),  CONVERT(DATETIME,'"
                + end_data + "', 102), '"
                + type + "', 'trwa', '"
                + title + "', '"
                + content + "')";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }


        public void send_invitation(int id_event, int id_sender, int id_receiver, String title, String content)
        {

            string query =
                "INSERT INTO invitations VALUES (" +
                +id_event + ", "
                + id_sender + ", "
                + id_receiver + ", '"
                + title + "', '"
                + content + "', CONVERT(DATETIME, '"
                + DateTime.Today + "', 102))";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }


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
        
        public void AssigntoAnnouncement(int id_a, int id_u, String from, String to)
        {
            string query =
                "INSERT INTO users_assigned_announcement VALUES " +
                "("
                + id_a + ", "
                + id_u + ", '"
                + from + "', '"
                + to + "')";

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void JoinToEvent(int id_e, int id_u)
        {
            string query =
                "INSERT INTO users_joined_event VALUES " +
                "("
                + id_e + ", "
                + id_u+")";
                
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }


        public void DeclineFromAnnouncement(int id_a, int id_u)
        {
            string query =
                "DELETE FROM users_assigned_announcement WHERE id_announcement=" + id_a + " AND id_user=" + id_u;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void DeclineFromEvent(int id_e, int id_u)
        {
            string query =
                "DELETE FROM users_joined_event WHERE id_event=" + id_e + " AND id_user=" + id_u;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void DeleteAnnouncement(int id_a)
        {
            string query =
                "DELETE FROM announcements WHERE id=" + id_a;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void DeleteEvent(int id_e)
        {
            string query =
                "DELETE FROM events WHERE id=" + id_e;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void DeleteEvent_id_a(int id_a)
        {
            string query =
                "DELETE FROM events WHERE id_announcement=" + id_a;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void Delete_Users_Assigned_Announcement(int id_a)
        {
            string query =
                "DELETE FROM users_assigned_announcement WHERE id_announcement=" + id_a;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public void Delete_Users_Joined_Event(int id_e)
        {
            string query =
                "DELETE FROM users_joined_event WHERE id_event=" + id_e;

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

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

        public SqlDataReader getLogin(String email, String pass)
        { 
            cmd = new SqlCommand("SELECT email, password FROM users where email='" + email + "' and password='" + pass + "'", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

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
        public List<int?> getIdEvents(int id_a)
        {
            List<int?> list = new List<int?>();
            List<Event> lista_wydarzeń = this.ListEvents();
            for (int i = 0; i < lista_wydarzeń.Count; i++)
            {
                if (lista_wydarzeń.ElementAt(i).id_announcement.Equals(id_a) && lista_wydarzeń.ElementAt(i).id_announcement != null) list.Add(lista_wydarzeń.ElementAt(i).id_announcement);
            }
            
            return list;
        }

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