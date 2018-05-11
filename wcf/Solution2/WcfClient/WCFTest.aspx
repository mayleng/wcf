<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WCFTest.aspx.cs" Inherits="WcfClient.WCFTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            wcf：Windows 通讯开发平台。
         
            <br />
            <br />
        </div>
         <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
         <asp:Button ID="btnSubmit" runat="server" Text="测试WCF服务" OnClick="btnClick" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="wcf-Redis-MySQL" />
    </form>
</body>
</html>
