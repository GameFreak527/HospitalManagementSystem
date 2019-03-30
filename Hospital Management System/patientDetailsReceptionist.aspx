<%@ Page Title="" Language="C#" MasterPageFile="~/Receptionist.Master" AutoEventWireup="true" CodeBehind="patientDetailsReceptionist.aspx.cs" Inherits="Hospital_Management_System.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="title">
        <h1 align="center" class="alert-info"> Patient details</h1>
    </div>
    <br />
    <div id="body">
    <asp:DetailsView align="center" ID="patientDetailsView" runat="server" Height="50px" Width="50%" AutoGenerateRows="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="PatientID"  ForeColor="Black" GridLines="Vertical" AutoGenerateEditButton="True" OnItemUpdating="patientDetailsView_ItemUpdating" OnModeChanging="patientDetailsView_ModeChanging" DataSourceID="patientDataSource">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:BoundField DataField="PatientID" HeaderText="PatientID" InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
            <asp:BoundField DataField="Ward" HeaderText="Ward" SortExpression="Ward" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
        </Fields>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:DetailsView>
        <asp:SqlDataSource ID="patientDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Hospital_ManagementDBConnectionString4 %>" SelectCommand="SELECT * FROM [Patient]" UpdateCommand="UPDATE [Patient] SET [Ward] = @Ward, [FirstName] = @FirstName, [LastName] = @LastName, [PhoneNumber] = @PhoneNumber, [Address] = @Address WHERE [PatientID] = @PatientID">
            
            <UpdateParameters>
                <asp:Parameter Name="Ward" Type="Int32" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="PhoneNumber" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="PatientID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    <br />
   
       
        </div>
    
</asp:Content>
