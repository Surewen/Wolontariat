<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AddAnnouncement.aspx.cs" Inherits="Wolontariat.AddAnnouncement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card card-container">
           Dodawanie ogłoszenia
           <p id="profile-name" class="profile-name-card"></p>
              Typ pomocy:
              <br />
                    <input type="radio" id="one" name="helpType"  required="required" runat="server"/>Jednorazowy<br />
                    <input type="radio" id="many" name="helpType" required="required" runat="server"/>Wielorazowy<br /><br />
              <br />
              Temat:
              <br />
                    <input type="text" id="subject" class="form-control" required="required" autofocus="autofocus" runat="server"/>
              <br />
              Zawartość:
              <br />
                    <input type="text" id="content" class="form-control" required="required" autofocus="autofocus" runat="server"/>
              <br />
              Do kiedy oferujesz/potrzebujesz pomocy: (nie wypełniamy jeżeli wybrałeś typ pomocy: 'Jednorazowy')
              <br />
                    <input type="date" id="end_date" name="endDate" runat="server"><br />
              <br />
           
              <asp:Button CssClass="btn btn-rg btn-register" type="submit" OnClick="Add_Announcement" runat="server" text="Dodaj"/>
        </div>
    </div>

</asp:Content>
