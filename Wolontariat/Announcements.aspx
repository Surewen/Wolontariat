<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Announcements.aspx.cs" Inherits="Wolontariat.Announcements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="/css/DatabaseTables.css" />
        <a id="add_announcement" runat="server" href="AddAnnouncement.aspx">Dodaj ogłoszenie</a> <br/><br/>
        <div style="overflow:auto;">
             <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
        </div>  
</asp:Content>
