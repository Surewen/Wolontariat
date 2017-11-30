<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="Wolontariat.AddEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
        <div class="card card-container">

           Dodawanie wydarzenia
     <p id="profile-name" class="profile-name-card"></p>
        Tytuł:
            <br />
     <input type="text" id="title" class="form-control" required="required" autofocus="autofocus" runat="server"/>
            <br />
        Treść:
            <br />
         <input type="text" id="content" class="form-control" required="required" autofocus="autofocus" runat="server"/>
            <br />
        Data wydarzenia:
            <br />
        <input type="text" id="due_data"  class="form-control" required="required" autofocus="autofocus" runat="server" placeholder="dd.mm.rrrr"/>
            <br />
            Data dodania:<br />
        <input type="text" id="add_date"  class="form-control" required="required" autofocus="autofocus" runat="server" placeholder="dd.mm.rrrr"/>

            <br /> 
            Autor:
            <br />
           <input type="text" id="autor"  class="form-control" required="required" autofocus="autofocus" runat="server"/>
            <br /> 

        <asp:Button CssClass="btn btn-rg btn-register" type="submit" OnClick="Add" runat="server" text="Dodaj"/>
           <br />
        </div>
    </div>
</asp:Content>
