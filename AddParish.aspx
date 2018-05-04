<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddParish.aspx.cs" Inherits="Diocese.AddParish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Page Content -->
        <div id="page-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"> WELCOME <asp:Label ID="Lblname" runat="server" Text="Label"></asp:Label></h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <div class="row"><!-- next row -->
    
 <!-- form -->
  <div class="loginform" style="margin-left:30%;width:50%">
        
  <div class="logincontainer">
    <label for="uname"><b>Church Name</b></label>
      
      <asp:TextBox ID="TBChurchName" runat="server" CssClass="input"></asp:TextBox>
   
          
    <label for="psw"><b>Place</b></label>
      
      <asp:TextBox ID="TBPlace" runat="server" CssClass="input"></asp:TextBox>
   
       <label for="psw"><b>UserName</b></label>
      
      <asp:TextBox ID="TBusername" runat="server" CssClass="input"></asp:TextBox>
      
      <label for="psw"><b>Password</b></label>
      
      <asp:TextBox ID="TBPassword" runat="server" CssClass="input"></asp:TextBox>
   
   
      <asp:button runat="server" text="Add" CssClass="loginbutton" ID="BtnAddParish" OnClick="BtnAddParish_Click"/>
  </div>
        </div>

<!-- /form -->
                </div>
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->
</asp:Content>
