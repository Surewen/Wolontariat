using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class EditAnnouncement : System.Web.UI.Page
    {
        SQLDatabase db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Metoda obsługująca edycję utworzonych ogłoszeń.
        /// Pobiera z formularza wprowadzone dane przez użytkownika, następnie wywołuje
        /// metodę EditAnnouncement przesyłając te wartości jako parametry metody.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Edit_Announcement(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            int id_a;
            if (Request.QueryString["id_a"] != null)
            {
                id_a = int.Parse(Request.QueryString["id_a"]);
                db.EditAnnouncement(id_a, end_date.Value, one.Checked, subject.Value, content.Value);
            }
            Response.Redirect("MyActivities.aspx");
            db.Disconnect();
        }
    }
}