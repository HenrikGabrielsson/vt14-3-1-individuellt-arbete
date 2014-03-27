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
        
    <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" />
</asp:Content>