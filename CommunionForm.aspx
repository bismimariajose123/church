<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="CommunionForm.aspx.cs" Inherits="Diocese.CommunionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:LinkButton ID="LnkbtnHome" runat="server" OnClick="LnkbtnHome_Click">Back to Home</asp:LinkButton>
  
     <!--grid-->
 	<div class="validation-system">
 		
 		<div class="validation-form">
 	<!---->
            

           <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Family Name</label>
                <asp:textbox ID="TBFamilyName" runat="server" required="" placeholder="Family Name"></asp:textbox>
            </div>
             <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Baptism Name</label>
               <asp:textbox ID="TBBaptismName" runat="server" required="" placeholder="Baptism Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Official Name</label>
                <asp:textbox ID="TBOfficialName" runat="server" required="" placeholder="Official Name of person recieving communion"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Date of Communion</label>
                <input type="date" id="dateofcommunion" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="" onchange="date_dis()">
                <asp:hiddenfield ID="Docommunionhhidden" runat="server"></asp:hiddenfield>
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
                 <label class="control-label">Gender</label>
              <asp:dropdownlist ID="DDLGender" runat="server"  required="" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px;" placeholder="--select--">
               <asp:ListItem Text="select" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Male" Value="1"></asp:ListItem>
               <asp:ListItem Text="Female" Value="2"></asp:ListItem>
               
              </asp:dropdownlist>
             
                 </div>
                    <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Date of Birth</label>
                <input type="date" id="datofbirth" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="" onchange="dateobbirth_dis()">
                <asp:hiddenfield ID="hiddob" runat="server"></asp:hiddenfield>
                </div>
                  
              <div class="clearfix"> </div>
            </div>
             <div class="vali-form">
              <div class="col-md-12 form-group">
              <asp:Button ID="BtnAdd_Communiondetails" runat="server" Text="Submit"  CssClass="btn btn-primary" OnClick="BtnAdd_Communiondetails_Click"/>
              <button type="reset" class="btn btn-default">Reset</button>
            </div>
               
          <div class="clearfix"> </div>
   </div>

   
 	<!---->
 </div>

</div>
    <script type="text/javascript">

        function date_dis()
        {
            var textbox = document.getElementById('dateofcommunion');
            document.getElementById('<%=Docommunionhhidden.ClientID%>').value = textbox.value;
            alert(textbox.value);

        }
        function dateobbirth_dis() {
            var textbox = document.getElementById('datofbirth');
            document.getElementById('<%=hiddob.ClientID%>').value = textbox.value;
        alert(textbox.value);
        }

        
          
         </script>
</asp:Content>
