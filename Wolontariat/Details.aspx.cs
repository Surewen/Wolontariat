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
        List<String>[] lista;
        String id_u, id_a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                id_a = Request.QueryString["id_a"];
                id_u = Request.QueryString["id_u"];
                
                db = new SQLDatabase();
                db.Connect();

                lista = db.ListUsers();
                String nick = "test";
                for (int i = 0; i < lista.Length; i++)
                {
                    if (lista[0].ElementAt(i) == id_u)
                    { nick = lista[1].ElementAt(i); }
                }
                
                DataTable dt = db.getAnnouncements();
                StringBuilder html = new StringBuilder();

                html.Append("<table border = '1'>");

                html.Append("<tr>");
                html.Append("<th>Id</th><th>Stworzone przez</th><th>Data dodania</th><th>Do kiedy</th><th>Typ pomocy</th><th>Status</th><th>Temat</th><th>Zawartość</th>");
                html.Append("</tr>");
                html.Append(nick);
                foreach (DataRow row in dt.Rows)
                {
                    try
                        {
                        if (int.Parse(id_a).Equals(row[0]))
                        {
                            html.Append("<tr>");

                            html.Append("<td>");
                            html.Append(row[0]);
                            html.Append("</td>");
                            html.Append("<td>");
                            html.Append(nick);
                            html.Append("</td>");
                            html.Append("<td>");
                            html.Append(row[2]);
                            html.Append("</td>");
                            html.Append("<td>");
                            if (row[4].Equals("jednorazowy")) { html.Append(row[2]); }
                            else { html.Append(row[3]); }
                            html.Append(row[3]);
                            html.Append("</td>");
                            html.Append("<td>");
                            html.Append(row[4]);
                            html.Append("</td>");
                            html.Append("<td>");
                            html.Append(row[5]);
                            html.Append("</td>");
                            html.Append("<td>");
                            html.Append(row[6]);
                            html.Append("</td>");
                            html.Append("<td>");
                            html.Append(row[7]);
                            html.Append("</td>");

                            html.Append("</tr>");
                        }

                    }
                    catch(ArgumentNullException a)
                        { }
                 
                
                }
                //Table end.
                html.Append("</table>");
                //Append the HTML string to Placeholder.
                PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });

                db.Disconnect();
            }
            
        }

        



    }
}