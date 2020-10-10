<%@ Page Title="New Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="LibraryApp.Admin.AddBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1> <%:Title %> </h1>
    <asp:FormView runat="server" ID="addBookForm" ItemType="LibraryApp.Models.book" DataKeyNames="book_id" InsertMethod="addBookForm_InsertItem" DefaultMode="Insert" RenderOuterTable="false" OnItemInserted="addBookForm_ItemInserted">
        <InsertItemTemplate>
            <fieldset>
                <ol>
                    <asp:DynamicEntity runat="server" Mode="Insert"></asp:DynamicEntity>
                </ol>
                <asp:Button runat="server" Text="Insert" CommandName="Insert" />
                <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" />
            </fieldset>
        </InsertItemTemplate>

    </asp:FormView>

</asp:Content>
