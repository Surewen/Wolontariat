using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class ModifyAnnouncement : System.Web.UI.Page
    {
        int id_a;
        int opcja;//1=usun, 2=edytuj
        SQLDatabase db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            id_a = int.Parse(Request.QueryString["id_an"]);
            opcja = 0;
            if (Request.QueryString["r"].Equals("z")) opcja = 1;
            if (Request.QueryString["r"].Equals("u")) opcja = 2;
            
            if (opcja == 1)
            {
                db.DeclineFromAnnouncement(id_a, db.getId((string)Session["id"]));
                Response.Redirect("MyActivities.aspx");
            }
           
            if (opcja == 2)
            {
                db.Delete_Users_Assigned_Announcement(id_a);
                db.DeleteAnnouncement(id_a);
                Response.Redirect("MyActivities.aspx");
            }
            db.Disconnect();
        }
    }
}