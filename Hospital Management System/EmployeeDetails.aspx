<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Hospital_Management_System.EmployeeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="container" style="overflow:hidden">
    <div id="EmployeeList" style="float:left; margin-left:20px">
        <h1><span class="badge badge-secondary">Employee Details</span></h1>
        <br />
    <asp:GridView ID="EmpDetails" runat="server" AutoGenerateColumns="false" BorderStyle="Solid" BorderWidth="1px" CellSpacing="1" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="linkSelect" Text="Select" runat="server" CommandArgument='<%#Eval("EmployeeID") %>' OnClick="linkSelect_Click" class="btn btn-outline-success"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    </div>
    <div id="employee" runat="server" style="float:right">
        <h1><span class="badge badge-secondary">Employee Ward location</span></h1>
        <br />
         <asp:GridView ID="employeeGrid" runat="server" BorderStyle="Solid" BorderWidth="1px" CellSpacing="1" HorizontalAlign="Center">
             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
             <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
    </div>
    </div>
</asp:Content>
