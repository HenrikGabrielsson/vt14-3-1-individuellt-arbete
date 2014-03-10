<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalList.aspx.cs" Inherits="Filmuthyrning.Pages.RentalPages.RentalList"  ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alla uthyrningar</title>
</head>
<body>
    <form id="Form" runat="server">
    <div>
        <%-- Tabellen med Filmer --%>
        <asp:ListView ID="RentalListView" runat="server" selectMethod="RentalListView_GetData" ItemType="Filmuthyrning.Model.BLL.Rental" DataKeyNames="RentalID" 
            DeleteMethod="RentalListView_DeleteItem">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Filmtitel</th>
                        <th>Kundnamn</th>
                        <th>Uthyrningsdatum</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>

            <%-- Items --%>
            <ItemTemplate>
                <tr>
                    <td><%# Item.MovieTitle %></td>
                    <td><%# String.Format("{0}, {1}",Item.lastName, Item.firstName) %></td>
                    <td><%# Item.RentalDate %></td>
                    <td><asp:HyperLink runat="server" NavigateUrl='<%# System.IO.Path.Combine("~","Uthyrning","Ändra",String.Format("?Rental={0}",Item.RentalID.ToString())) %>'>Uppdatera</asp:HyperLink></td>
                    <td class="command">
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" />
                    </td>
                </tr>
            </ItemTemplate>

            <%-- Om formuläret är tomt --%>
            <EmptyDataTemplate>
                <p>Det finns ingen data att visa.</p>
            </EmptyDataTemplate>

        </asp:ListView>
    </div>
    </form>
</body>
</html>
