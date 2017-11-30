<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Wolontariat.Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    EVENTS

   <a class="aMenu" href="AddEvent.aspx">Dodaj wydarzenie</a>
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="id" DataSourceID="SqlDataSource2">
        <Fields>
            <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="id"></asp:BoundField>
            <asp:BoundField DataField="created_by" HeaderText="Stworzone przez" SortExpression="created_by"></asp:BoundField>
            <asp:BoundField DataField="post_date" HeaderText="Data dodania" SortExpression="post_date"></asp:BoundField>
            <asp:BoundField DataField="due_date" HeaderText="Data ważności" SortExpression="due_date"></asp:BoundField>
            <asp:BoundField DataField="title" HeaderText="Tytuł" SortExpression="title"></asp:BoundField>
            <asp:BoundField DataField="content" HeaderText="Zawartość" SortExpression="content"></asp:BoundField>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
        </Fields>
    </asp:DetailsView>


    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:pww-databaseConnectionString %>' DeleteCommand="DELETE FROM [events] WHERE [id] = @id" InsertCommand="INSERT INTO [events] ([created_by], [post_date], [due_date], [title], [content]) VALUES (@created_by, @post_date, @due_date, @title, @content)" SelectCommand="SELECT * FROM [events]" UpdateCommand="UPDATE [events] SET [created_by] = @created_by, [post_date] = @post_date, [due_date] = @due_date, [title] = @title, [content] = @content WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="created_by" Type="String"></asp:Parameter>
            <asp:Parameter Name="post_date" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="due_date" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="title" Type="String"></asp:Parameter>
            <asp:Parameter Name="content" Type="String"></asp:Parameter>
        </InsertParameters>
        
        <UpdateParameters>
            <asp:Parameter Name="created_by" Type="String"></asp:Parameter>
            <asp:Parameter Name="post_date" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="due_date" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="title" Type="String"></asp:Parameter>
            <asp:Parameter Name="content" Type="String"></asp:Parameter>
            <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
