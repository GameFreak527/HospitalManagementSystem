<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor.Master" AutoEventWireup="true" CodeBehind="PatientDetailsDoc.aspx.cs" Inherits="Hospital_Management_System.PatientDetailsDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="title" class="title">
        <h2>Patient Details</h2>

    </div>
    <div id="body">
        <asp:DetailsView ID="patientDetails" runat="server" AutoGenerateRows="False" AllowPaging="True" HorizontalAlign="Center"  
              Height="112px" Width="300px"
             BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Horizontal" ForeColor="Black"
              >
             <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="Patient Id">
                <ItemTemplate>
                    <asp:Label ID="patientId" runat="server" Text='<%# Eval("PatientID") %>' />
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Ward Number">
                <ItemTemplate>
                    <asp:Label ID="ward" runat="server" Text='<%# Eval("Ward") %>' />
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="First Name">
                <ItemTemplate>
                    <asp:Label ID="firstName" runat="server" Text='<%# Eval("FirstName") %>' />
                </ItemTemplate>
                 <EditItemTemplate>
                            <asp:TextBox id="editName" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                        </EditItemTemplate>
      <%--Jasneet kaur  300961578--%>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name">
                <ItemTemplate>
                    <asp:Label ID="lastName" runat="server" Text='<%# Eval("LastName") %>' />
                </ItemTemplate>
                 <EditItemTemplate>
                            <asp:TextBox id="editlastname" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                        </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Phone Number">
                <ItemTemplate>
                    <asp:Label ID="phoneNum" runat="server" Text='<%# Eval("PhoneNumber") %>' />
                </ItemTemplate>
                  <EditItemTemplate>
                            <asp:TextBox id="editNum" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
                        </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="address" runat="server" Text='<%# Eval("Address") %>' />
                </ItemTemplate>
                  <EditItemTemplate>
                            <asp:TextBox id="editAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                        </EditItemTemplate>
            </asp:TemplateField>

            
            
           

        </Fields>
             <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
             <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <HeaderTemplate>
                <%#Eval("FirstName")%>
            </HeaderTemplate>
            
             <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            
        
    </asp:DetailsView>
        <!-- add if wants to edit or delete in details view
            <asp:CommandField ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
            -->
         </div>
</asp:Content>
