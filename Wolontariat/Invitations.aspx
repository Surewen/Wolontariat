<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Invitations.aspx.cs" Inherits="Wolontariat.Invitations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" runat="server" media="screen" href="/css/DatabaseTables.css" />
        <div><div class=title>Otrzymane zaproszenia</div></div> <br />
        <div class="table1">
            <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
        </div>
</asp:Content>
