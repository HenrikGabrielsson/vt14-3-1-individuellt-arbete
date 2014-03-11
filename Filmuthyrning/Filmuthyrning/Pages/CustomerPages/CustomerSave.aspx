<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerSave.aspx.cs" Inherits="Filmuthyrning.Pages.CustomerPages.CustomerSave" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server">
    <div>
        <label for="fNameBox">Förnamn:</label><asp:TextBox ID="fNameBox" runat="server"></asp:TextBox>
        <label for="lNameBox">Efternamn:</label><asp:TextBox ID="lNameBox" runat="server"></asp:TextBox>
        <label for="phoneBox">Telefonnummer:</label><asp:TextBox ID="phoneBox" runat="server"></asp:TextBox>
        <label for="emailBox">Emailadress:</label><asp:TextBox ID="emailBox" runat="server"></asp:TextBox>   

        <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" />
    </div>
    </form>
</body>
</html>
