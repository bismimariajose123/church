<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddPriest.aspx.cs" Inherits="Diocese.AddPriest" %>
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
                <div class="row"><!-- next row -->
    
 <!-- form -->
  <div class="loginform" style="margin-left:30%;width:50%">
        
  <div class="logincontainer">
    <label for="uname"><b>Priest Name</b></label>
     <asp:TextBox ID="TBPriestName" runat="server" CssClass="input"></asp:TextBox>
           
    <label for="psw"><b>Family Name</b></label>
      <asp:TextBox ID="TBFName" runat="server" CssClass="input"></asp:TextBox>
    
     <label for="psw"><b>Native Parish</b></label>
      <asp:TextBox ID="TBNativeParish" runat="server" CssClass="input"></asp:TextBox>
     
      <label for="psw"><b>Ordinance Date</b></label>
      <br />
      <%-- <input type="date" id="orddate" class="form-control1 ng-invalid ng-invalid-required"  required="" 
           style="width:100%" onchange="date_dis()">
      --%>
      <input type="date" id="orddate" style="width:100%" onchange="date_dis()" />

       <asp:hiddenfield ID="HidOrdinanceDate" runat="server" value=""></asp:hiddenfield>
               <br />
     <%-- <asp:TextBox ID="TBOrdinanceDate" runat="server" CssClass="input"></asp:TextBox>
     --%>
      <label for="psw"><b>Contact Number</b></label>
      <asp:TextBox ID="TBContactNumber" runat="server" CssClass="input"></asp:TextBox>
     
    
       <label for="psw"><b>Image</b></label>
      <asp:FileUpload ID="FileUploadimg" runat="server" />
       
      <asp:button runat="server" text="Add" ID="PriestAdd" CssClass="loginbutton" OnClick="PriestAdd_Click"/>
  </div>
        </div>
 
<!-- /form -->
                </div>
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->
  <script type="text/javascript">
      function date_dis() {
          var textbox = document.getElementById('orddate');
          alert(document.getElementById('<%=HidOrdinanceDate.ClientID%>').value = textbox.value);
      }
   </script>
</asp:Content>
