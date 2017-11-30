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

        protected void Add(object sender, EventArgs e)
        {
            SQLDatabase db = new SQLDatabase();
            db.Connect();
            db.InstertEvents(autor.Value, add_date.Value, due_data.Value,title.Value, content.Value);
            db.Disconnect();
        }
    }
}