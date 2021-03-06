﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Invite : System.Web.UI.Page
    {
        SQLDatabase db;
        int id_user, id_event;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// A method that supports the subsystem to invite volunteers to the parish. Invokes the SendInvitation method. 
        /// Parameters that are entered by the user are the subject and contents of the invitation, 
        /// then are sent as parameters of the SendIvitation method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Send_Invitation(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            if (Request.QueryString["id_u"] != null) id_user = int.Parse(Request.QueryString["id_u"]);
            if (Request.QueryString["id_e"] != null) id_event = int.Parse(Request.QueryString["id_e"]);
            db.SendInvitation(id_event, db.getId((string)Session["id"]), id_user, title.Value, content.Value);
            db.Disconnect();
        }
       
    }
}