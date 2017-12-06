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
    public partial class Details : System.Web.UI.Page
    {
        SQLDatabase db;
        int id_a, id_e;
        Boolean wielorazowe;
        string typ;
        List<Announcement> list_announcements;
        List<Event> list_events;
        StringBuilder html;
        protected void Page_Load(object sender, EventArgs e)
        {
            typ = "";
            if (Request.QueryString["id_a"]!=null) id_a = int.Parse(Request.QueryString["id_a"]);
            if (Request.QueryString["id_e"] != null) id_e = int.Parse(Request.QueryString["id_e"]);
            wielorazowe = false;
            db = new SQLDatabase();
            db.Connect();
            list_announcements = db.ListAnnouncements();
            list_events = db.ListEvents();
            html = new StringBuilder();

            if (Request.QueryString["id_a"] != null)
            {
                html.Append("<table border = '1'>");
                html.Append("<tr>");
                html.Append("<th>Id</th><th>Dodane przez</th><th>Nickname</th><th>Data dodania</th><th>Do kiedy</th><th>Typ pomocy</th><th>Status</th><th>Temat</th><th>Zawartość</th>");
                html.Append("</tr>");
                
                for (int i = 0; i < list_announcements.Count; i++)
                {
                    if (id_a == list_announcements.ElementAt(i).id)
                    {
                        typ = db.getType_User(list_announcements.ElementAt(i).id_user);
                        html.Append("<tr>");
                        html.Append("<td>" + list_announcements.ElementAt(i).id + "</td>");
                        html.Append("<td>" + typ + "</td>");
                        html.Append("<td>" + db.getNickname_id(list_announcements.ElementAt(i).id_user) + "</td>");
                        html.Append("<td>" + list_announcements.ElementAt(i).post_date + "</td>");
                        html.Append("<td>");
                        if (list_announcements.ElementAt(i).type_help.Equals("Jednorazowa")) html.Append("---");
                        else
                        {
                            wielorazowe = true;
                            html.Append(list_announcements.ElementAt(i).end_date);
                        }
                        html.Append("</td>");
                        html.Append("<td>" + list_announcements.ElementAt(i).type_help + "</td>");
                        html.Append("<td>" + list_announcements.ElementAt(i).current_status + "</td>");
                        html.Append("<td>" + list_announcements.ElementAt(i).title + "</td>");
                        html.Append("<td>" + list_announcements.ElementAt(i).content + "</td>");
                        html.Append("</tr>");
                    }
                }
                html.Append("</table>");
                html.Append("<br/><br/>");
            }
               
                if (Session["id"]!=null && Request.QueryString["id_a"]!= null)
                {
                    if (db.getType_User(db.getId((string)Session["id"])) == "volounteer" && typ == "needy")
                    {
                        zglos.Visible = true; html.Append("Zgłoś się do pomocy!");
                        if (wielorazowe)
                        {
                            html.Append("Potrzebna jest pomoc przez kilka dni, określ godziny, które Ci pasują: ");
                            from.Visible = true;
                            to.Visible = true;
                        }
                        html.Append("Możesz również utworzyć wydarzenie dla tego ogłoszenia: ");
                        create.Visible = true;
                    }
                }

            if (Request.QueryString["id_e"] != null)
            {
                html.Append("<table border = '1'>");

                html.Append("<tr>");
                html.Append("<th>Id</th><th>Utworzone przez</th><th>Data dodania</th><th>Data wydarzenia</th><th>Powiązanie z ogłoszeniem</th><th>Temat</th><th>Zawartość</th>");
                html.Append("</tr>");

                for (int i = 0; i < list_events.Count; i++)
                {
                    if (id_e == list_events.ElementAt(i).id)
                    {
                        typ = db.getType_User(list_events.ElementAt(i).id_user);
                        html.Append("<tr>");
                        html.Append("<td>" + list_events.ElementAt(i).id + "</td>");
                        html.Append("<td>" + db.getNickname_id(list_events.ElementAt(i).id_user) + "</td>");
                        html.Append("<td>" + list_events.ElementAt(i).post_date + "</td>");
                        html.Append("<td>" + list_events.ElementAt(i).due_date + "</td>");
                        if (list_events.ElementAt(i).id_announcement.Equals(null)) html.Append("<td>Nie</td>");
                        else html.Append("<td>Tak</td>");
                        html.Append("<td>" + list_events.ElementAt(i).title + "</td>");
                        html.Append("<td>" + list_events.ElementAt(i).content + "</td>");
                        html.Append("</tr>");
                        if (!list_events.ElementAt(i).id_announcement.Equals(null))
                        {
                            int id_anno = db.getIdAnnouncement((int)list_events.ElementAt(i).id_announcement);
                            html.Append("</br>Ogłoszenie, do którego zostało utworzone powyższe wydarzenie: </br>");
                            html.Append("<tr>");
                            html.Append("<th>Utworzone przez</th><th>Data dodania</th><th>Do kiedy</th><th>Typ pomocy</th><th>Status</th><th>Temat</th><th>Zawartość</th>");
                            html.Append("</tr>");
                            html.Append("<tr>");
                            html.Append("<td>" + db.getNickname_id(list_announcements.ElementAt(id_anno).id_user) + "</td>");
                            html.Append("<td>" + list_announcements.ElementAt(id_anno).post_date + "</td>");
                            html.Append("<td>");
                            if (list_announcements.ElementAt(id_anno).type_help.Equals("Jednorazowa")) html.Append("---");
                            else html.Append(list_announcements.ElementAt(id_anno).end_date);
                            html.Append("</td>");
                            html.Append("<td>" + list_announcements.ElementAt(id_anno).type_help + "</td>");
                            html.Append("<td>" + list_announcements.ElementAt(id_anno).current_status + "</td>");
                            html.Append("<td>" + list_announcements.ElementAt(id_anno).title + "</td>");
                            html.Append("<td>" + list_announcements.ElementAt(id_anno).content + "</td>");
                            html.Append("</tr>");
                        }
                    }
                }
                html.Append("</table>");
                html.Append("<br/><br/>");
            }
            if (Session["id"] != null && Request.QueryString["id_e"] != null)
            {
                if (db.getType_User(db.getId((string)Session["id"])) == "volounteer")
                {
                    html.Append("Możesz dołączyć do wydarzenia:");
                    join.Visible = true;
                    html.Append("Możesz zaprosić innego wolontariusza do wzięcia udziału w tym wydarzeniu:");
                    select.Visible = true;
                }
            }
            
            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });

            db.Disconnect();
        }


        protected void Zglos_Sie(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            db.AssignToAnnouncement(id_a, db.getId((string)Session["id"]), from.Text, to.Text);
            db.Disconnect();
        }

        protected void Join_To_Event(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            db.JoinToEvent(id_e, db.getId((string)Session["id"]));
            db.Disconnect();

        }

        protected void Create_Event(object sender, EventArgs e)
        {
            Response.Redirect("AddEvent.aspx?id_a="+id_a);
        }
        protected void Select_User(object sender, EventArgs e)
        {
            Response.Redirect("ListUsers.aspx?id_e=" + id_e);
        }

    }
}