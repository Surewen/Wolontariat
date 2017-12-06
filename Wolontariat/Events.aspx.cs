using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Events : System.Web.UI.Page
    {
        SQLDatabase db;
        List<Event> list_events;
        StringBuilder html;
        protected void Page_Load(object sender, EventArgs e)
        {
            html = new StringBuilder();
            db = new SQLDatabase();
            db.Connect();
            list_events = db.ListEvents();

            if (Session["id"] != null)
            {
                if (db.getType_User(db.getId((string)Session["id"])) == "volounteer") add_event.Visible = true;
            }
            
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Dodane przez</th><th>Data dodania</th><th>Data wydarzenia</th><th>Powiązane z ogłoszeniem potrzebującego</th><th>Temat</th>");
            html.Append("</tr>");
            for (int i = 0; i < list_events.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + db.getNickname_id(list_events.ElementAt(i).id_user)+ "</td>");
                html.Append("<td>" + list_events.ElementAt(i).post_date + "</td>");
                html.Append("<td>" + list_events.ElementAt(i).due_date+ "</td>");
                if (list_events.ElementAt(i).id_announcement.Equals(null)) html.Append("<td>Nie</td>");
                else html.Append("<td>Tak</td>");
                html.Append("<td>" + list_events.ElementAt(i).title + "</td>");
                html.Append("<td>");
                html.Append("<a href=\"Details.aspx?id_e=" + list_events.ElementAt(i).id + "\">Szczegóły</a>");
                html.Append("</td>");
                html.Append("</tr>");
            }
            html.Append("</table>");
            html.Append("<br/><br/>");
            
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            db.Disconnect();
        }
    }
}
