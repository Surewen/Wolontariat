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
        DataTable dt;
        List<Announcement> list;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            list = db.ListAnnouncements();
            dt = db.getMyActivities(db.getId((string)Session["id"]));

            if (db.getType_User(db.getId((string)Session["id"]))=="volounteer") display_assigned_announcements();

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
            html.Append("<th>Id ogłoszenia</th><th>SDodane przez</th><th>Data dodania</th><th>Do kiedy</th><th>Typ pomocy</th><th>Status</th><th>Temat</th><th>Zawartość</th><th>od</th><th>do</th><th>Modyfikuj</th>");
            html.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list.ElementAt(i).id.Equals((int)row[1])) id_a = i;
                }
                html.Append("<tr>");
                html.Append("<td>" + row[1] + "</td>");
                html.Append("<td>" + db.getNickname_id((int)row[2]) + "</td>");
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
                html.Append("<a href=\"ModifyAnnouncement.aspx?id_an=" + row[1] + "&r=z\">Zrezygnuj </a>");
                html.Append("</td>");
                html.Append("</tr>");
            }
            //Table end.
            html.Append("</table>");
            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            
        }

        public void display_created_announcements()
        {
            StringBuilder html = new StringBuilder();
            html.Append("Ogłoszenia, które dodałem:");
            html.Append("</br>");
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Id ogłoszenia</th><th>Data dodania</th><th>Do kiedy</th><th>Status</th><th>Temat</th><th>Zawartość</th><th>Modyfikuj</th>");
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
                    html.Append("<a href=\"ModifyAnnouncement.aspx?id_an=" + list.ElementAt(i).id + "&r=u\">Usuń </a>");
                    html.Append("<a href=\"EditAnnouncement.aspx?id_ann=" + list.ElementAt(i).id+"\">Edytuj </a>");
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