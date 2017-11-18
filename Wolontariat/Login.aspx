<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Wolontariat.Login" %>

<!DOCTYPE html>
<link rel="stylesheet" runat="server" media="screen" href="/css/Login.css" />
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
                    <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required="required" autofocus="autofocus" />
                    <input type="password" id="inputPassword" class="form-control" placeholder="Password" required="required" />
                    <div id="remember" class="checkbox">
                        <label>
                            <input type="checkbox" value="remember-me" /> Remember me
                        </label>
                    </div>
                    <button class="btn btn-lg btn-primary btn-block btn-signin" type="submit">Sign in</button>
                </form>
                <a href="#" class="forgot-password">
                    Forgot the password?
                </a>
        </div>
    </div>


</body>
</html>
