<%@ Page Title="Fel!" MasterPageFile="~/Pages/Shared/RentMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Filmuthyrning.Pages.Shared.error" %>

<asp:Content ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    Något gick fel!
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <p>Något verkar tyvärr ha gått fel. Gå tillbaka till <a href="../RentalPages/RentalList.aspx">startsidan</a></p>
</asp:Content>
