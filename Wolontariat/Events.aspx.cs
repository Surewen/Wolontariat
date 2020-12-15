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
    /// <summary>
    /// This class is a partial class linked with Events.aspx page. Its main function is to list all events.
    /// </summary>
    public partial class Events : System.Web.UI.Page
    {
        /// <summary>
        /// Database reference object
        /// </summary>
        SQLDatabase db;
        /// <summary>
        /// List where all events taken from the database
        /// </summary>
        List<Event> list_events;
        /// <summary>
        /// A helper tool to create a HTML table with data from the database.
        /// </summary>
        StringBuilder html;
        /// <summary>
        /// This method is responsible for getting data from the database, putting them into a StringBuilder and appending them to the Events.aspx page.
        /// </summary>
        /// <param name="sender">Parameter containing references to the control that raised the event</param>
        /// <param name="e">Parameter responsible for storing event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            html = new StringBuilder();
            db = new SQLDatabase();
            db.Connect();
            list_events = db.ListEvents();

            if (Session["id"] != null)
            {
                if (db.getType_User(db.getId((string)Session["id"])) == "volounteer" || db.getType_User(db.getId((string)Session["id"])) == "administrator") add_event.Visible = true;
            }
            
            html.Append("<table border = '1' align='center'>");
            html.Append("<tr>");
            html.Append("<th>Dodane przez</th><th>Data dodania</th><th>Data wydarzenia</th><th>Powiązane z ogłoszeniem potrzebującego</th><th>Temat</th>");
            html.Append("</tr>");
            for (int i = 0; i < list_events.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + db.getNickname_id(list_events.ElementAt(i).id_user)+ "</td>");
                html.Append("<td>" + list_events.ElementAt(i).post_date.ToString("yyyy-MM-dd") + "</td>");
                html.Append("<td>" + list_events.ElementAt(i).due_date.ToString("yyyy-MM-dd") + "</td>");
                if (list_events.ElementAt(i).id_announcement.Equals(null)) html.Append("<td>Nie</td>");
                else html.Append("<td>Tak</td>");
                html.Append("<td>" +list_events.ElementAt(i).title + "</td>");
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
