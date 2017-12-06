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
        List<Announcement> list;
        List<Event> lista_wydarzeń;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            list = db.ListAnnouncements();
            lista_wydarzeń = db.ListEvents();
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
            StringBuilder html = new StringBuilder();
            html.Append("Ogłoszenia, do których się zgłosiłem:");
            html.Append("</br>");
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Id ogłoszenia</th><th>Dodane przez</th><th>Data dodania</th><th>Do kiedy</th><th>Typ pomocy</th><th>Status</th><th>Temat</th><th>Zawartość</th><th>od</th><th>do</th><th>Modyfikuj</th>");
            html.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list.ElementAt(i).id.Equals((int)row[1])) id_a = i;
                }
                html.Append("<tr>");
                html.Append("<td>" + row[1] + "</td>");
                html.Append("<td>" + db.getNickname_id(list.ElementAt(id_a).id_user) + "</td>");
                html.Append("<td>" + list.ElementAt(id_a).post_date + "</td>");
                html.Append("<td>");
                if (list.ElementAt(id_a).type_help.Equals("Jednorazowa")) html.Append("---");
                else html.Append(list.ElementAt(id_a).end_date);
                html.Append("</td>");
                html.Append("<td>" + list.ElementAt(id_a).type_help + "</td>");
                html.Append("<td>" + list.ElementAt(id_a).current_status + "</td>");
                html.Append("<td>" + list.ElementAt(id_a).title + "</td>");
                html.Append("<td>" + list.ElementAt(id_a).content + "</td>");
                html.Append("<td>" + row[3] + "</td>");
                html.Append("<td>" + row[4] + "</td>");
                html.Append("<td>");
                html.Append("<a href=\"Modify.aspx?id_an=" + row[1] + "&r=z\">Zrezygnuj </a>");
                html.Append("</td>");
                html.Append("</tr>");
            }
            //Table end.
            html.Append("</table>");
            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            
        }





        public void display_joined_events()
        {
            StringBuilder html = new StringBuilder();
            html.Append("Wydarzenia, w których biorę udział:");
            html.Append("</br>");
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Id wydarzenia</th><th>Dodane przez</th><th>Data wydarzenia</th><th>Temat</th><th>Zawartość</th><th>Powiązane z ogłoszeniem</th><th>Modyfikuj</th><th>Szczegóły</th>");
            html.Append("</tr>");

            foreach (DataRow row in dt_events.Rows)
            {
                for (int i = 0; i < lista_wydarzeń.Count; i++)
                {
                    if (lista_wydarzeń.ElementAt(i).id.Equals((int)row[1])) id_a = i;
                }
                html.Append("<tr>");
                html.Append("<td>" + row[1] + "</td>");
                html.Append("<td>" + db.getNickname_id(lista_wydarzeń.ElementAt(id_a).id_user) + "</td>");
                html.Append("<td>" + lista_wydarzeń.ElementAt(id_a).due_date + "</td>");
                html.Append("<td>" + lista_wydarzeń.ElementAt(id_a).title + "</td>");
                html.Append("<td>" + lista_wydarzeń.ElementAt(id_a).content + "</td>");
                if (lista_wydarzeń.ElementAt(id_a).id_announcement.Equals(null)) html.Append("<td>Nie</td>");
                else html.Append("<td>Tak</td>");
                html.Append("<td>");
                html.Append("<a href=\"Modify.aspx?id_event=" + row[1] + "&r=z\">Zrezygnuj </a>");
                html.Append("</td>");
                html.Append("<td>");
                html.Append("<a href=\"Details.aspx?id_e=" + lista_wydarzeń.ElementAt(id_a).id + "\">Szczegóły</a>");
                html.Append("</td>");
                html.Append("</tr>");
            }
            //Table end.
            html.Append("</table>");
            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });


        }





        public void display_created_events()
        {
            StringBuilder html = new StringBuilder();
            html.Append("Wydarzenia, które dodałem:");
            html.Append("</br>");
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Data dodania</th><th>Data wydarzenia</th><th>Powiązane z ogłoszeniem potrzebującego</th><th>Temat</th>");
            html.Append("</tr>");
            for (int i = 0; i < lista_wydarzeń.Count; i++)
            {
                if (lista_wydarzeń.ElementAt(i).id_user.Equals(db.getId((string)Session["id"])))
                {
                    html.Append("<tr>");
                    html.Append("<td>" + lista_wydarzeń.ElementAt(i).post_date + "</td>");
                    html.Append("<td>" + lista_wydarzeń.ElementAt(i).due_date + "</td>");
                    if (lista_wydarzeń.ElementAt(i).id_announcement.Equals(null)) html.Append("<td>Nie</td>");
                    else html.Append("<td>Tak</td>");
                    html.Append("<td>" + lista_wydarzeń.ElementAt(i).title + "</td>");
                    html.Append("<td>");
                    html.Append("<a href=\"Modify.aspx?id_event=" + lista_wydarzeń.ElementAt(i).id + "&r=u\">Usuń </a>");
                    html.Append("<a href=\"EditEvent.aspx?id_ev=" + lista_wydarzeń.ElementAt(i).id + "\">Edytuj </a>");
                    html.Append("<td>");
                    html.Append("<a href=\"Details.aspx?id_e=" + lista_wydarzeń.ElementAt(i).id + "\">Szczegóły</a>");
                    html.Append("</td>");
                    html.Append("</td>");
                    html.Append("</tr>");
                }
            }
            //Table end.
            html.Append("</table>");
            //Append the HTML string to Placeholder.
            PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
            
        }

        public void display_created_announcements()
        {
            StringBuilder html = new StringBuilder();
            html.Append("Ogłoszenia, które dodałem:");
            html.Append("</br>");
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Id wydarzenia</th><th>Data dodania</th><th>Do kiedy</th><th>Status</th><th>Temat</th><th>Zawartość</th><th>Modyfikuj</th>");
            html.Append("</tr>");

            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i).id_user == db.getId((string)Session["id"]))
                {
                    html.Append("<tr>");
                    html.Append("<td>" + list.ElementAt(i).id + "</td>");
                    html.Append("<td>" + list.ElementAt(i).post_date + "</td>");
                    html.Append("<td>");
                    if (list.ElementAt(i).type_help.Equals("Jednorazowa")) html.Append("---");
                    else html.Append(list.ElementAt(i).end_date);
                    html.Append("</td>");
                    html.Append("<td>" + list.ElementAt(i).current_status + "</td>");
                    html.Append("<td>" + list.ElementAt(i).title + "</td>");
                    html.Append("<td>" + list.ElementAt(i).content + "</td>");
                    html.Append("<td>");
                    html.Append("<a href=\"Modify.aspx?id_an=" + list.ElementAt(i).id + "&r=u\">Usuń </a>");
                    html.Append("<a href=\"EditAnnouncement.aspx?id_announc=" + list.ElementAt(i).id + "\">Edytuj </a>");
                    html.Append("</td>");
                    html.Append("</tr>");
                }
            }
            //Table end.
            html.Append("</table>");
            //Append the HTML string to Placeholder.
            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });


        }


    }
}