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
    public partial class Announcements : System.Web.UI.Page
    {
        SQLDatabase db;
        protected void Page_Load(object sender, EventArgs e)
        {
                db = new SQLDatabase();
                db.Connect();
                List<Announcement> list = db.ListAnnouncements();
            
                StringBuilder html = new StringBuilder();

                if (Session["id"] == null)
                {
                    add_announcement.Visible = false;
                }
                else
                {
                    add_announcement.Visible = true; 
                }
                
                html.Append("<table border = '1'>");
                html.Append("<tr>");
                html.Append("<th>Data dodania</th><th>Stworzone przez</th><th>Status</th><th>Temat</th>");
                html.Append("</tr>");

           
            for (int i = 0; i < list.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>");
                html.Append(list.ElementAt(i).post_date);
                html.Append("</td>");
                html.Append("<td>");
                html.Append(db.getType_User(list.ElementAt(i).id_user));
                html.Append("</td>");
                html.Append("<td>");
                html.Append(list.ElementAt(i).current_status);
                html.Append("</td>");
                html.Append("<td>");
                html.Append(list.ElementAt(i).title);
                html.Append("</td>");
                html.Append("<td>");
                html.Append("<a href=\"Details.aspx?id_a=" + list.ElementAt(i).id + "\">Szczegóły</a>");
                html.Append("</td>");
                html.Append("</tr>");
            }
                //Table end.
                html.Append("</table>");
                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                db.Disconnect();
            }
        
    }
}