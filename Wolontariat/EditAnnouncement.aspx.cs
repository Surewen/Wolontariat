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
        /// <summary>
        /// The method that supports editing the adverts created. 
        /// It retrieves data from the form by the user, then calls the EditAnnouncement method, 
        /// sending these values as method parameters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Edit_Announcement(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            int id_a;
            if (Request.QueryString["id_a"] != null)
            {
                id_a = int.Parse(Request.QueryString["id_a"]);
                db.EditAnnouncement(id_a, end_date.Value, one.Checked, subject.Value, content.Value);
            }
            Response.Redirect("MyActivities.aspx");
            db.Disconnect();
        }
    }
}