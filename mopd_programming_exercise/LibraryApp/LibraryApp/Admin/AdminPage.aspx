<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="LibraryApp.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<h1>hello admin :)</h1>--%>
    <h1>Administration</h1>

    <div class="dropdown-content">
      
    </div>

    <div class="dropdown">
      <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
         Menu
      </button>
      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
        <a class="dropdown-item" href="/Admin/Authors">Authors</a>
        <a class="dropdown-item" href="/Admin/Books">Books</a>
        <a class="dropdown-item" href="/Admin/Publishers">Publishers</a>
        <a class="dropdown-item" href="/Admin/Genres">Genres</a>
        <a class="dropdown-item" href="/Admin/Members">Members</a>
      </div>
    </div>

</asp:Content>
