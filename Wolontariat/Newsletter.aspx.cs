using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Newsletter : System.Web.UI.Page
    {
        SQLDatabase db;
        List<Users> list_users;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Prepare_Email(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            List<String> lists_email = new List<string>();
            list_users = db.ListUsers();

            if (volounteers.Checked)
            {
                for (int i = 0; i < list_users.Count(); i++)
                {
                    if (list_users.ElementAt(i).type.Equals("volounteer")) lists_email.Add(list_users.ElementAt(i).email);
                }
            }
            if (needies.Checked)
            {
                for (int i = 0; i < list_users.Count(); i++)
                {
                    if (list_users.ElementAt(i).type.Equals("needy")) lists_email.Add(list_users.ElementAt(i).email);
                }
            }
            if (all.Checked)
            {
                for (int i = 0; i < list_users.Count(); i++)
                {
                    lists_email.Add(list_users.ElementAt(i).email);
                }
            }

            for (int i = 0; i < lists_email.Count(); i++)
            {
                Send_Email(lists_email.ElementAt(i), db.getNickname_email(lists_email.ElementAt(i)), subject.Value, content.Value);
            }
            
            db.Disconnect();
            
        }



        protected void Send_Email(string email, string nickname, string title, string content)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress((string)Session["id"]);
            msg.To.Add(email);
            msg.Subject = title;
            msg.Body = "Witaj " + nickname + "! "+content;
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