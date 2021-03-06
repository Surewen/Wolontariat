﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Login : System.Web.UI.Page
    {
        SQLDatabase db;
        /// <summary>
        /// The method that supports the login subsystem. 
        /// It retrieves the entered email and password from the form, then calls the getlogin method, 
        /// which returns a value of type SqlDataReader.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();

            if (db.getLogin(inputEmail.Value, inputPassword.Value).Read())
            {
                Session["id"] = inputEmail.Value;
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("Nieudana próba logowania!!!");
            }
            
            db.Disconnect();
        }
    }
}