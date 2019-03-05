<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Hospital_Management_System.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="outerDiv" style="margin-left:30%; overflow-wrap:inherit; width: 454px;" class="shadow-lg p-3 mb-2 bg-info text-white rounded">
        <div class="alert alert-danger" role="alert" runat="server" id="errorMessageDiv" visible="false">
            <asp:Label ID="errorMessage" runat="server" Text="ERROR" Enabled="false"></asp:Label>
        </div>
        <div id="contentDiv" class="p-3 mb-2 bg-danger text-white">
       <h2><span class="badge badge-secondary" style="margin-left:20%; margin-bottom:2%">Login</span></h2>
       <table>
           <tr>
               <th><asp:Label ID="id" runat="server" Text="Id"></asp:Label></th>
               <th><asp:TextBox ID="idTxtBox" runat="server"></asp:TextBox></th>
               <th><asp:RequiredFieldValidator ID="idValidation" runat="server" ErrorMessage="Id is required" ControlToValidate="idTxtBox"></asp:RequiredFieldValidator></th>
               
           </tr>
           <tr>
               <th><asp:Label ID="password" runat="server" Text="Password"></asp:Label></th>
               <th><asp:TextBox ID="passwordTxtBox" runat="server" TextMode="Password"></asp:TextBox></th>
               <th><asp:RequiredFieldValidator ID="passwordValidation" runat="server" ErrorMessage="Password is Required" ControlToValidate="passwordTxtBox"></asp:RequiredFieldValidator></th>
           </tr>
           
           <tr>
               <th></th>
               <th><asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-outline-success" OnClick="submit_Click"/></th>
           </tr>
       </table>
            </div>
   </div>
</asp:Content>
