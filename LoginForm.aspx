<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFirstPage.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Diocese.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="loginform" style="margin-left:30%;">
        
  <div class="logincontainer">
    <label for="uname"><b>Username</b></label>
      
      <asp:TextBox ID="TBUsername" runat="server" CssClass="input" data-toggle="tooltip" data-placement="top" required="" placeholder="Enter username"></asp:TextBox>
   
          
    <label for="psw"><b>Password</b></label>
      
      <asp:TextBox ID="TBPassword" runat="server" CssClass="input" data-toggle="tooltip" data-placement="top" required="" placeholder="Enter password" TextMode="Password"></asp:TextBox>
   
       <label for="parish"><b>Parish</b></label>
      <asp:DropDownList ID="DDLParish" runat="server" AppendDataBoundItems="True" CssClass="input" data-toggle="tooltip" data-placement="top" required="" placeholder="Select Parish" DataSourceID="ParishName" DataTextField="Parish_Name" DataValueField="Parish_ID">
          <asp:ListItem Value="0">--select--</asp:ListItem>
      </asp:DropDownList>
     
      <asp:SqlDataSource ID="ParishName" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnection %>" SelectCommand="SELECT * FROM [Sup_ParishTable]"></asp:SqlDataSource>
     
      <label for="parish"><b>User Type</b></label>
       <asp:DropDownList ID="DLLUsertype" runat="server" AppendDataBoundItems="True" CssClass="input" data-toggle="tooltip" data-placement="top" required="" >
          <asp:ListItem Value="0">--select--</asp:ListItem>
            <asp:ListItem Value="1">Super Admin</asp:ListItem>
           <asp:ListItem Value="2">Sub Admin</asp:ListItem>
           <asp:ListItem Value="3">Member</asp:ListItem>
           <asp:ListItem Value="4">Guest</asp:ListItem>
           <asp:ListItem Value="5">Accountant</asp:ListItem>
            <asp:ListItem Value="6">Sunday School</asp:ListItem>
      </asp:DropDownList>
       <asp:button runat="server" text="Login" ID="LogibBtn" CssClass="loginbutton" OnClick="LogibBtn_Click"/>
    
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
