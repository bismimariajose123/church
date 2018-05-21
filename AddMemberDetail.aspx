<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="AddMemberDetail.aspx.cs" Inherits="Diocese.AddMemberDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="LinkButtonHome" runat="server" OnClick="LinkButtonHome_Click">Back to Home</asp:LinkButton>
    <!--grid-->
 	<div class="validation-system">
 		
 		<div class="validation-form">
 	<!---->
         	<div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Family Name</label>
                <asp:textbox ID="TBFamilyName" runat="server" required="" placeholder="Native Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Parish Name</label>
               <asp:textbox ID="TBParishName" runat="server" required="" placeholder="Native Name"></asp:textbox>
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
              <label class="control-label">Relation to Head</label>
                <asp:dropdownlist ID="DDLRelation" runat="server" required="" AppendDataBoundItems="True"
                    style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:9px;height:45px;font-size:12px" DataSourceID="PositionTable" DataTextField="Position_Name" DataValueField="Position_Id">
                    <asp:ListItem Value="0">--select--</asp:ListItem>
                </asp:dropdownlist>
                <asp:SqlDataSource ID="PositionTable" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnection %>" SelectCommand="SELECT * FROM [PositionTable]"></asp:SqlDataSource>
                </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Occupation</label>
               <asp:textbox ID="TBOccupation" runat="server"  placeholder="Occupation"></asp:textbox>
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
                <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" id="marriedstatus" ng-model="model.winner"  class="ng-invalid ng-invalid-required" onclick="MarriedCheck()"></asp:checkbox>
                   Are you a married?   tick if yes
                    <asp:HiddenField ID="HiddenFieldMarriedstatus" runat="server" />
                </label>
              </div>
               </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Post Office</label>
               <asp:textbox ID="TBPO" runat="server" required="" placeholder="Post Office"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

            <div class="vali-form" id="Wifediv" style="display:none">
            <div class="col-md-6 form-group1">
              <label class="control-label">Spouse's Official Name</label>
                <asp:textbox ID="TBWifeOffName" runat="server"  placeholder="Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Spouse's Baptism Name</label>
               <asp:textbox ID="TBWifeBapName" runat="server" placeholder="Baptism Name"></asp:textbox>
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
         function MarriedCheck()
        {
             var Wifediv = document.getElementById("Wifediv");
            // var HiddenFieldMarriedstatus = document.getElementById('<%= HiddenFieldMarriedstatus.ClientID  %>')
            if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked)) {
              //  HiddenFieldMarriedstatus.value = 1;
                Wifediv.style.display = "block";
               
            }
            else {
               // HiddenFieldMarriedstatus.value = 0;
                Wifediv.style.display = "none";

            }
           
        }
         
             function date_dis() {
          var textbox = document.getElementById('orddate');
          document.getElementById('<%=Dobhidden.ClientID%>').value = textbox.value;
      }
   
</script>
</asp:Content>
