<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Invite.aspx.cs" Inherits="Wolontariat.Invite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
        <div class="card card-container">
          Formularz wysyłania zaproszeni
           <p id="profile-name" class="profile-name-card"></p>
              
              Temat:
              <br />
                    <input type="text" id="title" class="form-control" required="required" autofocus="autofocus" runat="server"/>
              <br />
              Zawartość:
              <br />
                    <input type="text" id="content" class="form-control" required="required" autofocus="autofocus" runat="server"/>
              <br />
            
           
              <asp:Button CssClass="btn btn-rg btn-register" id="send" type="submit" OnClick="send_invitation" runat="server" text="Wyślij zaproszenie"/>
        </div>
    </div>


</asp:Content>
