<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Newsletter.aspx.cs" Inherits="Wolontariat.Newsletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Grupa odbiorców:<br />
                    <input type="radio" id="volounteers" name="receiver"  required="required" runat="server"/>Wolontariusze<br />
                    <input type="radio" id="needies" name="receiver" required="required" runat="server"/>Potrzebujący<br />
                    <input type="radio" id="all" name="receiver" required="required" runat="server"/>Wszyscy<br /><br />
    Temat:<br />
                    <input type="text" id="subject" class="form-control" required="required" autofocus="autofocus" runat="server"/><br />
    Zawartość:<br />
              <input type="text" id="content" class="form-control" required="required" autofocus="autofocus" runat="server"/><br /><br />
               <asp:Button CssClass="btn btn-rg btn-register" type="submit" OnClick="Prepare_Email" runat="server" text="Wyślij"/>


</asp:Content>
