<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="LatihanQuiz.View.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Home Page</h1>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Name" DataField="Name" />
                <asp:BoundField HeaderText="Description" DataField="Description" />
                <asp:BoundField HeaderText="Price" DataField="Price" />
                <asp:BoundField HeaderText="FoodTypeID" DataField="FoodTypeID" />

                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <br />

        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label><br />
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label><br />
        <asp:TextBox ID="Description" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label><br />
        <asp:TextBox ID="Price" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Food Type ID"></asp:Label><br />
        <asp:TextBox ID="FoodTypeID" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add Food" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="ErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Logout" OnClick="Button2_Click" />
    </form>
</body>
</html>
