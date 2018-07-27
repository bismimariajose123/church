<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="SubadminAddResponsibility.aspx.cs" Inherits="Diocese.SubadminAddResponsibility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin-top:10px;"><b> WELCOME <asp:Label ID="LBLsubadminname" runat="server" Text="Label" ></asp:Label></b></div>
 
     <div class="reg-w3">
<div class="w3layouts-main">
	<h2>ADD DUTY</h2>
		<div>
             <label for="uname"><b>Responsibility</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBResponsibilityName" runat="server" CssClass="input"></asp:TextBox>
            
				<div class="clearfix"></div>

            <label for="uname"><b>User Name</b></label>
            <asp:TextBox ID="TBUname" runat="server" CssClass="input"></asp:TextBox>
            
				<div class="clearfix"></div>

            <label for="uname"><b>Password</b></label>
            <asp:TextBox ID="TBPasswd" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
            
				<div class="clearfix"></div>
				<%--buttonregform in subadmin/style.css--%>
            <asp:Button ID="BtnAddResponsibility" runat="server" Text="ADD"  CssClass="buttonregform" OnClick="BtnAddResponsibility_Click"/>
		</div>
		
</div>
</div>


</asp:Content>
