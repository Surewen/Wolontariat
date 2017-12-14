using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class EditEvent : System.Web.UI.Page
    {
        SQLDatabase db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// A method that supports editing of created events. 
        /// It retrieves data from the form entered by the user, then calls the EditEvent method by sending this data as method parameters.
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