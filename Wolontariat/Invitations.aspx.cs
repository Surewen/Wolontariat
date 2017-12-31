using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Invitations : System.Web.UI.Page
    {
        SQLDatabase db;
        StringBuilder html;
        List<Invitation> list_invitations;
        /// <summary>
        /// A method that displays the invitations the user has received
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                db = new SQLDatabase();
                db.Connect();
                list_invitations = db.ListInvitations();
                html = new StringBuilder();

                html.Append("Otrzymane zaproszenia");
                html.Append("<table border = '1' align='center'>");
                html.Append("<tr>");
                html.Append("<th>Data wysłania</th><th>Wysłane przez</th><th>Temat</th><th>Zawartość</th>");
                html.Append("</tr>");
                for (int i = 0; i < list_invitations.Count; i++)
                {
                    if (list_invitations.ElementAt(i).id_receiver.Equals(db.getId((string)Session["id"])))
                    {
                        html.Append("<tr>");
                        html.Append("<td>" + list_invitations.ElementAt(i).post_date + "</td>");
                        html.Append("<td>" + db.getNickname_id(list_invitations.ElementAt(i).id_sender) + "</td>");
                        html.Append("<td>" + list_invitations.ElementAt(i).title + "</td>");
                        html.Append("<td>" + list_invitations.ElementAt(i).content + "</td>");
                        html.Append("<td><a href=\"Details.aspx?id_e=" + list_invitations.ElementAt(i).id_event + "\">Szczegóły wydarzenia</a></td>");
                        html.Append("</tr>");
                    }
                }
                html.Append("</table>");
                html.Append("<br/><br/>");
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                db.Disconnect();
            }
        }
    }
}