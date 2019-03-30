<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateReportSearchIDPage.aspx.cs" Inherits="Hospital_Management_System.UpdateReportSearchIDPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Label ID="errorLabel" runat="server" Text="" Forecolor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
    <br/>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Please Enter the Report ID to be Updated"></asp:Label>
&nbsp;<asp:TextBox ID="IDTextBox" TextMode="Number" runat="server"></asp:TextBox>
      <br />
      <br />
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update Patients Records" />
</asp:Content>
