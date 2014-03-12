<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalSave.aspx.cs" Inherits="Filmuthyrning.Pages.RentalPages.RentalUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Uppdatera uthyrning</title>
</head>
<body>


    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <%-- Dropdownlista för film och kund --%>
        <asp:DropDownList ID="MovieDropDownList" runat="server" ItemType="Filmuthyrning.Model.BLL.Movie" SelectMethod="MovieDropDownList_GetData" DataTextField="Title" DataValueField="MovieID"></asp:DropDownList>
        <%-- Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du måste välja en film!" Text="*" Display="Dynamic" ControlToValidate="MovieDropDownList"></asp:RequiredFieldValidator>
        <asp:DropDownList ID="CustomerDropDownList" runat="server" ItemType="Filmuthyrning.Model.BLL.Customer" SelectMethod="CustomerDropDownList_GetData" DataTextField="LastName" DataValueField="CustomerID"></asp:DropDownList>
        <%-- Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du måste välja en film!" Text="*" Display="Dynamic" ControlToValidate="CustomerDropDownList"></asp:RequiredFieldValidator>
        

        <%--Hyrdatum--%>
        <label for="DateBox">HyrDatum:</label>
        <asp:TextBox ID="DateBox" type="date" runat="server"></asp:TextBox>
        <%-- Validering--%>      
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Datumet hade inte rätt format" Display="Dynamic" Text="*" ControlToValidate="DateBox" ValidationExpression="^[0-9]{4}-[0-9]{2}-[0-9]{2}$"></asp:RegularExpressionValidator>                
                    
        <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" />
    </div>
    </form>
</body>
</html>
