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
        /// <summary>
        /// The method is responsible for handling the subsystem of adding advertisements. Retrieves information from the form entered by the user. 
        /// Then it calls the InsertAnnouncement method by sending the previously retrieved information as method parameters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_Announcement(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            db.InsertAnnouncement(db.getId((string)Session["id"]), end_date.Value, one.Checked, subject.Value, content.Value);
          
            Response.Redirect("MyActivities.aspx");
            db.Disconnect();
        }
    }
}