<%@ Page Title="Uthyrningslista" MasterPageFile="~/Pages/Shared/RentMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="RentalList.aspx.cs" Inherits="Filmuthyrning.Pages.RentalPages.RentalList" %>

<asp:Content ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    Alla uthyrningar
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        
        <%-- Om en sparning lyckas så visas detta meddelande--%>
            <asp:Label ID="SuccessLabel" runat="server" Visible="false"></asp:Label>        
        <%-- Tabellen med Uthyrningarna --%>
        <asp:ListView ID="RentalListView" runat="server" selectMethod="RentalListView_GetData" ItemType="Filmuthyrning.Model.BLL.Rental" DataKeyNames="RentalID" 
            DeleteMethod="RentalListView_DeleteItem">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Filmtitel</th>
                        <th>Kundnamn</th>
                        <th>Uthyrningsdatum</th>
                        <th>Återlämningsdatum</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>

            <%-- Items --%>
            <ItemTemplate>
                <tr>
                    <td><%# Item.MovieTitle %></td>
                    <td><%# String.Format("{0}, {1}",Item.lastName, Item.firstName) %></td>
                    <td><%# Item.RentalDate.Split(' ')[0] %></td>
                    <td><%# Item.ReturnDate.Split(' ')[0] %></td>
                    <td><asp:HyperLink runat="server" 
                        NavigateUrl='<%# System.IO.Path.Combine("~","Uthyrning","Spara",String.Format("?Rental={0}",Item.RentalID.ToString())) %>'>
                        Uppdatera
                    </asp:HyperLink></td>
                    <td class="command">
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" OnClientClick="confirmBox()" CausesValidation="false" />
                    </td>
                </tr>
            </ItemTemplate>

            <%-- Om formuläret är tomt --%>
            <EmptyDataTemplate>
                <p>Det finns ingen data att visa.</p>
            </EmptyDataTemplate>

        </asp:ListView>
</asp:Content>