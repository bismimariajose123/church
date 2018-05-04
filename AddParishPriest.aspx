<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddParishPriest.aspx.cs" Inherits="Diocese.AddParishPriest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="reg-w3">
<div class="w3layouts-main">
	<h2>CREATE WARD</h2>
		<div>
             <label for="uname"><b>Priest Name</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBPriestName" runat="server" CssClass="input"></asp:TextBox>
            
				<div class="clearfix"></div>

            <label for="uname"><b>Join Year From</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBJYF" runat="server" CssClass="input"></asp:TextBox>
            
				<div class="clearfix"></div>

            <label for="uname"><b>Join Year To</b></label>
           <%-- input in loginform.css--%>
			<asp:TextBox ID="TBJYT" runat="server" CssClass="input"></asp:TextBox>
            
				<div class="clearfix"></div>

             <label for="uname"><b>Image</b></label>
           <%-- input in loginform.css--%>
			
            <asp:FileUpload ID="FileUpload1" runat="server"/>
				<div class="clearfix"></div>
			
				<%--buttonregform in subadmin/style.css--%>
            <asp:Button ID="BtnAdd" runat="server" Text="ADD"  CssClass="buttonregform"/>
		</div>
		
</div>
</div>

</asp:Content>
