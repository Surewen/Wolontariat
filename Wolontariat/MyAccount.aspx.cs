using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class MyAccount : System.Web.UI.Page
    {
        SQLDatabase db;
        StringBuilder html;
        List<Users> list_users;
        String email;
        String pass;
        int id, id_i;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            html = new StringBuilder();
            db.Connect();
            list_users = db.ListUsers();
            id = db.getId((string)Session["id"]);
            html.Append("<table border = '1' align='center'>");
            
            for (int i = 0; i < list_users.Count; i++)
            {
                if (list_users.ElementAt(i).id.Equals(id))
                {
                    html.Append("<tr><td>Id</td> <td>" + list_users.ElementAt(i).id + "</td></tr>");
                    html.Append("<tr><td>Imię</td> <td>" + list_users.ElementAt(i).name + "</td></tr>");
                    html.Append("<tr><td>Nazwisko</td> <td>" + list_users.ElementAt(i).surname + "</td></tr>");
                    html.Append("<tr><td>Nickname</td> <td>" + list_users.ElementAt(i).nickname + "</td></tr>");
                    html.Append("<tr><td>E-mail</td> <td>" + list_users.ElementAt(i).email + "</td></tr>");
                    html.Append("<tr><td>Płeć</td> <td>" + list_users.ElementAt(i).sex + "</td></tr>");
                    html.Append("<tr><td>Telefon</td> <td>" + list_users.ElementAt(i).telephone + "</td></tr>");
                    html.Append("<tr><td>Data urodzenia</td> <td>" + list_users.ElementAt(i).birth_date.ToString("yyyy-MM-dd") + "</td></tr>");
                    html.Append("<tr><td>Typ użytkownika</td> <td>" + list_users.ElementAt(i).type + "</td></tr>");
                    html.Append("<tr><td>Pesel</td> <td>" + list_users.ElementAt(i).pesel + "</td></tr>");
                    email = list_users.ElementAt(i).email;
                    pass = list_users.ElementAt(i).password;
                    id_i = i;
                }
            }

            html.Append("</table>");
            html.Append("<br/><br/>");
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            db.Disconnect();
        }
        protected void Form_Data(object sender, EventArgs e)
        {
            data_form.Visible = true;
            password_form.Visible = false;
            db = new SQLDatabase();
            db.Connect();
            list_users = db.ListUsers();
            nickname.Value = list_users.ElementAt(id_i).nickname;
            inputEmail.Value = list_users.ElementAt(id_i).email;
            name.Value= list_users.ElementAt(id_i).name;
            surname.Value= list_users.ElementAt(id_i).surname;
            telephone.Value= list_users.ElementAt(id_i).telephone;
            pesel.Value= list_users.ElementAt(id_i).pesel;
            db.Disconnect();
        }

        protected void Edit_Data(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            list_users = db.ListUsers();
            string sex = "";
            string type = "";
            if (!male.Checked && !female.Checked) sex = list_users.ElementAt(id_i).sex;
            else
            {
                if (male.Checked) sex = "male";
                else sex = "female";
            }
            if (!volounteer.Checked && !needy.Checked) type = list_users.ElementAt(id_i).type;
            else
            {
                if (volounteer.Checked) type = "volounteer";
                else type = "needy";
            }
            if (birthDate.Value=="") birthDate.Value = list_users.ElementAt(id_i).birth_date.ToString("yyyy-MM-dd");
           
            db.EditAccount(id, nickname.Value, pesel.Value, inputEmail.Value, telephone.Value, name.Value, surname.Value, birthDate.Value, sex, type);
            
            if (!inputEmail.Value.Equals(email))
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
            else Response.Redirect("MyAccount.aspx");
            db.Disconnect();
        }

        protected void Edit_Password(object sender, EventArgs e)
        {
            password_form.Visible = true;
            data_form.Visible = false;
            if (password != null && new_password != null)
            {
                db = new SQLDatabase();
                db.Connect();
                if (pass.Equals(password.Value))
                {
                    db.EditPassword(id, new_password.Value);
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");
                }
                db.Disconnect();
            }
        }

        protected void Delete_Account(object sender, EventArgs e)
        {
            List<int> list_announcement_id = ListAnnouncements_User();
            List<int> list_events_id = ListEventsFromAnnouncement_User();
            List<int> list_invitations_id = ListInvitations_User();
            db = new SQLDatabase();
            db.Connect();

            db.Delete_Users_Assigned_Announcement_id_user(id);
            for (int i = 0; i < list_announcement_id.Count; i++)
            { db.Delete_Users_Assigned_Announcement(list_announcement_id.ElementAt(i)); }

            for (int i = 0; i < list_events_id.Count; i++)
            { db.Delete_Users_Joined_Event(list_events_id.ElementAt(i)); }

            db.Delete_Users_Joined_Event_id_user(id);
            for (int i = 0; i < list_events_id.Count; i++)
            { db.Delete_Users_Joined_Event(list_events_id.ElementAt(i)); }

            for (int i = 0; i < list_invitations_id.Count; i++)
            { db.DeleteInvitation_id(list_invitations_id.ElementAt(i)); }
            
            for (int i = 0; i < list_events_id.Count; i++)
            { db.DeleteEvent(list_events_id.ElementAt(i)); }
            
            for (int i = 0; i < list_announcement_id.Count; i++)
            { db.DeleteAnnouncement(list_announcement_id.ElementAt(i)); }
            
            db.DeleteUser(id);
            Session.RemoveAll();
            Response.Redirect("Home.aspx");
            db.Disconnect();
        }


        /// <summary>
        /// lista identyfiakatorow ogloszen, ktore dodal uzytkownik
        /// </summary>
        /// <returns></returns>
        public List<int> ListAnnouncements_User()
        {
            db = new SQLDatabase();
            db.Connect();
            List<Announcement> list = db.ListAnnouncements();
            List<int> list_id = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (id == list.ElementAt(i).id_user) list_id.Add(list.ElementAt(i).id);
            }
            db.Disconnect();
            return list_id;
        }

        /// <summary>
        /// lista identyfikatorow wydarzen, które dodal uzytkownik
        /// </summary>
        /// <returns></returns>
        public List<int> ListEvents_User()
        {
            db = new SQLDatabase();
            db.Connect();
            List<Event> list = db.ListEvents();
            List<int> list_id = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (id == list.ElementAt(i).id_user) list_id.Add(list.ElementAt(i).id);
            }
            db.Disconnect();
            return list_id;
        }

        /// <summary>
        /// lista identyfikator wydarzen, ktore powstaly na podstawie ogloszen dodanych przez uzytkownika
        /// </summary>
        /// <returns></returns>
        public List<int> ListEventsFromAnnouncement_User()
        {
            List<int> list_announcements_id = ListAnnouncements_User();
            List<int> list_events_id2 = ListEvents_User(); //lista identyfikatorow wydarzen, ktore dodal uzytkownik plus list_events_id
            db = new SQLDatabase();
            db.Connect();
            List<Event> list_events = db.ListEvents();
            List<int> list_events_id = new List<int>(); //lista identyfikatorow wydarzen, ktore powstaly na podstawie ogloszen dodanych przez uzytkownika

            for (int j = 0; j < list_announcements_id.Count; j++)
            {
                for (int i = 0; i < list_events.Count; i++)
                {
                    if (list_announcements_id.ElementAt(j) == list_events.ElementAt(i).id_announcement) list_events_id.Add(list_events.ElementAt(i).id);
                }
            }

            for (int i = 0; i < list_events_id.Count; i++)
            {
                list_events_id2.Add(list_events_id.ElementAt(i));
            }
            db.Disconnect();
            return list_events_id2;
        }


        public List<int> ListInvitations_User()
        {
            List<int> list_events_id = ListEventsFromAnnouncement_User();
            db = new SQLDatabase();
            db.Connect();
            List<Invitation> list_invitations = db.ListInvitations();
          
            List<int> list_invitations_id = new List<int>();


            for (int i = 0; i < list_events_id.Count; i++)
            {
                for (int j = 0; j < list_invitations.Count; j++)
                {
                    if (list_events_id.ElementAt(i) == list_invitations.ElementAt(j).id_event) list_invitations_id.Add(list_invitations.ElementAt(j).id);
                }
            }

            for (int i = 0; i < list_invitations.Count; i++)
            {
                if (id==list_invitations.ElementAt(i).id_sender)
                {
                    list_invitations_id.Add(list_invitations.ElementAt(i).id);
                }
            }

            db.Disconnect();
            return list_invitations_id;
        }

    }
    
}