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
        List<String>[] lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                db = new SQLDatabase();
                db.Connect();
                DataTable dt = db.getAnnouncements();
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

                lista = db.ListUsers();
                String rodzaj = "ww";
                
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < lista.Length; i++)
                    {
                        if (row[1].Equals(int.Parse(lista[0].ElementAt(i)))) { rodzaj = lista[10].ElementAt(i); }
                    }
                    html.Append("<tr>");
                    html.Append("<td>");
                    html.Append(row[2]);
                    html.Append("</td>");
                    html.Append("<td>");
                    html.Append(rodzaj);
                    html.Append("</td>");
                    html.Append("<td>");
                    html.Append(row[5]);
                    html.Append("</td>");
                    html.Append("<td>");
                    html.Append(row[6]);
                    html.Append("</td>");
                    html.Append("<td>");
                    html.Append("<a href=\"Details.aspx?id_a="+row[0]+"&id_u="+row[1]+"\">Szczegóły</a>"); 
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
}