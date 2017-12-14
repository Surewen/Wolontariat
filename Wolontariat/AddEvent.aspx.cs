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

        /// <summary>
        /// The method responsible for handling the subsystem of adding events. Retrieves information from the form entered by the user. 
        /// Then it calls the InsertEvents method to send the downloaded values as method parameters. 
        /// The event can also be created on the basis of the announcement, the method checks if the announcement number is sent using QueryString. 
        /// If so, the value of the advertisement number is sent. If number -1 is not sent. 
        /// In the InsertEvents method there is further support for the value of the advertisement number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_Event(object sender, EventArgs e)
        {
            SQLDatabase db = new SQLDatabase();
            int id_a = -1; ;
            if (Request.QueryString["id_a"]!=null) id_a = int.Parse(Request.QueryString["id_a"]);

            db.Connect();
            db.InstertEvents(id_a, db.getId((string)Session["id"]), due_date.Value, title.Value, content.Value);
          
            db.Disconnect();
            Response.Redirect("Events.aspx");
        }
    }
}