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
        int id_a, id_e;
        int opcja;//1=zrezygnuj, 2=usun
        SQLDatabase db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            if (Request.QueryString["id_a"] !=null) id_a = int.Parse(Request.QueryString["id_a"]);
            if (Request.QueryString["id_e"] != null) id_e = int.Parse(Request.QueryString["id_e"]);
            opcja = 0;
            if (Request.QueryString["r"] != null)
            {
                if (Request.QueryString["r"].Equals("z")) opcja = 1;
                if (Request.QueryString["r"].Equals("u")) opcja = 2;
            } 
            
            if (opcja == 1)
            {
                if (Request.QueryString["id_a"] != null)db.DeclineFromAnnouncement(id_a, db.getId((string)Session["id"]));
                if (Request.QueryString["id_e"] != null)db.DeclineFromEvent(id_e, db.getId((string)Session["id"]));
                Response.Redirect("MyActivities.aspx");
            }
           
            if (opcja == 2)
            {
                if (Request.QueryString["id_e"] != null)
                {
                    db.Delete_Users_Joined_Event(id_e);
                    db.DeleteInvitation(id_e);
                    db.DeleteEvent(id_e);
                }
                if (Request.QueryString["id_a"] != null)
                {
                    List<int?> list_events_id = db.getIdEvents(id_a);
                    for (int i = 0; i < list_events_id.Count; i++)
                    {
                        db.Delete_Users_Joined_Event((int)list_events_id.ElementAt(i));
                        db.DeleteInvitation((int)list_events_id.ElementAt(i));
                    }
                    db.DeleteEvent_id_a(id_a);
                    db.Delete_Users_Assigned_Announcement(id_a);
                    db.DeleteAnnouncement(id_a);
                }
                Response.Redirect("MyActivities.aspx");
            }
            db.Disconnect();
        }
    }
}