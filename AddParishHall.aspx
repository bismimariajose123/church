<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddParishHall.aspx.cs" Inherits="Diocese.AddParishHall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="reg-w3">
<div class="w3layouts-main">
	<h2>ADD PARISH HALL</h2>
		<div>
             <label for="uname"><b>Hall Name</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBHallName" runat="server" CssClass="input"></asp:TextBox>
            
				<div class="clearfix"></div>
				<%--buttonregform in subadmin/style.css--%>
            <asp:Button ID="Btnadd" runat="server" Text="ADD"  CssClass="buttonregform"/>
		</div>
		
</div>
</div>
</asp:Content>
