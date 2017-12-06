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
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            
            if (Session["id"] != null)
            {
                if (db.getType_User(db.getId((string)Session["id"])) == "volounteer" && db.getType_User(db.getId((string)Session["id"])) == "volounteer")
                {
                    add_event.Visible = true;
                }
            }
            List<Event> list = db.ListEvents();
            StringBuilder html = new StringBuilder();
            html.Append("<table border = '1'>");

            html.Append("<tr>");
            html.Append("<th>Dodane przez</th><th>Data dodania</th><th>Data wydarzenia</th><th>Powiązane z ogłoszeniem potrzebującego</th><th>Temat</th>");
            html.Append("</tr>");
            for (int i = 0; i < list.Count; i++)
            {
                    html.Append("<tr>");
                    html.Append("<td>" + db.getNickname_id(list.ElementAt(i).id_user)+ "</td>");
                    html.Append("<td>" + list.ElementAt(i).post_date + "</td>");
                    html.Append("<td>" + list.ElementAt(i).due_date+ "</td>");
                    if (list.ElementAt(i).id_announcement.Equals(null)) html.Append("<td>Nie</td>");
                    else html.Append("<td>Tak</td>");
                html.Append("<td>" + list.ElementAt(i).title + "</td>");
                html.Append("<td>");
                html.Append("<a href=\"Details.aspx?id_e=" + list.ElementAt(i).id + "\">Szczegóły</a>");
                html.Append("</td>");
                html.Append("</tr>");
            }

            //Table end.
            html.Append("</table>");
            html.Append("<br/><br/>");



            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            db.Disconnect();

        }

     


    }
}
