<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddSubAdmin.aspx.cs" Inherits="Diocese.AddSubAdmin" %>
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
      <asp:DropDownList ID="DDLChurchName" runat="server" CssClass="input" AppendDataBoundItems="True" DataSourceID="ParishTable" DataTextField="Parish_Name" DataValueField="Parish_ID" required="">
           <asp:ListItem Value="0">--select--</asp:ListItem>
          
      </asp:DropDownList>
          
      <asp:SqlDataSource ID="ParishTable" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnection %>" SelectCommand="SELECT [Parish_ID], [Parish_Name] FROM [Sup_ParishTable]"></asp:SqlDataSource>
          
     <label for="psw"><b>Username</b></label>
      <asp:TextBox ID="TBUname" runat="server" CssClass="input" required=""></asp:TextBox>
     
      <label for="psw"><b>Password</b></label>
      <asp:TextBox ID="TBPwd" runat="server" CssClass="input" TextMode="Password" required=""></asp:TextBox>
     
      <asp:button runat="server" text="Add"  ID="Btn_Sub_admin_login" CssClass="loginbutton" OnClick="Btn_Sub_admin_login_Click"/>
  </div>
        </div>

<!-- /form -->
                </div>
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->
</asp:Content>
