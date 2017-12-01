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


        ///<summary>procedura pobierająca dane z formularza odpowiadającego dodawaniu wydarzeń a następnie
        ///wywołująca procedure dodania do bazy danych</summary>
        /// <param name="sender">obiekt wysyłany z formularza dodawania wydarzenia</param>
        /// <param name="e"></param>
        ///<param "db"> obiekt klasy zarządzającej za bazą danych</param>
        protected void Add(object sender, EventArgs e)
        {
            SQLDatabase db = new SQLDatabase();
            db.Connect();
            Int16 id_announcement = 0;
            db.InstertEvents(id_announcement, autor.Value, add_date.Value, due_data.Value,title.Value, content.Value);
            db.Disconnect();
        }
    }
}