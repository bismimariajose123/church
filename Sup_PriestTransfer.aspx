<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminMaster.Master" AutoEventWireup="true" CodeBehind="Sup_PriestTransfer.aspx.cs" Inherits="Diocese.Sup_PriestTransfer" %>
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
             
          
    <label for="psw"><b>Parish Name</b></label>
      
      
        <asp:dropdownlist ID="DDLParishName" runat="server"  required="" style="width:100%;display: inline-block;
border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px" placeholder="--select--"
             AppendDataBoundItems="true">
            <asp:ListItem Value="0">--select--</asp:ListItem>
            </asp:dropdownlist>
         
       
        <label for="psw"><b>Place</b></label>
      
      <label for="psw"><b>Designation</b></label>

 <asp:TextBox ID="TBDesignation" runat="server" CssClass="input"  required=""></asp:TextBox>
   
      <asp:button runat="server" text="Add" CssClass="loginbutton" ID="BtnPriest_Transfer" OnClick="BtnPriest_Transfer_Click"/>
  </div>
        </div>

<!-- /form -->
                </div>
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->

</asp:Content>
