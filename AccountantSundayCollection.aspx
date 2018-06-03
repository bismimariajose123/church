<%@ Page Title="" Language="C#" MasterPageFile="~/AccountantMasterPage.Master" AutoEventWireup="true" CodeBehind="AccountantSundayCollection.aspx.cs" Inherits="Diocese.AccountantSundayCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
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
              <label class="control-label">Amount</label>
                <asp:textbox ID="TBAmount" runat="server" required=""></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
             <label class="control-label">Date</label>
                <input type="date" class="form-control1 ng-invalid ng-invalid-required" id="orddate" ng-model="model.date" required="" onchange="date_dis()">
                <asp:hiddenfield ID="Dobhidden" runat="server"></asp:hiddenfield>
                </div>
            <div class="clearfix"> </div>
            </div>

            
             <div class="vali-form">
              <div class="col-md-12 form-group">
              <asp:Button ID="BtnSundayCollection" runat="server" Text="Submit"  CssClass="btn btn-primary" OnClick="BtnSundayCollection_Click"/>
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
             alert(textbox.value);
         }
    </script>

</asp:Content>
