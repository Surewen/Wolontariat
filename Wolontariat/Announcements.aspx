﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Announcements.aspx.cs" Inherits="Wolontariat.Announcements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

             <a id="add_announcement" runat="server" href="AddAnnouncement.aspx">Dodaj ogłoszenie</a> <br/><br/>
             <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
      
</asp:Content>
