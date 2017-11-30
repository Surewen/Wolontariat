using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Register : System.Web.UI.Page
    {
        SQLDatabase db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_User(object sender, EventArgs e)
        {
            
            db = new SQLDatabase();
            db.Connect();
            db.InsertUser(nickname.Value, inputPassword.Value, pesel.Value, inputEmail.Value, telephone.Value, name.Value, surname.Value, Request.Form["birthDate"], "male", "volounteer");
            db.Disconnect();
        }
    }
}