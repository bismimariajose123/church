<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="BaptismForm.aspx.cs" Inherits="Diocese.BaptismForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--grid-->
 	<div class="validation-system">
 		
 		<div class="validation-form">
 	<!---->
             <div class="vali-form">
            <div class="col-md-6 form-group1">
 
              <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" ID="newborn" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" 
                        onclick="Newborn()" ></asp:checkbox>
                  New Born?<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
                 
              </div>
                </div>
                 <div class="col-md-6 form-group1 form-last">
                <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" ID="marriedstatus" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" 
                        onclick="Newborn()"></asp:checkbox>
                  Married<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
              </div>
                </div>
                  <div class="clearfix"> </div>
                 </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">

                <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" ID="parishmember" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" 
                        onclick="Newborn()"></asp:checkbox>
                   Are your Parents member of this Parish?<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
              </div>
                
               </div>
           
            </div>

         	<div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Family Name</label>
                <asp:textbox ID="TBFamilyName" runat="server" required="" placeholder="Family Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Parish Name</label>
               <asp:textbox ID="TBParishName" runat="server" required="" placeholder="Parish Name"></asp:textbox>
            </div>
            <div class="clearfix"> </div>
            </div>

             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Official Name</label>
                <asp:textbox ID="TBOfficialName" runat="server" required="" placeholder="Person receiving Baptism Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Baptism Name</label>
               <asp:textbox ID="TBBaptismName" runat="server" required="" placeholder="Person receiving Baptism Baptism Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Date of Baptism</label>
                <input type="date" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="Dobaphidden" runat="server"></asp:hiddenfield>
                </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Gender</label>
              <asp:dropdownlist ID="DDLGender" runat="server"  required="" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px" placeholder="--select--">
               <asp:ListItem Text="Male" Value="1"></asp:ListItem>
               <asp:ListItem Text="Female" Value="2"></asp:ListItem>
               
              </asp:dropdownlist>
                </div>

            <div class="clearfix"> </div>
            </div>

               <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Place of Baptism</label>
                  <asp:dropdownlist ID="DDLPlaceBaptism" runat="server"  required="" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing:border-box;margin-top:7px;height:45px;font-size:9px" placeholder="--select--">
             </asp:dropdownlist> 

            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label"> Baptism Parish</label>
               <asp:textbox ID="TBBapParish" runat="server"  placeholder="Parish Name"></asp:textbox>
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
              <label class="control-label">Father's Baptism Name</label>
                <asp:textbox ID="TBFatherBapName" runat="server"  placeholder="Baptism Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Mother's Baptism Name</label>
               <asp:textbox ID="TBMotherBapName" runat="server"  placeholder="Baptism Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>
             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Godfather's Name</label>
                <asp:textbox ID="TBGodfatherName" runat="server" required="" placeholder="Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Godmother's Name</label>
               <asp:textbox ID="TBGodmotherName" runat="server" required="" placeholder="Official Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Parish Priest's Name</label>
                <asp:textbox ID="TBParishPriestName" runat="server" required="" placeholder="Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Blessed By</label>
               <asp:textbox ID="TBCelebrantName" runat="server" required="" placeholder="Celebrant's Name"></asp:textbox>
        </div>
            <div class="clearfix"> </div>
            </div>

            

            <div class="vali-form" id="divFC" style="display:none">
            <div class="col-md-6 form-group1">
               <label class="control-label">Father's BaptismCertificate or any proof of christianity</label>
                <asp:fileupload runat="server" ID="FileuploadFatherCertificate" required=""></asp:fileupload>
                </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Mother's BaptismCertificate any proof of christianity</label>
                <asp:fileupload runat="server" ID="FileuploadMotherCertificate" required=""></asp:fileupload>
                </div>
            <div class="clearfix"> </div>
            </div>

             <div class="vali-form" id="divGFC" style="display:none">
            <div class="col-md-6 form-group1">
               <label class="control-label">GodFather's BaptismCertificate</label>
                <asp:fileupload runat="server" ID="FileuploadGF" required=""></asp:fileupload>
                </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">GodMother's BaptismCertificate</label>
                <asp:fileupload runat="server" ID="FileuploadGM" required=""></asp:fileupload>
                </div>
            <div class="clearfix"> </div>
            </div> 

  <div class="vali-form">
              <div class="col-md-12 form-group">
              
              <asp:Button ID="Button1" runat="server" Text="Submit"  CssClass="btn btn-primary"/>
              <button type="reset" class="btn btn-default">Reset</button>
            </div>
          <div class="clearfix"> </div>
   </div>

   
 	<!---->
 </div>

</div>
    <script type="text/javascript">
        function Newborn()
        {
            if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked) && (document.getElementById('<%= newborn.ClientID  %>').checked)) {
                alert("incorrect selection");
            }
            else if ((document.getElementById('<%= newborn.ClientID  %>').checked) && (document.getElementById('<%= parishmember.ClientID  %>').checked)) {
                // if ((document.getElementById('<%= parishmember.ClientID  %>').checked) == false && (document.getElementById('<%= marriedstatus.ClientID  %>').checked) == false) {
                // alert("hi");
                var divFC = document.getElementById("divFC");
                var divGFC = document.getElementById("divGFC");

                divFC.style.display = "none"
                divGFC.style.display = "block";



            }
            else if ((document.getElementById('<%= newborn.ClientID  %>').checked) && (document.getElementById('<%= parishmember.ClientID  %>').checked) == false) {
                var divFC = document.getElementById("divFC");
                var divGFC = document.getElementById("divGFC");

                divFC.style.display = "block"
                divGFC.style.display = "block";

            }
            else if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked) && (document.getElementById('<%= parishmember.ClientID  %>').checked)) {
                var divFC = document.getElementById("divFC");
                var divGFC = document.getElementById("divGFC");
                divFC.style.display = "none"
                divGFC.style.display = "none";
            }

            else if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked) && (document.getElementById('<%= parishmember.ClientID  %>').checked) == false) {
                var divFC = document.getElementById("divFC");
                var divGFC = document.getElementById("divGFC");
                divFC.style.display = "none"
                divGFC.style.display = "block";
            }
            
        }
        
        



</script>
</asp:Content>

