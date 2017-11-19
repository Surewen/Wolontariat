using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CHECK COOKIES CONSENT
            if (Request.Cookies["CookieConsent"] != null)
            {
                cookieConsent.Visible = false;
            }
        }








        protected void Accept_Cookies(object sender, EventArgs e)
        {
            HttpCookie cookie_consent = new HttpCookie("CookieConsent");
            cookie_consent.Value = "yes";
            cookie_consent.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Add(cookie_consent);
            cookieConsent.Visible = false;
        }
    }
}