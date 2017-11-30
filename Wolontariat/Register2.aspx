<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Wolontariat.Register" %>

<!DOCTYPE html>
<link rel="stylesheet" runat="server" media="screen" href="/css/Register.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <div class="container">
        <div class="card card-container">
            <img id="profile-img" class="profile-img-card" src="//ssl.gstatic.com/accounts/ui/avatar_2x.png" />
            <p id="profile-name" class="profile-name-card"></p>

                <form id="form1" runat="server">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    Login:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="nickname" type="text" runat="server" required="required"></asp:TextBox>
                    <br />
                    Hasło:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:TextBox ID="inputPassword" type="password" runat="server" required="required"></asp:TextBox>
                    <br />
                    Powtórz hasło:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="repeatPassword" runat="server"></asp:TextBox>
                    <br />
                   Pesel:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="pesel" runat="server" required="required"></asp:TextBox>
                    <br />
                    E-mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:TextBox ID="inputEmail" runat="server" required="required"></asp:TextBox>
                    <br />
                    Telephone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="telephone" runat="server" required="required"></asp:TextBox>
                    <br />
                    Imię:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="name" runat="server" required="required"></asp:TextBox>
                    <br />
                    Nazwisko:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="sunrname" runat="server" required="required"></asp:TextBox>
                    <br />
                    Płeć:
                     <asp:RadioButtonList ID="sex" runat="server">
                        <asp:ListItem>Mężczyzna</asp:ListItem>
                        <asp:ListItem>Kobieta</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    Data urodzenia:
                    <asp:Calendar ID="Calendar1" runat="server" required="required" ></asp:Calendar>
                    <br />
                    Typ użytkownika:<br />
                    <br />
                    <asp:RadioButtonList ID="type" runat="server">
                        <asp:ListItem>Wolontariusz</asp:ListItem>
                        <asp:ListItem>Potrzebujący</asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <button class="btn btn-rg btn-register" onClick="RegisterUser2" runat="server">Register</button>
                </form>
        </div>
    </div>

</body>
</html>