<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CloseAppointmentPage.aspx.cs" Inherits="Hospital_Management_System.CloseAppointmentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Label ID="errorLabel" runat="server" Text="" Forecolor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
      <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Close a Patients Appointment" Font-Size="X-Large" Font-Bold="true"></asp:Label>
    <br/>
    <br />
    <asp:Label ID="DiagnosisLabel" runat="server" Text="Please Enter the Diagnosis: "></asp:Label>
    <asp:TextBox ID="DiagnosisTextBox" TextMode="MultiLine"  runat="server"></asp:TextBox>
&nbsp;<br />
    <asp:Label ID="PrescriptionLabel" runat="server" Text="Please Enter the Prescrption Given: "></asp:Label>
    <asp:TextBox ID="PrescriptionTextBox" TextMode="MultiLine"  runat="server"></asp:TextBox>
    <br />
    <br />
   <div id="date1"> 
                 <asp:Label ID="Label2" runat="server" Text="Choose End Date and Time"></asp:Label>
               <asp:Calendar ID="End_Calendar" runat="server">
            </asp:Calendar>

                 <asp:Label ID="EndTimeLabel" runat="server" Text="End Time:"></asp:Label>

            <asp:TextBox ID="EndTime" TextMode="Time" runat="server" Height="50px" Width="200px"></asp:TextBox>   
           </div>

     <asp:Button ID="Button1" runat="server" Text="Create Appointment" OnClick="Button1_Click" />
</asp:Content>
