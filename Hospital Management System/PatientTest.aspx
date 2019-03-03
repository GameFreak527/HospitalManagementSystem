<%@ Page Title="" Language="C#" MasterPageFile="~/Patient.Master" AutoEventWireup="true" CodeBehind="PatientTest.aspx.cs" Inherits="Hospital_Management_System.PatientTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>This is the list of the employees</h1>
    <asp:ListBox ID="employeeList" runat="server"></asp:ListBox>
</asp:Content>
