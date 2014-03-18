﻿<%@ Page Language="C#" Title="Spara Kund" MasterPageFile="~/Pages/Shared/RentMaster.Master" AutoEventWireup="true" CodeBehind="CustomerSave.aspx.cs" Inherits="Filmuthyrning.Pages.CustomerPages.CustomerSave" ViewStateMode="Disabled" %>

<asp:Content ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    Lägg till eller ändra kund
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <%--Här samlas alla valideringsfel --%>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <label for="fNameBox">Förnamn:</label><asp:TextBox ID="fNameBox" runat="server"></asp:TextBox>
    <%-- Validering --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du måste fylla i ett förnamn!" Text="*" ControlToValidate="fNameBox"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Förnamnet får inte vara längre än 50 tecken!" Display="Dynamic" Text="*" ControlToValidate="fNameBox" ValidationExpression="^.{0,50}$"></asp:RegularExpressionValidator>
   
    
    <label for="lNameBox">Efternamn:</label><asp:TextBox ID="lNameBox" runat="server"></asp:TextBox>   
    <%-- Validering --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du måste fylla i ett efternamn!" Text="*" ControlToValidate="lNameBox"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Efternamnet får inte vara längre än 50 tecken!" Display="Dynamic" Text="*" ValidationExpression="^.{0,50}$" ControlToValidate="lNameBox"></asp:RegularExpressionValidator>
    
    
    <label for="phoneBox">Telefonnummer:</label><asp:TextBox ID="phoneBox" runat="server"></asp:TextBox>
    <%-- Validering --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Du måste fylla i ett telefonnummer!" Text="*" ControlToValidate="phoneBox"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Telefonnumret får inte vara längre än 10 tecken! och får enbart bestå av siffror" Display="Dynamic" Text="*" ValidationExpression="^[0-9]{1,10}$" ControlToValidate="phoneBox"></asp:RegularExpressionValidator>    
    
    <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" />
</asp:Content>