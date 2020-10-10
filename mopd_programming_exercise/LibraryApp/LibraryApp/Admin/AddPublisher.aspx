<%@ Page Title="New Publisher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPublisher.aspx.cs" Inherits="LibraryApp.Admin.AddPublisher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>

    <asp:FormView runat="server" ID="addPublisherForm" ItemType="LibraryApp.Models.publisher" DataKeyNames="publisher_name" InsertMethod="addPublisherForm_InsertItem" DefaultMode="Insert" RenderOuterTable="false" OnItemInserted="addPublisherForm_ItemInserted">
        <InsertItemTemplate>
            <fieldset>
                <ol>
                    <asp:DynamicEntity runat="server" Mode="Insert"></asp:DynamicEntity>
                </ol>
                <asp:Button runat="server" Text="Insert" CommandName="Insert" />
                <asp:Button runat="server" Text="Cancel" CausesValidation="true" OnClick="cancelButton_Click" />
            </fieldset>
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>
