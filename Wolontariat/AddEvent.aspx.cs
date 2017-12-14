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
        /// Metoda odpowiadająca za obsługę podsystemu dodawania wydarzeń.
        /// Pobiera z formularza informacje wprowadzone przez użytkownika, 
        /// następnie wywołuje metodę InsertEvents przesyłąc pobrane wartości jako parametry metody.
        /// Wydarzenie można utworzyć również na podstawie ogłoszenia, metoda sprawdza czy zostaje przesłany numer ogłoszenia
        /// za pomocą QueryString, jeżeli tak jest przesyłana wartość numeru ogłoszenia, 
        /// jeżeli nie jest przesyłany numer -1. W metodzie InsertEvents znajduje się dalsza obsługa wartości numeru ogłoszenia
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