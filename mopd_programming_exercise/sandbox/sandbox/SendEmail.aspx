<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="sandbox.SendEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="ApproveButton" runat="server" Text="Approve Request" OnClick="ApproveButton_Click" />
    <asp:Button ID="RejectButton" runat="server" Text="Reject Request" OnClick="RejectButton_Click" />
</asp:Content>
