using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class AddAnnouncement : System.Web.UI.Page
    {
        SQLDatabase db;
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void Add_Announcement(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            db.InstertAnnouncement(db.getId((string)Session["id"]), end_date.Value, one.Checked, subject.Value, content.Value);
            


            db.Disconnect();
        }
    }
}