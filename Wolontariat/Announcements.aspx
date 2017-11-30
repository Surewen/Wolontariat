<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Announcements.aspx.cs" Inherits="Wolontariat.AddAnnouncement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <a class="aMenu" href="AddAnnouncement.aspx">Dodaj ogłoszenie</a>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pww-databaseConnectionString %>" SelectCommand="SELECT * FROM [announcements]"></asp:SqlDataSource>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <AlternatingItemTemplate>
            <span style="background-color: #FFFFFF;color: #284775;">id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            post_date:
            <asp:Label ID="post_dateLabel" runat="server" Text='<%# Eval("post_date") %>' />
            <br />
            created_by:
            <asp:Label ID="created_byLabel" runat="server" Text='<%# Eval("created_by") %>' />
            <br />
            current_status:
            <asp:Label ID="current_statusLabel" runat="server" Text='<%# Eval("current_status") %>' />
            <br />
            content:
            <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
            <br />
            <br />
            </span>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <span style="background-color: #999999;">id:
            <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
            <br />
            post_date:
            <asp:TextBox ID="post_dateTextBox" runat="server" Text='<%# Bind("post_date") %>' />
            <br />
            created_by:
            <asp:TextBox ID="created_byTextBox" runat="server" Text='<%# Bind("created_by") %>' />
            <br />
            current_status:
            <asp:TextBox ID="current_statusTextBox" runat="server" Text='<%# Bind("current_status") %>' />
            <br />
            content:
            <asp:TextBox ID="contentTextBox" runat="server" Text='<%# Bind("content") %>' />
            <br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Aktualizuj" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Anuluj" />
            <br />
            <br />
            </span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>Nie zostały zwrócone żadne dane.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">post_date:
            <asp:TextBox ID="post_dateTextBox" runat="server" Text='<%# Bind("post_date") %>' />
            <br />
            created_by:
            <asp:TextBox ID="created_byTextBox" runat="server" Text='<%# Bind("created_by") %>' />
            <br />
            current_status:
            <asp:TextBox ID="current_statusTextBox" runat="server" Text='<%# Bind("current_status") %>' />
            <br />
            content:
            <asp:TextBox ID="contentTextBox" runat="server" Text='<%# Bind("content") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Wstaw" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Wyczyść" />
            <br />
            <br />
            </span>
        </InsertItemTemplate>
        <ItemTemplate>
            <span style="background-color: #E0FFFF;color: #333333;">id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            post_date:
            <asp:Label ID="post_dateLabel" runat="server" Text='<%# Eval("post_date") %>' />
            <br />
            created_by:
            <asp:Label ID="created_byLabel" runat="server" Text='<%# Eval("created_by") %>' />
            <br />
            current_status:
            <asp:Label ID="current_statusLabel" runat="server" Text='<%# Eval("current_status") %>' />
            <br />
            content:
            <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
            <br />
            <br />
            </span>
        </ItemTemplate>
        <LayoutTemplate>
            <div style="font-family: Verdana, Arial, Helvetica, sans-serif;" id="itemPlaceholderContainer" runat="server">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF;">
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <span style="background-color: #E2DED6;font-weight: bold;color: #333333;">id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            post_date:
            <asp:Label ID="post_dateLabel" runat="server" Text='<%# Eval("post_date") %>' />
            <br />
            created_by:
            <asp:Label ID="created_byLabel" runat="server" Text='<%# Eval("created_by") %>' />
            <br />
            current_status:
            <asp:Label ID="current_statusLabel" runat="server" Text='<%# Eval("current_status") %>' />
            <br />
            content:
            <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
            <br />
            <br />
            </span>
        </SelectedItemTemplate>
    </asp:ListView>





</asp:Content>
