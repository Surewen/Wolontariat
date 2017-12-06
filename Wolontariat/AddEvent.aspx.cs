using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class AddEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Add_Event(object sender, EventArgs e)
        {
            SQLDatabase db = new SQLDatabase();
            int id_a = -1; ;
            if (Request.QueryString["id_anno"]!=null) id_a = int.Parse(Request.QueryString["id_anno"]);

            db.Connect();
            db.InstertEvents(id_a, db.getId((string)Session["id"]), due_date.Value, title.Value, content.Value);
          
            db.Disconnect();
            Response.Redirect("Events.aspx");
        }
    }
}