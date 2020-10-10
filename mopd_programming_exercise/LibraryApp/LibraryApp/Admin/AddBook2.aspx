<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook2.aspx.cs" Inherits="LibraryApp.Admin.AddBook2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>

    <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>

    <table class="table">
        <tr id="id_row" runat="server">
            <td><asp:Label ID="LabelAddISBN" runat="server">ISBN: </asp:Label></td>
            <td>
                <asp:TextBox ID="AddISBN" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* ISBN required." ControlToValidate="AddISBN" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelBookName" runat="server">Name: </asp:Label></td>
            <td>
                <asp:TextBox ID="AddBookName" runat="server"></asp:TextBox>
                <%--validation--%>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddEdition" runat="server">Edition: </asp:Label></td>
            <td>
                <asp:TextBox ID="AddEdition" runat="server"></asp:TextBox>
                <%--validation--%>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddYear" runat="server">Year: </asp:Label></td>
            <td>
                <asp:TextBox ID="AddYear" runat="server"></asp:TextBox>
                <%--validation--%>
            </td>
        </tr>
        <tr>
            <td><a title="New Publisher" href="~/Admin/AddPublisher">  <asp:Label ID="LabelAddPublisher" runat="server">Publisher: </asp:Label></a></td>
            <td>
                <asp:DropDownList ID="DropDownAddPublisher" runat="server" ItemType="LibraryApp.Models.publisher" SelectMethod="GetPublishers" DataTextField="publisher_name" DataValueField="publisher_name" >
                </asp:DropDownList>
                <%--validation--%>
            </td>
        </tr>
        <tr>
            <td><a title="New Genre" href="#" > <asp:Label ID="LabelGenre" runat="server">Genre: </asp:Label></a></td>
            <td>
                <asp:DropDownList ID="DropDownAddGenre" runat="server" ItemType="LibraryApp.Models.genre" SelectMethod="GetGenres" DataTextField="genre_name" DataValueField="genre_name" >
                </asp:DropDownList>
                <%--validation--%>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddImageFile" runat="server">Image File: </asp:Label></td>
            <td>
                <asp:FileUpload ID="BookImage" runat="server" />
                <%--validation--%>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddRating" runat="server">Rating: </asp:Label></td>
            <td>
                <asp:TextBox ID="AddRating" runat="server"></asp:TextBox>
                <%--validation--%>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddSummary" runat="server">Summary: </asp:Label></td>
            <td>
                <asp:TextBox ID="AddSummary" runat="server" TextMode="MultiLine" Columns="40" Rows="5"></asp:TextBox>
                <%--validation--%>
            </td>
        </tr>

        <%--authors--%>
        <tr>
            <td><a title="New Author" href="~/Admin/AddAuthor"> <asp:Label ID="LabelAddAuthors" runat="server">Authors: </asp:Label></a></td>
            <td>
                <asp:CheckBoxList ID="AddAuthors" ItemType="LibraryApp.Models.author" SelectMethod="GetAuthors" SelectionMode="Multiple" DataTextField="full_name" DataValueField="author_id" runat="server"></asp:CheckBoxList>
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="BookButton" runat="server" Text="AddBook" OnClick="AddBookButton_Clicked"  Visible="true"/>
    <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Clicked" CausesValidation="false" />
    
    
</asp:Content>
