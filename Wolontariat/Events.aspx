<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Wolontariat.Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
             <a id="add_event" runat="server" href="AddEvent.aspx" visible="false">Dodaj wydarzenie</a> <br/><br/>
   
             <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
</asp:Content>
