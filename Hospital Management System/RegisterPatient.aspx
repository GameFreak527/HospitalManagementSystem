<%@ Page Title="" Language="C#" MasterPageFile="~/Receptionist.Master" AutoEventWireup="true" CodeBehind="RegisterPatient.aspx.cs" Inherits="Hospital_Management_System.RegisterPatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Patient Registration</h1>
    <div class="alert alert-danger" role="alert" runat="server" id="errorMessageDiv" visible="false">
            <asp:Label ID="errorMessage" runat="server" Text="ERROR" Enabled="false" Font-Bold="true"></asp:Label>
        </div>
    <table>
        <tr style="align-content:center">
            <td>
                <asp:Label ID="firstNameLabel" runat="server" Text="First Name"></asp:Label>   
                
            </td>
            <td>
                <asp:TextBox ID="firstNameTxtBox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ErrorMessage="First Name is required" ControlToValidate="firstNameTxtBox"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="align-content:center">
            <td>
                <asp:Label ID="lastNameLabel" runat="server" Text="Last Name"></asp:Label>   
            </td>
            <td>
                <asp:TextBox ID="lastNameTxtBox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="lastNameRequired" runat="server" ErrorMessage="Last Name is required" ControlToValidate="lastNameTxtBox"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="align-content:center">
            <td>
                <asp:Label ID="addressLabel" runat="server" Text="Address"></asp:Label>   
            </td>
            <td>
                <asp:TextBox ID="addressTxtBox" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="addressValidator" runat="server" ErrorMessage="Address is required" ControlToValidate="addressTxtBox"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="align-content:center">
            <td>
                <asp:Label ID="phoneLabel" runat="server" Text="Phone number"></asp:Label>   
            </td>
            <td>
                <asp:TextBox ID="phoneTxtBox" runat="server" TextMode="Phone"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="phoneNumberValidator" runat="server" ErrorMessage="Phone Number is required" ControlToValidate="phoneTxtBox"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="align-content:center">
            <td>
                <asp:Label ID="wardLabel" runat="server" Text="Ward"></asp:Label>   
            </td>
            <td>
                <asp:DropDownList ID="wardList" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr style="align-content:center">
            <td>

            </td>
            <td>
                <asp:Button ID="submitBtn" runat="server" Text="Register" OnClick="submitBtn_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
