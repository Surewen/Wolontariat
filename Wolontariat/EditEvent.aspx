<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="Wolontariat.EditEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card card-container">

           Edytowanie wydarzenia
     <p id="profile-name" class="profile-name-card"></p>
        Data wydarzenia:
            <br />
      <input type="date" id="due_date" name="duedate" runat="server" value=""><br />
            <br />
           Tytuł:
            <br />
     <input type="text" id="title" class="form-control" required="required" autofocus="autofocus" runat="server"/>
            <br />
        Zawartość:
            <br />
         <input type="text" id="content" class="form-control" required="required" autofocus="autofocus" runat="server"/>
            <br />

        <asp:Button CssClass="btn btn-rg btn-register" type="submit" id="edytuj" OnClick="Edit_Event" runat="server" text="Edytuj"/>
           <br />
        </div>
    </div>

</asp:Content>
