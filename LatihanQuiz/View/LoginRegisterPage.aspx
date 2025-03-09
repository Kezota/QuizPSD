<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRegisterPage.aspx.cs" Inherits="LatihanQuiz.View.AddPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login Register Page</h1>

        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
        <asp:Button ID="Register" runat="server" Text="Register" OnClick="Register_Click" />
    </form>
</body>
</html>

