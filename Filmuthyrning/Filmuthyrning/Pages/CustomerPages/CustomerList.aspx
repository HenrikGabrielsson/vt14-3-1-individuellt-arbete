<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Filmuthyrning.Pages.CustomerPages.CustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server">
    <div>
        <asp:ListView ID="ListView_Customer" ItemType="Filmuthyrning.Model.BLL.Customer" SelectMethod="ListView_Customer_GetData" DataKeyNames="CustomerID" runat="server" 
            DeleteMethod="ListView_Customer_DeleteItem">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Förnamn</th>
                        <th>Efternamn</th>
                        <th>Telefonnummer</th>
                        <th>Email</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Item.FirstName  %></td>
                    <td><%# Item.LastName  %></td>
                    <td><%# Item.PhoneNumber  %></td>
                    <td><%# Item.Email  %></td>
                    <td><asp:HyperLink runat="server" 
                        NavigateUrl='<%# System.IO.Path.Combine("~","Kund","Spara",String.Format("?Customer={0}",Item.CustomerID.ToString())) %>'>
                        Uppdatera
                    </asp:HyperLink></td>
                    <td class="command">
                        <asp:LinkButton CommandName="Delete" CausesValidation="false" Text="Ta bort" runat="server" />
                    </td>
                </tr>

            </ItemTemplate>
            <EmptyDataTemplate>
                <p>Det finns inga kunder att visa.</p>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
