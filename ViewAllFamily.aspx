<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewAllFamily.aspx.cs" Inherits="Diocese.ViewAllFamily" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-right:80%">

  <%-- -------- search & user info start--%>
    <ul class="nav pull-right top-menu">
        <li>
            <label style="color:white">Search by column</label>
        </li>
        <br /><i class="glyphicon glyphicon-search"></i>
        <li>
            
            <asp:TextBox ID="TBSearchFamily" runat="server" CssClass="form-control search" placeholder=" Search"></asp:TextBox>
        </li>
       
    </ul>
  <%--  -------------search & user info end--%>
</div>

    <asp:GridView ID="GVFamilyDetails" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Family_ID" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
        BorderWidth="1px" CellPadding="4"  >
        <Columns>
            
             <asp:TemplateField HeaderText="Family Name" SortExpression="FamilyName">
                 <ItemTemplate>
                    <asp:Label ID="LBLFamilyName" runat="server" Text='<%# Bind("FamilyName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="HeadName" HeaderText="Head Name" SortExpression="HeadName" />

            <asp:TemplateField HeaderText="Ward Name" SortExpression="Ward_id" >
                <ItemTemplate>
                     <asp:Label ID="LBLWardName" runat="server" Text='<%# Bind("WardName") %>'></asp:Label>              
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            <asp:BoundField DataField="FamilyNo" HeaderText="FamilyNo" SortExpression="FamilyNo" />
            <asp:BoundField DataField="Contact_No" HeaderText="Contact_No" SortExpression="Contact_No" />
           
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    </asp:Content>
