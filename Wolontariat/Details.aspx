﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Wolontariat.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:PlaceHolder ID = "PlaceHolder2" runat="server" /><br />
    
    <asp:TextBox ID="from" value="Od" runat="server" Visible="false"></asp:TextBox><br />
    
    <asp:TextBox ID="to" value="Do" runat="server" Visible="false"></asp:TextBox><br />
    
    <asp:Button ID="zglos" onClick="zglos_sie" runat="server" visible="false" Text="Zgłoś się" />

</asp:Content>