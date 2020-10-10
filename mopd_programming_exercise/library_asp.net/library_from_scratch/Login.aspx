<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="library_from_scratch.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="lbUsername" Text="Username" runat="server"/>
            <asp:TextBox ID="tbUsername" runat="server" />
        </div>
        <div>
            <asp:Label ID="lbPassword" Text="Password" runat="server"/>
            <asp:TextBox ID="tbPassword" runat="server" />
        </div>
        <div>
            <asp:CheckBox ID="cbRememberMe" Text="Remember Me" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnLogin" Text="Login" OnClick="btnLogin_Click" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>

