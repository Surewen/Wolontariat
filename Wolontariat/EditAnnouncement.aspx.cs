using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class EditAnnouncement : System.Web.UI.Page
    {
        SQLDatabase db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Edit_Announcement(object sender, EventArgs e)
        {
            int id_a = int.Parse(Request.QueryString["id_ann"]);
            db = new SQLDatabase();
            db.Connect();

            db.EditAnnouncement(id_a, end_date.Value, one.Checked, subject.Value, content.Value);
            Response.Redirect("MyActivities.aspx");
            db.Disconnect();
        }
    }
}