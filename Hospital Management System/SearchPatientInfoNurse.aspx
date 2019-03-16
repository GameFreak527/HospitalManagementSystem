<%@ Page Title="" Language="C#" MasterPageFile="~/Nurse.Master" AutoEventWireup="true" CodeBehind="SearchPatientInfoNurse.aspx.cs" Inherits="Hospital_Management_System.SearchPatientInfoNurse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="title" class="title">
       <h2> Search Patient</h2>
   </div>
    <div id="body">
        <asp:GridView ID="searchPatient" runat="server" AutoGenerateColumns="False" Width="500px"
             OnSelectedIndexChanged="searchPatient_SelectedIndexChanged" DataKeyNames="PatientID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
            >
             <Columns>
                <asp:BoundField DataField="PatientID" HeaderText="Patient Id" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:CommandField ShowSelectButton="true" />
               
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
</asp:Content>
