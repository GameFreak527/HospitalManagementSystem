<%@ Page Title="" Language="C#" MasterPageFile="~/Receptionist.Master" AutoEventWireup="true" CodeBehind="searchPatientInfoReceptionist.aspx.cs" Inherits="Hospital_Management_System.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="searchLabel" runat="server" Text="Search By ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="searchText" runat="server" OnTextChanged="searchText_TextChanged"></asp:TextBox>
            </td>
        </tr>
        </table>
    <br />
    <asp:GridView ID="searchPatient" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="PatientID"  ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="searchPatient_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="PatientID" HeaderText="PatientID" InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
            <asp:HyperLinkField NavigateUrl="patientDetailsReceptionist.aspx" Text="SELECT" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
</asp:GridView>
    
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Hospital_ManagementDBConnectionString2 %>" SelectCommand="SELECT [PatientID], [FirstName], [PhoneNumber] FROM [Patient] WHERE ([FirstName] LIKE '%' + @FirstName + '%')">
    <SelectParameters>
        <asp:ControlParameter ControlID="searchText" Name="FirstName" PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
    
</asp:Content>
