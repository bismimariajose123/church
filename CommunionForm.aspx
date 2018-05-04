<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="CommunionForm.aspx.cs" Inherits="Diocese.CommunionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!--grid-->
 	<div class="validation-system">
 		
 		<div class="validation-form">
 	<!---->
             <div class="vali-form">
            <div class="col-md-6 form-group1">
 
             <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" ID="parishmember" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" onclick="ShowHideDiv()" checked></asp:checkbox>
                   Is a member of this Parish?<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
              </div>
                </div>
                  <div class="clearfix"> </div>
                 </div>

           <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Family Name</label>
                <asp:textbox ID="TBFamilyName" runat="server" required="" placeholder="Family Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Parish Name</label>
               <asp:textbox ID="TBParishName" runat="server" required="" placeholder="Person's Parish Name"></asp:textbox>
            </div>
            <div class="clearfix"> </div>
            </div>

             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Official Name</label>
                <asp:textbox ID="TBOfficialName" runat="server" required="" placeholder="Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Baptism Name</label>
               <asp:textbox ID="TBBaptismName" runat="server" required="" placeholder="Baptism Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>
               <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label"> Parish where Communion is received</label>
                <asp:textbox ID="TBCommunionParish" runat="server"  placeholder="Parish Name"></asp:textbox>
           </div>
            <div class="col-md-6 form-group1 form-last">
               <label class="control-label"> Person's Diocese</label>
                <asp:textbox ID="TBdiocese" runat="server"  placeholder="Diocese Name"></asp:textbox>
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

               
            <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Parish Priest's Name</label>
                <asp:textbox ID="TBParishPriestName" runat="server" required="" placeholder="where communion is held"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Blessed By</label>
               <asp:textbox ID="TBCelebrantName" runat="server" required="" placeholder="Celebrant's Name"></asp:textbox>
        </div>
            <div class="clearfix"> </div>
            </div>
              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Date of Communion</label>
                <input type="date" id="dateofcommunion" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="Docommunionhhidden" runat="server"></asp:hiddenfield>
                </div>
                    <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Gender</label>
              <asp:dropdownlist ID="DDLGender" runat="server"  required="" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px;" placeholder="--select--">
               <asp:ListItem Text="select" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Male" Value="1"></asp:ListItem>
               <asp:ListItem Text="Female" Value="2"></asp:ListItem>
               
              </asp:dropdownlist>
                
            </div>
              <div class="clearfix"> </div>
            </div>
             <div class="vali-form">
              <div class="col-md-12 form-group">
              <asp:Button ID="Btndeath" runat="server" Text="Submit"  CssClass="btn btn-primary"/>
              <button type="reset" class="btn btn-default">Reset</button>
            </div>
               
          <div class="clearfix"> </div>
   </div>

   
 	<!---->
 </div>

</div>

</asp:Content>
