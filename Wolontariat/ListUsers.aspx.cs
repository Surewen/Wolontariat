﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class ListUsers : System.Web.UI.Page
    {
        SQLDatabase db;
        int id_e;
        StringBuilder html;
        List<Users> list_users;
        /// <summary>
        /// A method that displays all volunteer users. It is used to select the person you want to invite to participate in the event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id_u"] != null) { Reset_Password(int.Parse(Request.QueryString["id_u"])); }
            db = new SQLDatabase();
            html = new StringBuilder();
            db.Connect();
            list_users = db.ListUsers();
            
            html.Append("<table border = '1' align='center'>");

            html.Append("<tr>");
            html.Append("<th>Id</th><th>Imię</th><th>Nazwisko</th><th>Nickname</th><th>E-mail</th><th>Płeć</th><th>Telefon</th>");
            html.Append("</tr>");

            for (int i = 0; i < list_users.Count; i++)
            {
                
                    html.Append("<tr>");
                    html.Append("<td>" + list_users.ElementAt(i).id + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).name + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).surname + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).nickname + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).email + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).sex + "</td>");
                    html.Append("<td>" + list_users.ElementAt(i).telephone + "</td>");
                    html.Append("<td><a href=\"ListUsers.aspx?id_u="+ list_users.ElementAt(i).id+"\">Resetuj hasło</a></td>");
                    html.Append("</tr>");
                
            }
            
            html.Append("</table>");
            html.Append("<br/><br/>");
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            
            db.Disconnect();
        }



        protected void Reset_Password(int id_u)
        {
            db = new SQLDatabase();
            db.Connect();
            db.ResetPassword(id_u);
            Send_Email(db.getEmail(id_u), db.getNickname_id(id_u));
            db.Disconnect();
        }

        protected void Send_Email(string email, string nickname)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress((string)Session["id"]);
            msg.To.Add(email);
            msg.Subject = "Resetowanie hasła";
            msg.Body = "Witaj " + nickname + "! Zmieniono Ci hasło na: password. Zaleca się po zalogowaniu zmianę hasła!";
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential((string)Session["id"], "pwwmoderato");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            }
        }

    }
}