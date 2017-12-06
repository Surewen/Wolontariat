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