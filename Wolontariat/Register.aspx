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
                <form class="form-signin">
                    <span id="reauth-email" class="reauth-email"></span>
                    <input type="text" id="nickname" class="form-control" placeholder="Nazwa użytkownika" required="required" autofocus="autofocus" />
                    <input type="email" id="inputEmail" class="form-control" placeholder="Email" required="required" autofocus="autofocus" />
                    <input type="password" id="inputPassword" class="form-control" placeholder="Hasło" required="required" />
                    <input type="password" id="repeatPassword" class="form-control" placeholder="Powrórz hasło" required="required" />
                    <input type="text" id="name" class="form-control" placeholder="Imię" required="required" />
                    <input type="text" id="surname" class="form-control" placeholder="Nazwisko" required="required" />
                    Data urodzenia:
                    <input type="date" name="birthDate"><br />
                    Typ użytkownika:<br />
                    <label><input type="radio" id="volounteer" name="userType"  required="required" />Wolontariusz</label><br />
                    <input type="radio" id="needy" name="userType" required="required" />Potrzebujący<br /><br />
                    <button class="btn btn-rg btn-register" type="submit">Register</button>
                </form>
        </div>
    </div>

</body>
</html>
