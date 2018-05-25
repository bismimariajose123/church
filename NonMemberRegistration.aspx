<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="NonMemberRegistration.aspx.cs" Inherits="Diocese.NonMemberRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--grid-->
 	<div class="validation-system">
 		
 		<div class="validation-form">
 	<!---->
             	<div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Username Name</label>
                <asp:textbox ID="TBusername" runat="server" required="" placeholder="Username"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Password</label>
               <asp:textbox ID="TBPassword" runat="server" required="" placeholder="Password"></asp:textbox>
            </div>
            <div class="clearfix"> </div>
            </div>

         	<div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Family Name</label>
                <asp:textbox ID="TBFamilyName" runat="server" required="" placeholder="Native Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Parish Name</label>
                <asp:DropDownList ID="DropDownList1" AppendDataBoundItems="true" runat="server" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:12px;" DataSourceID="SqlDataSource1" DataTextField="Parish_Name" DataValueField="Parish_ID"> 
                <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
             </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnection %>" SelectCommand="SELECT [Parish_ID], [Parish_Name] FROM [Sup_ParishTable]"></asp:SqlDataSource>
                </div>
            <div class="clearfix"> </div>
            </div>

             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Official Name</label>
                <asp:textbox ID="TBOfficialName" runat="server" required="" placeholder="Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Post Office</label>
               <asp:textbox ID="TBPO" runat="server" required="" placeholder="Post Office"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Email</label>
                <asp:textbox ID="TBEmail" runat="server"  placeholder="Email"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Contact Number</label>
               <asp:textbox ID="TBContactNumber" runat="server"  placeholder="Contact Number"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Date of Birth</label>
                <input type="date" class="form-control1 ng-invalid ng-invalid-required" id="orddate" ng-model="model.date" required="" onchange="date_dis()">
                <asp:hiddenfield ID="Dobhidden" runat="server"></asp:hiddenfield>
                </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Landmark</label>
               <asp:textbox ID="TBLandmark" runat="server"  placeholder="Landmark" required=""></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>


            <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Father's Name</label>
                <asp:textbox ID="TBFatherName" runat="server" required="" placeholder="Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Mother's Name</label>
               <asp:textbox ID="TBMotherName" runat="server" required="" placeholder="Official Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>
            
          
               <label for="psw"><b>Image</b></label>
      <asp:FileUpload ID="FileUploadimg" runat="server" />

             <div class="vali-form">
              <div class="col-md-12 form-group">
              <asp:Button ID="BtnAddMember" runat="server" Text="Submit" OnClick="BtnAddMember_Click" CssClass="btn btn-primary" />
              <button type="reset" class="btn btn-default">Reset</button>
            </div>
          <div class="clearfix"> </div>
   </div>
 	<!---->
 </div>

</div>

     <script type="text/javascript">
         
         function date_dis() {
             var textbox = document.getElementById('orddate');
             document.getElementById('<%=Dobhidden.ClientID%>').value = textbox.value;
         }

</script>
</asp:Content>
