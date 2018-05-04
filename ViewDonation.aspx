<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewDonation.aspx.cs" Inherits="Diocese.ViewDonation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-right:80%">

  <%-- -------- search & user info start--%>
    <ul class="nav pull-right top-menu">
        <li>
            <label style="color:white">Search by column</label>
        </li>
        <br /><i class="glyphicon glyphicon-search"></i>
        <li>
            
            <asp:TextBox ID="TBSearch" runat="server" CssClass="form-control search" placeholder=" Search"></asp:TextBox>
        </li>
       
    </ul>
  <%--  -------------search & user info end--%>
</div>

    <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
</asp:Content>
