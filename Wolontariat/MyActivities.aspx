<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="MyActivities.aspx.cs" Inherits="Wolontariat.MyActivities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="/css/DatabaseTables.css" />
    <div><div class=title>Ogłoszenia, do których się zgłosiłem</div></div> <br />
    <div class="table1">
        <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
    </div>
    <br />
    <div><div class=title>Wydarzenia, w których biorę udział</div></div> <br />
    <div class="table1">
        <asp:PlaceHolder ID = "PlaceHolder2" runat="server" />
    </div>
    <br />
    <div><div class=title>Wydarzenia, które dodałem</div></div> <br />
    <div class="table1">
        <asp:PlaceHolder ID = "PlaceHolder3" runat="server" />
    </div>
    <br />
    <div><div class=title>Ogłoszenia, które dodałem</div></div> <br />
    <div class="table1">
        <asp:PlaceHolder ID = "PlaceHolder4" runat="server" />
    </div>
    <br />
    
</asp:Content>
