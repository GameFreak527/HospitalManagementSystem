<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="Hospital_Management_System.ViewReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       &nbsp;<br />
       <asp:Label ID="Label5" runat="server" Text="Complete List of Patients Medical History" Font-Size="X-Large" Font-Bold="true"></asp:Label>
&nbsp;<asp:GridView ID="searchPatient" runat="server" AutoGenerateColumns="False" Width="500px"
             BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
            >
             <Columns>
                 <asp:BoundField DataField="AppointmentID" HeaderText="Report Id" />
                <asp:BoundField DataField="Patient" HeaderText="Patient Id" />
                <asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis" />
                  <asp:BoundField DataField="Employee" HeaderText="Employee Id" />
                <asp:BoundField DataField="Prescription" HeaderText="Medication Prescribed" />
                <asp:CommandField ShowSelectButton="false" />
               
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
</asp:Content>
