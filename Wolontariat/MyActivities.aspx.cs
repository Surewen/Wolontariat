using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class MyActivities : System.Web.UI.Page
    {
        SQLDatabase db;
        int id_a;
        DataTable dt, dt_events;
        List<Announcement> list_announcements;
        List<Event> list_events;
        StringBuilder html;
        /// <summary>
        /// The method that supports the display of announcements and events that the logged-on user has added and 
        /// the declarations he has declared his help and events he takes part in. 
        /// The method also supports the option of resigning, editing and deleting announcements and events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            list_announcements = db.ListAnnouncements();
            list_events = db.ListEvents();
            dt = db.getMyActivities(db.getId((string)Session["id"]));
            dt_events = db.getMyActivitiesEvents(db.getId((string)Session["id"]));
            if (db.getType_User(db.getId((string)Session["id"])) == "volounteer")
            {
                display_assigned_announcements();
                display_created_events();
                display_joined_events();
            }
            display_created_announcements();
            db.Disconnect();
        }
        
        public void display_assigned_announcements()
        {
            html = new StringBuilder();
            html.Append("Ogłoszenia, do których się zgłosiłem: </br>");
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Id ogłoszenia</th><th>Dodane przez</th><th>Data dodania</th><th>Do kiedy</th><th>Typ pomocy</th><th>Status</th><th>Temat</th><th>Zawartość</th><th>od</th><th>do</th><th>Modyfikuj</th>");
            html.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < list_announcements.Count; i++)
                { if (list_announcements.ElementAt(i).id.Equals((int)row[1])) id_a = i; }
                    
                html.Append("<tr>");
                html.Append("<td>" + row[1] + "</td>");
                html.Append("<td>" + db.getNickname_id(list_announcements.ElementAt(id_a).id_user) + "</td>");
                html.Append("<td>" + list_announcements.ElementAt(id_a).post_date.ToString("yyyy-MM-dd") + "</td>");
                html.Append("<td>");
                if (list_announcements.ElementAt(id_a).type_help.Equals("Jednorazowa")) html.Append("---");
                else html.Append(list_announcements.ElementAt(id_a).end_date);
                html.Append("</td>");
                html.Append("<td>" + list_announcements.ElementAt(id_a).type_help + "</td>");
                html.Append("<td>" + list_announcements.ElementAt(id_a).current_status + "</td>");
                html.Append("<td>" + list_announcements.ElementAt(id_a).title + "</td>");
                html.Append("<td>" + list_announcements.ElementAt(id_a).content + "</td>");
                html.Append("<td>" + row[3] + "</td>");
                html.Append("<td>" + row[4] + "</td>");
                html.Append("<td>");
                html.Append("<a href=\"Modify.aspx?id_a=" + row[1] + "&r=z\">Zrezygnuj </a>");
                html.Append("</td>");
                html.Append("</tr>");
            }
            html.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
        
        public void display_joined_events()
        {
            html = new StringBuilder();
            html.Append("Wydarzenia, w których biorę udział: </br>");
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Id wydarzenia</th><th>Dodane przez</th><th>Data wydarzenia</th><th>Temat</th><th>Zawartość</th><th>Powiązane z ogłoszeniem</th><th>Modyfikuj</th><th>Szczegóły</th>");
            html.Append("</tr>");

            foreach (DataRow row in dt_events.Rows)
            {
                for (int i = 0; i < list_events.Count; i++)
                { if (list_events.ElementAt(i).id.Equals((int)row[1])) id_a = i; }
                html.Append("<tr>");
                html.Append("<td>" + row[1] + "</td>");
                html.Append("<td>" + db.getNickname_id(list_events.ElementAt(id_a).id_user) + "</td>");
                html.Append("<td>" + list_events.ElementAt(id_a).due_date.ToString("yyyy-MM-dd") + "</td>");
                html.Append("<td>" + list_events.ElementAt(id_a).title + "</td>");
                html.Append("<td>" + list_events.ElementAt(id_a).content + "</td>");
                if (list_events.ElementAt(id_a).id_announcement.Equals(null)) html.Append("<td>Nie</td>");
                else html.Append("<td>Tak</td>");
                html.Append("<td>");
                html.Append("<a href=\"Modify.aspx?id_e=" + row[1] + "&r=z\">Zrezygnuj </a>");
                html.Append("</td>");
                html.Append("<td>");
                html.Append("<a href=\"Details.aspx?id_e=" + list_events.ElementAt(id_a).id + "\">Szczegóły</a>");
                html.Append("</td>");
                html.Append("</tr>");
            }
            html.Append("</table>");
            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
        }
        
        public void display_created_events()
        {
            html = new StringBuilder();
            html.Append("Wydarzenia, które dodałem: </br>");
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Data dodania</th><th>Data wydarzenia</th><th>Powiązane z ogłoszeniem potrzebującego</th><th>Temat</th>");
            html.Append("</tr>");
            for (int i = 0; i < list_events.Count; i++)
            {
                if (list_events.ElementAt(i).id_user.Equals(db.getId((string)Session["id"])))
                {
                    html.Append("<tr>");
                    html.Append("<td>" + list_events.ElementAt(i).post_date.ToString("yyyy-MM-dd") + "</td>");
                    html.Append("<td>" + list_events.ElementAt(i).due_date.ToString("yyyy-MM-dd") + "</td>");
                    if (list_events.ElementAt(i).id_announcement.Equals(null)) html.Append("<td>Nie</td>");
                    else html.Append("<td>Tak</td>");
                    html.Append("<td>" + list_events.ElementAt(i).title + "</td>");
                    html.Append("<td>");
                    html.Append("<a href=\"Modify.aspx?id_e=" + list_events.ElementAt(i).id + "&r=u\">Usuń </a>");
                    html.Append("<a href=\"EditEvent.aspx?id_e=" + list_events.ElementAt(i).id + "\">Edytuj </a>");
                    html.Append("<td>");
                    html.Append("<a href=\"Details.aspx?id_e=" + list_events.ElementAt(i).id + "\">Szczegóły</a>");
                    html.Append("</td>");
                    html.Append("</td>");
                    html.Append("</tr>");
                }
            }
            html.Append("</table>");
            PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
        }

        public void display_created_announcements()
        {
            html = new StringBuilder();
            html.Append("Ogłoszenia, które dodałem: </br>");
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Id wydarzenia</th><th>Data dodania</th><th>Do kiedy</th><th>Status</th><th>Temat</th><th>Zawartość</th><th>Modyfikuj</th>");
            html.Append("</tr>");

            for (int i = 0; i < list_announcements.Count; i++)
            {
                if (list_announcements.ElementAt(i).id_user == db.getId((string)Session["id"]))
                {
                    html.Append("<tr>");
                    html.Append("<td>" + list_announcements.ElementAt(i).id + "</td>");
                    html.Append("<td>" + list_announcements.ElementAt(i).post_date.ToString("yyyy-MM-dd") + "</td>");
                    html.Append("<td>");
                    if (list_announcements.ElementAt(i).type_help.Equals("Jednorazowa")) html.Append("---");
                    else html.Append(list_announcements.ElementAt(i).end_date);
                    html.Append("</td>");
                    html.Append("<td>" + list_announcements.ElementAt(i).current_status + "</td>");
                    html.Append("<td>" + list_announcements.ElementAt(i).title + "</td>");
                    html.Append("<td>" + list_announcements.ElementAt(i).content + "</td>");
                    html.Append("<td>");
                    html.Append("<a href=\"Modify.aspx?id_a=" + list_announcements.ElementAt(i).id + "&r=u\">Usuń </a>");
                    html.Append("<a href=\"EditAnnouncement.aspx?id_a=" + list_announcements.ElementAt(i).id + "\">Edytuj </a>");
                    html.Append("</td>");
                    html.Append("</tr>");
                }
            }
            html.Append("</table>");
            PlaceHolder4.Controls.Add(new Literal { Text = html.ToString() });
        }
        
    }
}