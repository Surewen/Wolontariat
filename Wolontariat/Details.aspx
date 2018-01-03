<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Wolontariat.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="/css/DatabaseTables.css" />
    <div class="table1">
        <asp:PlaceHolder ID = "PlaceHolder" runat="server" /><br />
    </div>
    <asp:TextBox ID="from" value="Od" runat="server" Visible="false"></asp:TextBox><br />
    
    <asp:TextBox ID="to" value="Do" runat="server" Visible="false"></asp:TextBox><br />
    
    <asp:Button ID="zglos" onClick="Zglos_Sie" runat="server" visible="false" Text="Zgłoś się" />

    <asp:Button ID="create" onClick="Create_Event" runat="server" visible="false" Text="Utwórz wydarzenie" />
    <asp:Button ID="join" onClick="Join_To_Event" runat="server" visible="false" Text="Dołącz do wydarzenia" />
    <asp:Button ID="select" onClick="Select_User" runat="server" visible="false" Text="Wybierz wolontariusza" />
</asp:Content>
