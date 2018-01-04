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
        List<Announcement> list_announcements;
        StringBuilder html;
        /// <summary>
        /// The method responsible for displaying all advertisements based on the list of Announcement objects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
                db = new SQLDatabase();
                db.Connect();
                list_announcements = db.ListAnnouncements();
                html = new StringBuilder();

            if (Session["id"] == null) add_announcement.Visible = false;
            else {
                add_announcement.Visible = false;
                if (db.getType_User(db.getId((string)Session["id"]))!="administrator") add_announcement.Visible = true; 
            }
            
                html.Append("<table border = '1' align='center'> ");
                html.Append("<tr>");
                html.Append("<th>Data dodania</th><th>Stworzone przez</th><th>Dodane przez</th><th>Status</th><th>Temat</th>");
                html.Append("</tr>");
            
            for (int i = 0; i < list_announcements.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + list_announcements.ElementAt(i).post_date.ToString("yyyy-MM-dd") + "</td>");
                html.Append("<td>" + db.getNickname_id(list_announcements.ElementAt(i).id_user) + "</td>");
                html.Append("<td>" + db.getType_User(list_announcements.ElementAt(i).id_user).Replace("needy", "Potrzebujący").Replace("volounteer","Wolontariusz") + "</td>");
                html.Append("<td>" + list_announcements.ElementAt(i).current_status + "</td>");
                html.Append("<td>" + list_announcements.ElementAt(i).title + "</td>");
                html.Append("<td><a href=\"Details.aspx?id_a=" + list_announcements.ElementAt(i).id + "\">Szczegóły</a></td>");
                html.Append("</tr>");
            }
                html.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                db.Disconnect();
            }
        
    }
}