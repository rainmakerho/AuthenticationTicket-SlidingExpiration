<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FormAuthTest.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:TextBox runat="server" ID="txtUserId"></asp:TextBox>
            <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_OnClick"/>
        </div>
    </form>
</body>
</html>
