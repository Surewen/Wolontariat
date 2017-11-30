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


        ///<summary>procedura pobierająca dane z formularza odpowiadającego dodawaniu wydarzeń a następnie
        ///wywołująca procedure dodania do bazy danych</summary>
        /// <param name="sender"> obiekt przesyłany z formularza rejestracji</param>
        /// <param name="e"></param>
        ///<param "db"> obiekt klasy zarządzającej za bazą danych</param>
        protected void Register_User(object sender, EventArgs e)
        {
            
            db = new SQLDatabase();
            db.Connect();
            db.InsertUser(nickname.Value, inputPassword.Value, pesel.Value, inputEmail.Value, telephone.Value, name.Value, surname.Value, "1991-11-11", "male", "volounteer");
            db.Disconnect();
        }
    }
}