using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    /// <summary>
    /// This class is a partial class responsible for editing events.
    /// </summary>
    public partial class EditEvent : System.Web.UI.Page
    {
        SQLDatabase db;
        /// <summary>
        /// This method executes when the page loasds but is empty since everything needed for editing loads from aspx file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// This method is responsible for making a connection to database, trying to put the edited data into the database and returning to the events list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Edit_Event(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            if (Request.QueryString["id_e"]!= null)
            {
                int id_e = int.Parse(Request.QueryString["id_e"]);
                db.EditEvent(id_e, due_date.Value, title.Value, content.Value);
                Response.Redirect("Events.aspx");
            }
            db.Disconnect();
        }

    }
}