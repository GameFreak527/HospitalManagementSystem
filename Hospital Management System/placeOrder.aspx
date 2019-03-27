<%@ Page Title="" Language="C#" MasterPageFile="~/Pharmacist.Master" AutoEventWireup="true" CodeBehind="placeOrder.aspx.cs" Inherits="Hospital_Management_System.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="errorLabel" CssClass="alert-success" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="inventoryLabel" runat="server" Text="Inventory ID"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="inventoryIDList" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="nameLabel" runat="server" Text="Medical Item Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Medical Item Name is required" ControlToValidate="nameTxt" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
             <td>
                <asp:Label ID="descriptionLabel" runat="server" Text="Medical Item Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="descriptionTxt" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Medical Item Description is required" ControlToValidate="descriptionTxt" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
             <td>
                <asp:Label ID="supplierLabel" runat="server" Text="Supplier"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="supplierTxt" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Supplier information is required" ControlToValidate="supplierTxt" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
              <td>
                <asp:Label ID="priceLabel" runat="server" Text="Medical Item Price"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="priceTxt" runat="server" TextMode="Number"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Medical item price is required" ControlToValidate="priceTxt" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            </tr>
        <tr>
            <td>
                <asp:Label ID="quantityLabel" runat="server" Text="Medical Item Quantity"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="quantityTxt" runat="server" TextMode="number"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Quantity of medical item is required" ControlToValidate="quantityTxt" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Button class="alert-success" ID="placeOrderButton" runat="server" Text="Place Order" OnClick="placeOrderButton_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
