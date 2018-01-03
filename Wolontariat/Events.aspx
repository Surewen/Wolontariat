<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Wolontariat.Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
             <a id="add_event" runat="server" href="AddEvent.aspx" visible="false">Dodaj wydarzenie</a> <br/><br/>
       <link rel="stylesheet" runat="server" media="screen" href="/css/DatabaseTables.css" />
         <div class="table1">
             <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
             </div>
</asp:Content>
