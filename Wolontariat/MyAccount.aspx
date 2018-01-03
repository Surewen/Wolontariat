﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="Wolontariat.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" runat="server" media="screen" href="/css/DatabaseTables.css" />
     <div class="table1">
        <asp:PlaceHolder ID = "PlaceHolder1" runat="server" /><br />
     </div>
     <asp:Button ID="form_data" onClick="Form_Data" runat="server" Text="Zmień dane" />
    <asp:Button ID="edit_password" onClick="Edit_Password" runat="server" Text="Zmień hasło" />
    <asp:Button ID="delete_account" OnClick="Delete_Account" runat="server" Text="Usuń konto" />

     <div class="container" ID="password_form" visible="false" runat="server" align="center">
        <div class="card card-container">
           <p id="profile-name" class="profile-name-card"></p>

              Wprowadź bieżące hasło:
              <br /><input type="password" id="password" class="form-control" runat="server"/><br />
              Wprowadź nowe hasło:
              <br /><input type="password" id="new_password" class="form-control" runat="server"/> <br />
              
              <asp:Button CssClass="btn btn-rg btn-register" id="change" type="submit" OnClick="Edit_Password" runat="server" text="Zmień hasło"/>
        </div>
    </div>

    <div class="container" ID="data_form" visible="false" runat="server" align="center" >
        <div class="card card-container">
           <p id="profile-name" class="profile-name-card"></p>
                    Nickname: <input type="text" id="nickname" class="form-control"  runat="server"/></br>
                    E-mail: <input type="email" id="inputEmail" class="form-control" runat="server"/></br>
                    Imię: <input type="text" id="name" class="form-control" runat="server"/></br>
                    Nazwisko: <input type="text" id="surname" class="form-control" runat="server"/></br>
                    Pesel: <input type="text" id="pesel" class="form-control" runat="server"/></br>
                    Telefon: <input type="text" id="telephone" class="form-control" runat="server"/></br>
                    Jeżeli nie chcesz zmieniać poniższych pól, pozostaw je niewypełnione <br />
                    Data urodzenia: <input type="date" id="birthDate" name="birthDate" runat="server" value=""><br />
                    Płeć:<br />
                    <input type="radio" id="male" name="userSex" runat="server"/>Mężczyzna<br />
                    <input type="radio" id="female" name="userSex" runat="server"/>Kobieta<br />
                    Typ użytkownika:<br />
                    <input type="radio" id="volounteer" name="userType" runat="server"/>Wolontariusz<br />
                    <input type="radio" id="needy" name="userType" runat="server"/>Potrzebujący<br />
              
              <asp:Button CssClass="btn btn-rg btn-register" id="Button1" type="submit" OnClick="Edit_Data" runat="server" text="Potwierdź zmiany"/>
        </div>
    </div>


</asp:Content>
