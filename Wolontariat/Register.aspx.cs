using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Register : System.Web.UI.Page
    {
        protected void RegisterUser(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["pww-databaseConnectionString"].ConnectionString);
                con.Open();
                string insert = "insert into users (pesel, email, name, surname, birth_date, sex, type) values (@pesel, @email, @name, @surname, @birth_date, @sex, @type) ";
                SqlCommand cmd = new SqlCommand(insert, con);
               
            }
            catch (Exception ef)
            { }
        }
    }
}