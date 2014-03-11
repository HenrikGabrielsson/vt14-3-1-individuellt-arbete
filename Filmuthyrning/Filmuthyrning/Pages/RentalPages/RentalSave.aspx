<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalSave.aspx.cs" Inherits="Filmuthyrning.Pages.RentalPages.RentalUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Uppdatera uthyrning</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


        <%-- Dropdownlista för filmer --%>
        <asp:DropDownList ID="MovieDropDownList" runat="server" ItemType="Filmuthyrning.Model.BLL.Movie" SelectMethod="MovieDropDownList_GetData" DataTextField="Title" DataValueField="MovieID"></asp:DropDownList>
        <asp:DropDownList ID="CustomerDropDownList" runat="server" ItemType="Filmuthyrning.Model.BLL.Customer" SelectMethod="CustomerDropDownList_GetData" DataTextField="LastName" DataValueField="CustomerID"></asp:DropDownList>

        <%--Hyrdatum--%>
        <label for="DateBox">HyrDatum:</label>
        <asp:TextBox ID="DateBox" type="date" runat="server"></asp:TextBox>              
        <asp:Label ID="test" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" />
    </div>
    </form>
</body>
</html>
