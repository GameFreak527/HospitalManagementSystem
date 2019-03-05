<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="registerEmployee.aspx.cs" Inherits="Hospital_Management_System.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 30%" id="loginDiv">
        <div>
            <asp:Label runat="server" Text="Ward"></asp:Label>
            &nbsp;&nbsp;
        <asp:TextBox runat="server" type="number" ID="wardNumber" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="WardRequiredFieldValidator" runat="server" ErrorMessage="Ward number is required" ForeColor ="Red" ControlToValidate="wardNumber"></asp:RequiredFieldValidator>

            <br />
            <br />
        </div>
        <div>
            <asp:Label runat="server" Text="Label"> Employee Type </asp:Label>
            &nbsp;
        <asp:TextBox runat="server" type="number" ID="employeeType" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="EmployeetypeRequiredFieldValidator1" runat="server" ErrorMessage="Employee type is required" ForeColor ="Red" ControlToValidate="employeeType"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter correct Employee type" MaximumValue="5" MinimumValue="1" ForeColor ="Red" ControlToValidate="employeeType"></asp:RangeValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label runat="server" Text="Label"> First Name </asp:Label>
            &nbsp;
        <asp:TextBox runat="server" ID="firstName" CausesValidation="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ErrorMessage="First Name is required" ForeColor ="Red" ControlToValidate="firstName"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label runat="server" Text="Last Name"></asp:Label>
            &nbsp;
         <asp:TextBox runat="server" ID="lastName"></asp:TextBox>
            <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ErrorMessage="Last Name is required" ForeColor ="Red" ControlToValidate="lastName"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label runat="server" Text="Label"> Contact </asp:Label>
            &nbsp;
          <asp:TextBox runat="server" ID="contactNumber" TextMode="Phone"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ContactRequiredFieldValidator" runat="server" ErrorMessage="Contact Number is required" ForeColor ="Red" ControlToValidate="contactNumber"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label runat="server" Text="Label"> Address </asp:Label>
            &nbsp;
             <asp:TextBox runat="server" ID="address" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator" runat="server" ErrorMessage="Address is required" ForeColor ="Red" ControlToValidate="address"></asp:RequiredFieldValidator>
            <br />
            <br />

        </div>
        <div>
            <asp:Label runat="server" Text="Label"> Email </asp:Label>
            &nbsp;
              <asp:TextBox runat="server" CssClass="active" ID="emailID" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email is required" ForeColor ="Red" ControlToValidate="emailID"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label runat="server" Text="Label"> password </asp:Label>
            &nbsp;
              <asp:TextBox runat="server" CssClass="active" ID="userPassword" type="password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Password is required" ForeColor ="Red" ControlToValidate="userPassword"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label runat="server" Text="Label"> SIN </asp:Label>
            &nbsp;
             <asp:TextBox runat="server" ID="sinNumber" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="SinRequiredFieldValidator" runat="server" ErrorMessage="Sin Number is required"  ForeColor ="Red" ControlToValidate="sinNumber"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>

        <asp:Button ID="registerBtn" runat="server" Text="Register" CssClass="button" OnClick="registerBtn_Click" />
    </div>

</asp:Content>
