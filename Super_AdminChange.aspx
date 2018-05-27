<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminMaster.Master" AutoEventWireup="true" CodeBehind="Super_AdminChange.aspx.cs" Inherits="Diocese.Super_AdminChange" %>
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
    <label for="uname"><b>Priest Name</b></label>
      
        <asp:dropdownlist ID="DDLPriestName" runat="server"  required="" style="width:100%;display: inline-block; 
border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px"  
            DataSourceID="PriestTable" DataTextField="Parish_Priest_Name" DataValueField="Parish_Priest_ID" AppendDataBoundItems="true">
            <asp:ListItem Value="0">--select--</asp:ListItem>
            </asp:dropdownlist>
             
          
      <asp:SqlDataSource ID="PriestTable" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnection %>" SelectCommand="SELECT [Parish_Priest_ID], [Parish_Priest_Name] FROM [Sup_PriestTable]"></asp:SqlDataSource>
             
        <label for="psw"><b>UserName</b></label>
      <asp:TextBox ID="TBUsername" runat="server" CssClass="input"  required=""></asp:TextBox>
      
      <label for="psw"><b>Password</b></label>

 <asp:TextBox ID="TBPassword" runat="server" CssClass="input"  required=""></asp:TextBox>
   
      <asp:button runat="server" text="Add" CssClass="loginbutton" ID="BtnPriest_SuperAdmin" OnClick="BtnPriest_SuperAdmin_Click"/>
  </div>
        </div>

<!-- /form -->
                </div>
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->


    </asp:Content>


