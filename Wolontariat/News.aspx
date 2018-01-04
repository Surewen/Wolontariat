<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Wolontariat.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Ranking TOP 5 najpopularniejszych wydarzeń <br />
    <link rel="stylesheet" runat="server" media="screen" href="/css/DatabaseTables.css" />
    <div class="table1">
     <asp:PlaceHolder ID = "PlaceHolder" runat="server" /><br />
        </div>
</asp:Content>
