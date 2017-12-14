﻿using System;
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
        /// <summary>
        /// Metoda obsługująca proces rejestracji. Pobiera z formularza dane wprowadzone przez użytkownika, 
        /// następnie wywołuje metodę InsertUser przesyłając pobrane dane jako parametry metody.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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