using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class ModifyAnnouncement : System.Web.UI.Page
    {
        int id_a, id_e, id_u;
        int opcja;//1=zrezygnuj, 2=usun
        SQLDatabase db;
        /// <summary>
        /// The method that supports the possibility of resignation from the performance of the announcement 
        /// or from taking part in the event. 
        /// It also supports deleting announcements or events that the logged-in user has created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            if (Request.QueryString["id_a"] !=null) id_a = int.Parse(Request.QueryString["id_a"]);
            if (Request.QueryString["id_e"] != null) id_e = int.Parse(Request.QueryString["id_e"]);
            if (Request.QueryString["id_u"] != null) id_u = int.Parse(Request.QueryString["id_u"]);
            opcja = 0;
            if (Request.QueryString["r"] != null)
            {
                if (Request.QueryString["r"].Equals("z")) opcja = 1;
                if (Request.QueryString["r"].Equals("u")) opcja = 2;
            } 
            
            if (opcja == 1)
            {
                if (Request.QueryString["id_a"] != null)db.DeclineFromAnnouncement(id_a, db.getId((string)Session["id"]));
                if (Request.QueryString["id_e"] != null)db.DeclineFromEvent(id_e, db.getId((string)Session["id"]));
                Response.Redirect("MyActivities.aspx");
            }
           
            if (opcja == 2)
            {
                if (Request.QueryString["id_e"] != null)
                {
                    if (Request.QueryString["id_u"] != null) Send_Email(db.getEmail(id_u), db.getNickname_id(id_u), true, db.getTitleEvent(id_e));
                    db.Delete_Users_Joined_Event(id_e);
                    db.DeleteInvitation(id_e);
                    db.DeleteEvent(id_e);
                }
                if (Request.QueryString["id_a"] != null)
                {
                    if (Request.QueryString["id_u"] != null) Send_Email(db.getEmail(id_u), db.getNickname_id(id_u), false, db.getTitleAnnouncement(id_a));
                    List<int?> list_events_id = db.getIdEvents(id_a);
                    for (int i = 0; i < list_events_id.Count; i++)
                    {
                        db.Delete_Users_Joined_Event((int)list_events_id.ElementAt(i));
                        db.DeleteInvitation((int)list_events_id.ElementAt(i));
                    }
                    db.DeleteEvent_id_a(id_a);
                    db.Delete_Users_Assigned_Announcement(id_a);
                    db.DeleteAnnouncement(id_a);
                }
                if (Request.QueryString["id_u"] == null) Response.Redirect("MyActivities.aspx");
            }
            db.Disconnect();
        }


        protected void Send_Email(string email, string nickname, Boolean wydarzenie, string title)
        {
            string subject = "";
            string body = "";
            title = "aa";
            if (wydarzenie)
            {
                subject = "Usunięcie Twojego wydarzneia";
                body = "Witaj " + nickname + "! Usunięto Twoje wydarzenie: "+ title+" z powodu naruszenia regulaminu.";
            }
            else
            {
                subject = "Usunięcie Twojego ogłoszenia";
                body = "Witaj " + nickname + "! Usunięto Twoje ogłoszenie: " + title + "  z powodu naruszenia regulaminu.";
            } 
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress((string)Session["id"]);
            msg.To.Add(email);
            msg.Subject = subject;
            msg.Body = body;
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