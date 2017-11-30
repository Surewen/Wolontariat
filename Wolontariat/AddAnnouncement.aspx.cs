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
    public partial class AddAnnouncement1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["pww-databaseConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into announcements values ('" + DateTime.Today +"', '"+TextBox1.Text+"', '"+TextBox3.Text+"', '"+TextBox2.Text+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";




        }
    }
}