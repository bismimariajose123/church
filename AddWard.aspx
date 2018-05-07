<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddWard.aspx.cs" Inherits="Diocese.AddWard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="reg-w3">
<div class="w3layouts-main">
	<h2>CREATE WARD</h2>
		<div>
             <label for="uname"><b>Ward name</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBWardName" runat="server" CssClass="input"></asp:TextBox>
            
				<div class="clearfix"></div>
				<%--buttonregform in subadmin/style.css--%>
            <asp:Button ID="BtnAddWard" runat="server" Text="ADD"  CssClass="buttonregform" OnClick="BtnAddWard_Click"/>
		</div>
		
</div>
</div>
</asp:Content>
