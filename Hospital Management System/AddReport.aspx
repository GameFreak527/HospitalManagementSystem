<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddReport.aspx.cs" Inherits="Hospital_Management_System.AddReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label4" runat="server" Text="Please Fill out Report Details:" Font-Bold="true" Font-Size="Large"></asp:Label>
    <br />
    <asp:Label ID="errorLabel" runat="server" Text="" Forecolor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="PatientLabel" runat="server" Text="Insert Patient ID"></asp:Label>
&nbsp;
    <asp:TextBox ID="PatientIDTextBox" TextMode="Number" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Insert Employee ID"></asp:Label>
&nbsp;<asp:TextBox ID="EmployeeIDTextBox" TextMode="Number"  runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Diagnosis"></asp:Label>
&nbsp;
    <asp:TextBox ID="DiagnosisTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Prescription"></asp:Label>
&nbsp;<asp:TextBox ID="PrescriptionTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Add Medical Report" OnClick="Button1_Click" />
</asp:Content>
