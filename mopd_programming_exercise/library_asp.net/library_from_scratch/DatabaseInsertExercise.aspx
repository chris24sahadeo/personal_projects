<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatabaseInsertExercise.aspx.cs" Inherits="library_from_scratch.DatabaseInsertExercise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="ltConnection"  runat="server" Visible="false" />
    <h2>Database Insert Exercise</h2>
    <h3>Student Table</h3>
    <div>
        <div>
            <label>First Name</label>
            <asp:TextBox ID="tbFirstName" runat="server" />
        </div>
        <div>
            <label>Last Name</label>
            <asp:TextBox ID="tbLastName" runat="server" />
        </div>
        <div>
            <label>Email Address</label>
            <asp:TextBox ID="tbEmailAddress" runat="server" />
        </div>
        <div>
            <label>Date Of Birth</label>
            <asp:TextBox ID="tbDateOfBirth" runat="server" />
            <%-- Date picker?? --%>
            <%--<asp:Calendar ID="calDob" runat="server" />--%>
        </div>
        <div>
            <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
        </div>
        <div>
            <asp:Literal ID="ltResponse" runat="server" />
        </div>
    </div>
    <div>
        <asp:Literal ID="ltMessage" runat="server" />
    </div>
</asp:Content>
