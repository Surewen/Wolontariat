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
        int id_a;
        Boolean wielorazowe;
        protected void Page_Load(object sender, EventArgs e)
        {
                id_a = int.Parse(Request.QueryString["id_a"]);
                wielorazowe = false;
                db = new SQLDatabase();

                db.Connect();
                List<Announcement> list = db.ListAnnouncements();
                StringBuilder html = new StringBuilder();

                html.Append("<table border = '1'>");

                html.Append("<tr>");
                html.Append("<th>Id</th><th>Dodane przez</th><th>Nickname</th><th>Data dodania</th><th>Do kiedy</th><th>Typ pomocy</th><th>Status</th><th>Temat</th><th>Zawartość</th>");
                html.Append("</tr>");
                string typ = ""; 
                for (int i = 0; i < list.Count; i++)
                    {
                    if (id_a == list.ElementAt(i).id)
                    {
                    typ = db.getType_User(list.ElementAt(i).id_user);
                        html.Append("<tr>");
                        html.Append("<td>" + list.ElementAt(i).id + "</td>");
                        html.Append("<td>" + typ + "</td>");
                        html.Append("<td>" + db.getNickname_id(list.ElementAt(i).id_user) + "</td>");
                        html.Append("<td>" + list.ElementAt(i).post_date + "</td>");
                        html.Append("<td>");
                        if (list.ElementAt(i).type_help.Equals("Jednorazowa")) html.Append("---");
                        else
                        {
                            wielorazowe = true;
                            html.Append(list.ElementAt(i).end_date);
                        }
                        html.Append("</td>");
                        html.Append("<td>" + list.ElementAt(i).type_help + "</td>");
                        html.Append("<td>" + list.ElementAt(i).current_status + "</td>");
                        html.Append("<td>" + list.ElementAt(i).title + "</td>");
                        html.Append("<td>" + list.ElementAt(i).content + "</td>");
                        html.Append("</tr>");
                    }
                }
            
                //Table end.
                html.Append("</table>");
                html.Append("<br/><br/>");
                
               
                if (Session["id"]!=null)
                {
                if (db.getType_User(db.getId((string)Session["id"])) == "volounteer" && typ == "needy")
                {
                    zglos.Visible = true; html.Append("Zgłoś się do pomocy!");
                    if (wielorazowe)
                    {
                        html.Append("Potrzebna jest pomoc przez kilka dni, określ godziny, które Ci pasują: ");
                        from.Visible = true;
                        to.Visible = true;
                    }
                }
                }
                //Append the HTML string to Placeholder.
                PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });

            db.Disconnect();
        }


        protected void zglos_sie(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
           
            db.AssigntoAnnouncement(id_a, db.getId((string)Session["id"]), from.Text, to.Text);
            
            db.Disconnect();


        }
        }
}