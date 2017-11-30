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
        private String sex;
        private String type;
    
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
            if(male.Checked)
            {
                sex = "male";
            }
            else
            {
                sex = "female";
            }
            if (volounteer.Checked)
            {
                type = "volounteer";
            }
            else
            {
                type = "needy";
            }

            db = new SQLDatabase();
            db.Connect();
            db.InsertUser(nickname.Value, inputPassword.Value, pesel.Value, inputEmail.Value, telephone.Value, name.Value, surname.Value, birthDate.Value, sex, type);
            db.Disconnect();
        }
    }
}