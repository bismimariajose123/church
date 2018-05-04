<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFirstPage.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Diocese.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="loginform" style="margin-left:30%;">
        
  <div class="logincontainer">
    <label for="uname"><b>Username</b></label>
      
      <asp:TextBox ID="TBUsername" runat="server" CssClass="input" data-toggle="tooltip" data-placement="top" title="Enter username"></asp:TextBox>
   
          
    <label for="psw"><b>Password</b></label>
      
      <asp:TextBox ID="TBPassword" runat="server" CssClass="input" data-toggle="tooltip" data-placement="top" title="Enter password"></asp:TextBox>
   
       <label for="parish"><b>Parish</b></label>
      <asp:DropDownList ID="DDLParish" runat="server" CssClass="input" data-toggle="tooltip" data-placement="top" title="Select Parish"></asp:DropDownList>
     
      <asp:button runat="server" text="Login" CssClass="loginbutton"/>
    
    <label>
      <input type="checkbox" checked="checked" name="remember"> Remember me
    </label>
      
  </div>

  <div class="logincontainer" style="background-color:#f1f1f1">
      <asp:button runat="server" text="Cancel" CssClass="cancelbtn"/>
   
    <span class="psw">Forgot <a href="#">password?</a></span>
  </div>
        </div>
</asp:Content>
