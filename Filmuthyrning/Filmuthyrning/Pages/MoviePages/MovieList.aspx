<%@ Page Title="Filmlista" MasterPageFile="~/Pages/Shared/RentMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="Filmuthyrning.Pages.MoviePages.MovieList" %>

<asp:Content ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    Alla filmer
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />    
        <asp:ListView ID="MovieListView" runat="server" ItemType="Filmuthyrning.Model.BLL.Movie" SelectMethod="MovieListView_GetData">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Titel</th>
                        <th>År</th>
                        <th>Genre</th>
                        <th>Prisgrupp</th>
                        <th>Hyrtid(dagar)</th>
                        <th>Antal ex.</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Item.Title %></td>
                    <td><%# Item.Year %></td>
                    <td><%# Item.Genre %></td>
                    <td><%# Item.PriceGroupText %></td>
                    <td><%# Item.RentalPeriod %></td>
                    <td><%# Item.Quantity %></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
</asp:Content>