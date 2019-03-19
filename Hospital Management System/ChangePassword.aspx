<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Hospital_Management_System.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <asp:Label ID="passwordSuccess" runat="server" CSSClass ="alert-success" Text=""></asp:Label>
        <asp:Label ID="passwordFailure" runat="server" CSSClass = "alert-danger" Text=""></asp:Label>
        <tr>
            <td>
                <asp:Label ID="usernameLbl" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="usernameTxt" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="active" ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
            </td>
             <td>
                 <asp:RequiredFieldValidator class="alert-danger" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password is required" ControlToValidate="PasswordTxt"></asp:RequiredFieldValidator>
             </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="changePasswordLbl" runat="server" Text="New Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="active" ID="changePasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
            </td>
             <td>
                 <asp:RequiredFieldValidator class="alert-danger" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required to update" ControlToValidate="changePasswordTxt"></asp:RequiredFieldValidator>
             </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="changePasswordLbl2" runat="server" Text="Confirm Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox class="active" ID="changePasswordTxt2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator class="alert-danger" ID="changePasswordRequiredFieldValidator" runat="server" ErrorMessage="Enter Password again to confirm" ControlToValidate="changePasswordTxt2"></asp:RequiredFieldValidator>
                <asp:CompareValidator class="alert-danger" ID="CompareValidator1" runat="server" ErrorMessage="Passwords must match" ControlToValidate="changePasswordTxt2" ControlToCompare="changePasswordTxt"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button class ="alert-success" ID="changePasswordBtn" runat="server" Text="Change Password" OnClick="changePasswordBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
