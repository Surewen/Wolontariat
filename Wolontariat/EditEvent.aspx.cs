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
        /// <summary>
        /// Metoda obsługująca edycję utworzonych wydarzeń. Pobiera dane
        /// z formularza wprowadzone przez użytkownika, nastęnie wywołuje metodę EditEvent
        /// przesyłając te dane jako parametry metody.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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