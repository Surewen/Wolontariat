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
                <form class="form-signin" runat="server">
                    <span id="reauth-email" class="reauth-email"></span>
                    <input type="text" id="nickname" class="form-control" placeholder="Nazwa użytkownika" required="required" autofocus="autofocus" runat="server"/>
                    <input type="email" id="inputEmail" class="form-control" placeholder="Email" required="required" autofocus="autofocus" runat="server"/>
                    <input type="password" id="inputPassword" class="form-control" placeholder="Hasło" required="required" runat="server"/>
                    <input type="password" id="repeatPassword" class="form-control" placeholder="Powrórz hasło" required="required" runat="server"/>
                    <input type="text" id="name" class="form-control" placeholder="Imię" required="required" runat="server"/>
                    <input type="text" id="surname" class="form-control" placeholder="Nazwisko" required="required" runat="server"/>
                    <input type="text" id="pesel" class="form-control" placeholder="PESEL" required="required" runat="server"/>
                   <input type="text" id="telephone" class="form-control" placeholder="Telefon" required="required" runat="server"/>

                    Data urodzenia:
                    <input type="date" id="birthDate" name="birthDate" runat="server" value=""><br />
                    Płeć:<br />
                    <input type="radio" id="male" name="userSex"  required="required" runat="server"/>Mężczyzna<br />
                    <input type="radio" id="female" name="userSex" required="required" runat="server"/>Kobieta<br /><br />
                    Typ użytkownika:<br />
                    <input type="radio" id="volounteer" name="userType"  required="required" runat="server"/>Wolontariusz<br />
                    <input type="radio" id="needy" name="userType" required="required" runat="server"/>Potrzebujący<br /><br />
                    <asp:Button CssClass="btn btn-rg btn-register" type="submit" OnClick="Register_User" runat="server" text="Zarejestruj"/>
                </form>
        </div>
    </div>

</body>
</html>
