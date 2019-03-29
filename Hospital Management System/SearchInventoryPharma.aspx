<%@ Page Title="" Language="C#" MasterPageFile="~/Pharmacist.Master" AutoEventWireup="true" CodeBehind="SearchInventoryPharma.aspx.cs" Inherits="Hospital_Management_System.SearchInventoryPharma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        * {
  box-sizing: border-box;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="title" class="title">
       <h2>Inventory List</h2>
   </div>
    <div id="body1">
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" HorizontalAlign="Left" widt AutoGenerateColumns="False" DataKeyNames="MedicalItemsID" DataSourceID="InventoryItems" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="202px" Height="116px">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="MedicalItemsID" HeaderText="MedicalItemsID" InsertVisible="False" ReadOnly="True" SortExpression="MedicalItemsID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Supplier" HeaderText="Supplier" SortExpression="Supplier" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
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
        <asp:SqlDataSource ID="InventoryItems" runat="server" ConnectionString="<%$ ConnectionStrings:Hospital_ManagementDBConnectionString %>" DeleteCommand="DELETE FROM [MedicalItems] WHERE [MedicalItemsID] = @MedicalItemsID" InsertCommand="INSERT INTO [MedicalItems] ([Inventory], [Name], [Description], [Supplier], [Price], [Quantity]) VALUES (@Name, @Description, @Supplier, @Price, @Quantity)" SelectCommand="SELECT * FROM [MedicalItems]" UpdateCommand="UPDATE [MedicalItems] SET [Name] = @Name, [Description] = @Description, [Supplier] = @Supplier, [Price] = @Price, [Quantity] = @Quantity WHERE [MedicalItemsID] = @MedicalItemsID">
            <DeleteParameters>
                <asp:Parameter Name="MedicalItemsID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Inventory" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Supplier" Type="String" />
                <asp:Parameter Name="Price" Type="Decimal" />
                <asp:Parameter Name="Quantity" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Supplier" Type="String" />
                <asp:Parameter Name="Price" Type="Decimal" />
                <asp:Parameter Name="Quantity" Type="Int32" />
                <asp:Parameter Name="MedicalItemsID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
       
        </div>
</asp:Content>
