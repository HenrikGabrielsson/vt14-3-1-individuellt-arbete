<%@ Page Title="Spara uthyrning" MasterPageFile="~/Pages/Shared/RentMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="RentalSave.aspx.cs" Inherits="Filmuthyrning.Pages.RentalPages.RentalUpdate" %>

<asp:Content ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    Lägg till eller ändra uthyrning
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />  

    <%-- Dropdownlista för film --%>
    <label for="MovieDropDownList">Välj film:</label>
    <asp:DropDownList ID="MovieDropDownList" runat="server" ItemType="Filmuthyrning.Model.BLL.Movie" SelectMethod="MovieDropDownList_GetData" DataTextField="Title" DataValueField="MovieID"></asp:DropDownList>
    <%-- Validering--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du måste välja en film!" Text="*" Display="Dynamic" ControlToValidate="MovieDropDownList"></asp:RequiredFieldValidator>
    
    <%-- Dropdownlista för kund --%>
    <label for="CustomerDropDownList">Välj kund:</label>
    <asp:DropDownList ID="CustomerDropDownList" runat="server" ItemType="Filmuthyrning.Model.BLL.Customer" SelectMethod="CustomerDropDownList_GetData" DataTextField="BothNames" DataValueField="CustomerID"></asp:DropDownList>
    <%-- Validering--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du måste välja en film!" Text="*" Display="Dynamic" ControlToValidate="CustomerDropDownList"></asp:RequiredFieldValidator>
        
    <%--Hyrdatum--%>
    <label for="DateBox">HyrDatum:</label>
    <asp:TextBox ID="DateBox" type="date" runat="server"></asp:TextBox>
    <%-- Validering--%>      
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Datumet hade inte rätt format" Display="Dynamic" Text="*" ControlToValidate="DateBox" ValidationExpression="^[0-9]{4}-[0-9]{2}-[0-9]{2}$"></asp:RegularExpressionValidator>                
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Datumet måste vara mellan 1900-01-01 och 2079-06-06" Text="*" Display="Dynamic" ControlToValidate="Datebox" Type="Date" MaximumValue="2079-06-06" MinimumValue="1900-01-01"></asp:RangeValidator>                   
    <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" />
</asp:Content>