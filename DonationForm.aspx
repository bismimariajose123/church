<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="DonationForm.aspx.cs" Inherits="Diocese.DonationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:LinkButton ID="LnkbtnHome" runat="server" OnClick="LnkbtnHome_Click">Back to Home</asp:LinkButton>
  
       <!--grid-->
 	<div class="validation-system">
 		
 		<div class="validation-form">
 	<!---->
             <div class="vali-form">
            <div class="col-md-6 form-group1">
 
             <div class="checkbox1">
              
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
            <div class="col-md-6 form-group1">
              <label class="control-label"> Contact Number</label>
                <asp:textbox ID="TBContactNobr" runat="server"  placeholder="Contact Number"></asp:textbox>
           </div>
            <div class="col-md-6 form-group1 form-last">
               <label class="control-label"> Person's Diocese</label>
                <asp:textbox ID="TBdiocese" runat="server"  placeholder="Diocese Name"></asp:textbox>
                </div>
            <div class="clearfix"> </div>
            </div>

            <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Event Name</label>
                <asp:dropdownlist ID="DDLEventName" runat="server"  required="" AppendDataBoundItems="true" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px;" placeholder="--select--" >
              <asp:ListItem Text="select" Value="0"></asp:ListItem>
                  </asp:dropdownlist>  
                
                </div>
            <div class="clearfix"> </div>
            </div>

              
           
            <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Amount</label>
                <asp:textbox ID="TBAmount" runat="server" required="" placeholder="amount "></asp:textbox>
            </div>
                      
            <div class="clearfix"> </div>
            </div>
             
             <div class="vali-form">
              <div class="col-md-12 form-group">
              <asp:Button ID="BtnDonation" runat="server" Text="Submit"  CssClass="btn btn-primary" OnClick="BtnDonation_Click"/>
              <button type="reset" class="btn btn-default">Reset</button>
                  <asp:LinkButton ID="PaymentLink" runat="server" Visible="false">Click for payment</asp:LinkButton>
            </div>
          <div class="clearfix"> </div>
   </div>

   
 	<!---->
 </div>

</div>


</asp:Content>
