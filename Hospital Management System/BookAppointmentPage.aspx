<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookAppointmentPage.aspx.cs" Inherits="Hospital_Management_System.BookAppointmentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="errorLabel" runat="server" Text="" Forecolor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
    <br />
    <br />
    <asp:Label ID="EmployeeLabel" runat="server" Text="Please Enter the ID of the Doctor or Nurse: "></asp:Label>
    <asp:TextBox ID="EmployeeTextBox" TextMode="Number"  runat="server"></asp:TextBox>
&nbsp;<br />
    <asp:Label ID="PatientLabel" runat="server" Text="Please Enter the ID of the Patient: "></asp:Label>
    <asp:TextBox ID="PatientTextBox" TextMode="Number"  runat="server"></asp:TextBox>
    <br />
    <br />
   <div id="date1"> 
                 <asp:Label ID="Label2" runat="server" Text="Choose  Date"></asp:Label>
               <asp:Calendar ID="Begin_Calendar" runat="server">
            </asp:Calendar>

                 <asp:Label ID="BeginTimeLabel" runat="server" Text="Begin Time:"></asp:Label>

            <asp:TextBox ID="BeginTime" TextMode="Time" runat="server" Height="50px" Width="200px"></asp:TextBox>   
           </div>

            <div id="date2" style="position: relative; left: 400px; margin-top: -300px;">
                <asp:Label ID="Label3" runat="server" Text="Choose End Date"></asp:Label>
            <asp:Calendar ID="End_Calendar" runat="server">
            </asp:Calendar>
                 <asp:Label ID="EndTimeLabel" runat="server" Text="End Time"></asp:Label>
                <asp:TextBox ID="EndTime" TextMode="Time" runat="server" Height="50px" Width="200px"></asp:TextBox>   
            </div>
     <asp:Button ID="Button1" runat="server" Text="Create Appointment" OnClick="Button1_Click" />
  
</asp:Content>