<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="CreateFamily.aspx.cs" Inherits="Diocese.CreateFamily" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="reg-w3">
<div class="w3layouts-main">
	<h2>CREATE FAMILY</h2>
		<div>
             <label for="uname"><b>Family name</b></label>
            <asp:TextBox ID="TBFamilyName" runat="server" CssClass="input"></asp:TextBox>
           
            <label for="uname"><b>Family Number</b></label>
			<asp:TextBox ID="TBFamilyNbr" runat="server" CssClass="input"></asp:TextBox>
           
             <label for="uname"><b>Family Head Name</b></label>
			<asp:TextBox ID="TBHeadName" runat="server" CssClass="input"></asp:TextBox>
           
              <label for="uname"><b>User Name</b></label>
			<asp:TextBox ID="TBUname" runat="server" CssClass="input"></asp:TextBox>
            <label for="uname"><b>Password</b></label>
			<asp:TextBox ID="TBPass" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
			
           <%-- input in loginform.css--%>
			    <label for="uname"><b>Ward Name </b></label>
            <asp:DropDownList ID="DDLWardName" runat="server" CssClass="input" AppendDataBoundItems="true">
                 <asp:ListItem Value="0">--select--</asp:ListItem>
            </asp:DropDownList>
           <br />
            <label for="uname"><b>Contact Nob</b></label>
			<asp:TextBox ID="TBContactNo" runat="server" CssClass="input"></asp:TextBox>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  
            ControlToValidate="TBContactNo" ErrorMessage="max 10 digit"  
            ValidationExpression="[0-9]{10}" ForeColor="Red"></asp:RegularExpressionValidator> 
           
          	<div class="clearfix"></div>
				<%--buttonregform in subadmin/style.css--%>
            <asp:Button ID="BtnCreateFamily" runat="server" Text="ADD"  CssClass="buttonregform" OnClick="BtnCreateFamily_Click"/>
		</div>
		<a href="login.html">CreateFamily</a>
</div>
</div>
</asp:Content>
