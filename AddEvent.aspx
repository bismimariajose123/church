<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="Diocese.AddEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="reg-w3">
<div class="w3layouts-main">
	<h2>ADD EVENT</h2>
		<div>
             <label for="uname"><b>Event Name</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBEventName" runat="server" CssClass="input"></asp:TextBox>
            
				<div class="clearfix"></div>
				<%--buttonregform in subadmin/style.css--%>
            <asp:Button ID="btn_Add" runat="server" Text="ADD"  CssClass="buttonregform" OnClick="btn_Add_Click"/>
		</div>
		
</div>
</div>


</asp:Content>
