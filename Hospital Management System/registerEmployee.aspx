<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="registerEmployee.aspx.cs" Inherits="Hospital_Management_System.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 30%" id="loginDiv">
        <asp:Label ID="registerLblSuccess" runat="server" Text="" CssClass="alert-success"></asp:Label>
        <asp:Label ID="registerLblError" runat="server" Text="" CssClass="alert-danger"></asp:Label>
        
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Ward"></asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" type="number" ID="wardNumber" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="WardRequiredFieldValidator" runat="server" ErrorMessage="Ward number is required" ForeColor ="Red" ControlToValidate="wardNumber"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Employee Type"></asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" type="number" ID="employeeType" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RangeValidator ID="EmployeeTypeRangeValidator" runat="server" ErrorMessage="Enter correct Employee type between 1 to 5" MaximumValue="5" MinimumValue="1" ForeColor ="Red" ControlToValidate="employeeType"></asp:RangeValidator>
                     <asp:RequiredFieldValidator ID="EmployeeTypeRequiredFieldValidator" runat="server" ErrorMessage="Employee Type is required" ForeColor ="Red" ControlToValidate="employeeType"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label runat="server" Text="First Name"></asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" ID="firstName"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ErrorMessage="First Name is required" ForeColor ="Red" ControlToValidate="firstName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label runat="server" Text="Last Name"></asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" ID="lastName"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ErrorMessage="Last Name is required" ForeColor ="Red" ControlToValidate="lastName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label runat="server" Text="Contact"></asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" ID="contactNumber" TextMode="Phone"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="ContactRequiredFieldValidator" runat="server" ErrorMessage="Contact Number is required" ForeColor ="Red" ControlToValidate="contactNumber"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" ID="address" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator" runat="server" ErrorMessage="Address is required" ForeColor ="Red" ControlToValidate="address"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>
                   <asp:Label runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" ID="emailID" TextMode="Email"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email is required" ForeColor ="Red" ControlToValidate="emailID"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>
                   <asp:Label runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" ID="userPassword" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Password is required" ForeColor ="Red" ControlToValidate="userPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>
                   <asp:Label runat="server" Text="SIN number"></asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" ID="sinNumber" TextMode="Number" MaxLength="10"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="SinRequiredFieldValidator" runat="server" ErrorMessage="Sin Number is required of length 10" ForeColor ="Red" ControlToValidate="sinNumber"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td> <td> <asp:Button ID="registerBtn" runat="server" Text="Register" class="alert-success" OnClick="registerBtn_Click" /></td>
            </tr>
        </table>
     

        
    </div>

</asp:Content>
