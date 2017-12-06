using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Invite : System.Web.UI.Page
    {
        SQLDatabase db;
        int id_user, id_event;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void send_invitation(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            if (Request.QueryString["id_user"] != null) id_user = int.Parse(Request.QueryString["id_user"]);
            if (Request.QueryString["id_event"] != null) id_event = int.Parse(Request.QueryString["id_event"]);
            db.send_invitation(id_event, db.getId((string)Session["id"]), id_user, title.Value, content.Value);
            db.Disconnect();
        }
       
    }
}