<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddParishHall.aspx.cs" Inherits="Diocese.AddParishHall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="reg-w3">
<div class="w3layouts-main">
	<h2>ADD PARISH HALL</h2>
		<div>
             <label for="uname"><b>Hall Name</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBHallName" runat="server" CssClass="input" required=""></asp:TextBox>
             <label for="uname"><b>Hall Number</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBHallNO" runat="server" CssClass="input" required=""></asp:TextBox>
             <label for="uname"><b>Number of People</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBNobr_People" runat="server" CssClass="input" required=""></asp:TextBox>
           
             <label for="uname"><b>Rate</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBRate" runat="server" CssClass="input" required=""></asp:TextBox>
           
				<div class="clearfix"></div>
				<%--buttonregform in subadmin/style.css--%>
            <asp:Button ID="BtnaddHall" runat="server" Text="ADD"  CssClass="buttonregform" OnClick="BtnaddHall_Click"/>
		</div>
		
</div>
</div>
</asp:Content>
