<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LibraryApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Hello :)</h3>
    <address>
        LP 52 Joe Street<br />
        Dinsley Village<br />
        Tacarigua<br />
        <abbr title="Phone">P:</abbr>
        868.320.4240
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:info@chris24sahadeo.com">info@chris24sahadeo.com</a><br />
        <%--<strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>--%>
    </address>
</asp:Content>
