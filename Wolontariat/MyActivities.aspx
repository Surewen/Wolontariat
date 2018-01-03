<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="MyActivities.aspx.cs" Inherits="Wolontariat.MyActivities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="/css/DatabaseTables.css" />
    <div class="table1">
    <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
    <br />
    <asp:PlaceHolder ID = "PlaceHolder2" runat="server" />
    <br />
    <asp:PlaceHolder ID = "PlaceHolder3" runat="server" />
    <br />
    <asp:PlaceHolder ID = "PlaceHolder4" runat="server" />
    <br />
    </div>
</asp:Content>
