<%@ Page Language="C#" Title="Kundlista" MasterPageFile="~/Pages/Shared/RentMaster.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Filmuthyrning.Pages.CustomerPages.CustomerList" %>
<asp:Content ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    Alla kunder
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

        <%-- Här sparas sidans fel--%>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
  
        <%-- Om en sparning lyckas så visas detta meddelande--%>
            <asp:Label ID="SuccessLabel" runat="server" Visible="false" />

        <%-- Här hamnar alla kunder  --%>
        <asp:ListView ID="ListView_Customer" ItemType="Filmuthyrning.Model.BLL.Customer" SelectMethod="ListView_Customer_GetData" DataKeyNames="CustomerID" runat="server" 
            DeleteMethod="ListView_Customer_DeleteItem">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Förnamn</th>
                        <th>Efternamn</th>
                        <th>Telefonnummer</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Item.FirstName  %></td>
                    <td><%# Item.LastName  %></td>
                    <td><%# Item.PhoneNumber  %></td>
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
</asp:Content>