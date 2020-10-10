<%@ Page Title="New Author" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAuthors.aspx.cs" Inherits="LibraryApp.Admin.AddAuthors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>

    <asp:FormView runat="server" ID="addAuthorForm"
        ItemType="LibraryApp.Models.author" DataKeyNames="author_id"
        InsertMethod="addAuthorForm_InsertItem" DefaultMode="Insert"
        RenderOuterTable="false" OnItemInserted="addAuthorForm_ItemInserted">
        <InsertItemTemplate>
            <fieldset>
                <ol>
                    <asp:DynamicEntity runat="server" Mode="Insert" />
                </ol>
                <asp:Button runat="server" Text="Insert" CommandName="Insert" />
                <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" />
            </fieldset>
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>
