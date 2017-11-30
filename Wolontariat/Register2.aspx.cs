using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Register2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
        protected void RegisterUser2(object sender, EventArgs e)
        {
            SQLDatabase db = new SQLDatabase();
            db.Connect();

          

            db.Disconnect();

        }


    }
}