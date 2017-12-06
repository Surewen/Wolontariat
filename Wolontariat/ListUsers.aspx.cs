using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class ListUsers : System.Web.UI.Page
    {
        SQLDatabase db;
        int id_e;
        StringBuilder html;
        List<Users> list_users;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id_e"] != null) id_e = int.Parse(Request.QueryString["id_e"]);
            db = new SQLDatabase();
            html = new StringBuilder();
            db.Connect();
            list_users = db.ListUsers();
            
            html.Append("<table border = '1'>");

            html.Append("<tr>");
            html.Append("<th>Id</th><th>Imię</th><th>Nazwisko</th><th>Nickname</th><th>E-mail</th><th>Płeć</th><th>Telefon</th>");
            html.Append("</tr>");

            for (int i = 0; i < list_users.Count; i++)
            {
                if (list_users.ElementAt(i).type.Equals("volounteer"))
                {
                    html.Append("<tr>");
                    html.Append("<td>" + list_users.ElementAt(i).id + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).name + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).surname + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).nickname + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).email + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).sex + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).telephone + "</td>");
                    html.Append("<td><a href=\"Invite.aspx?id_u="+ list_users.ElementAt(i).id+"&id_e="+id_e+"\">Zaproś</a></td>");
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