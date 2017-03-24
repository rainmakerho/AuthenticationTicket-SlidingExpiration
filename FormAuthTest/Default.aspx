<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormAuthTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="lsIdentityInfos" runat="server"></asp:ListBox>
            <hr/>
             <asp:Button runat="server" ID="btnAddIdentity" Text="Add Identity Info" OnClick="btnAddIdentity_OnClick"/>
        </div>
    </form>
</body>
</html>
