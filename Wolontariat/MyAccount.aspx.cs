using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class MyAccount : System.Web.UI.Page
    {
        SQLDatabase db;
        StringBuilder html;
        List<Users> list_users;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            html = new StringBuilder();
            db.Connect();
            list_users = db.ListUsers();

            html.Append("<table border = '1' align='center'>");
            
            for (int i = 0; i < list_users.Count; i++)
            {
                if (list_users.ElementAt(i).id.Equals(db.getId((string)Session["id"])))
                {
                    html.Append("<tr><td>Id</td> <td>" + list_users.ElementAt(i).id + "</td></tr>");
                    html.Append("<tr><td>Imię</td> <td>" + list_users.ElementAt(i).name + "</td></tr>");
                    html.Append("<tr><td>Nazwisko</td> <td>" + list_users.ElementAt(i).surname + "</td></tr>");
                    html.Append("<tr><td>Nickname</td> <td>" + list_users.ElementAt(i).nickname + "</td></tr>");
                    html.Append("<tr><td>E-mail</td> <td>" + list_users.ElementAt(i).email + "</td></tr>");
                    html.Append("<tr><td>Płeć</td> <td>" + list_users.ElementAt(i).sex + "</td></tr>");
                    html.Append("<tr><td>Telefon</td> <td>" + list_users.ElementAt(i).telephone + "</td></tr>");
                    html.Append("<tr><td>Data urodzenia</td> <td>" + list_users.ElementAt(i).birth_date.ToString("yyyy-MM-dd") + "</td></tr>");
                    html.Append("<tr><td>Typ użytkownika</td> <td>" + list_users.ElementAt(i).type + "</td></tr>");
                    html.Append("<tr><td>Pesel</td> <td>" + list_users.ElementAt(i).pesel + "</td></tr>");
                }
            }

            html.Append("</table>");
            html.Append("<br/><br/>");
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            db.Disconnect();
        }
        protected void Form_Data(object sender, EventArgs e)
        {
            data_form.Visible = true;
            password_form.Visible = false;
            db = new SQLDatabase();
            db.Connect();
            list_users = db.ListUsers();
            
            nickname.Value = list_users.ElementAt(db.getId((string)Session["id"])-1).nickname;
            inputEmail.Value = list_users.ElementAt(db.getId((string)Session["id"]) - 1).email;
            name.Value= list_users.ElementAt(db.getId((string)Session["id"]) - 1).name;
            surname.Value= list_users.ElementAt(db.getId((string)Session["id"]) - 1).surname;
            telephone.Value= list_users.ElementAt(db.getId((string)Session["id"]) - 1).telephone;
            pesel.Value= list_users.ElementAt(db.getId((string)Session["id"]) - 1).pesel;
            db.Disconnect();
        }

        protected void Edit_Data(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            db.Connect();
            list_users = db.ListUsers();
            string sex = "";
            string type = "";
            if (!male.Checked && !female.Checked) sex = list_users.ElementAt(db.getId((string)Session["id"]) - 1).sex;
            else
            {
                if (male.Checked) sex = "male";
                else sex = "female";
            }
            if (!volounteer.Checked && !needy.Checked) type = list_users.ElementAt(db.getId((string)Session["id"]) - 1).type;
            else
            {
                if (volounteer.Checked) type = "volounteer";
                else type = "needy";
            }
            if (birthDate.Value.Equals("1900-01-01")) birthDate.Value= list_users.ElementAt(db.getId((string)Session["id"]) - 1).birth_date.ToString("yyyy-MM-dd");
            int id = db.getId((string)Session["id"]);
            db.EditAccount(id, nickname.Value, pesel.Value, inputEmail.Value, telephone.Value, name.Value, surname.Value, birthDate.Value, sex, type);
            db.Disconnect();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        protected void Edit_Password(object sender, EventArgs e)
        {
            password_form.Visible = true;
            data_form.Visible = false;
            if (password != null && new_password != null)
            {
                db = new SQLDatabase();
                
            }
        }

        protected void Delete_Account(object sender, EventArgs e)
        {

        }
    }
    
}