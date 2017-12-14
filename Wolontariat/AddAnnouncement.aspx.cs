using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class AddAnnouncement : System.Web.UI.Page
    {
        SQLDatabase db;
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        /// <summary>
        /// Metoda odpowiadająca za obsługę podsystemu dodawania ogłoszenia.
        /// Pobiera informacje z formularza wprowadzone przez użytkownika, 
        /// następnie wywołuje metodę InsertAnnouncement przesyłając pobrane wcześniej informacje jako parametry metody
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_Announcement(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            db.InsertAnnouncement(db.getId((string)Session["id"]), end_date.Value, one.Checked, subject.Value, content.Value);
          
            Response.Redirect("MyActivities.aspx");
            db.Disconnect();
        }
    }
}